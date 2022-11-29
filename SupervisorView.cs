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

                    Console.WriteLine("Новый водитель успешно добавлен");
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

        #region DL
        private async void button3_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var dl = await db.DriverLicences
                    .Include(u => u.Driver)
                    .ToListAsync();

                dataGridView2.Rows.Clear();

                foreach (var u in dl)
                {
                    string[] row =
                    {
                        $"{u.Id}", $"{string.Join(' ',  u.Driver.Surname,  u.Driver.Name,u.Driver.Patronymic)}",
                        $"{u.Driver.BirthTown}", $"{u.StartDate}",
                        $"{u.EndDate}", $"{u.IssuerName}",
                        $"{u.RegionNum}"
                    };
                    dataGridView2.Rows.Add(row);
                }
            }
        }
        #endregion

        private async void GetCars_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var cars = await db.TransportVehicle.ToListAsync();

                carsDataView.Rows.Clear();

                foreach (var car in cars)
                {
                    string[] row = { 
                        $"{car.Id}",
                        $"{car.Model}",
                        $"{car.Color}",
                        $"{car.LicencePlate}",
                        $"{car.EngineVolume}", 
                        $"{car.ReleaseYear}" 
                    };

                    carsDataView.Rows.Add(row);
                }
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var incidents = await db.Incidents
                    .Include(x => x.TransportVehicle)
                    .Include(x => x.Driver)
                    .Include(x => x.Violation)
                    .Where(x => x.RepaymentDate == DateTime.MinValue)
                    .ToListAsync();

                violationsGrid.Rows.Clear();

                foreach (var inc in incidents)
                {
                    string[] row = { 
                        $"{string.Join(' ', inc.Driver.Surname, inc.Driver.Name, inc.Driver.Patronymic)}",
                        $"{inc.TransportVehicle.LicencePlate}", 
                        $"{inc.Date}",
                        $"{inc.Violation.Name}",
                        $"{inc.Description}"
                    };

                    violationsGrid.Rows.Add(row);
                }
            }
        }
    }
}