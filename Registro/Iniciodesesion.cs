using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro
{
    public partial class Iniciodesesion : Form
    {
        public Iniciodesesion()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RolCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RolCb.SelectedIndex = 0;
            UsuarioTb.Text = "";
            ContrasenaTb.Text = " ";
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\serme\OneDrive\Documentos\ClinicaDb.mdf;Integrated Security=True;Connect Timeout=30");
        public static string Role;

        private void AccesoBtn_Click(object sender, EventArgs e)
        {
            if (RolCb.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona tu posicion");
            }
            else if (RolCb.SelectedIndex == 0)
            {
                if (UsuarioTb.Text == "" || ContrasenaTb.Text == "")
                {
                    MessageBox.Show("Ingrese su Nombre y contraseña");
                }
                else if (UsuarioTb.Text == "Admin" && ContrasenaTb.Text == "Pass")
                {
                    Role = "Admin";
                    Pacientes obj = new Pacientes();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Los datos que ingreso son incorrectos.");
                }
            }
            else if (RolCb.SelectedIndex == 1)
            {
                if (UsuarioTb.Text == "" || ContrasenaTb.Text == "")
                {
                    MessageBox.Show("Ingrese su Nombre y contraseña");
                }
                else if (UsuarioTb.Text == "Doctor" && ContrasenaTb.Text == "Pass")
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select Count (*) from DoctorTbl where DocNombre='" + UsuarioTb.Text + "' and DocContraseña='" + ContrasenaTb.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Role = "Doctor";
                        Prescripciones obj = new Prescripciones();
                        obj.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Doctor no encontrado");
                    }
                    Con.Close();

                }
            }
            else
            {

                if (UsuarioTb.Text == "" || ContrasenaTb.Text == "")
                {
                    MessageBox.Show("Ingrese su Nombre y contraseña");
                }
                else if (UsuarioTb.Text == "Recepcionista" && ContrasenaTb.Text == "Pass")
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select Count (*) from RecepcionistaTbl where RecepNombre ='" + UsuarioTb.Text + "' and RecepContraseña='" + ContrasenaTb.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Role = "Doctor";
                        Form2 obj = new Form2();
                        obj.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Recepcionista  no encontrada");
                    }
                    Con.Close();

                }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}


