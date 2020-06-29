namespace CurumimClient
{
    partial class GameWinOrLoserForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWinOrLoserForms));
            this.lblBau = new System.Windows.Forms.Label();
            this.lblEsm = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.pbxBau = new System.Windows.Forms.PictureBox();
            this.pbxEsm = new System.Windows.Forms.PictureBox();
            this.pbxScore = new System.Windows.Forms.PictureBox();
            this.pbxStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEsm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBau
            // 
            this.lblBau.Font = new System.Drawing.Font("Segoe Script", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBau.Location = new System.Drawing.Point(30, 231);
            this.lblBau.Name = "lblBau";
            this.lblBau.Size = new System.Drawing.Size(100, 24);
            this.lblBau.TabIndex = 0;
            this.lblBau.Text = "0";
            this.lblBau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEsm
            // 
            this.lblEsm.Font = new System.Drawing.Font("Segoe Script", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEsm.Location = new System.Drawing.Point(136, 231);
            this.lblEsm.Name = "lblEsm";
            this.lblEsm.Size = new System.Drawing.Size(100, 23);
            this.lblEsm.TabIndex = 1;
            this.lblEsm.Text = "0";
            this.lblEsm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Segoe Script", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(252, 231);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(90, 24);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxBau
            // 
            this.pbxBau.Image = ((System.Drawing.Image)(resources.GetObject("pbxBau.Image")));
            this.pbxBau.Location = new System.Drawing.Point(30, 174);
            this.pbxBau.Name = "pbxBau";
            this.pbxBau.Size = new System.Drawing.Size(100, 54);
            this.pbxBau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxBau.TabIndex = 3;
            this.pbxBau.TabStop = false;
            // 
            // pbxEsm
            // 
            this.pbxEsm.Image = ((System.Drawing.Image)(resources.GetObject("pbxEsm.Image")));
            this.pbxEsm.Location = new System.Drawing.Point(136, 174);
            this.pbxEsm.Name = "pbxEsm";
            this.pbxEsm.Size = new System.Drawing.Size(100, 54);
            this.pbxEsm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxEsm.TabIndex = 4;
            this.pbxEsm.TabStop = false;
            // 
            // pbxScore
            // 
            this.pbxScore.Image = ((System.Drawing.Image)(resources.GetObject("pbxScore.Image")));
            this.pbxScore.Location = new System.Drawing.Point(242, 174);
            this.pbxScore.Name = "pbxScore";
            this.pbxScore.Size = new System.Drawing.Size(100, 54);
            this.pbxScore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxScore.TabIndex = 5;
            this.pbxScore.TabStop = false;
            // 
            // pbxStatus
            // 
            this.pbxStatus.Image = ((System.Drawing.Image)(resources.GetObject("pbxStatus.Image")));
            this.pbxStatus.Location = new System.Drawing.Point(74, 12);
            this.pbxStatus.Name = "pbxStatus";
            this.pbxStatus.Size = new System.Drawing.Size(233, 156);
            this.pbxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxStatus.TabIndex = 6;
            this.pbxStatus.TabStop = false;
            // 
            // GameWinOrLoserForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 264);
            this.Controls.Add(this.pbxStatus);
            this.Controls.Add(this.pbxScore);
            this.Controls.Add(this.pbxEsm);
            this.Controls.Add(this.pbxBau);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblEsm);
            this.Controls.Add(this.lblBau);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameWinOrLoserForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "End Game";
            this.Load += new System.EventHandler(this.GameWinOrLoserForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEsm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblBau;
        private System.Windows.Forms.Label lblEsm;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.PictureBox pbxBau;
        private System.Windows.Forms.PictureBox pbxEsm;
        private System.Windows.Forms.PictureBox pbxScore;
        private System.Windows.Forms.PictureBox pbxStatus;
    }
}