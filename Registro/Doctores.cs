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
    public partial class Doctores : Form
    {
        public Doctores()
        {
            InitializeComponent();
            DisplayDoc();
            Clear();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\serme\OneDrive\Documentos\ClinicaDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayDoc()
        {
            Con.Open();
            string Query = "Select * from DoctorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DoctorsDGV.DataSource = ds.Tables[0];
            Con.Close();
            
        }
        private void Clear()
        {
            txtNombreDoc.Text = "";
            txtTel.Text = "";
            txtDireccionDoc.Text = "";
            txtExpDoc.Text = "";
            txtContrasenaDoc.Text= "";
            DocGenCb.SelectedIndex = 0;
            DocEspecCb.SelectedIndex = 0;
            Key = 0;
        }


        private void Doctores_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombreDoc.Text == "" || txtContrasenaDoc.Text == "" || txtTel.Text == "" || txtDireccionDoc.Text == "" || DocGenCb.SelectedIndex == -1 || DocEspecCb.SelectedIndex == -1)
            {
                MessageBox.Show("Falta de Información");
            }
            else
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into DoctorTbl(DocNombre,DOCDOB,DOCGEN,DOCSPEC,DOCEXP,DOCTEl,DOCADD,DOCPASS)values(@DN,@DD,@DG,@DS,@DE,@DT,@DA,@DPA)", Con);
                    cmd.Parameters.AddWithValue("@DN", txtNombreDoc.Text);
                    cmd.Parameters.AddWithValue("@DD", DOcDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@DG", DocGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DS", DocEspecCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DE", txtExpDoc.Text);
                    cmd.Parameters.AddWithValue("@DT", txtTel.Text);
                    cmd.Parameters.AddWithValue("@DA", txtDireccionDoc.Text);
                    cmd.Parameters.AddWithValue("@DPA", txtContrasenaDoc.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Añadido");
                    Con.Close();
                    DisplayDoc();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
        int Key = 0;
        private void DoctorsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombreDoc.Text = DoctorsDGV.SelectedRows[0].Cells[1].Value.ToString();
            DOcDOB.Text = DoctorsDGV.SelectedRows[0].Cells[2].Value.ToString();
            DocGenCb.SelectedItem = DoctorsDGV.SelectedRows[0].Cells[3].Value.ToString();
            DocEspecCb.SelectedItem = DoctorsDGV.SelectedRows[0].Cells[4].Value.ToString();
            txtExpDoc.Text = DoctorsDGV.SelectedRows[0].Cells[5].Value.ToString();
            txtTel.Text = DoctorsDGV.SelectedRows[0].Cells[6].Value.ToString();
            txtDireccionDoc.Text = DoctorsDGV.SelectedRows[0].Cells[7].Value.ToString();
            txtContrasenaDoc.Text = DoctorsDGV.SelectedRows[0].Cells[8].Value.ToString();
            if (txtNombreDoc.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DoctorsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNombreDoc.Text == "" || txtContrasenaDoc.Text == "" || txtTel.Text == "" || txtDireccionDoc.Text == "" || DocGenCb.SelectedIndex == -1 || DocEspecCb.SelectedIndex == -1)
            {
                MessageBox.Show("Falta de Información");
            }
            else
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update DoctorTbl set DocNombre=@DN,DOCDOB=@DD,DOCGEN=@DG,DOCSPEC=@DS,DOCEXP=@DE,DOCTEl=@DT,DOCADD=@DA,DOCPASS=@DPA where DOCId=@DKey", Con);
                    cmd.Parameters.AddWithValue("@DN", txtNombreDoc.Text);
                    cmd.Parameters.AddWithValue("@DD", DOcDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@DG", DocGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DS", DocEspecCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DE", txtExpDoc.Text);
                    cmd.Parameters.AddWithValue("@DT", txtTel.Text);
                    cmd.Parameters.AddWithValue("@DA", txtDireccionDoc.Text);
                    cmd.Parameters.AddWithValue("@DPA", txtContrasenaDoc.Text);
                    cmd.Parameters.AddWithValue("@DKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Editado");
                    Con.Close();
                    DisplayDoc();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Seleccione al Doctor");
            }
            else
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from DoctorTbl where DocId=@DKey", Con);

                    cmd.Parameters.AddWithValue("@DKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Eliminado");
                    Con.Close();
                    DisplayDoc();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }
    }
}
