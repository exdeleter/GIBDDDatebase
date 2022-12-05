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
            label1.Location = new System.Drawing.Point(170, 310);
            label1.Text = "Логин: ";
            textBox1.Visible = true;
            label1.Visible = true;
            textBox2.Visible = true;
            label2.Visible = true;
            isSupervisor = true;
            button3.Visible = true;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (isSupervisor)
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Введите логин и(или) пароль");
                    return;
                }

                using (ApplicationContext db = new ApplicationContext())
                {
                    var supervisors = await db.Supervisors.ToListAsync();

                    var currentSupervisor = supervisors.Where(x => x.Login == textBox1.Text).FirstOrDefault();

                    if (currentSupervisor == null)
                    {
                        MessageBox.Show($"Сотрудник с логином {textBox1.Text} не найден", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if(!currentSupervisor.Password.Equals(textBox2.Text)) {
                        MessageBox.Show("Пароль неверный!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SupervisorView form1 = new SupervisorView();
                    form1.Show();
                    this.Hide();
                }
            } else
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Введите серию и номер");
                    return;
                }
                DriverForm df = new DriverForm();
                df.LoadDriver(textBox1.Text);
                df.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Серия и номер паспорта:";
            label1.Location = new System.Drawing.Point(0, 310);
            label1.Visible = true;
            label2.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = true;
            button3.Visible = true;
            isSupervisor = false;
        }
    }
}
