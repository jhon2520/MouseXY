using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MouseXY
{
    public partial class VentanaInicial : Form
    {
        private Label labelX = new Label();
        private Label labelY = new Label();
        private int posX = Cursor.Position.X;
        private int posY = Cursor.Position.Y;
        private double witdhScreen = SystemParameters.FullPrimaryScreenWidth;
        private double heigthScreen = SystemParameters.FullPrimaryScreenHeight;
        private enum Localizaciones{izqArriba,derArriba,centro, izqAbajo,derAbajo }
        private Localizaciones localizaciones = Localizaciones.centro;
        private int labelXposX = ((int)SystemParameters.FullPrimaryScreenWidth / 2);
        private int labelXposY = ((int)SystemParameters.FullPrimaryScreenHeight / 2);
        private int labelYposX = (int)(SystemParameters.FullPrimaryScreenWidth / 2 + 65);
        private int labelYposY = (int)(SystemParameters.FullPrimaryScreenHeight / 2);
        private Form activeForm = null;


        public VentanaInicial()
        {
            InitializeComponent();
        }


        private void sumar(int a, int b)
        {
            System.Windows.Forms.MessageBox.Show((a + b).ToString());
        }

        private void sumar(int a, int b,int c)
        {
            System.Windows.Forms.MessageBox.Show((a + b +c).ToString());
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            this.labelX.Location = new Point(labelXposX, labelXposY);
            this.labelX.AutoSize = false;
            this.labelX.Size = new Size(65, 25);
            this.labelX.TextAlign = ContentAlignment.MiddleCenter;
            this.labelX.Text = "PosiciónX";
            this.labelX.ForeColor = Color.White;
            this.labelX.Font = new Font(FontFamily.GenericSansSerif, 18.0f, FontStyle.Bold);
            this.labelX.MouseMove += new MouseEventHandler(EventMouse); 
            
            this.labelY.Location = new Point(labelYposX, labelYposY);
            this.labelY.AutoSize = false;
            this.labelY.Size = new Size(65, 25);
            this.labelY.TextAlign = ContentAlignment.MiddleCenter;
            this.labelY.Text = "PosiciónY";
            this.labelY.ForeColor = Color.White;
            this.labelY.Font = new Font(FontFamily.GenericSansSerif, 18.0f, FontStyle.Bold);
            this.labelY.MouseMove += new MouseEventHandler(EventMouse); 


            Form formBG = new Form();
            formBG.StartPosition = FormStartPosition.Manual;
            formBG.FormBorderStyle = FormBorderStyle.None;
            formBG.Opacity = 0.55d;
            formBG.BackColor = Color.Black;
            formBG.WindowState = FormWindowState.Maximized;
            formBG.TopMost = true;
            formBG.Location = this.Location;
            formBG.ShowInTaskbar = true;
            formBG.MouseMove += new MouseEventHandler(EventMouse);
            formBG.MouseDown += new MouseEventHandler(ChancePosition);
            formBG.KeyDown += new KeyEventHandler(Cerrarform);
            formBG.MouseDown += new MouseEventHandler(CopiarAPortapales);
            formBG.Controls.Add(labelX);
            formBG.Controls.Add(labelY);
            activeForm = formBG;
            this.Visible = false;
            formBG.ShowDialog();
            this.Visible = true;


        }
        private void EventMouse(object sender, EventArgs args)
        {
            

            this.posX = Cursor.Position.X;
            this.posY = Cursor.Position.Y;
            this.labelX.Text = this.posX.ToString();
            this.labelY.Text = this.posY.ToString();

        }

        private void ChancePosition(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                switch (localizaciones)
                {
                    case Localizaciones.centro:
                        this.labelXposX = (20);
                        this.labelXposY = (20);
                        this.labelYposX = (85);
                        this.labelYposY = (20);
                        this.localizaciones = Localizaciones.izqArriba;
                        break;
                    case Localizaciones.izqArriba:
                        this.labelXposX = ((int)SystemParameters.FullPrimaryScreenWidth - 130);
                        this.labelXposY = (20);
                        this.labelYposX = ((int)SystemParameters.FullPrimaryScreenWidth - 65);
                        this.labelYposY = (20);
                        this.localizaciones = Localizaciones.derArriba;

                        break;
                    case Localizaciones.derArriba:
                        this.labelXposX = ((int)SystemParameters.FullPrimaryScreenWidth - 130);
                        this.labelXposY = ((int)SystemParameters.FullPrimaryScreenHeight - 20);
                        this.labelYposX = ((int)SystemParameters.FullPrimaryScreenWidth - 65);
                        this.labelYposY = ((int)SystemParameters.FullPrimaryScreenHeight - 20);
                        this.localizaciones = Localizaciones.derAbajo;
                        break;
                    case Localizaciones.derAbajo:
                        this.labelXposX = (20);
                        this.labelXposY = ((int)SystemParameters.FullPrimaryScreenHeight - 20);
                        this.labelYposX = (85);
                        this.labelYposY = ((int)SystemParameters.FullPrimaryScreenHeight - 20);
                        localizaciones = Localizaciones.izqAbajo;
                        break;
                    case Localizaciones.izqAbajo:
                        this.labelXposX = ((int)SystemParameters.FullPrimaryScreenWidth / 2);
                        this.labelXposY = ((int)SystemParameters.FullPrimaryScreenHeight / 2);
                        this.labelYposX = (int)(SystemParameters.FullPrimaryScreenWidth / 2 + 65);
                        this.labelYposY = (int)(SystemParameters.FullPrimaryScreenHeight / 2);
                        this.localizaciones = Localizaciones.centro;
                        break;
                    default:
                        break;
                }

                this.labelX.Location = new Point(labelXposX, labelXposY);
                this.labelY.Location = new Point(labelYposX, labelYposY);
            }

        }

        private void Cerrarform(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.X) || e.KeyCode == Keys.Escape) { activeForm.Close(); }
        }
        private void CopiarAPortapales(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    using (Aviso aviso = new Aviso())
                    {
                        Clipboard.SetText($"{this.labelX.Text},{this.labelY.Text}");
                        aviso.ShowDialog();

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.6;
        }

        private void pnlSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            this.Opacity = 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
