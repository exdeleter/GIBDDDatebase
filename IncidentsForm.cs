using GIBDDDatebase.Models;
using Microsoft.EntityFrameworkCore;

namespace GIBDDDatebase
{
    public partial class IncidentsForm : Form
    {
        private readonly ApplicationContext _context;
        public IncidentsForm()
        {
            InitializeComponent();
            _context = new ApplicationContext();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var transportVehicleId = 0;

                if (string.IsNullOrEmpty(tsId.Text))
                {
                    using (ApplicationContext cn = new ApplicationContext())
                    {
                        transportVehicleId = _context.TransportVehicle
                            .FirstOrDefaultAsync(x => x.LicencePlate == numId.Text)
                            .Id;
                    }
                    
                }
                else
                {
                    transportVehicleId = int.Parse(tsId.Text);
                }
                
                var incident = new Incident()
                {
                    DriverId = int.Parse(driverId.Text),
                    TransportVehicleId = transportVehicleId,
                    ViolationId = int.Parse(violId.Text),
                    Date = dateTimePicker1.Value.ToUniversalTime(),
                    Description = caption.Text,
                };

                await _context.AddAsync(incident);

                await _context.SaveChangesAsync();
                
                MessageBox.Show(
                    $"Нарушение успешно выдано",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IncidentsForm_Load(object sender, EventArgs e)
        {
            GetDrivers();
            GetCars();
            GetViolations();
        }

        private async void GetDrivers()
        {
            using (ApplicationContext ap = new ApplicationContext())
            {
                var drivers = await ap.DriverLicences
                    .Include(x => x.Driver)
                    .Where(x => x.EndDate > DateTime.UtcNow)
                    .ToListAsync();

                dataGridView1.Rows.Clear();

                foreach (var dr in drivers)
                {
                    string[] row =
                    {
                        $"{dr.DriverId}",
                        $"{string.Join(' ', dr.Driver.Surname, dr.Driver.Name, dr.Driver.Patronymic)}",
                        $"{dr.Driver.SeriesNumber}"
                    };
                    
                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private async void GetCars()
        {
            using (ApplicationContext ap = new ApplicationContext())
            {
                var cars = await ap.TransportVehicle
                    .ToListAsync();

                dataGridView2.Rows.Clear();

                foreach (var car in cars)
                {
                    string[] row =
                    {
                        $"{car.Id}",
                        $"{car.Model}",
                        $"{car.LicencePlate}",
                        $"{car.Color}",
                        $"{car.ReleaseYear}",
                    };

                    dataGridView2.Rows.Add(row);
                }
            }
        }

        private async void GetViolations()
        {
            using (ApplicationContext ap = new ApplicationContext())
            {
                var viols = await ap.Violations
                    .ToListAsync();

                dataGridView3.Rows.Clear();

                foreach (var viol in viols)
                {
                    string[] row =
                    {
                        $"{viol.Id}",
                        $"{viol.Code}",
                        $"{viol.Name}",
                        $"{viol.Fine}",
                    };

                    dataGridView3.Rows.Add(row);
                }
            }
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var drivers = new List<DriverLicence>();

            try
            {
                if (nameRadio.Checked)
                {
                    drivers = await _context.DriverLicences
                        .Include(x => x.Driver)
                        .Where(x => x.EndDate > DateTime.UtcNow && (
                            x.Driver.Name.Contains(textBox1.Text) ||     
                            x.Driver.Surname.Contains(textBox1.Text) ||     
                            x.Driver.Patronymic.Contains(textBox1.Text)
                        ))
                        .ToListAsync();
                }

                if (seriesNumberRadio.Checked)
                {
                    drivers = await _context.DriverLicences
                        .Include(x => x.Driver)
                        .Where(x => x.Driver.SeriesNumber.Contains(textBox1.Text))
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView1.Rows.Clear();

            foreach (var dr in drivers)
            {
                string[] row =
                {
                    $"{dr.DriverId}",
                    $"{string.Join(' ', dr.Driver.Surname, dr.Driver.Name, dr.Driver.Patronymic)}",
                    $"{dr.Driver.SeriesNumber}"
                };
                
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selRowNum = dataGridView1.CurrentCell.RowIndex;

            var selectedId = dataGridView1.Rows[selRowNum].Cells[0].Value.ToString();

            driverId.Text = selectedId;
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selRowNum = dataGridView2.CurrentCell.RowIndex;

            var selectedId = dataGridView2.Rows[selRowNum].Cells[0].Value.ToString();

            tsId.Text = selectedId;
        }

        private async void textBox2_TextChanged(object sender, EventArgs e)
        {
            var cars = new List<TransportVehicle>();

            try
            {
                if (radioButton2.Checked)
                {
                    cars = await _context.TransportVehicle
                        .Where(x => x.Model.Contains(textBox2.Text))
                        .ToListAsync();
                }

                if (radioButton1.Checked)
                {
                    cars = await _context.TransportVehicle
                        .Where(x => x.LicencePlate.Contains(textBox2.Text.ToUpper()))
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView2.Rows.Clear();

            foreach (var car in cars)
            {
                string[] row =
                {
                        $"{car.Id}",
                        $"{car.Model}",
                        $"{car.LicencePlate}",
                        $"{car.Color}",
                        $"{car.ReleaseYear}",
                };

                dataGridView2.Rows.Add(row);
            }
        }

        private async void textBox3_TextChanged(object sender, EventArgs e)
        {
            var viols = new List<Violation>();

            try
            {
                if (radioButton4.Checked)
                {
                    viols = await _context.Violations
                        .Where(x => x.Code.Contains(textBox3.Text))
                        .ToListAsync();
                }

                if (radioButton3.Checked)
                {
                    viols = await _context.Violations
                        .Where(x => x.Name.Contains(textBox3.Text))
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView3.Rows.Clear();

            foreach (var viol in viols)
            {
                string[] row =
                {
                    $"{viol.Id}",
                    $"{viol.Code}",
                    $"{viol.Name}",
                    $"{viol.Fine}",
                };

                dataGridView3.Rows.Add(row);
            }
        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selRowNum = dataGridView3.CurrentCell.RowIndex;

            var selectedId = dataGridView3.Rows[selRowNum].Cells[0].Value.ToString();

            violId.Text = selectedId;
        }
    }
}

