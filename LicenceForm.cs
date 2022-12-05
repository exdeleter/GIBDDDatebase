using GIBDDDatebase.Models;
using Microsoft.EntityFrameworkCore;

namespace GIBDDDatebase
{
    internal partial class LicenceForm : Form
    {
        private bool isEdit;

        private int _id;

        private readonly ApplicationContext _context;

        public LicenceForm()
        {
            _context = new ApplicationContext();
            InitializeComponent();
        }

        private async void AddLicence(object sender, EventArgs e)
        {
            if(!isEdit)
            {
                try
                {
                    var driver = _context.Drivers.FirstOrDefault(x => x.Id == int.Parse(idText.Text));

                    if (driver == null)
                    {
                        MessageBox.Show("Данного водителя не существует", "Ошибка", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    var driverLicence = new DriverLicence()
                    {
                        DriverId = driver.Id,
                        StartDate = startPicker.Value.ToUniversalTime(),
                        EndDate = endPicker.Value.ToUniversalTime(),
                        IssuerName = issuerNameText.Text,
                        RegionNum = int.Parse(regionNumText.Text),
                    };

                    await _context.AddAsync(driverLicence);

                    await _context.SaveChangesAsync();

                    AddCategory(driverLicence.Id);

                    MessageBox.Show(
                        $"Водительские права водителю " +
                        $"{string.Join(' ', driver.Surname, driver.Name, driver.Patronymic)} " +
                        $"успешно выданы",
                        "Успех",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information
                    );
                    
                    return;
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            try
            {
                var driverLicence = _context.DriverLicences.FirstOrDefault(x => x.Id == _id);
                
                driverLicence.StartDate = startPicker.Value.ToUniversalTime();
                driverLicence.EndDate = endPicker.Value.ToUniversalTime();
                driverLicence.IssuerName = issuerNameText.Text;
                driverLicence.RegionNum = int.Parse(regionNumText.Text);
                
                await _context.SaveChangesAsync();

                MessageBox.Show("Изменения сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Произошла ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private async void AddCategory(int driverLicenceId)
        {
            List<DriverLicenceCategory> dlc = new List<DriverLicenceCategory>();

            if (categoryACheckbox.Checked)
            {
                dlc.Add(new DriverLicenceCategory()
                {
                    DriverLicenceId = driverLicenceId,
                    StartDate = startPicker.Value.ToUniversalTime(),
                    EndDate = endPicker.Value.ToUniversalTime(),
                    CategoryId = 1
                });
            }

            if (categoryBCheckbox.Checked)
            {
                dlc.Add(new DriverLicenceCategory()
                {
                    DriverLicenceId = driverLicenceId,
                    StartDate = startPicker.Value.ToUniversalTime(),
                    EndDate = endPicker.Value.ToUniversalTime(),
                    CategoryId = 2
                });
            }

            if (categoryCCheckbox.Checked)
            {
                dlc.Add(new DriverLicenceCategory()
                {
                    DriverLicenceId = driverLicenceId,
                    StartDate = startPicker.Value.ToUniversalTime(),
                    EndDate = endPicker.Value.ToUniversalTime(),
                    CategoryId = 3
                });
            }

            await _context.AddRangeAsync(dlc);

            await _context.SaveChangesAsync();
        }

        private void addYears_Click(object sender, EventArgs e)
        {
            endPicker.Value = startPicker.Value.AddYears(10).ToUniversalTime();
        }

        public async void GetDriverLicence(int id)
        {
            var driverLicence = await _context.DriverLicences
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (driverLicence == null)
            {
                MessageBox.Show("Данного водительского удостоверения не существует", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            idText.Text = driverLicence.DriverId.ToString();
            startPicker.Value = driverLicence.StartDate < DateTimePicker.MinimumDateTime
                ? DateTimePicker.MinimumDateTime
                : driverLicence.StartDate;
            endPicker.Value = driverLicence.EndDate < DateTimePicker.MinimumDateTime
                ? DateTimePicker.MinimumDateTime
                : driverLicence.EndDate;
            issuerNameText.Text = driverLicence.IssuerName;
            regionNumText.Text = driverLicence.RegionNum.ToString();

            LoadCategory(driverLicence.Id);

            button1.Text = "Сохранить водительское удостоверение";

            isEdit = true;

            _id = id;
        }

        private void LoadCategory(int driverLicenceId)
        {
            var dlc = _context.DriverLicenceCategories
                .Include(x => x.Category)
                .Where(x => x.DriverLicenceId == driverLicenceId)
                .Select(x => x.Category.Name);

            categoryACheckbox.Checked = dlc.Contains("A");

            categoryBCheckbox.Checked = dlc.Contains("B");

            categoryCCheckbox.Checked = dlc.Contains("C");
        }
    }
}
