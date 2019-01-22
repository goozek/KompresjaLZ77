using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace LZ77_gui
{
    public partial class FrmMain : Form
    {
        Thread thread;
        List<String> dictionary;
        List<String> buffer;
        int startSize = 0;
        enum State { compressing, decompressing };
        State currentState = State.compressing;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            txtInput.Text = txtInput.Text.Replace("\n", " ").Replace("\r", "");
            if (txtInput.Text.Length < 4 || txtInput.Text.Length < numBufferSize.Value)
            {
                MessageBox.Show("Tekst musi zawierać przynajmniej tyle znaków, co pojemność bufora (" + numBufferSize.Value + ").", "Nie można skompresować tego tekstu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            startSize = txtInput.Text.Length;
            disableButtons();
            currentState = State.compressing;
            thread = new Thread(compress);
            thread.Start();
        }

        private void btnDecompress_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length < 6)
            {
                MessageBox.Show("Minimalna długość tekstu do zdekompresowania to 6 znaków.", "Nie można zdekompresować tego tekstu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            startSize = txtInput.Lines.Length;
            disableButtons();
            currentState = State.decompressing;
            thread = new Thread(decompress);
            thread.Start();
        }

        private void btnCompressPreview_Click(object sender, EventArgs e)
        {
            txtInput.Text = txtInput.Text.Replace("\n", " ").Replace("\r", "");
            if (txtInput.Text.Length < 4)
            {
                MessageBox.Show("Tekst musi zawierać przynajmniej tyle znaków, co pojemność bufora (" + numBufferSize.Value + ").", "Nie można skompresować tego tekstu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numDictionarySize.Value > 128 || numBufferSize.Value > 128)
            {
                MessageBox.Show("Kompresja z podglądem jest możliwa dla wielkości słownika i bufora nieprzekraczających 128.", "Nie można skompresować tego tekstu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvBuffer.AutoSizeColumnsMode = numBufferSize.Value > 16 ? DataGridViewAutoSizeColumnsMode.DisplayedCells : DataGridViewAutoSizeColumnsMode.Fill;
            dgvDictionary.AutoSizeColumnsMode = numDictionarySize.Value > 16 ? DataGridViewAutoSizeColumnsMode.DisplayedCells : DataGridViewAutoSizeColumnsMode.Fill;
            currentState = State.compressing;
            startSize = txtInput.Text.Length;
            disableButtons();
            initializeDGVs();
            dgvBuffer.Enabled = true;
            dgvDictionary.Enabled = true;
            initializeDictionary();
            setUpBuffer();
            updateDGVs();
            thread = new Thread(compressPreview);
            thread.Start();
        }

        private void btnDecompressPreview_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length < 6)
            {
                MessageBox.Show("Minimalna długość tekstu do zdekompresowania to 6 znaków.", "Nie można zdekompresować tego tekstu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numDictionarySize.Value > 128 || numBufferSize.Value > 128)
            {
                MessageBox.Show("Dekompresja z podglądem jest możliwa dla wielkości słownika i bufora nieprzekraczających 128.", "Nie można skompresować tego tekstu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvBuffer.AutoSizeColumnsMode = numBufferSize.Value > 16 ? DataGridViewAutoSizeColumnsMode.DisplayedCells : DataGridViewAutoSizeColumnsMode.Fill;
            dgvDictionary.AutoSizeColumnsMode = numDictionarySize.Value > 16 ? DataGridViewAutoSizeColumnsMode.DisplayedCells : DataGridViewAutoSizeColumnsMode.Fill;
            buffer = new List<string>();
            startSize = txtInput.Lines.Length;
            currentState = State.decompressing;
            disableButtons();
            initializeDGVs();
            dgvBuffer.Enabled = true;
            dgvDictionary.Enabled = true;

            thread = new Thread(decompressPreview);
            thread.Start();
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            try
            {
                thread.Abort();
            }
            catch (Exception) { }
            enableButtons();
        }

        private void compress()
        {
            buffer = new List<string>();
            initializeDictionary();
            initializeDGVs();

            while (txtInput.Text != null && txtInput.Text.Length > 0)
                compressStep();

            this.Invoke(new Action(delegate () { enableButtons(); }));
        }

        private void decompress()
        {
            initializeDictionary();
            this.Invoke(new Action(delegate ()
            {
                var lines = txtInput.Lines;
                var newLines = lines.Skip(1);
                txtInput.Lines = newLines.ToArray();
            }));

            try
            {
                while (txtInput.Lines != null && txtInput.Lines.Count() > 0)
                    decompressStep();
            }
            catch (Exception)
            {
                MessageBox.Show("Nastąpił nieoczekiwany błąd. Upewnij się, że format danych do dekompresji był poprawny.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Invoke(new Action(delegate () { enableButtons(); }));
        }

        private void compressPreview()
        {
            this.Invoke(new Action(delegate () { btnNextStep.Enabled = true; }));

            if (txtInput.Text == null || txtInput.Text.Length == 0)
            {
                this.Invoke(new Action(delegate () { enableButtons(); }));
                this.Invoke(new Action(delegate () { btnNextStep.Enabled = false; }));
            }
        }

        private void decompressPreview()
        {
            this.Invoke(new Action(delegate () { btnNextStep.Enabled = true; }));
            initializeDictionary();
            updateDGVs();
            this.Invoke(new Action(delegate ()
            {
                var lines = txtInput.Lines;
                var newLines = lines.Skip(1);
                txtInput.Lines = newLines.ToArray();
            }));
        }

        private void decompressStep()
        {
            string line = txtInput.Lines[0];
            string[] elements = line.Split(',');
            int param1 = Int32.Parse(elements[0]);
            int param2 = Int32.Parse(elements[1]);
            string character = line.Substring(line.Length - 1, 1);

            List<string> dictTmp = new List<string>(dictionary);
            foreach (string s in buffer)
                dictTmp.Add(s);

            string output = "";
            for (int i = 0; i < param2; i++)
                output += dictTmp[param1 + i];

            output += character;

            buffer = new List<string>();
            for (int i = 0; i < output.Length; i++)
            {
                dictionary.RemoveAt(0);
                dictionary.Add(output[i].ToString());
                buffer.Add(output[i].ToString());
            }


            this.Invoke(new Action(delegate ()
            {
                var lines = txtInput.Lines;
                var newLines = lines.Skip(1);
                txtInput.Lines = newLines.ToArray();
                txtOutput.Text += output;
            }));
        }

        private void compressStep()
        {
            setUpBuffer();
            int longestSubstringLength = 1;
            String textToFind = txtInput.Text;
            textToFind = textToFind.Substring(0, textToFind.Length < Int32.Parse(numBufferSize.Value.ToString()) ? textToFind.Length : Int32.Parse(numBufferSize.Value.ToString()));
            String dict = String.Join(String.Empty, dictionary.ToArray());
            for (; longestSubstringLength < numBufferSize.Value && txtInput.Text.Length > 1; longestSubstringLength++)
            {
                if (textToFind.Length < longestSubstringLength || dict.IndexOf(textToFind.Substring(0, longestSubstringLength)) < 0)
                    break;
            }

            longestSubstringLength--;
            if (txtInput.Text.Length > 1)
            {
                for (int i = 0; i <= longestSubstringLength; i++)
                {
                    dictionary.RemoveAt(0);
                    dictionary.Add(txtInput.Text.Substring(i, 1));
                }
            }

            this.Invoke(new Action(delegate ()
            {
                if (longestSubstringLength == 0) //if character doesn't exist in dictionary
                {
                    txtOutput.Text += Environment.NewLine + "0,0," + textToFind[0];
                }
                else
                {
                    txtOutput.Text += Environment.NewLine + dict.IndexOf(textToFind.Substring(0, longestSubstringLength)) + "," + longestSubstringLength + "," + txtInput.Text.Substring(longestSubstringLength, 1);
                }

                txtInput.Text = txtInput.Text.Substring(longestSubstringLength + 1, txtInput.TextLength - longestSubstringLength - 1);
                txtOutput.SelectionStart = txtOutput.TextLength;
                txtOutput.ScrollToCaret();
            }));

            setUpBuffer();
        }

        private void disableButtons()
        {
            btnCompress.Enabled = false;
            btnCompressPreview.Enabled = false;
            btnDecompress.Enabled = false;
            btnDecompressPreview.Enabled = false;
            numDictionarySize.Enabled = false;
            numBufferSize.Enabled = false;
            txtInput.Enabled = false;
            btnChange.Enabled = false;
            btnBreak.Enabled = true;
        }

        private void enableButtons()
        {
            this.Invoke(new Action(delegate ()
            {
                btnCompress.Enabled = true;
                btnCompressPreview.Enabled = true;
                btnDecompress.Enabled = true;
                btnDecompressPreview.Enabled = true;
                numDictionarySize.Enabled = true;
                numBufferSize.Enabled = true;
                txtInput.Enabled = true;
                btnChange.Enabled = true;
                btnBreak.Enabled = false;
                btnNextStep.Enabled = false;
                lblProgress.Text = "0%";
                progressBar1.Value = 0;
                dgvBuffer.Enabled = false;
                dgvDictionary.Enabled = false;
                dgvBuffer.Columns.Clear();
                dgvDictionary.Columns.Clear();
            }));
        }

        private void initializeDictionary()
        {
            this.Invoke(new Action(delegate ()
            {
                if (currentState == State.compressing)
                    txtOutput.Text = txtInput.Text.Substring(0, 1);
            }));
            dictionary = new List<string>();
            for (int i = 0; i < numDictionarySize.Value; i++)
                dictionary.Add(txtInput.Text[0].ToString());
        }

        private void setUpBuffer()
        {
            buffer = new List<string>();
            for (int i = 0; i < numBufferSize.Value && i < txtInput.Text.Length; i++)
                buffer.Add(txtInput.Text[i].ToString());
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            String tmp = txtInput.Text;
            txtInput.Text = txtOutput.Text;
            txtOutput.Text = tmp;
        }

        private void initializeDGVs()
        {
            this.Invoke(new Action(delegate ()
            {
                for (int i = 0; i < numDictionarySize.Value; i++)
                    dgvDictionary.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = i.ToString() });

                for (int i = 0; i < numBufferSize.Value; i++)
                    dgvBuffer.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = i.ToString() });
            }));
        }

        private void updateDGVs()
        {
            this.Invoke(new Action(delegate ()
            {
                if (dgvDictionary.Rows.Count > 0)
                {
                    dgvDictionary.Rows.RemoveAt(0);
                    dgvBuffer.Rows.RemoveAt(0);
                }

                dgvDictionary.Rows.Add(dictionary.ToArray());
                dgvBuffer.Rows.Add(buffer.ToArray());
            }));

        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (currentState == State.compressing)
            {
                compressStep();
            }
            else
            {
                try
                {
                    decompressStep();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nastąpił nieoczekiwany błąd. Upewnij się, że format danych do dekompresji był poprawny.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    enableButtons();
                    return;

                }
            }
            updateDGVs();
            int progress;
            if (currentState == State.compressing)
            {
                progress = 100 * (startSize - txtInput.Text.Length) / startSize;
            }
            else
            {
                progress = 100 * (startSize - txtInput.Lines.Count()) / startSize;
            }
            this.Invoke(new Action(delegate ()
            {
                progressBar1.Value = progress;
                lblProgress.Text = progress + "%";
            }));

            if (txtInput.Text.Length == 0)
                enableButtons();
        }
    }
}
