using Microsoft.EntityFrameworkCore;

namespace GIBDDDatebase
{
    public partial class DriverForm : Form
    {
        private int _driverId = 0;
        private readonly ApplicationContext _context;
        
        public DriverForm()
        {
            _context =  new ApplicationContext();
            InitializeComponent();
        }

        internal async void LoadDriver(string seriesNumber)
        {
            var driver = await _context.Drivers
                .FirstOrDefaultAsync(x => x.SeriesNumber == seriesNumber);

            if (driver == null)
            {
                MessageBox.Show("Данного водителя не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form ifrm = Application.OpenForms[0];
                ifrm.Show();
                this.Hide();
                return;
            }
            
            _driverId = driver.Id;

            GetInsurancePolicy();
            GetViolations();
        }

        private void DriverForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            this.Hide();
        }

        private void DriverForm_Load(object sender, EventArgs e)
        {
            GetInsurancePolicy();
            GetViolations();
        }

        private async void GetInsurancePolicy()
        {
            using (var ap = new ApplicationContext())
            {
                var insurances = await ap.InsurancePolicies
                    .Include(x => x.TransportVehicle)
                    .Include(x => x.DriverLicence)
                    .Where(x => x.DriverLicence.DriverId == _driverId)
                    .ToListAsync();

                dataGridView1.Rows.Clear();

                foreach (var insurance in insurances)
                {
                    string[] row =
                    {
                        $"{insurance.TransportVehicle.Model}",
                        $"{insurance.TransportVehicle.LicencePlate}",
                        $"{insurance.StartDate}",
                        $"{insurance.EndDate}",
                        $"{insurance.InsuranseSum}"
                    };

                    dataGridView1.Rows.Add(row);
                }
            }
        }
        
        private async void GetViolations()
        {
            using (var ap = new ApplicationContext())
            {
                var viols = await ap.Incidents
                    .Include(x => x.Violation)
                    .Include(x => x.TransportVehicle)
                    .Where(x => x.DriverId == _driverId)
                    .OrderByDescending(x => x.Date)
                    .ToListAsync();

                dataGridView2.Rows.Clear();

                foreach (var viol in viols)
                {
                    string[] row =
                    {
                        $"{viol.Id}",
                        $"{viol.TransportVehicle.Model}",
                        $"{viol.TransportVehicle.LicencePlate}",
                        $"{viol.Date}",
                        $"{viol.Description}",
                        $"{viol.Violation.Name}",
                        $"{viol.Violation.Fine}",
                        $"{viol.RepaymentDate}",
                    };

                    dataGridView2.Rows.Add(row);
                }
            }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selRowNum = dataGridView2.CurrentCell.RowIndex;

            var selectedId = dataGridView2.Rows[selRowNum].Cells[0].Value.ToString();

            PaymentForm payment = new PaymentForm();

            payment.GetReceipt(int.Parse(selectedId));

            payment.ShowDialog();
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            GetViolations();
        }
    }
}
