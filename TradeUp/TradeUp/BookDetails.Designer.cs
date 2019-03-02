namespace TradeUp
{
    partial class BookDetails
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
            this.authorLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.isbnLabel = new System.Windows.Forms.Label();
            this.posterUsernameLabel = new System.Windows.Forms.Label();
            this.posterUsernameLabelCopy = new System.Windows.Forms.Label();
            this.authorLabelCopy = new System.Windows.Forms.Label();
            this.titleLabelCopy = new System.Windows.Forms.Label();
            this.isbnLabelCopy = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(42, 299);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(61, 20);
            this.authorLabel.TabIndex = 8;
            this.authorLabel.Text = "Author:";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(42, 237);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(42, 20);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "Title:";
            // 
            // isbnLabel
            // 
            this.isbnLabel.AutoSize = true;
            this.isbnLabel.Location = new System.Drawing.Point(42, 175);
            this.isbnLabel.Name = "isbnLabel";
            this.isbnLabel.Size = new System.Drawing.Size(51, 20);
            this.isbnLabel.TabIndex = 6;
            this.isbnLabel.Text = "ISBN:";
            // 
            // posterUsernameLabel
            // 
            this.posterUsernameLabel.AutoSize = true;
            this.posterUsernameLabel.Location = new System.Drawing.Point(42, 111);
            this.posterUsernameLabel.Name = "posterUsernameLabel";
            this.posterUsernameLabel.Size = new System.Drawing.Size(137, 20);
            this.posterUsernameLabel.TabIndex = 12;
            this.posterUsernameLabel.Text = "Poster Username:";
            // 
            // posterUsernameLabelCopy
            // 
            this.posterUsernameLabelCopy.AutoSize = true;
            this.posterUsernameLabelCopy.Location = new System.Drawing.Point(264, 111);
            this.posterUsernameLabelCopy.Name = "posterUsernameLabelCopy";
            this.posterUsernameLabelCopy.Size = new System.Drawing.Size(39, 20);
            this.posterUsernameLabelCopy.TabIndex = 16;
            this.posterUsernameLabelCopy.Text = "Text";
            // 
            // authorLabelCopy
            // 
            this.authorLabelCopy.AutoSize = true;
            this.authorLabelCopy.Location = new System.Drawing.Point(264, 299);
            this.authorLabelCopy.Name = "authorLabelCopy";
            this.authorLabelCopy.Size = new System.Drawing.Size(39, 20);
            this.authorLabelCopy.TabIndex = 15;
            this.authorLabelCopy.Text = "Text";
            // 
            // titleLabelCopy
            // 
            this.titleLabelCopy.AutoSize = true;
            this.titleLabelCopy.Location = new System.Drawing.Point(264, 237);
            this.titleLabelCopy.Name = "titleLabelCopy";
            this.titleLabelCopy.Size = new System.Drawing.Size(39, 20);
            this.titleLabelCopy.TabIndex = 14;
            this.titleLabelCopy.Text = "Text";
            // 
            // isbnLabelCopy
            // 
            this.isbnLabelCopy.AutoSize = true;
            this.isbnLabelCopy.Location = new System.Drawing.Point(264, 175);
            this.isbnLabelCopy.Name = "isbnLabelCopy";
            this.isbnLabelCopy.Size = new System.Drawing.Size(39, 20);
            this.isbnLabelCopy.TabIndex = 13;
            this.isbnLabelCopy.Text = "Text";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(504, 465);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(121, 38);
            this.closeButton.TabIndex = 17;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // BookDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 540);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.posterUsernameLabelCopy);
            this.Controls.Add(this.authorLabelCopy);
            this.Controls.Add(this.titleLabelCopy);
            this.Controls.Add(this.isbnLabelCopy);
            this.Controls.Add(this.posterUsernameLabel);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.isbnLabel);
            this.Name = "BookDetails";
            this.Text = "Book Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label isbnLabel;
        private System.Windows.Forms.Label posterUsernameLabel;
        private System.Windows.Forms.Label posterUsernameLabelCopy;
        private System.Windows.Forms.Label authorLabelCopy;
        private System.Windows.Forms.Label titleLabelCopy;
        private System.Windows.Forms.Label isbnLabelCopy;
        private System.Windows.Forms.Button closeButton;
    }
}