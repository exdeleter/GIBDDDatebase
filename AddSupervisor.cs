using GIBDDDatebase.Models;

using Microsoft.EntityFrameworkCore;

namespace GIBDDDatebase
{
    public partial class AddSupervisor : Form
    {
        public AddSupervisor()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var ap = new ApplicationContext())
            {
                var sup = await ap.Supervisors.FirstOrDefaultAsync(x => x.Login == textBox1.Text);

                if (sup != null)
                {
                    MessageBox.Show("Данный сотрудник уже существует", 
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    return;
                }

                var super = new Supervisor
                {
                    Login = textBox1.Text,
                    Password = textBox2.Text
                };

                try
                {
                    await ap.AddAsync(super);

                    await ap.SaveChangesAsync();
                    
                    MessageBox.Show(
                        $"Новый сотрудник успешно создан",
                        "Успех",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
