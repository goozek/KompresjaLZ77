namespace LZ77_gui
{
    partial class FrmMain
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.numDictionarySize = new System.Windows.Forms.NumericUpDown();
            this.btnCompress = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numBufferSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDecompress = new System.Windows.Forms.Button();
            this.btnCompressPreview = new System.Windows.Forms.Button();
            this.btnDecompressPreview = new System.Windows.Forms.Button();
            this.btnBreak = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.dgvDictionary = new System.Windows.Forms.DataGridView();
            this.dgvBuffer = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNextStep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDictionarySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuffer)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(53, 422);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBar1.Size = new System.Drawing.Size(722, 25);
            this.progressBar1.TabIndex = 0;
            // 
            // numDictionarySize
            // 
            this.numDictionarySize.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numDictionarySize.Location = new System.Drawing.Point(467, 231);
            this.numDictionarySize.Margin = new System.Windows.Forms.Padding(2);
            this.numDictionarySize.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numDictionarySize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numDictionarySize.Name = "numDictionarySize";
            this.numDictionarySize.Size = new System.Drawing.Size(47, 20);
            this.numDictionarySize.TabIndex = 1;
            this.numDictionarySize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(11, 227);
            this.btnCompress.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(189, 24);
            this.btnCompress.TabIndex = 2;
            this.btnCompress.Text = "Kompresuj";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 233);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rozmiar słownika (z przedziału <4;128>)";
            // 
            // numBufferSize
            // 
            this.numBufferSize.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numBufferSize.Location = new System.Drawing.Point(467, 259);
            this.numBufferSize.Margin = new System.Windows.Forms.Padding(2);
            this.numBufferSize.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numBufferSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numBufferSize.Name = "numBufferSize";
            this.numBufferSize.Size = new System.Drawing.Size(47, 20);
            this.numBufferSize.TabIndex = 4;
            this.numBufferSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 261);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rozmiar bufora (z przedziału <4;128>)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 428);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Postęp:";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(779, 428);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(21, 13);
            this.lblProgress.TabIndex = 7;
            this.lblProgress.Text = "0%";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(11, 22);
            this.txtInput.Margin = new System.Windows.Forms.Padding(2);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(384, 199);
            this.txtInput.TabIndex = 8;
            this.txtInput.Text = "ala ma kota. kot ma na imie filemon. filemon lubi lezec na kanapie. ala kocha kot" +
    "a filemona.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tekst do kompresji/dekompresji:";
            // 
            // btnDecompress
            // 
            this.btnDecompress.Location = new System.Drawing.Point(206, 227);
            this.btnDecompress.Margin = new System.Windows.Forms.Padding(2);
            this.btnDecompress.Name = "btnDecompress";
            this.btnDecompress.Size = new System.Drawing.Size(189, 24);
            this.btnDecompress.TabIndex = 10;
            this.btnDecompress.Text = "Dekompresuj";
            this.btnDecompress.UseVisualStyleBackColor = true;
            this.btnDecompress.Click += new System.EventHandler(this.btnDecompress_Click);
            // 
            // btnCompressPreview
            // 
            this.btnCompressPreview.Location = new System.Drawing.Point(11, 255);
            this.btnCompressPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompressPreview.Name = "btnCompressPreview";
            this.btnCompressPreview.Size = new System.Drawing.Size(189, 24);
            this.btnCompressPreview.TabIndex = 11;
            this.btnCompressPreview.Text = "Kompresuj (z podglądem)";
            this.btnCompressPreview.UseVisualStyleBackColor = true;
            this.btnCompressPreview.Click += new System.EventHandler(this.btnCompressPreview_Click);
            // 
            // btnDecompressPreview
            // 
            this.btnDecompressPreview.Location = new System.Drawing.Point(206, 255);
            this.btnDecompressPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnDecompressPreview.Name = "btnDecompressPreview";
            this.btnDecompressPreview.Size = new System.Drawing.Size(189, 24);
            this.btnDecompressPreview.TabIndex = 12;
            this.btnDecompressPreview.Text = "Dekompresuj (z podglądem)";
            this.btnDecompressPreview.UseVisualStyleBackColor = true;
            this.btnDecompressPreview.Click += new System.EventHandler(this.btnDecompressPreview_Click);
            // 
            // btnBreak
            // 
            this.btnBreak.Enabled = false;
            this.btnBreak.Location = new System.Drawing.Point(804, 422);
            this.btnBreak.Margin = new System.Windows.Forms.Padding(2);
            this.btnBreak.Name = "btnBreak";
            this.btnBreak.Size = new System.Drawing.Size(47, 25);
            this.btnBreak.TabIndex = 13;
            this.btnBreak.Text = "Anuluj";
            this.btnBreak.UseVisualStyleBackColor = true;
            this.btnBreak.Click += new System.EventHandler(this.btnBreak_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(467, 22);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(383, 197);
            this.txtOutput.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Wyjście:";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(400, 22);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(61, 197);
            this.btnChange.TabIndex = 16;
            this.btnChange.Text = "<     >";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // dgvDictionary
            // 
            this.dgvDictionary.AllowUserToAddRows = false;
            this.dgvDictionary.AllowUserToDeleteRows = false;
            this.dgvDictionary.AllowUserToResizeColumns = false;
            this.dgvDictionary.AllowUserToResizeRows = false;
            this.dgvDictionary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDictionary.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDictionary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDictionary.Enabled = false;
            this.dgvDictionary.Location = new System.Drawing.Point(12, 336);
            this.dgvDictionary.Name = "dgvDictionary";
            this.dgvDictionary.ReadOnly = true;
            this.dgvDictionary.RowHeadersVisible = false;
            this.dgvDictionary.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvDictionary.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvDictionary.Size = new System.Drawing.Size(383, 68);
            this.dgvDictionary.TabIndex = 17;
            // 
            // dgvBuffer
            // 
            this.dgvBuffer.AllowUserToAddRows = false;
            this.dgvBuffer.AllowUserToDeleteRows = false;
            this.dgvBuffer.AllowUserToResizeColumns = false;
            this.dgvBuffer.AllowUserToResizeRows = false;
            this.dgvBuffer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBuffer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvBuffer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuffer.Enabled = false;
            this.dgvBuffer.Location = new System.Drawing.Point(467, 336);
            this.dgvBuffer.MultiSelect = false;
            this.dgvBuffer.Name = "dgvBuffer";
            this.dgvBuffer.ReadOnly = true;
            this.dgvBuffer.RowHeadersVisible = false;
            this.dgvBuffer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvBuffer.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvBuffer.ShowEditingIcon = false;
            this.dgvBuffer.Size = new System.Drawing.Size(383, 68);
            this.dgvBuffer.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Zawartość słownika:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(464, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Zawartość bufora/wyjście dekodera:";
            // 
            // btnNextStep
            // 
            this.btnNextStep.Enabled = false;
            this.btnNextStep.Location = new System.Drawing.Point(12, 284);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(383, 23);
            this.btnNextStep.TabIndex = 21;
            this.btnNextStep.Text = "Następny krok";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 458);
            this.Controls.Add(this.btnNextStep);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvBuffer);
            this.Controls.Add(this.dgvDictionary);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnBreak);
            this.Controls.Add(this.btnDecompressPreview);
            this.Controls.Add(this.btnCompressPreview);
            this.Controls.Add(this.btnDecompress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numBufferSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.numDictionarySize);
            this.Controls.Add(this.progressBar1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Kompresja/dekompresja LZ77 - Kamil Guzek 271054";
            ((System.ComponentModel.ISupportInitialize)(this.numDictionarySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuffer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NumericUpDown numDictionarySize;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numBufferSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDecompress;
        private System.Windows.Forms.Button btnCompressPreview;
        private System.Windows.Forms.Button btnDecompressPreview;
        private System.Windows.Forms.Button btnBreak;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.DataGridView dgvDictionary;
        private System.Windows.Forms.DataGridView dgvBuffer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNextStep;
    }
}

