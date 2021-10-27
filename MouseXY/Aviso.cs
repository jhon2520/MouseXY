using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseXY
{
    public partial class Aviso : Form
    {

        private int contador = 0;
        public Aviso()
        {
            InitializeComponent();
        }

        private void Aviso_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.Icon = Properties.Resources.raven1;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contador++;
            if(contador == 1)
            {
                this.Close();
            }
        }
    }
}
