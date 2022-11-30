using GIBDDDatebase.Models;

namespace GIBDDDatebase
{
    public partial class LicenceForm : Form
    {
        public LicenceForm()
        {
            InitializeComponent();
        }

        private async void AddLicence(object sender, EventArgs e)
        {
            using( ApplicationContext cn = new ApplicationContext() )
            {
                var driver = cn.Drivers.Where(x => x.Id == int.Parse(idText.Text)).FirstOrDefault();

                if (driver == null)
                {
                    MessageBox.Show("Данного водителя не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var driverLicence = new DriverLicence()
                {
                    Driver = driver,
                    DriverId = driver.Id,
                    StartDate = startPicker.Value.ToUniversalTime(),
                    EndDate = endPicker.Value.ToUniversalTime(),
                    IssuerName = issuerNameText.Text,
                    RegionNum = int.Parse(regionNumText.Text),
                };

                await cn.AddAsync(driverLicence);

                await cn.SaveChangesAsync();

                MessageBox.Show($"Водительские права водителю " +
                    $"{string.Join(' ', driver.Surname, driver.Name, driver.Patronymic)} " +
                    $"успешно выданы", "Успех", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
    }
}
