namespace Press_Your_Luck
{
    partial class About
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
            this.aboutRTextBox = new System.Windows.Forms.RichTextBox();
            this.aboutCloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // aboutRTextBox
            // 
            this.aboutRTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.aboutRTextBox.Font = new System.Drawing.Font("Bookman Old Style", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutRTextBox.Location = new System.Drawing.Point(12, 12);
            this.aboutRTextBox.Name = "aboutRTextBox";
            this.aboutRTextBox.Size = new System.Drawing.Size(527, 272);
            this.aboutRTextBox.TabIndex = 0;
            this.aboutRTextBox.Text = "";
            // 
            // aboutCloseButton
            // 
            this.aboutCloseButton.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutCloseButton.Location = new System.Drawing.Point(224, 313);
            this.aboutCloseButton.Name = "aboutCloseButton";
            this.aboutCloseButton.Size = new System.Drawing.Size(77, 29);
            this.aboutCloseButton.TabIndex = 1;
            this.aboutCloseButton.Text = "Close";
            this.aboutCloseButton.UseVisualStyleBackColor = true;
            this.aboutCloseButton.Click += new System.EventHandler(this.aboutCloseButton_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(551, 354);
            this.Controls.Add(this.aboutCloseButton);
            this.Controls.Add(this.aboutRTextBox);
            this.Name = "About";
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox aboutRTextBox;
        private System.Windows.Forms.Button aboutCloseButton;
    }
}