using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.PowerPacks;
using System.Windows.Forms;

namespace Eventick
{
    public partial class FrmActPpal : Form
    {
        Image favoritovacio = Image.FromFile(@"..\..\Iconos\corazonvacio.png");
        Image favoritolleno = Image.FromFile(@"..\..\Iconos\corazonrojo.png");
        public FrmActPpal()
        {
            InitializeComponent();
            cbbTipo.SelectedIndex = 0;
            cbbTiempo.SelectedIndex = 0;
            cbbDificultad.SelectedIndex = 0;
            picMaximizar.Image = Image.FromFile(@"..\..\Iconos\maximizar2.png");
            lblDistancia.Text = trbDistancia.Value.ToString() + " km";

            txtPalabraClave.Text = "PALABRA CLAVE";
            txtPalabraClave.Font = new Font(txtPalabraClave.Font, FontStyle.Bold);
            txtPalabraClave.ForeColor = Color.Gray;

            txtLocalidad.Text = "LOCALIDAD";
            txtLocalidad.Font = new Font(txtLocalidad.Font, FontStyle.Bold);
            txtLocalidad.ForeColor = Color.Gray;


            btnActividad.BackColor = colorBotonesActivos;
            btnEvento.BackColor = Color.Transparent;


        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                picMaximizar.Image = Image.FromFile(@"..\..\Iconos\maximizar2.png");
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                picMaximizar.Image = Image.FromFile(@"..\..\Iconos\maximizar.png");

                this.WindowState = FormWindowState.Normal;
            }
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
        }

        private bool mouseDown;
        private Point lastLocation;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // By using Sender, one method could handle multiple ComboBoxes
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                // Always draw the background
                e.DrawBackground();

                // Drawing one of the items?
                if (e.Index >= 0)
                {
                    // Set the string alignment.  Choices are Center, Near and Far
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    // Set the Brush to ComboBox ForeColor to maintain any ComboBox color settings
                    // Assumes Brush is solid
                    Brush brush = new SolidBrush(cbx.ForeColor);

                    // If drawing highlighted selection, change brush
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    // Draw the string
                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }

        private void toggPruebaPaneles_CheckedChanged(object sender, EventArgs e)
        {
            Panel panelNoticia = new Panel() { Name = "panelNoticia", BackColor = Color.Transparent, Size = new Size(850, 145) };
            flpNoticias.Controls.Add(panelNoticia);
            PictureBox picNoticia = new PictureBox() { Name = "picNoticia", Image = Image.FromFile(@"..\..\Iconos\yo.jpg"), Size = new Size(241, 135), SizeMode = PictureBoxSizeMode.Normal };
            panelNoticia.Controls.Add(picNoticia);
            LinkLabel llblTitulo = new LinkLabel() { Name="llblTitulo", Location= new Point(261, 2), Text="Hola" };
            panelNoticia.Controls.Add(llblTitulo);
            Label lblLocalidad = new Label() { Name="lblLocalidad", Location= new Point(264, 24), Text="Casa", Font=new Font("Microsoft Sans Serif", 12,FontStyle.Bold) };
            panelNoticia.Controls.Add(lblLocalidad);
            Panel panelInfo = new Panel() { Name="panelInfo", BackColor=Color.Transparent,Size = new Size(588, 25), Location=new Point(276, 46) };
            panelNoticia.Controls.Add(panelInfo);
            Label lblInfo1 = new Label() { Name = "lblInfo1", AutoSize=true, Dock = DockStyle.Left, Text = "466m" };
            panelInfo.Controls.Add(lblInfo1);
            Label lblInfo2 = new Label() { Name = "lblInfo2", AutoSize = true, Dock = DockStyle.Left, Text = "|" };
            panelInfo.Controls.Add(lblInfo2);
            Label lblInfo3 = new Label() { Name = "lblInfo3", AutoSize = true, Dock = DockStyle.Left, Text = "Circular" };
            panelInfo.Controls.Add(lblInfo3);
            Label lblInfo4 = new Label() { Name = "lblInfo4", AutoSize = true, Dock = DockStyle.Left, Text = "|" };
            panelInfo.Controls.Add(lblInfo4);
            Label lblInfo5 = new Label() { Name = "lblInfo5", AutoSize = true, Dock = DockStyle.Left, Text = "Media" };
            panelInfo.Controls.Add(lblInfo5);
            Label lblInfo6 = new Label() { Name = "lblInfo6", AutoSize = true, Dock = DockStyle.Left, Text = "|" };
            panelInfo.Controls.Add(lblInfo6);
            Label lblInfo7 = new Label() { Name = "lblInfo7", AutoSize = true, Dock = DockStyle.Left, Text = "4h" };
            panelInfo.Controls.Add(lblInfo7);
            Label lblInfo8 = new Label() { Name = "lblInfo8", AutoSize = true, Dock = DockStyle.Left, Text = "|" };
            panelInfo.Controls.Add(lblInfo8);
            Label lblInfo9 = new Label() { Name = "lblInfo9", AutoSize = true, Dock = DockStyle.Left, Text = "12 km" };
            panelInfo.Controls.Add(lblInfo9);
            PictureBox picFavorito = new PictureBox() { Name = "picFavorito", Cursor=Cursors.Hand, Image = favoritovacio, Size = new Size(35, 35), Location = new Point(261, 100), SizeMode = PictureBoxSizeMode.Zoom };
            panelNoticia.Controls.Add(picFavorito);
            PictureBox picCompartir = new PictureBox() { Name="picCompartir", Image=Image.FromFile(@"..\..\Iconos\compartir.png"),Size=new Size(35,35), Location= new Point(300,100), SizeMode = PictureBoxSizeMode.Zoom };
            panelNoticia.Controls.Add(picCompartir);
            picFavorito.Click += new EventHandler(picFavorito_Click);
            
        }

        Color colorBotonesActivos = Color.FromArgb(230, 240, 229);
        private void btnActividad_Click(object sender, EventArgs e)
        {
            if (btnActividad.BackColor == Color.Transparent && btnEvento.BackColor == colorBotonesActivos)
            {
                btnActividad.BackColor = Color.FromArgb(230, 240, 229);
                btnEvento.BackColor = Color.Transparent;
            }
        }

        private void picFavorito_Click(object sender, EventArgs e)
        {
            PictureBox picFavorito = sender as PictureBox;
            
            if (picFavorito.Image == favoritovacio)
            {
                picFavorito.Image = favoritolleno;
            }
            else
            {
                picFavorito.Image = favoritovacio;
            }
        }


        private void btnEvento_Click(object sender, EventArgs e)
        {
            if (btnEvento.BackColor == Color.Transparent && btnActividad.BackColor == colorBotonesActivos)
            {
                btnEvento.BackColor = Color.FromArgb(230, 240, 229);
                btnActividad.BackColor = Color.Transparent;
            }
        }

        private void trbDistancia_Scroll(object sender, EventArgs e)
        {
            lblDistancia.Text = trbDistancia.Value.ToString() + " km";
        }

        private void txtPalabraClave_Enter(object sender, EventArgs e)
        {
            if(txtPalabraClave.Text=="PALABRA CLAVE")
            {
                txtPalabraClave.Text = "";
                txtPalabraClave.ForeColor = default;
                txtPalabraClave.Font = new Font(txtPalabraClave.Font, FontStyle.Regular);
            }
        }

        private void txtPalabraClave_Leave(object sender, EventArgs e)
        {
            if (txtPalabraClave.Text == "")
            {
                txtPalabraClave.Text = "PALABRA CLAVE";
                txtPalabraClave.Font = new Font(txtPalabraClave.Font, FontStyle.Bold);

                txtPalabraClave.ForeColor = Color.Gray;

            }
        }

        private void txtLocalidad_Enter(object sender, EventArgs e)
        {
            if (txtLocalidad.Text == "LOCALIDAD")
            {
                txtLocalidad.Text = "";
                txtLocalidad.ForeColor = default;
                txtLocalidad.Font = new Font(txtLocalidad.Font, FontStyle.Regular);

            }
        }

        private void txtLocalidad_Leave(object sender, EventArgs e)
        {
            if (txtLocalidad.Text == "")
            {
                txtLocalidad.Text = "LOCALIDAD";
                txtLocalidad.Font = new Font(txtLocalidad.Font, FontStyle.Bold);
                txtLocalidad.ForeColor = Color.Gray;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picUser_Click(object sender, EventArgs e)
        {
            panelUser.Visible = !panelUser.Visible;
        }

    }
}
