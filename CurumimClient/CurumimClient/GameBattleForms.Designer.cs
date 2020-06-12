namespace CurumimGameForms
{
    partial class GameBattleForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBattleForms));
            this.pnlField = new System.Windows.Forms.Panel();
            this.pnlFieldRight = new System.Windows.Forms.Panel();
            this.pnlFieldLeft = new System.Windows.Forms.Panel();
            this.pnlBattle = new System.Windows.Forms.Panel();
            this.lblPlayer2Name = new System.Windows.Forms.Label();
            this.lblPlayer1Name = new System.Windows.Forms.Label();
            this.pbxChatBattle = new System.Windows.Forms.PictureBox();
            this.pnlField.SuspendLayout();
            this.pnlBattle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChatBattle)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlField
            // 
            this.pnlField.BackColor = System.Drawing.Color.Transparent;
            this.pnlField.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlField.BackgroundImage")));
            this.pnlField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlField.Controls.Add(this.pnlFieldRight);
            this.pnlField.Controls.Add(this.pnlFieldLeft);
            this.pnlField.Location = new System.Drawing.Point(60, 50);
            this.pnlField.Name = "pnlField";
            this.pnlField.Size = new System.Drawing.Size(1104, 409);
            this.pnlField.TabIndex = 0;
            // 
            // pnlFieldRight
            // 
            this.pnlFieldRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFieldRight.Location = new System.Drawing.Point(587, 0);
            this.pnlFieldRight.Name = "pnlFieldRight";
            this.pnlFieldRight.Size = new System.Drawing.Size(517, 409);
            this.pnlFieldRight.TabIndex = 4;
            // 
            // pnlFieldLeft
            // 
            this.pnlFieldLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFieldLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlFieldLeft.Name = "pnlFieldLeft";
            this.pnlFieldLeft.Size = new System.Drawing.Size(517, 409);
            this.pnlFieldLeft.TabIndex = 3;
            // 
            // pnlBattle
            // 
            this.pnlBattle.Controls.Add(this.lblPlayer2Name);
            this.pnlBattle.Controls.Add(this.lblPlayer1Name);
            this.pnlBattle.Controls.Add(this.pbxChatBattle);
            this.pnlBattle.Controls.Add(this.pnlField);
            this.pnlBattle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBattle.Location = new System.Drawing.Point(0, 0);
            this.pnlBattle.Name = "pnlBattle";
            this.pnlBattle.Size = new System.Drawing.Size(1222, 527);
            this.pnlBattle.TabIndex = 2;
            // 
            // lblPlayer2Name
            // 
            this.lblPlayer2Name.AutoSize = true;
            this.lblPlayer2Name.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer2Name.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2Name.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblPlayer2Name.Location = new System.Drawing.Point(857, 10);
            this.lblPlayer2Name.Name = "lblPlayer2Name";
            this.lblPlayer2Name.Size = new System.Drawing.Size(80, 28);
            this.lblPlayer2Name.TabIndex = 4;
            this.lblPlayer2Name.Text = "Player 2";
            this.lblPlayer2Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer1Name
            // 
            this.lblPlayer1Name.AutoSize = true;
            this.lblPlayer1Name.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer1Name.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1Name.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblPlayer1Name.Location = new System.Drawing.Point(259, 10);
            this.lblPlayer1Name.Name = "lblPlayer1Name";
            this.lblPlayer1Name.Size = new System.Drawing.Size(80, 28);
            this.lblPlayer1Name.TabIndex = 3;
            this.lblPlayer1Name.Text = "Player 1";
            this.lblPlayer1Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxChatBattle
            // 
            this.pbxChatBattle.BackColor = System.Drawing.Color.Transparent;
            this.pbxChatBattle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxChatBattle.BackgroundImage")));
            this.pbxChatBattle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxChatBattle.Location = new System.Drawing.Point(1171, 484);
            this.pbxChatBattle.Name = "pbxChatBattle";
            this.pbxChatBattle.Size = new System.Drawing.Size(51, 43);
            this.pbxChatBattle.TabIndex = 1;
            this.pbxChatBattle.TabStop = false;
            this.pbxChatBattle.Click += new System.EventHandler(this.pbxChatBattle_Click);
            // 
            // GameBattleForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1222, 527);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBattle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameBattleForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.GameBattleForms_Load);
            this.pnlField.ResumeLayout(false);
            this.pnlBattle.ResumeLayout(false);
            this.pnlBattle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChatBattle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlField;
        private System.Windows.Forms.Panel pnlBattle;
        private System.Windows.Forms.Panel pnlFieldRight;
        private System.Windows.Forms.Panel pnlFieldLeft;
        private System.Windows.Forms.Label lblPlayer2Name;
        private System.Windows.Forms.Label lblPlayer1Name;
        private System.Windows.Forms.PictureBox pbxChatBattle;
    }
}