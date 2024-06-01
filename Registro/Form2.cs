using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            if (Iniciodesesion.Role == "Recepcionista")
            {
                RecepcionistaLbl.Enabled = false;
                DoctorLbl.Enabled = false;
                laboratoriolbl.Enabled = false;

            }
            ContarPacientes();
            ContarDoctoress();
            ContarPrueba();
            ContarVIH();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\serme\OneDrive\Documentos\ClinicaDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void ContarPacientes()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count (*) from PacienteTbl ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PatNumlbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void ContarVIH()
        {
            string Status = "Positivo";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count (*) from PacienteTbl where  PacienteHIV='"+Status +'"', Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            VIHlbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void ContarDoctoress()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from DoctorTbl ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DocNumlbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void ContarPrueba()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count (*) from TestTbl ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            LabTestlbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PacientesLbl_Click(object sender, EventArgs e)
        {
            Pacientes obj = new Pacientes();
            obj.Show();
            this.Hide();
        }

        private void DoctorLbl_Click(object sender, EventArgs e)
        {
            Doctores obj = new Doctores();
            obj.Show();
            this.Hide();
        }

        private void laboratoriolbl_Click(object sender, EventArgs e)
        {
            Laboratorio obj = new Laboratorio();
            obj.Show();
            this.Hide();
        }

        private void RecepcionistaLbl_Click(object sender, EventArgs e)
        {
            Recepcionista obj = new Recepcionista();
            obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Iniciodesesion obj = new Iniciodesesion();
            obj.Show();
            this.Hide();
        }
    }
}
