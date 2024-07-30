using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageManager
{
    public partial class Privatno : Form
    {
        public Privatno()
        {
            InitializeComponent();
        }

        private void Privatno_Load(object sender, EventArgs e)
        {

        }

        private void Privatno_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
