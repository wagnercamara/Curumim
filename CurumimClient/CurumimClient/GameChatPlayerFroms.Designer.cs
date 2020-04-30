namespace CurumimGameForms
{
    partial class GameChatPlayerFroms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameChatPlayerFroms));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pbxLeft = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnBax = new System.Windows.Forms.Button();
            this.rbxMessage = new System.Windows.Forms.RichTextBox();
            this.pbxSend = new System.Windows.Forms.PictureBox();
            this.pbxClouse = new System.Windows.Forms.PictureBox();
            this.rbxHitory = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLeft)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClouse)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlLeft.Controls.Add(this.pbxLeft);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLeft.Location = new System.Drawing.Point(749, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(51, 526);
            this.pnlLeft.TabIndex = 1;
            // 
            // pbxLeft
            // 
            this.pbxLeft.Image = ((System.Drawing.Image)(resources.GetObject("pbxLeft.Image")));
            this.pbxLeft.Location = new System.Drawing.Point(3, 3);
            this.pbxLeft.Name = "pbxLeft";
            this.pbxLeft.Size = new System.Drawing.Size(48, 40);
            this.pbxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLeft.TabIndex = 1;
            this.pbxLeft.TabStop = false;
            this.pbxLeft.Click += new System.EventHandler(this.pbxLeft_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlBase);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 526);
            this.panel1.TabIndex = 2;
            // 
            // pnlBase
            // 
            this.pnlBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pnlBase.Controls.Add(this.btnUp);
            this.pnlBase.Controls.Add(this.btnBax);
            this.pnlBase.Controls.Add(this.rbxMessage);
            this.pnlBase.Controls.Add(this.pbxSend);
            this.pnlBase.Controls.Add(this.pbxClouse);
            this.pnlBase.Controls.Add(this.rbxHitory);
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.ForeColor = System.Drawing.Color.White;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(749, 526);
            this.pnlBase.TabIndex = 3;
            // 
            // btnUp
            // 
            this.btnUp.Enabled = false;
            this.btnUp.Location = new System.Drawing.Point(6, 456);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(737, 3);
            this.btnUp.TabIndex = 5;
            this.btnUp.Text = "button2";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnBax
            // 
            this.btnBax.Enabled = false;
            this.btnBax.Location = new System.Drawing.Point(6, 520);
            this.btnBax.Name = "btnBax";
            this.btnBax.Size = new System.Drawing.Size(737, 3);
            this.btnBax.TabIndex = 4;
            this.btnBax.Text = "button1";
            this.btnBax.UseVisualStyleBackColor = true;
            // 
            // rbxMessage
            // 
            this.rbxMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.rbxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rbxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxMessage.ForeColor = System.Drawing.Color.White;
            this.rbxMessage.Location = new System.Drawing.Point(6, 465);
            this.rbxMessage.Name = "rbxMessage";
            this.rbxMessage.Size = new System.Drawing.Size(664, 49);
            this.rbxMessage.TabIndex = 3;
            this.rbxMessage.Text = "";
            this.rbxMessage.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // pbxSend
            // 
            this.pbxSend.Image = ((System.Drawing.Image)(resources.GetObject("pbxSend.Image")));
            this.pbxSend.Location = new System.Drawing.Point(676, 465);
            this.pbxSend.Name = "pbxSend";
            this.pbxSend.Size = new System.Drawing.Size(67, 49);
            this.pbxSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxSend.TabIndex = 2;
            this.pbxSend.TabStop = false;
            this.pbxSend.Click += new System.EventHandler(this.pbxSend_Click);
            // 
            // pbxClouse
            // 
            this.pbxClouse.Image = ((System.Drawing.Image)(resources.GetObject("pbxClouse.Image")));
            this.pbxClouse.Location = new System.Drawing.Point(0, 0);
            this.pbxClouse.Name = "pbxClouse";
            this.pbxClouse.Size = new System.Drawing.Size(48, 40);
            this.pbxClouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxClouse.TabIndex = 0;
            this.pbxClouse.TabStop = false;
            this.pbxClouse.Click += new System.EventHandler(this.pbxClouse_Click);
            // 
            // rbxHitory
            // 
            this.rbxHitory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.rbxHitory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rbxHitory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbxHitory.ForeColor = System.Drawing.Color.White;
            this.rbxHitory.Location = new System.Drawing.Point(6, 43);
            this.rbxHitory.Name = "rbxHitory";
            this.rbxHitory.ReadOnly = true;
            this.rbxHitory.Size = new System.Drawing.Size(737, 407);
            this.rbxHitory.TabIndex = 0;
            this.rbxHitory.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(132, 86);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // GameChatPlayerFroms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 526);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameChatPlayerFroms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLeft)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClouse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.PictureBox pbxSend;
        private System.Windows.Forms.PictureBox pbxClouse;
        private System.Windows.Forms.RichTextBox rbxHitory;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pbxLeft;
        private System.Windows.Forms.RichTextBox rbxMessage;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnBax;
    }
}