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
    public partial class Prescripciones : Form
    {
        public Prescripciones()
        {
            InitializeComponent();
            DisplayPrescripcione();
            GetDoctorId();
            GetPacienteId();
            GetTest();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\serme\OneDrive\Documentos\ClinicaDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayPrescripcione()
        {
            Con.Open();
            string Query = "Select * from PrescripcionTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PrescripcionesDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
         private void Clear()
        {
            DoctorIdCb.SelectedIndex = 0;
            PacienteIdCb.SelectedIndex = 0;
            TestIdCb.SelectedIndex = 0;
            CostoTb.Text = "";
            MedicamentosTb.Text = "";
            NombreDoctorTB.Text = "";
            NombrePacienteTb.Text = "";
            NombrePruebaTb.Text = "";
            
        }

        private void GetNombreDoctor()
        {
            Con.Open();
            string Query = "Select * from DoctorTbl where DoctorId= " + DoctorIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                NombreDoctorTB.Text = dr["NombreDoctor"].ToString();
            } 

            Con.Close();

        }

        private void GetNombrePaciente()
        {
            Con.Open();
            string Query = "Select * from PacientesTbl where PacienteId= " + PacienteIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                NombrePacienteTb.Text = dr["NombrePaciente"].ToString();
            }

            Con.Close();

        }

        private void GetNombreTest()
        {
            Con.Open();
            string Query = "Select * from TestTbl where TestNum= " + TestIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                NombrePruebaTb.Text = dr["NombreTest"].ToString();
                CostoTb.Text= dr["TestCost"].ToString();
              
            }

            Con.Close();

        }

        private void GetDoctorId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select  DoctorId from DoctorTbl", Con);
            SqlDataReader rdr;
            rdr=cmd.ExecuteReader();
            DataTable dt= new DataTable();
            dt.Columns.Add("DoctorId", typeof(int));
            dt.Load(rdr);
            DoctorIdCb.ValueMember = "DoctorId";
            DoctorIdCb.DataSource = dt;
            Con.Close();

        }

        private void GetPacienteId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select  PacienteId from PacienteTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PacienteId", typeof(int));
            dt.Load(rdr);
            PacienteIdCb.ValueMember = "PacienteId";
            PacienteIdCb.DataSource = dt;
            Con.Close();
        }

        private void GetTest()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select  TestNum from TestTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TestNum", typeof(int));
            dt.Load(rdr);
            TestIdCb.ValueMember = "TestNum";
            TestIdCb.DataSource = dt;
            Con.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DoctorIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetNombreDoctor();
        }

        private void PacienteIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNombrePaciente();
        }

        private void TestIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetTest();
        }

        private void DisplayPrescripciones()
        {
            Con.Open();
            string Query = "Select * from TestTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PrescripcionesDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        int Key = 0;


        private void button4_Click(object sender, EventArgs e)
        {
            
                if (NombrePacienteTb.Text == "" || NombreDoctorTB.Text == "" || NombrePruebaTb.Text == "" )
                {
                    MessageBox.Show("Falta de Información");
                }
                else
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("Insert into PrescripcionTbl(DoctorId,NombreDoctor,PacienteId,NombrePaciente,LabTestId,LabTestNombre,Medicamentos,Costo)values(@OI,@ON,@PI,@PN,@TI,@TN,@Med,@Co)", Con);
                        cmd.Parameters.AddWithValue("@OI", DoctorIdCb.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@ON", NombreDoctorTB.Text);
                        cmd.Parameters.AddWithValue("@PI", PacienteIdCb.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@PN", NombrePacienteTb.Text);
                        cmd.Parameters.AddWithValue("@TI", TestIdCb.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@TN", NombrePruebaTb.Text);
                        cmd.Parameters.AddWithValue("@Med", MedicamentosTb.Text);
                        cmd.Parameters.AddWithValue("@Co",  CostoTb.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Prescripcion añadida");
                        Con.Close();
                        DisplayPrescripciones();
                        Clear();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
            

        }

        private void PrescripcionesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // PresTxt.Text = PrescripcionesDGV.SelectedRows[0].Cells[2].Value.ToString();
            PresTxt.Text = "";
            PresTxt.Text=" Sistema de Registro Medico\n\n"+" PRESCRIPCION "+ "\n***************************************************************"+"\n"+DateTime.Today.Date+"\n\n\n\n  Medicina:" +  PrescripcionesDGV.SelectedRows[0].Cells[2].Value.ToString() + "\n\n\n\n Sistema de Registro ";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(PresTxt.Text + "\n", new Font("Averia", 18, FontStyle.Regular), Brushes.Black, new Point(95, 80));
            e.Graphics.DrawString ("\n\t " + "Gracias", new Font("Averia", 15, FontStyle.Bold), Brushes.Red, new Point(200, 300));
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Iniciodesesion obj = new Iniciodesesion();
            obj.Show();
            this.Hide();
        }
    }
}
