namespace GIBDDDatebase
{
    partial class LicenceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenceForm));
            this.idText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.issuerNameText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.regionNumText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.startPicker = new System.Windows.Forms.DateTimePicker();
            this.endPicker = new System.Windows.Forms.DateTimePicker();
            this.addYears = new System.Windows.Forms.Button();
            this.categoryACheckbox = new System.Windows.Forms.CheckBox();
            this.categoryBCheckbox = new System.Windows.Forms.CheckBox();
            this.categoryCCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // idText
            // 
            this.idText.Location = new System.Drawing.Point(282, 18);
            this.idText.Name = "idText";
            this.idText.Size = new System.Drawing.Size(125, 30);
            this.idText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Идентификатор водителя:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 98);
            this.button1.TabIndex = 2;
            this.button1.Text = "Выдать права";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddLicence);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 52);
            this.label2.TabIndex = 4;
            this.label2.Text = "Наименование, \r\nвыдающего органа:\r\n";
            // 
            // issuerNameText
            // 
            this.issuerNameText.Location = new System.Drawing.Point(282, 64);
            this.issuerNameText.Name = "issuerNameText";
            this.issuerNameText.Size = new System.Drawing.Size(125, 30);
            this.issuerNameText.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Номер региона:\r\n";
            // 
            // regionNumText
            // 
            this.regionNumText.Location = new System.Drawing.Point(282, 122);
            this.regionNumText.Name = "regionNumText";
            this.regionNumText.Size = new System.Drawing.Size(125, 30);
            this.regionNumText.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 26);
            this.label5.TabIndex = 7;
            this.label5.Text = "Дата начала действия:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(12, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(266, 26);
            this.label6.TabIndex = 8;
            this.label6.Text = "Дата окончания действия:";
            // 
            // startPicker
            // 
            this.startPicker.Location = new System.Drawing.Point(282, 173);
            this.startPicker.Name = "startPicker";
            this.startPicker.Size = new System.Drawing.Size(250, 30);
            this.startPicker.TabIndex = 9;
            // 
            // endPicker
            // 
            this.endPicker.Location = new System.Drawing.Point(282, 220);
            this.endPicker.Name = "endPicker";
            this.endPicker.Size = new System.Drawing.Size(250, 30);
            this.endPicker.TabIndex = 10;
            // 
            // addYears
            // 
            this.addYears.Location = new System.Drawing.Point(438, 256);
            this.addYears.Name = "addYears";
            this.addYears.Size = new System.Drawing.Size(94, 29);
            this.addYears.TabIndex = 11;
            this.addYears.Text = "+ 10 лет";
            this.addYears.UseVisualStyleBackColor = true;
            this.addYears.Click += new System.EventHandler(this.addYears_Click);
            // 
            // categoryACheckbox
            // 
            this.categoryACheckbox.AutoSize = true;
            this.categoryACheckbox.Location = new System.Drawing.Point(29, 305);
            this.categoryACheckbox.Name = "categoryACheckbox";
            this.categoryACheckbox.Size = new System.Drawing.Size(135, 26);
            this.categoryACheckbox.TabIndex = 12;
            this.categoryACheckbox.Text = "категория A";
            this.categoryACheckbox.UseVisualStyleBackColor = true;
            // 
            // categoryBCheckbox
            // 
            this.categoryBCheckbox.AutoSize = true;
            this.categoryBCheckbox.Location = new System.Drawing.Point(170, 305);
            this.categoryBCheckbox.Name = "categoryBCheckbox";
            this.categoryBCheckbox.Size = new System.Drawing.Size(137, 26);
            this.categoryBCheckbox.TabIndex = 13;
            this.categoryBCheckbox.Text = "Категория B";
            this.categoryBCheckbox.UseVisualStyleBackColor = true;
            // 
            // categoryCCheckbox
            // 
            this.categoryCCheckbox.AutoSize = true;
            this.categoryCCheckbox.Location = new System.Drawing.Point(313, 305);
            this.categoryCCheckbox.Name = "categoryCCheckbox";
            this.categoryCCheckbox.Size = new System.Drawing.Size(137, 26);
            this.categoryCCheckbox.TabIndex = 14;
            this.categoryCCheckbox.Text = "Категория C";
            this.categoryCCheckbox.UseVisualStyleBackColor = true;
            // 
            // LicenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 495);
            this.Controls.Add(this.categoryCCheckbox);
            this.Controls.Add(this.categoryBCheckbox);
            this.Controls.Add(this.categoryACheckbox);
            this.Controls.Add(this.addYears);
            this.Controls.Add(this.endPicker);
            this.Controls.Add(this.startPicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.regionNumText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.issuerNameText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idText);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "LicenceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выдача ВУ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox idText;
        private Label label1;
        private Button button1;
        private Label label2;
        private TextBox issuerNameText;
        private Label label3;
        private TextBox regionNumText;
        private Label label5;
        private Label label6;
        private DateTimePicker startPicker;
        private DateTimePicker endPicker;
        private Button addYears;
        private CheckBox categoryACheckbox;
        private CheckBox categoryBCheckbox;
        private CheckBox categoryCCheckbox;
    }
}