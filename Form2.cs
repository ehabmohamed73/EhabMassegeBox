using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EhabMessage
{
    public partial class Form2 : Form
    {
       
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            EhabMessageBox.Show("heeey","Ehab",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Error,MessageBoxDefaultButton.Button2);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            EhabMessageBox.Show("مرحبا   dsg agfsdfgsdgfdh estrey gggggggfdgfh " +
                "fgjfgjfjjjjjjjjjjjjjdgfjerthngfurtg",MessageBoxIcon.Question);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            EhabMessageBox.Show("لعبه الفمار", "لقد فزت",MessageBoxIcon.Warning);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            EhabMessageBox.Show("dsjbf", MessageBoxButtons.AbortRetryIgnore,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            EhabMessageBox.Show("text olay", MessageBoxIcon.Warning);
        }
    }
}
