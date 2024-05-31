using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.ComponentModel.Design.Serialization;

namespace Registro
{
    public partial class Recepcionista : Form
    {
        public Recepcionista()
        {
            InitializeComponent();
            DisplayRec();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\serme\OneDrive\Documentos\ClinicaDb.mdf;Integrated Security=True;Connect Timeout=30");
        int key = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Boton Eliminar
        private void Eliminarbtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Seleccione al cliente");
            }
            else
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from recepcionistaTbl where RecepId=@RKey", Con);
                  
                    cmd.Parameters.AddWithValue("@RKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Recepcionista Eliminado");
                    Con.Close();
                    DisplayRec();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }

        private void DisplayRec()
        {
            Con.Open();
            string Query = "Select * from RecepcionistaTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);
          
            //CORREGIR ESTE ERROR EN LA TABLA
             //RecepcionistaDGV.DataSource ds.TABLES[0];
            Con.Close();
            DisplayRec();
        }

        //Boton Agregar
        private void Agregarbtn_Click(object sender, EventArgs e)
        {
            if (RNombreTb.Text == "" || RContraseña.Text == "" || RTelefonoTb.Text == "" || RAdddTb.Text == "")
            {
                MessageBox.Show("Falta de Información");
            }
            else
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into RecepcionistaTbl(RecepNombre,RecepTelefono,RecepAddd,RecepContraseña)values(@RN,@RT,@RA,@RC)", Con);
                    cmd.Parameters.AddWithValue("@RN", RNombreTb.Text);
                    cmd.Parameters.AddWithValue("@RT", RTelefonoTb.Text);
                    cmd.Parameters.AddWithValue("@RA", RAdddTb.Text);
                    cmd.Parameters.AddWithValue("@RC", RContraseña.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Recepcionista Añadido");
                    Con.Close();
                    DisplayRec();
                    Clear();
                } catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void Recepcionista_Load(object sender, EventArgs e)
        {

        }
        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RNombreTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            RTelefonoTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            RAdddTb.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            RContraseña.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            if (RNombreTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            }
        }

        //Este es el boton de editar
        private void button6_Click(object sender, EventArgs e)
        {
            if (RNombreTb.Text == "" || RContraseña.Text == "" || RTelefonoTb.Text == "" || RAdddTb.Text == "")
            {
                MessageBox.Show("Falta de Información");
            }
            else
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update RecepcionistaTbl set  RecepNombre=@RN,RecepTelefono=@RT,RecepAddd=@RA,RecepContraseña=@RC where RecepId=@RKey", Con);
                    cmd.Parameters.AddWithValue("@RN", RNombreTb.Text);
                    cmd.Parameters.AddWithValue("@RT", RTelefonoTb.Text);
                    cmd.Parameters.AddWithValue("@RA", RAdddTb.Text);
                    cmd.Parameters.AddWithValue("@RC", RContraseña.Text);
                    cmd.Parameters.AddWithValue("@RKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Recepcionista Actualizado");
                    Con.Close();
                    DisplayRec();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        private void Clear()
        {
            RNombreTb.Text = "";
            RContraseña.Text = "";
            RTelefonoTb.Text = "";
            RAdddTb.Text = "";
            Key = 0;
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }

    //int Key = 0;
   // private void RecepcionistaDGV_CellContentClick(objet sender, DataGridViewCellEventsArgs e)
    
       
        }
    





  

