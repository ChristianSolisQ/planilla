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

namespace WorkShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ocultar la ventana actual
            this.Hide();
            //mostrar la otra ventana
            new Pagos().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'workShopDataSet8.empleado' Puede moverla o quitarla según sea necesario.
            this.empleadoTableAdapter3.Fill(this.workShopDataSet8.empleado);
            // TODO: esta línea de código carga datos en la tabla 'workShopDataSet4.empleado' Puede moverla o quitarla según sea necesario.
            this.empleadoTableAdapter2.Fill(this.workShopDataSet4.empleado);
            // TODO: esta línea de código carga datos en la tabla 'workShopDataSet3.empleado' Puede moverla o quitarla según sea necesario.
            this.empleadoTableAdapter1.Fill(this.workShopDataSet3.empleado);
            // TODO: esta línea de código carga datos en la tabla 'workShopDataSet.empleado' Puede moverla o quitarla según sea necesario.
            this.empleadoTableAdapter.Fill(this.workShopDataSet.empleado);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string querry = "insert into empleado(nombre,apellido,direccion,cargo) values(@nombre,@apellido,@direccion,@cargo)";
            SqlCommand cmd = new SqlCommand(querry, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("@apellido", textBox2.Text);
            cmd.Parameters.AddWithValue("@direccion", textBox3.Text);
            cmd.Parameters.AddWithValue("@cargo", textBox4.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("El empleado se ha guardado");
                UpdateDataGridView("select* from empleado", "empleado");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string querry = "delete from empleado where id_empleado=@id";
            SqlCommand cmd = new SqlCommand(querry, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", comboBox1.Text);
          
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("El empleado se ha eliminado");
                UpdateDataGridView("select* from empleado", "empleado");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string querry = "update  empleado set nombre=@nombre, apellido=@apellido, direccion=@direccion, cargo=@cargo where id_empleado=@id";
            SqlCommand cmd = new SqlCommand(querry, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@id", comboBox1.Text);
            cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
            cmd.Parameters.AddWithValue("@apellido", textBox2.Text);
            cmd.Parameters.AddWithValue("@direccion", textBox3.Text);
            cmd.Parameters.AddWithValue("@cargo", textBox4.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("El empleado se ha modificado");
                UpdateDataGridView("select* from empleado", "empleado");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateDataGridView(string querry,string tbl )
        {
            //hace la conexion y llena el dataset
            SqlDataAdapter ada = new SqlDataAdapter(querry, Conexion.Conectar());
            DataSet ds = new DataSet();
            //se llena con el nombre de la tabla
            ada.Fill(ds, tbl);
            //el datasource muestra el contenido
            dataGridView1.DataSource = ds;
            //la pone con el nombre de un atributo
            dataGridView1.DataMember = tbl;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string query = "Select * From empleado Where nombre Like '" + textBox5.Text + "%'";
            UpdateDataGridView(query, "empleado");
        }
    }
   
   
    }

