namespace example
{
    partial class SifrelemePaneli
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
            this.sifreBox = new System.Windows.Forms.TextBox();
            this.sifreLabel = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.md5Box = new System.Windows.Forms.RichTextBox();
            this.shaBox = new System.Windows.Forms.RichTextBox();
            this.md5label = new System.Windows.Forms.Label();
            this.shaLabel = new System.Windows.Forms.Label();
            this.md5lengthlabel = new System.Windows.Forms.Label();
            this.shalengthlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sifreBox
            // 
            this.sifreBox.Location = new System.Drawing.Point(178, 95);
            this.sifreBox.Name = "sifreBox";
            this.sifreBox.Size = new System.Drawing.Size(238, 22);
            this.sifreBox.TabIndex = 0;
            this.sifreBox.TextChanged += new System.EventHandler(this.sifreBox_TextChanged);
            // 
            // sifreLabel
            // 
            this.sifreLabel.AutoSize = true;
            this.sifreLabel.Location = new System.Drawing.Point(106, 98);
            this.sifreLabel.Name = "sifreLabel";
            this.sifreLabel.Size = new System.Drawing.Size(34, 16);
            this.sifreLabel.TabIndex = 1;
            this.sifreLabel.Text = "Şifre";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(212, 276);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(240, 100);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            // 
            // md5Box
            // 
            this.md5Box.Location = new System.Drawing.Point(176, 145);
            this.md5Box.Name = "md5Box";
            this.md5Box.Size = new System.Drawing.Size(240, 100);
            this.md5Box.TabIndex = 8;
            this.md5Box.Text = "";
            // 
            // shaBox
            // 
            this.shaBox.Location = new System.Drawing.Point(176, 275);
            this.shaBox.Name = "shaBox";
            this.shaBox.Size = new System.Drawing.Size(240, 100);
            this.shaBox.TabIndex = 9;
            this.shaBox.Text = "";
            // 
            // md5label
            // 
            this.md5label.AutoSize = true;
            this.md5label.Location = new System.Drawing.Point(106, 190);
            this.md5label.Name = "md5label";
            this.md5label.Size = new System.Drawing.Size(35, 16);
            this.md5label.TabIndex = 10;
            this.md5label.Text = "MD5";
            // 
            // shaLabel
            // 
            this.shaLabel.AutoSize = true;
            this.shaLabel.Location = new System.Drawing.Point(106, 330);
            this.shaLabel.Name = "shaLabel";
            this.shaLabel.Size = new System.Drawing.Size(35, 16);
            this.shaLabel.TabIndex = 11;
            this.shaLabel.Text = "SHA";
            // 
            // md5lengthlabel
            // 
            this.md5lengthlabel.AutoSize = true;
            this.md5lengthlabel.Location = new System.Drawing.Point(454, 190);
            this.md5lengthlabel.Name = "md5lengthlabel";
            this.md5lengthlabel.Size = new System.Drawing.Size(35, 16);
            this.md5lengthlabel.TabIndex = 12;
            this.md5lengthlabel.Text = "MD5";
            // 
            // shalengthlabel
            // 
            this.shalengthlabel.AutoSize = true;
            this.shalengthlabel.Location = new System.Drawing.Point(454, 330);
            this.shalengthlabel.Name = "shalengthlabel";
            this.shalengthlabel.Size = new System.Drawing.Size(35, 16);
            this.shalengthlabel.TabIndex = 13;
            this.shalengthlabel.Text = "SHA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(150, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "Şifreleme Paneli";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SifrelemePaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 477);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shalengthlabel);
            this.Controls.Add(this.md5lengthlabel);
            this.Controls.Add(this.shaLabel);
            this.Controls.Add(this.md5label);
            this.Controls.Add(this.shaBox);
            this.Controls.Add(this.md5Box);
            this.Controls.Add(this.sifreLabel);
            this.Controls.Add(this.sifreBox);
            this.Name = "SifrelemePaneli";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sifreBox;
        private System.Windows.Forms.Label sifreLabel;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox md5Box;
        private System.Windows.Forms.RichTextBox shaBox;
        private System.Windows.Forms.Label md5label;
        private System.Windows.Forms.Label shaLabel;
        private System.Windows.Forms.Label md5lengthlabel;
        private System.Windows.Forms.Label shalengthlabel;
        private System.Windows.Forms.Label label1;
    }
}