namespace CurumimGameForms
{
    partial class GameChatBatlleForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameChatBatlleForms));
            this.rbxMessage = new System.Windows.Forms.RichTextBox();
            this.rbxHitory = new System.Windows.Forms.RichTextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelUp = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // rbxMessage
            // 
            this.rbxMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.rbxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rbxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxMessage.ForeColor = System.Drawing.Color.White;
            this.rbxMessage.Location = new System.Drawing.Point(6, 226);
            this.rbxMessage.Name = "rbxMessage";
            this.rbxMessage.Size = new System.Drawing.Size(300, 30);
            this.rbxMessage.TabIndex = 10;
            this.rbxMessage.Text = "";
            // 
            // rbxHitory
            // 
            this.rbxHitory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.rbxHitory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rbxHitory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxHitory.ForeColor = System.Drawing.Color.White;
            this.rbxHitory.Location = new System.Drawing.Point(6, 34);
            this.rbxHitory.Name = "rbxHitory";
            this.rbxHitory.ReadOnly = true;
            this.rbxHitory.Size = new System.Drawing.Size(302, 186);
            this.rbxHitory.TabIndex = 8;
            this.rbxHitory.Text = "";
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSendMessage.BackgroundImage")));
            this.btnSendMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSendMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendMessage.FlatAppearance.BorderSize = 0;
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSendMessage.Location = new System.Drawing.Point(227, 262);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 11;
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(6, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 30);
            this.btnClose.TabIndex = 12;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelUp
            // 
            this.panelUp.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(314, 38);
            this.panelUp.TabIndex = 13;
            this.panelUp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelUp_MouseMove);
            // 
            // GameChatBatlleForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(314, 292);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelUp);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.rbxMessage);
            this.Controls.Add(this.rbxHitory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameChatBatlleForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.GameChatBatlleForms_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox rbxMessage;
        private System.Windows.Forms.RichTextBox rbxHitory;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelUp;
    }
}