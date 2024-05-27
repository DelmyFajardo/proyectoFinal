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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Eliminarbtn_Click(object sender, EventArgs e)
        {

        }

        private void DisplayRec()
        {
            Con.Open();
            string Query = "Select * from RecepcionistaTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);

            //CORREGIR ESTE ERROR EN LA TABLA
             //RecepcionistaDGV.DataSource ds.TABLES[0];
            Con.Close();
        }
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
                } catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }

    //int Key = 0;
   // private void RecepcionistaDGV_CellContentClick(objet sender, DataGridViewCellEventsArgs e)
    
       
        }
    





  

