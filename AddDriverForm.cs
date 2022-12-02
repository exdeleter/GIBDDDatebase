using System.ComponentModel;
using GIBDDDatebase.Models;
using Microsoft.EntityFrameworkCore;

namespace GIBDDDatebase
{
    public partial class AddDriverForm : Form
    {
        private bool isEdit = false;

        private int _id = 0;

        public AddDriverForm()
        {
            InitializeComponent();
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            if (!isEdit)
            {
                var driver = new Driver()
                {
                    Name = nameText.Text,
                    Surname = surnameText.Text,
                    Patronymic = patronymicText.Text,
                    DateBirth = dateBirthPicker.Value.ToUniversalTime(),
                    BirthTown = birthTownText.Text,
                    SeriesNumber = seriesNumberText.Text,
                };

                try
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var drivers = db.Drivers;

                        await drivers.AddAsync(driver);

                        await db.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Произошла ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Водитель успешно добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                try
                {
                    using (ApplicationContext context = new ApplicationContext())
                    {
                        var driver = context.Drivers.Where(x => x.Id == _id).FirstOrDefault();

                        if (driver == null)
                        {
                            MessageBox.Show("Данного водителя не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        driver.Name = nameText.Text;
                        driver.Surname = surnameText.Text;
                        driver.Patronymic = patronymicText.Text;
                        driver.DateBirth = dateBirthPicker.Value.ToUniversalTime();
                        driver.BirthTown = birthTownText.Text;
                        driver.SeriesNumber = seriesNumberText.Text;

                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Произошла ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                MessageBox.Show("Водитель успешно добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void nameText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nameText.Text))
                e.Cancel = true;
        }

        private void surnameText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(surnameText.Text))
                e.Cancel = true;
        }

        private void patronymicText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(patronymicText.Text))
                e.Cancel = true;
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(birthTownText.Text))
                e.Cancel = true;
        }

        private void seriesNumberText_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(seriesNumberText.Text))
                e.Cancel = true;
        }

        internal async void GetDriver(int id)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var driver = await context.Drivers.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (driver == null)
                {
                    MessageBox.Show("Данного водителя не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                nameText.Text = driver.Name; 
                surnameText.Text = driver.Surname; 
                patronymicText.Text = driver.Patronymic; 
                dateBirthPicker.Value = driver.DateBirth; 
                birthTownText.Text = driver.BirthTown; 
                seriesNumberText.Text = driver.SeriesNumber;

            }

            addButton.Text = "Сохранение водителя";

            isEdit = true;

            _id = id; 
        }
    }
}
