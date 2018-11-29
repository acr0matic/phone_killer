namespace NumberKiller
{
    partial class app_UI
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.start_button = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.name_textbox = new System.Windows.Forms.TextBox();
            this.source_button = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.phone_field_label = new System.Windows.Forms.Label();
            this.name_field_label = new System.Windows.Forms.Label();
            this.phone_textbox = new System.Windows.Forms.MaskedTextBox();
            this.log_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.Font = new System.Drawing.Font("Roboto Th", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_button.Location = new System.Drawing.Point(173, 114);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(138, 59);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "ЗАПУСК";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Roboto Th", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(12, 23);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(44, 19);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Имя:";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Roboto Th", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneLabel.Location = new System.Drawing.Point(12, 71);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(138, 19);
            this.phoneLabel.TabIndex = 2;
            this.phoneLabel.Text = "Номер телефона:";
            this.phoneLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // name_textbox
            // 
            this.name_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.name_textbox.Location = new System.Drawing.Point(173, 23);
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(138, 23);
            this.name_textbox.TabIndex = 3;
            this.name_textbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.name_textbox_MouseClick);
            // 
            // source_button
            // 
            this.source_button.Font = new System.Drawing.Font("Roboto Th", 12.75F);
            this.source_button.Location = new System.Drawing.Point(12, 114);
            this.source_button.Name = "source_button";
            this.source_button.Size = new System.Drawing.Size(74, 28);
            this.source_button.TabIndex = 5;
            this.source_button.Text = "БАЗА";
            this.source_button.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(317, 23);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(690, 594);
            this.webBrowser.TabIndex = 6;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // phone_field_label
            // 
            this.phone_field_label.AutoSize = true;
            this.phone_field_label.Font = new System.Drawing.Font("Roboto Th", 10F);
            this.phone_field_label.ForeColor = System.Drawing.Color.Red;
            this.phone_field_label.Location = new System.Drawing.Point(170, 91);
            this.phone_field_label.Name = "phone_field_label";
            this.phone_field_label.Size = new System.Drawing.Size(147, 17);
            this.phone_field_label.TabIndex = 7;
            this.phone_field_label.Text = "Вы не ввели телефон";
            this.phone_field_label.Visible = false;
            // 
            // name_field_label
            // 
            this.name_field_label.AutoSize = true;
            this.name_field_label.Font = new System.Drawing.Font("Roboto Th", 10F);
            this.name_field_label.ForeColor = System.Drawing.Color.Red;
            this.name_field_label.Location = new System.Drawing.Point(184, 47);
            this.name_field_label.Name = "name_field_label";
            this.name_field_label.Size = new System.Drawing.Size(115, 17);
            this.name_field_label.TabIndex = 8;
            this.name_field_label.Text = "Вы не ввели имя";
            this.name_field_label.Visible = false;
            // 
            // phone_textbox
            // 
            this.phone_textbox.AsciiOnly = true;
            this.phone_textbox.BeepOnError = true;
            this.phone_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.phone_textbox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.phone_textbox.Location = new System.Drawing.Point(173, 67);
            this.phone_textbox.Mask = "9(999) 000-0000";
            this.phone_textbox.Name = "phone_textbox";
            this.phone_textbox.Size = new System.Drawing.Size(138, 23);
            this.phone_textbox.TabIndex = 9;
            // 
            // log_button
            // 
            this.log_button.Font = new System.Drawing.Font("Roboto Th", 12.75F);
            this.log_button.Location = new System.Drawing.Point(12, 145);
            this.log_button.Name = "log_button";
            this.log_button.Size = new System.Drawing.Size(74, 28);
            this.log_button.TabIndex = 10;
            this.log_button.Text = "ОТЧЕТ";
            this.log_button.UseVisualStyleBackColor = true;
            this.log_button.Click += new System.EventHandler(this.log_button_Click);
            // 
            // app_UI
            // 
            this.ClientSize = new System.Drawing.Size(1019, 633);
            this.Controls.Add(this.log_button);
            this.Controls.Add(this.phone_textbox);
            this.Controls.Add(this.name_field_label);
            this.Controls.Add(this.phone_field_label);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.source_button);
            this.Controls.Add(this.name_textbox);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.start_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "app_UI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox name_textbox;
        private System.Windows.Forms.Button source_button;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Label phone_field_label;
        private System.Windows.Forms.Label name_field_label;
        private System.Windows.Forms.MaskedTextBox phone_textbox;
        private System.Windows.Forms.Button log_button;
    }
}

