using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurumimClient
{
    public partial class GameLoadForms : Form
    {
        public GameLoadForms(int MaxValue)
        {
            InitializeComponent();
            this.progressBar.Maximum = MaxValue;
        }
        private delegate void SetDelegate(int value);
        private void GameLoadForms_Load(object sender, EventArgs e)
        {
            this.progressBar.Minimum = 0;
        }
        public void SetValueProgessBar(int value)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new SetDelegate(SetValueProgessBar), new object[] { value });
            }
            else
            {
                this.progressBar.Value = value;
            }
        }
    }
}
