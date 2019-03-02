namespace TradeUp
{
    partial class Trade
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
            this.mainFeedListBox = new System.Windows.Forms.ListBox();
            this.tradeButton = new System.Windows.Forms.Button();
            this.mainFeedLabel = new System.Windows.Forms.Label();
            this.myTextBooksLabel = new System.Windows.Forms.Label();
            this.userListBox = new System.Windows.Forms.ListBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainFeedListBox
            // 
            this.mainFeedListBox.FormattingEnabled = true;
            this.mainFeedListBox.ItemHeight = 20;
            this.mainFeedListBox.Location = new System.Drawing.Point(70, 78);
            this.mainFeedListBox.Name = "mainFeedListBox";
            this.mainFeedListBox.Size = new System.Drawing.Size(258, 324);
            this.mainFeedListBox.TabIndex = 1;
            // 
            // tradeButton
            // 
            this.tradeButton.Location = new System.Drawing.Point(309, 473);
            this.tradeButton.Name = "tradeButton";
            this.tradeButton.Size = new System.Drawing.Size(140, 34);
            this.tradeButton.TabIndex = 2;
            this.tradeButton.Text = "Send Trade";
            this.tradeButton.UseVisualStyleBackColor = true;
            this.tradeButton.Click += new System.EventHandler(this.tradeButton_Click);
            // 
            // mainFeedLabel
            // 
            this.mainFeedLabel.AutoSize = true;
            this.mainFeedLabel.Location = new System.Drawing.Point(66, 36);
            this.mainFeedLabel.Name = "mainFeedLabel";
            this.mainFeedLabel.Size = new System.Drawing.Size(164, 20);
            this.mainFeedLabel.TabIndex = 3;
            this.mainFeedLabel.Text = "Avaialable Text Books";
            // 
            // myTextBooksLabel
            // 
            this.myTextBooksLabel.AutoSize = true;
            this.myTextBooksLabel.Location = new System.Drawing.Point(360, 36);
            this.myTextBooksLabel.Name = "myTextBooksLabel";
            this.myTextBooksLabel.Size = new System.Drawing.Size(112, 20);
            this.myTextBooksLabel.TabIndex = 4;
            this.myTextBooksLabel.Text = "My Text Books";
            // 
            // userListBox
            // 
            this.userListBox.FormattingEnabled = true;
            this.userListBox.ItemHeight = 20;
            this.userListBox.Location = new System.Drawing.Point(364, 78);
            this.userListBox.Name = "userListBox";
            this.userListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.userListBox.Size = new System.Drawing.Size(258, 324);
            this.userListBox.TabIndex = 5;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(482, 473);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(140, 34);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // Trade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 540);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.userListBox);
            this.Controls.Add(this.myTextBooksLabel);
            this.Controls.Add(this.mainFeedLabel);
            this.Controls.Add(this.tradeButton);
            this.Controls.Add(this.mainFeedListBox);
            this.Name = "Trade";
            this.Text = "Trade";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox mainFeedListBox;
        private System.Windows.Forms.Button tradeButton;
        private System.Windows.Forms.Label mainFeedLabel;
        private System.Windows.Forms.Label myTextBooksLabel;
        private System.Windows.Forms.ListBox userListBox;
        private System.Windows.Forms.Button closeButton;
    }
}