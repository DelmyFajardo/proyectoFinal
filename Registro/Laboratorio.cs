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
    public partial class Laboratorio : Form
    {
        public Laboratorio()
        {
            InitializeComponent();
            DisplayTest();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\serme\OneDrive\Documentos\ClinicaDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayTest()
        {
            Con.Open();
            string Query = "Select * from TestTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            LabDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        int Key = 0;
        private void Clear()
        {
            txtNombreExamen.Text = "";
            txtCostoExam.Text = "";
            
            Key = 0;
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        

        private void btnAggExam_Click(object sender, EventArgs e)
        {
            if (txtCostoExam.Text == "" || txtNombreExamen.Text == "")
            {
                MessageBox.Show("Falta de Información");
            }
            else
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into TestTbl(TestNombre,TestCosto)values(@TN,@TC)", Con);
                    cmd.Parameters.AddWithValue("@TN", txtNombreExamen.Text);
                    cmd.Parameters.AddWithValue("@TC", txtCostoExam.Text);
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Examen Añadido");
                    Con.Close();
                    DisplayTest();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LabDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreExamen.Text = LabDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtCostoExam.Text = LabDGV.SelectedRows[0].Cells[2].Value.ToString();
    
            if (txtNombreExamen.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(LabDGV.SelectedRows[0].Cells[1].Value.ToString());
            }
        }

        private void btnEditExam_Click(object sender, EventArgs e)
        {
            if (txtCostoExam.Text == "" || txtNombreExamen.Text == "")
            {
                MessageBox.Show("Falta de Información");
            }
            else
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update TestTbl set TestNombre=@TN,TestCosto=@TC where TestNum@TKey", Con);
                    cmd.Parameters.AddWithValue("@TN", txtNombreExamen.Text);
                    cmd.Parameters.AddWithValue("@TC", txtCostoExam.Text);
                    cmd.Parameters.AddWithValue("@TKey", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Examen Editado");
                    Con.Close();
                    DisplayTest();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }

        private void btnElimExam_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Seleccione el Examen");
            }
            else
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from TestTbl where TestNum=@TKey", Con);

                    cmd.Parameters.AddWithValue("@TKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Examen Eliminado");
                    Con.Close();
                    DisplayTest();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Iniciodesesion obj = new Iniciodesesion();
            obj.Show();
            this.Hide();
        }
    }
}
