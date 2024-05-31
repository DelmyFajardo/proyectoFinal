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
    public partial class Pacientes : Form
    {
        public Pacientes()
        {
            InitializeComponent();
            DisplayPac();
        }

        private void Pacientes_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //Boton Editar
        private void button6_Click(object sender, EventArgs e)
        {
            if (txtNombrePaciente.Text == "" || txtTelPaciente.Text == "" || txtDireccionPaciente.Text == "" || GeneroPacienteCb.SelectedIndex == -1 || VIHPacienteCb.SelectedIndex == -1)
            {
                MessageBox.Show("Falta de Información");
            }
            else
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update PacienteTbl set PacienteNombre==@PN,PacienteGenero=@PG,PacienteFechadeNacimiento=@PFN,PacienteDireccion=@PD,PacienteTelefono=@PT,PacienteHIV=@PH,PacAll=@PA where PacId=@PKey", Con);
                    cmd.Parameters.AddWithValue("@DPN", txtNombrePaciente.Text);
                    cmd.Parameters.AddWithValue("@PG", GeneroPacienteCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PFN", PacDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@PD", txtDireccionPaciente.Text);
                    cmd.Parameters.AddWithValue("@PT", txtTelPaciente.Text);
                    cmd.Parameters.AddWithValue("@PH", VIHPacienteCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PA", txtAlergiasPaciente.Text);
                    cmd.Parameters.AddWithValue("@PKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paciente Editado");
                    Con.Close();
                    DisplayPac();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\serme\OneDrive\Documentos\ClinicaDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayPac()
        {
            Con.Open();
            string Query = "Select * from PacientesTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PacientesDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        int Key = 0;
        private void Clear()
        {
            txtNombrePaciente.Text = "";
            txtTelPaciente.Text = "";
            txtDireccionPaciente.Text = "";
            txtAlergiasPaciente.Text = "";
            GeneroPacienteCb.SelectedIndex = 0;
            VIHPacienteCb.SelectedIndex = 0;
            Key = 0;
        }

        private void btnAgregarPac_Click(object sender, EventArgs e)
        {
            if (txtNombrePaciente.Text == "" || txtTelPaciente.Text == "" || txtDireccionPaciente.Text == "" || GeneroPacienteCb.SelectedIndex == -1 || VIHPacienteCb.SelectedIndex == -1)
            {
                MessageBox.Show("Falta de Información");
            }
            else
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into PacienteTbl(PacienteNombre,PacienteGenero,PacienteFechadeNacimiento,PacienteDireccion,PacienteTelefono,PacienteHIV,PacAll)values(@PN,@PG,@PFN,@PD,@PT,@PH,@PA)", Con);
                    cmd.Parameters.AddWithValue("@DPN", txtNombrePaciente.Text);
                    cmd.Parameters.AddWithValue("@PG", GeneroPacienteCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PFN", PacDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@PD", txtDireccionPaciente.Text);
                    cmd.Parameters.AddWithValue("@PT", txtTelPaciente.Text);
                    cmd.Parameters.AddWithValue("@PH", VIHPacienteCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PA", txtAlergiasPaciente.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paciente Añadido");
                    Con.Close();
                    DisplayPac();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }

        private void PacientesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombrePaciente.Text = PacientesDGV.SelectedRows[0].Cells[1].Value.ToString();
            GeneroPacienteCb.SelectedItem = PacientesDGV.SelectedRows[0].Cells[2].Value.ToString();
            PacDOB.Text = PacientesDGV.SelectedRows[0].Cells[3].Value.ToString();
            txtDireccionPaciente.Text = PacientesDGV.SelectedRows[0].Cells[4].Value.ToString();
            txtTelPaciente.Text = PacientesDGV.SelectedRows[0].Cells[5].Value.ToString();
            VIHPacienteCb.SelectedItem = PacientesDGV.SelectedRows[0].Cells[6].Value.ToString();
            txtAlergiasPaciente.Text = PacientesDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (txtNombrePaciente.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PacientesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void btnEliminarPac_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Seleccione al Paciente");
            }
            else
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from PacientesTbl where PacId=@PKey", Con);

                    cmd.Parameters.AddWithValue("@PKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paciente Eliminado");
                    Con.Close();
                    DisplayPac();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Iniciodesesion obj = new Iniciodesesion();
            obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
