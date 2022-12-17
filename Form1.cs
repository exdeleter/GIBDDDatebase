using GIBDDDatebase.Models;
using Microsoft.EntityFrameworkCore;

namespace GIBDDDatebase
{
    public partial class PaymentForm : Form
    {
        private int inspId = 0;

        public PaymentForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var _context = new ApplicationContext())
                {
                    var inc = await _context.Incidents.FirstOrDefaultAsync(x => x.Id == inspId);

                    if (inc != null)
                    {
                        inc.RepaymentDate = DateTime.UtcNow;
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"{ex.Message}", "Произошла ошибка при оплате", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Отлично, оплата прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            this.Hide();
        }

        public async void GetReceipt(int id)
        {
            using (var _context = new ApplicationContext())
            {
                var incident = await _context.Incidents
                    .Include(x => x.TransportVehicle)
                    .Include(x => x.Driver)
                    .Include(x => x.Violation)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (incident == null)
                {
                    MessageBox.Show("Данного нарушения не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Form ifrm = Application.OpenForms[0];
                    ifrm.Show();
                    this.Hide();
                    return;
                }

                inspId= incident.Id;

                FillFields(incident);
            }
        }

        private void FillFields(Incident? inc)
        {
            textBox1.Text = string.Join(' ', inc?.Driver?.Surname, inc?.Driver?.Name, inc?.Driver?.Patronymic);
            textBox2.Text = inc?.TransportVehicle?.LicencePlate;
            textBox4.Text = inc?.TransportVehicle?.Model;
            textBox5.Text = inc.Date.ToShortDateString();
            richTextBox2.Text = inc.Violation.Name;
            richTextBox1.Text = inc.Description;

            if (inc.Date > DateTime.UtcNow.AddDays(-30))
            {
                textBox3.Text = (int.Parse(inc.Violation.Fine)/2).ToString();
            } else
            {
                textBox3.Text = inc.Violation.Fine;
            }
        }
    }
}
