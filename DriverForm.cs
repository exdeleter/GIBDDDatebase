namespace GIBDDDatebase
{
    public partial class DriverForm : Form
    {

        public DriverForm()
        {
            InitializeComponent();
        }

        internal void LoadDriver(string seriesNumber)
        {
            textBox1.Text = seriesNumber;
        }

        private void DriverForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            this.Hide();
        }
    }
}
