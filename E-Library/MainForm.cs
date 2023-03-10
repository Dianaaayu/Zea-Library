using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace E_Library
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            openfd.Filter = "Image Files(*.jpg;*.jpeg;*.gif;) | *.jpg;*.jpeg;*.gif;";
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                imageText.Text = openfd.FileName;
                pictureBox1.Image = new Bitmap(openfd.FileName);
                pictureBox1.ImageLocation = openfd.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost; user id=root; database=perpus";
            string query = "INSERT INTO tbl_produk(kode_buku,judul_buku,harga_buku,stok_buku,IMAGE)VALUES('" + this.KODEBUKU.Text + "','" + this.JUDULBUKU.Text + "','" + this.HARGABUKU.Text + "','" + this.STOKBUKU.Text + "','" + Path.GetFileName(pictureBox1.ImageLocation) + "')";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data berhasil disimpan");
            conn.Close();
            File.Copy(imageText.Text, Application.StartupPath + @"\Image\" + Path.GetFileName(pictureBox1.ImageLocation));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost; user id=root; database=perpus";
            string query = "DELETE FROM tbl_produk WHERE kode_buku='" + this.KODEBUKU.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data berhasil dihapus");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost; user id=root; database=perpus";
            string query = "UPDATE tbl_produk SET judul_buku='" + this.JUDULBUKU.Text + "',harga_buku='" + this.HARGABUKU.Text + "',stok_buku='" + this.STOKBUKU.Text + "' WHERE kode_buku='" + this.KODEBUKU.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data berhasil diubah");
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost; user id=root; database=perpus";
            string query = "SELECT * FROM tbl_produk";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("PICTURE", Type.GetType("System.Byte[]"));

            foreach (DataRow row in dt.Rows)
            {
                row["PICTURE"] = File.ReadAllBytes(Application.StartupPath + @"\Image\" + Path.GetFileName(row["IMAGE"].ToString()));
            }

            dataGridView1.DataSource = dt;
        }
    }
}
