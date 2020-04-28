namespace CurumimGameForms
{
    partial class GameAvatarForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameAvatarForms));
            this.lblOptions = new System.Windows.Forms.Label();
            this.pbxAvatar = new System.Windows.Forms.PictureBox();
            this.pbxNext = new System.Windows.Forms.PictureBox();
            this.pbxReturn = new System.Windows.Forms.PictureBox();
            this.pbxSelect = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOptions
            // 
            this.lblOptions.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptions.Location = new System.Drawing.Point(0, -1);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(350, 32);
            this.lblOptions.TabIndex = 2;
            this.lblOptions.Text = "Avatar";
            this.lblOptions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxAvatar
            // 
            this.pbxAvatar.BackColor = System.Drawing.Color.White;
            this.pbxAvatar.InitialImage = null;
            this.pbxAvatar.Location = new System.Drawing.Point(0, 48);
            this.pbxAvatar.Name = "pbxAvatar";
            this.pbxAvatar.Size = new System.Drawing.Size(350, 500);
            this.pbxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxAvatar.TabIndex = 3;
            this.pbxAvatar.TabStop = false;
            // 
            // pbxNext
            // 
            this.pbxNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxNext.BackgroundImage")));
            this.pbxNext.Location = new System.Drawing.Point(368, 197);
            this.pbxNext.Name = "pbxNext";
            this.pbxNext.Size = new System.Drawing.Size(38, 38);
            this.pbxNext.TabIndex = 7;
            this.pbxNext.TabStop = false;
            this.pbxNext.Click += new System.EventHandler(this.pbxNext_Click);
            // 
            // pbxReturn
            // 
            this.pbxReturn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxReturn.BackgroundImage")));
            this.pbxReturn.Location = new System.Drawing.Point(368, 285);
            this.pbxReturn.Name = "pbxReturn";
            this.pbxReturn.Size = new System.Drawing.Size(38, 39);
            this.pbxReturn.TabIndex = 8;
            this.pbxReturn.TabStop = false;
            this.pbxReturn.Click += new System.EventHandler(this.pbxReturn_Click);
            // 
            // pbxSelect
            // 
            this.pbxSelect.Image = ((System.Drawing.Image)(resources.GetObject("pbxSelect.Image")));
            this.pbxSelect.Location = new System.Drawing.Point(368, 241);
            this.pbxSelect.Name = "pbxSelect";
            this.pbxSelect.Size = new System.Drawing.Size(38, 38);
            this.pbxSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxSelect.TabIndex = 9;
            this.pbxSelect.TabStop = false;
            this.pbxSelect.Click += new System.EventHandler(this.pbxSelect_Click);
            // 
            // GameAvatarForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(420, 548);
            this.ControlBox = false;
            this.Controls.Add(this.pbxSelect);
            this.Controls.Add(this.pbxReturn);
            this.Controls.Add(this.pbxNext);
            this.Controls.Add(this.pbxAvatar);
            this.Controls.Add(this.lblOptions);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameAvatarForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.GameAvatarForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.PictureBox pbxAvatar;
        private System.Windows.Forms.PictureBox pbxNext;
        private System.Windows.Forms.PictureBox pbxReturn;
        private System.Windows.Forms.PictureBox pbxSelect;
    }
}