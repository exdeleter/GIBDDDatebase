namespace GIBDDDatebase
{
    partial class AddDriverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDriverForm));
            this.label1 = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.surnameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.patronymicText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.birthTownText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.seriesNumberText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateBirthPicker = new System.Windows.Forms.DateTimePicker();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя:";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(177, 16);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(156, 27);
            this.nameText.TabIndex = 1;
            this.nameText.Validating += new System.ComponentModel.CancelEventHandler(this.nameText_Validating);
            // 
            // surnameText
            // 
            this.surnameText.Location = new System.Drawing.Point(177, 49);
            this.surnameText.Name = "surnameText";
            this.surnameText.Size = new System.Drawing.Size(156, 27);
            this.surnameText.TabIndex = 3;
            this.surnameText.Validating += new System.ComponentModel.CancelEventHandler(this.surnameText_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Фамилия:";
            // 
            // patronymicText
            // 
            this.patronymicText.Location = new System.Drawing.Point(177, 82);
            this.patronymicText.Name = "patronymicText";
            this.patronymicText.Size = new System.Drawing.Size(156, 27);
            this.patronymicText.TabIndex = 5;
            this.patronymicText.Validating += new System.ComponentModel.CancelEventHandler(this.patronymicText_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Отчество:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата рождения:";
            // 
            // birthTownText
            // 
            this.birthTownText.Location = new System.Drawing.Point(177, 148);
            this.birthTownText.Name = "birthTownText";
            this.birthTownText.Size = new System.Drawing.Size(156, 27);
            this.birthTownText.TabIndex = 9;
            this.birthTownText.Validating += new System.ComponentModel.CancelEventHandler(this.textBox4_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Место рождения:";
            // 
            // seriesNumberText
            // 
            this.seriesNumberText.Location = new System.Drawing.Point(177, 181);
            this.seriesNumberText.Name = "seriesNumberText";
            this.seriesNumberText.Size = new System.Drawing.Size(156, 27);
            this.seriesNumberText.TabIndex = 11;
            this.seriesNumberText.Validating += new System.ComponentModel.CancelEventHandler(this.seriesNumberText_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(12, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "Серия и номер:";
            // 
            // dateBirthPicker
            // 
            this.dateBirthPicker.Location = new System.Drawing.Point(177, 115);
            this.dateBirthPicker.Name = "dateBirthPicker";
            this.dateBirthPicker.Size = new System.Drawing.Size(250, 27);
            this.dateBirthPicker.TabIndex = 12;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addButton.Location = new System.Drawing.Point(133, 268);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(151, 85);
            this.addButton.TabIndex = 13;
            this.addButton.Text = "Добавить водителя";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AddDriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 450);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.dateBirthPicker);
            this.Controls.Add(this.seriesNumberText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.birthTownText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.patronymicText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.surnameText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddDriverForm";
            this.Text = "Добавление(изменение) водителя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox nameText;
        private TextBox surnameText;
        private Label label2;
        private TextBox patronymicText;
        private Label label3;
        private Label label4;
        private TextBox birthTownText;
        private Label label5;
        private TextBox seriesNumberText;
        private Label label6;
        private DateTimePicker dateBirthPicker;
        private Button addButton;
    }
}