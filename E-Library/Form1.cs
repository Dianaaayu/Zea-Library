namespace E_Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "admin" && password.Text == "admin")
            {
                new MainForm().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Username Atau Password Kamu Salah :)");
                username.Clear();
                password.Clear();
                username.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}