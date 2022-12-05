using GIBDDDatebase.Models;
using Microsoft.EntityFrameworkCore;

namespace GIBDDDatebase
{
    public partial class SupervisorView : Form
    {
        private readonly ApplicationContext _context;

        public SupervisorView()
        {
            _context = new ApplicationContext();
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e) => GetDriversAsync();

        public async void GetDriversAsync()
        {
            var drivers = await _context.Drivers.ToListAsync();

            dataGridView1.Rows.Clear();

            foreach (var u in drivers)
            {
                string[] row =
                {
                    $"{u.Id}", $"{u.Name}",
                    $"{u.Surname}", $"{u.Patronymic}", 
                    $"{u.DateBirth}", $"{u.BirthTown}",
                    $"{u.SeriesNumber}"
                };

                dataGridView1.Rows.Add(row);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
        }

        private void SupervisorView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region DL
        private async void button3_Click(object sender, EventArgs e)
        {
            var dl = await _context.DriverLicences
                .Include(u => u.Driver)
                .Where(x => x.EndDate > DateTime.Now.ToUniversalTime())
                .ToListAsync();

            dataGridView2.Rows.Clear();

            foreach (var u in dl)
            {
                var currentDlc = _context.DriverLicenceCategories
                    .Include(u => u.Category)
                    .Where(x => x.DriverLicenceId == u.Id)
                    .Select(x => x.Category.Name);

                string[] row =
                {
                    $"{u.Id}", $"{string.Join(' ',  u.Driver.Surname,  u.Driver.Name,u.Driver.Patronymic)}",
                    $"{u.Driver.BirthTown}", $"{u.StartDate}",
                    $"{u.EndDate}", $"{u.IssuerName}",
                    $"{u.RegionNum}", $"{string.Join(", ", currentDlc)}"
                };

                dataGridView2.Rows.Add(row);
            }
        }

        #endregion

        private async void GetCars_Click(object sender, EventArgs e)
        {
            var cars = await _context.TransportVehicle.ToListAsync();

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

        private async void button4_Click(object sender, EventArgs e)
        {
            var incidents = await _context.Incidents
                .Include(x => x.TransportVehicle)
                .Include(x => x.Driver)
                .Include(x => x.Violation)
                .Where(x => x.RepaymentDate == DateTime.MinValue || x.RepaymentDate == null)
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

        private void OpenFormAddDriverLicence(object sender, EventArgs e)
        {
            LicenceForm form = new LicenceForm();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddDriverForm df = new AddDriverForm();
            df.ShowDialog();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var drivers = new List<Driver>();

            if (nameRadio.Checked)
            {
                drivers = await _context.Drivers.Where(x => x.Name.Contains(textBox1.Text)).ToListAsync();
            }

            if (surnameRadio.Checked)
            {
                drivers = await _context.Drivers.Where(x => x.Surname.Contains(textBox1.Text)).ToListAsync();
            }

            if (patronymicRadio.Checked)
            {
                drivers = await _context.Drivers.Where(x => x.Patronymic.Contains(textBox1.Text)).ToListAsync();
            }

            if (birthTownRadio.Checked)
            {
                drivers = await _context.Drivers.Where(x => x.BirthTown.Contains(textBox1.Text)).ToListAsync();
            }

            if (seriesNumberRadio.Checked)
            {
                drivers = await _context.Drivers.Where(x => x.SeriesNumber.Contains(textBox1.Text)).ToListAsync();
            }

            dataGridView1.Rows.Clear();

            foreach (var u in drivers)
            {
                string[] row =
                {
                    $"{u.Id}", $"{u.Name}",
                    $"{u.Surname}", $"{u.Patronymic}",
                    $"{u.DateBirth}", $"{u.BirthTown}",
                    $"{u.SeriesNumber}"
                };
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int selRowNum = dataGridView1.CurrentCell.RowIndex;

            var selectedId = dataGridView1.Rows[selRowNum].Cells[0].Value.ToString();

            AddDriverForm df = new AddDriverForm();

            df.GetDriver(int.Parse(selectedId));

            df.ShowDialog();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selRowNum = dataGridView2.CurrentCell.RowIndex;

            var selectedId = dataGridView2.Rows[selRowNum].Cells[0].Value.ToString();

            LicenceForm dl = new LicenceForm();

            dl.GetDriverLicence(int.Parse(selectedId));

            dl.ShowDialog();
        }

        private async void textBox2_TextChanged(object sender, EventArgs e)
        {
            var driverLicencies = new List<DriverLicence>();
            try
            {
                if (driverIdRadio.Checked)
                {
                    driverLicencies = await _context.DriverLicences
                        .Include(x => x.Driver)
                        .Where(x => x.Driver.Name.Contains(textBox2.Text) ||
                                    x.Driver.Patronymic.Contains(textBox2.Text) ||
                                    x.Driver.Surname.Contains(textBox2.Text))
                        .ToListAsync();
                }

                if (townRadio.Checked)
                {
                    driverLicencies = await _context.DriverLicences
                        .Include(x => x.Driver)
                        .Where(x => x.Driver.BirthTown.Contains(textBox2.Text))
                        .ToListAsync();
                }

                if (issuerRadio.Checked)
                {
                    driverLicencies = await _context.DriverLicences
                        .Where(x => x.IssuerName.Contains(textBox2.Text))
                        .ToListAsync();
                }

                if (ragionRadio.Checked)
                {
                    int num = 0;
                    if (int.TryParse(textBox2.Text, out num))
                    {
                        driverLicencies = await _context.DriverLicences
                            .Include(x => x.Driver)
                            .Where(x => x.RegionNum == num)
                            .ToListAsync();
                    } else
                    {
                        driverLicencies = await _context.DriverLicences
                            .Include(u => u.Driver)
                            .Where(x => x.EndDate > DateTime.Now.ToUniversalTime())
                            .ToListAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            dataGridView2.Rows.Clear();

            foreach (var u in driverLicencies)
            {
                var currentDlc = _context.DriverLicenceCategories
                    .Include(u => u.Category)
                    .Where(x => x.DriverLicenceId == u.Id)
                    .Select(x => x.Category.Name);

                string[] row =
                {
                    $"{u.Id}", $"{string.Join(' ',  u.Driver.Surname,  u.Driver.Name,u.Driver.Patronymic)}",
                    $"{u.Driver.BirthTown}", $"{u.StartDate}",
                    $"{u.EndDate}", $"{u.IssuerName}",
                    $"{u.RegionNum}", $"{string.Join(", ", currentDlc)}"
                };

                dataGridView2.Rows.Add(row);
            }
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            var isuransePolicies = await  _context.InsurancePolicies
                .Include(x => x.TransportVehicle)
                .Include(x => x.DriverLicence)
                .Include(x => x.DriverLicence.Driver)
                .ToListAsync();

            dataGridView3.Rows.Clear();

            foreach (var u in isuransePolicies)
            {

                string[] row =
                {
                    $"{string.Join(' ',  u.DriverLicence.Driver.Surname,  u.DriverLicence.Driver.Name,u.DriverLicence.Driver.Patronymic)}",
                    $"{u.TransportVehicle.LicencePlate}", $"{u.StartDate}",
                    $"{u.EndDate}", $"{u.InsuranseSum}"
                };

                dataGridView3.Rows.Add(row);
            }
        }
    }
}