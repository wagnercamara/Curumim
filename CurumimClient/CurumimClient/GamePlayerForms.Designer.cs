namespace CurumimGameForms
{
    partial class GamePlayerForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamePlayerForms));
            this.pnlUp = new System.Windows.Forms.Panel();
            this.pnlSpc = new System.Windows.Forms.Panel();
            this.pbxSpectador = new System.Windows.Forms.PictureBox();
            this.lblSpectator = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.div1 = new System.Windows.Forms.Button();
            this.pbxUpDown = new System.Windows.Forms.PictureBox();
            this.lblAbout = new System.Windows.Forms.Label();
            this.lblLocationBatlle = new System.Windows.Forms.Label();
            this.lblLocaitionStore = new System.Windows.Forms.Label();
            this.lblLocationChat = new System.Windows.Forms.Label();
            this.lblLocationArsenal = new System.Windows.Forms.Label();
            this.lblHome = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbxBatlle = new System.Windows.Forms.PictureBox();
            this.pbxChat = new System.Windows.Forms.PictureBox();
            this.pbxArsenal = new System.Windows.Forms.PictureBox();
            this.pbxStore = new System.Windows.Forms.PictureBox();
            this.pbxHome = new System.Windows.Forms.PictureBox();
            this.pbxImgFundo = new System.Windows.Forms.PictureBox();
            this.pnlUp.SuspendLayout();
            this.pnlSpc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSpectador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBatlle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArsenal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImgFundo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUp
            // 
            this.pnlUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlUp.Controls.Add(this.pnlSpc);
            this.pnlUp.Controls.Add(this.button3);
            this.pnlUp.Controls.Add(this.button2);
            this.pnlUp.Controls.Add(this.button1);
            this.pnlUp.Controls.Add(this.div1);
            this.pnlUp.Controls.Add(this.pbxUpDown);
            this.pnlUp.Controls.Add(this.lblAbout);
            this.pnlUp.Controls.Add(this.lblLocationBatlle);
            this.pnlUp.Controls.Add(this.lblLocaitionStore);
            this.pnlUp.Controls.Add(this.lblLocationChat);
            this.pnlUp.Controls.Add(this.lblLocationArsenal);
            this.pnlUp.Controls.Add(this.lblHome);
            this.pnlUp.Controls.Add(this.lblExit);
            this.pnlUp.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pnlUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUp.Location = new System.Drawing.Point(0, 0);
            this.pnlUp.Name = "pnlUp";
            this.pnlUp.Size = new System.Drawing.Size(998, 39);
            this.pnlUp.TabIndex = 5;
            this.pnlUp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlUp_MouseMove);
            // 
            // pnlSpc
            // 
            this.pnlSpc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(217)))), ((int)(((byte)(206)))));
            this.pnlSpc.Controls.Add(this.pbxSpectador);
            this.pnlSpc.Controls.Add(this.lblSpectator);
            this.pnlSpc.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlSpc.Location = new System.Drawing.Point(0, 34);
            this.pnlSpc.Name = "pnlSpc";
            this.pnlSpc.Size = new System.Drawing.Size(998, 3);
            this.pnlSpc.TabIndex = 14;
            // 
            // pbxSpectador
            // 
            this.pbxSpectador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxSpectador.Image = ((System.Drawing.Image)(resources.GetObject("pbxSpectador.Image")));
            this.pbxSpectador.Location = new System.Drawing.Point(390, 15);
            this.pbxSpectador.Name = "pbxSpectador";
            this.pbxSpectador.Size = new System.Drawing.Size(252, 253);
            this.pbxSpectador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxSpectador.TabIndex = 9;
            this.pbxSpectador.TabStop = false;
            this.pbxSpectador.Visible = false;
            this.pbxSpectador.Click += new System.EventHandler(this.pbxSpectador_Click);
            // 
            // lblSpectator
            // 
            this.lblSpectator.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpectator.ForeColor = System.Drawing.Color.Black;
            this.lblSpectator.Location = new System.Drawing.Point(390, 269);
            this.lblSpectator.Name = "lblSpectator";
            this.lblSpectator.Size = new System.Drawing.Size(252, 23);
            this.lblSpectator.TabIndex = 7;
            this.lblSpectator.Text = "Modo Spectador";
            this.lblSpectator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSpectator.Visible = false;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(606, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(2, 23);
            this.button3.TabIndex = 13;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(500, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(2, 23);
            this.button2.TabIndex = 12;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(394, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(2, 23);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // div1
            // 
            this.div1.Enabled = false;
            this.div1.Location = new System.Drawing.Point(283, 8);
            this.div1.Name = "div1";
            this.div1.Size = new System.Drawing.Size(2, 23);
            this.div1.TabIndex = 10;
            this.div1.UseVisualStyleBackColor = true;
            // 
            // pbxUpDown
            // 
            this.pbxUpDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxUpDown.Image = ((System.Drawing.Image)(resources.GetObject("pbxUpDown.Image")));
            this.pbxUpDown.Location = new System.Drawing.Point(722, 2);
            this.pbxUpDown.Name = "pbxUpDown";
            this.pbxUpDown.Size = new System.Drawing.Size(38, 29);
            this.pbxUpDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxUpDown.TabIndex = 8;
            this.pbxUpDown.TabStop = false;
            this.pbxUpDown.Click += new System.EventHandler(this.pbxUpDown_Click);
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAbout.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.ForeColor = System.Drawing.Color.White;
            this.lblAbout.Location = new System.Drawing.Point(946, 9);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(49, 23);
            this.lblAbout.TabIndex = 6;
            this.lblAbout.Text = "About";
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            // 
            // lblLocationBatlle
            // 
            this.lblLocationBatlle.AutoSize = true;
            this.lblLocationBatlle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLocationBatlle.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationBatlle.ForeColor = System.Drawing.Color.White;
            this.lblLocationBatlle.Location = new System.Drawing.Point(634, 9);
            this.lblLocationBatlle.Name = "lblLocationBatlle";
            this.lblLocationBatlle.Size = new System.Drawing.Size(49, 23);
            this.lblLocationBatlle.TabIndex = 5;
            this.lblLocationBatlle.Text = "Batlle";
            this.lblLocationBatlle.Click += new System.EventHandler(this.lblLocationBatlle_Click);
            // 
            // lblLocaitionStore
            // 
            this.lblLocaitionStore.AutoSize = true;
            this.lblLocaitionStore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLocaitionStore.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocaitionStore.ForeColor = System.Drawing.Color.White;
            this.lblLocaitionStore.Location = new System.Drawing.Point(529, 9);
            this.lblLocaitionStore.Name = "lblLocaitionStore";
            this.lblLocaitionStore.Size = new System.Drawing.Size(45, 23);
            this.lblLocaitionStore.TabIndex = 4;
            this.lblLocaitionStore.Text = "Store";
            this.lblLocaitionStore.Click += new System.EventHandler(this.lblLocaitionStore_Click);
            // 
            // lblLocationChat
            // 
            this.lblLocationChat.AutoSize = true;
            this.lblLocationChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLocationChat.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationChat.ForeColor = System.Drawing.Color.White;
            this.lblLocationChat.Location = new System.Drawing.Point(428, 9);
            this.lblLocationChat.Name = "lblLocationChat";
            this.lblLocationChat.Size = new System.Drawing.Size(41, 23);
            this.lblLocationChat.TabIndex = 3;
            this.lblLocationChat.Text = "Chat";
            this.lblLocationChat.Click += new System.EventHandler(this.lblLocationChat_Click);
            // 
            // lblLocationArsenal
            // 
            this.lblLocationArsenal.AutoSize = true;
            this.lblLocationArsenal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLocationArsenal.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationArsenal.ForeColor = System.Drawing.Color.White;
            this.lblLocationArsenal.Location = new System.Drawing.Point(307, 8);
            this.lblLocationArsenal.Name = "lblLocationArsenal";
            this.lblLocationArsenal.Size = new System.Drawing.Size(61, 23);
            this.lblLocationArsenal.TabIndex = 2;
            this.lblLocationArsenal.Text = "Arsenal";
            this.lblLocationArsenal.Click += new System.EventHandler(this.lblLocationArsenal_Click);
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHome.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.ForeColor = System.Drawing.Color.White;
            this.lblHome.Location = new System.Drawing.Point(221, 9);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(47, 23);
            this.lblHome.TabIndex = 1;
            this.lblHome.Text = "Home";
            this.lblHome.Click += new System.EventHandler(this.lblHome_Click);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(3, 9);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(36, 23);
            this.lblExit.TabIndex = 0;
            this.lblExit.Text = "Exit";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pbxBatlle);
            this.panel1.Controls.Add(this.pbxChat);
            this.panel1.Controls.Add(this.pbxArsenal);
            this.panel1.Controls.Add(this.pbxStore);
            this.panel1.Controls.Add(this.pbxHome);
            this.panel1.Controls.Add(this.pbxImgFundo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 559);
            this.panel1.TabIndex = 6;
            // 
            // pbxBatlle
            // 
            this.pbxBatlle.BackColor = System.Drawing.Color.Transparent;
            this.pbxBatlle.Location = new System.Drawing.Point(867, 457);
            this.pbxBatlle.Name = "pbxBatlle";
            this.pbxBatlle.Size = new System.Drawing.Size(128, 103);
            this.pbxBatlle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxBatlle.TabIndex = 5;
            this.pbxBatlle.TabStop = false;
            this.pbxBatlle.Click += new System.EventHandler(this.pbxBatlle_Click);
            // 
            // pbxChat
            // 
            this.pbxChat.BackColor = System.Drawing.Color.Transparent;
            this.pbxChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxChat.Location = new System.Drawing.Point(394, 420);
            this.pbxChat.Name = "pbxChat";
            this.pbxChat.Size = new System.Drawing.Size(75, 73);
            this.pbxChat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxChat.TabIndex = 4;
            this.pbxChat.TabStop = false;
            this.pbxChat.Click += new System.EventHandler(this.pbxChat_Click);
            // 
            // pbxArsenal
            // 
            this.pbxArsenal.BackColor = System.Drawing.Color.Transparent;
            this.pbxArsenal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxArsenal.Location = new System.Drawing.Point(184, 254);
            this.pbxArsenal.Name = "pbxArsenal";
            this.pbxArsenal.Size = new System.Drawing.Size(75, 73);
            this.pbxArsenal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxArsenal.TabIndex = 3;
            this.pbxArsenal.TabStop = false;
            this.pbxArsenal.Click += new System.EventHandler(this.pbxArsenal_Click);
            // 
            // pbxStore
            // 
            this.pbxStore.BackColor = System.Drawing.Color.Transparent;
            this.pbxStore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxStore.Location = new System.Drawing.Point(747, 290);
            this.pbxStore.Name = "pbxStore";
            this.pbxStore.Size = new System.Drawing.Size(75, 73);
            this.pbxStore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxStore.TabIndex = 2;
            this.pbxStore.TabStop = false;
            this.pbxStore.Click += new System.EventHandler(this.pbxStore_Click);
            // 
            // pbxHome
            // 
            this.pbxHome.BackColor = System.Drawing.Color.Transparent;
            this.pbxHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxHome.Location = new System.Drawing.Point(542, 272);
            this.pbxHome.Name = "pbxHome";
            this.pbxHome.Size = new System.Drawing.Size(75, 73);
            this.pbxHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxHome.TabIndex = 1;
            this.pbxHome.TabStop = false;
            this.pbxHome.Click += new System.EventHandler(this.pbxHome_Click);
            // 
            // pbxImgFundo
            // 
            this.pbxImgFundo.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbxImgFundo.Image = ((System.Drawing.Image)(resources.GetObject("pbxImgFundo.Image")));
            this.pbxImgFundo.Location = new System.Drawing.Point(0, -8);
            this.pbxImgFundo.Name = "pbxImgFundo";
            this.pbxImgFundo.Size = new System.Drawing.Size(998, 572);
            this.pbxImgFundo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImgFundo.TabIndex = 0;
            this.pbxImgFundo.TabStop = false;
            // 
            // GamePlayerForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(998, 598);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlUp);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GamePlayerForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlUp.ResumeLayout(false);
            this.pnlUp.PerformLayout();
            this.pnlSpc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSpectador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBatlle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArsenal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImgFundo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlUp;
        private System.Windows.Forms.PictureBox pbxUpDown;
        private System.Windows.Forms.Label lblSpectator;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblLocationBatlle;
        private System.Windows.Forms.Label lblLocaitionStore;
        private System.Windows.Forms.Label lblLocationChat;
        private System.Windows.Forms.Label lblLocationArsenal;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbxBatlle;
        private System.Windows.Forms.PictureBox pbxChat;
        private System.Windows.Forms.PictureBox pbxArsenal;
        private System.Windows.Forms.PictureBox pbxStore;
        private System.Windows.Forms.PictureBox pbxHome;
        private System.Windows.Forms.PictureBox pbxImgFundo;
        private System.Windows.Forms.Button div1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlSpc;
        private System.Windows.Forms.PictureBox pbxSpectador;
    }
}