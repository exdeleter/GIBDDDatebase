using GIBDDDatebase.Models;
using Microsoft.EntityFrameworkCore;

namespace GIBDDDatebase
{
    public partial class SupervisorView : Form
    {
        public SupervisorView()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e) => GetDriversAsync();

        public async void GetDriversAsync()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var drivers = await db.Drivers.ToListAsync();

                dataGridView1.Rows.Clear();

                foreach (var u in drivers)
                {
                    string[] row =
                    {
                        $"{u.Id}", $"{u.Name}",
                        $"{u.Surname}", $"{u.Patronymic}", 
                        $"{u.DateBirth}", $"{u.BirthTown}"
                    };
                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Driver newUser = new Driver
                    {
                        Name = textBox1.Text,
                        Surname = textBox2.Text,
                        Patronymic = textBox3.Text,
                        DateBirth = dateTimePicker1.Value.ToUniversalTime(),
                        BirthTown = textBox4.Text
                    };

                    db.Drivers.Add(newUser);

                    await db.SaveChangesAsync();

                    Console.WriteLine("������ ������� ���������");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            GetDriversAsync();
        }

        private void SupervisorView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
