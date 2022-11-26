using Microsoft.EntityFrameworkCore;

namespace GIBDDDatebase
{
    public partial class Login : Form
    {
        private bool isSupervisor = false;
        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label1.Visible = true;
            textBox2.Visible = true;
            label2.Visible = true;
            isSupervisor = true;
            button3.Visible = true;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Введите логин и(или) пароль");
                return;
            }

            if (isSupervisor)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var supervisors = await db.Supervisors.ToListAsync();

                    var currentSupervisor = supervisors.Where(x => x.Login == textBox1.Text).FirstOrDefault();

                    if (currentSupervisor == null)
                    {
                        MessageBox.Show($"Сотрудник с логином {textBox1.Text} не найден");
                        return;
                    }

                    if(!currentSupervisor.Password.Equals(textBox2.Text)) {
                        MessageBox.Show("Пароль неверный!");
                        return;
                    }

                    SupervisorView form1 = new SupervisorView();
                    form1.Show();
                    this.Hide();
                }
            }
        }
    }
}
