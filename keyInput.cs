using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrowserPrivateModeSwitcher
{
    public partial class keyInput : Form
    {
        public keyInput()
        {
            this.InitializeComponent();
        }

        public void SetText(int text)
        {
            if (text < 0 || text >= 10000)
            {
                throw new ArgumentOutOfRangeException(nameof(text), "The argument named of \"text\" is out of range. It must be from 0 to 9999");
            }
            this.maskedTextBox1.Text = text.ToString();
        }

        public int GetText()
        {
            return int.Parse(this.maskedTextBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
