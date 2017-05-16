namespace WindowsFormsApplication2
{
    partial class Cvor
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
            this.usernameText = new System.Windows.Forms.TextBox();
            this.usernameButton = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.startButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IPText = new System.Windows.Forms.TextBox();
            this.portText = new System.Windows.Forms.TextBox();
            this.chat = new System.Windows.Forms.ListBox();
            this.counter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.srednjaLabel = new System.Windows.Forms.Label();
            this.paketibox = new System.Windows.Forms.ListBox();
            this.potvrdebox = new System.Windows.Forms.ListBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameText
            // 
            this.usernameText.Location = new System.Drawing.Point(88, 12);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(100, 20);
            this.usernameText.TabIndex = 0;
            // 
            // usernameButton
            // 
            this.usernameButton.Location = new System.Drawing.Point(102, 38);
            this.usernameButton.Name = "usernameButton";
            this.usernameButton.Size = new System.Drawing.Size(75, 23);
            this.usernameButton.TabIndex = 1;
            this.usernameButton.Text = "CONNECT";
            this.usernameButton.UseVisualStyleBackColor = true;
            this.usernameButton.Click += new System.EventHandler(this.usernameButton_Click);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.startButton);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.IPText);
            this.groupBox.Controls.Add(this.portText);
            this.groupBox.Enabled = false;
            this.groupBox.Location = new System.Drawing.Point(12, 67);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(260, 74);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(120, 19);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(134, 45);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port";
            // 
            // IPText
            // 
            this.IPText.Location = new System.Drawing.Point(47, 45);
            this.IPText.Name = "IPText";
            this.IPText.Size = new System.Drawing.Size(48, 20);
            this.IPText.TabIndex = 1;
            // 
            // portText
            // 
            this.portText.Location = new System.Drawing.Point(47, 19);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(48, 20);
            this.portText.TabIndex = 0;
            // 
            // chat
            // 
            this.chat.FormattingEnabled = true;
            this.chat.Location = new System.Drawing.Point(12, 263);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(259, 95);
            this.chat.TabIndex = 3;
            // 
            // counter
            // 
            this.counter.AutoSize = true;
            this.counter.Location = new System.Drawing.Point(27, 247);
            this.counter.Name = "counter";
            this.counter.Size = new System.Drawing.Size(0, 13);
            this.counter.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Srednja vrijednost:";
            this.label3.Visible = false;
            // 
            // srednjaLabel
            // 
            this.srednjaLabel.AutoSize = true;
            this.srednjaLabel.Location = new System.Drawing.Point(223, 361);
            this.srednjaLabel.Name = "srednjaLabel";
            this.srednjaLabel.Size = new System.Drawing.Size(0, 13);
            this.srednjaLabel.TabIndex = 6;
            // 
            // paketibox
            // 
            this.paketibox.FormattingEnabled = true;
            this.paketibox.Location = new System.Drawing.Point(16, 148);
            this.paketibox.Name = "paketibox";
            this.paketibox.Size = new System.Drawing.Size(116, 82);
            this.paketibox.TabIndex = 7;
            // 
            // potvrdebox
            // 
            this.potvrdebox.FormattingEnabled = true;
            this.potvrdebox.Location = new System.Drawing.Point(138, 147);
            this.potvrdebox.Name = "potvrdebox";
            this.potvrdebox.Size = new System.Drawing.Size(134, 82);
            this.potvrdebox.TabIndex = 8;
            // 
            // Cvor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 403);
            this.Controls.Add(this.potvrdebox);
            this.Controls.Add(this.paketibox);
            this.Controls.Add(this.srednjaLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.counter);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.usernameButton);
            this.Controls.Add(this.usernameText);
            this.Name = "Cvor";
            this.Text = "Cvor";
            this.Load += new System.EventHandler(this.Cvor_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.Button usernameButton;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IPText;
        private System.Windows.Forms.TextBox portText;
        private System.Windows.Forms.ListBox chat;
        private System.Windows.Forms.Label counter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label srednjaLabel;
        private System.Windows.Forms.ListBox paketibox;
        private System.Windows.Forms.ListBox potvrdebox;
    }
}

