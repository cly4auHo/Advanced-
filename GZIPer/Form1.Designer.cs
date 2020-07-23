namespace GZIPer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonFind = new System.Windows.Forms.Button();
            this.ButtonCompression = new System.Windows.Forms.Button();
            this.FileText = new System.Windows.Forms.TextBox();
            this.CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.FileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonFind
            // 
            this.ButtonFind.Location = new System.Drawing.Point(138, 68);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(136, 23);
            this.ButtonFind.TabIndex = 0;
            this.ButtonFind.Text = "Find";
            this.ButtonFind.UseVisualStyleBackColor = true;
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // ButtonCompression
            // 
            this.ButtonCompression.Location = new System.Drawing.Point(280, 68);
            this.ButtonCompression.Name = "ButtonCompression";
            this.ButtonCompression.Size = new System.Drawing.Size(136, 23);
            this.ButtonCompression.TabIndex = 1;
            this.ButtonCompression.Text = "Compression";
            this.ButtonCompression.UseVisualStyleBackColor = true;
            this.ButtonCompression.Click += new System.EventHandler(this.ButtonCompression_Click);
            // 
            // FileText
            // 
            this.FileText.Location = new System.Drawing.Point(12, 97);
            this.FileText.Multiline = true;
            this.FileText.Name = "FileText";
            this.FileText.ReadOnly = true;
            this.FileText.Size = new System.Drawing.Size(776, 276);
            this.FileText.TabIndex = 2;
            // 
            // CheckedListBox
            // 
            this.CheckedListBox.CheckOnClick = true;
            this.CheckedListBox.FormattingEnabled = true;
            this.CheckedListBox.Location = new System.Drawing.Point(12, 12);
            this.CheckedListBox.Name = "CheckedListBox";
            this.CheckedListBox.Size = new System.Drawing.Size(120, 79);
            this.CheckedListBox.TabIndex = 4;
            this.CheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBox_ItemCheck);
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(138, 12);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(278, 20);
            this.FileName.TabIndex = 5;
            this.FileName.Text = "Enter file name";
            this.FileName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FileName_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 377);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.CheckedListBox);
            this.Controls.Add(this.FileText);
            this.Controls.Add(this.ButtonCompression);
            this.Controls.Add(this.ButtonFind);
            this.Name = "Form1";
            this.Text = "Explorer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonFind;
        private System.Windows.Forms.Button ButtonCompression;
        private System.Windows.Forms.TextBox FileText;
        private System.Windows.Forms.CheckedListBox CheckedListBox;
        private System.Windows.Forms.TextBox FileName;
    }
}

