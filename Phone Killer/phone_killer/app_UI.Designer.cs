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
            this.phone_textbox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.info_label = new System.Windows.Forms.Label();
            this.log_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.Font = new System.Drawing.Font("Roboto Th", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_button.Location = new System.Drawing.Point(173, 109);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(166, 59);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "ЗАПУСК";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Roboto Th", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(12, 27);
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
            this.name_textbox.Location = new System.Drawing.Point(173, 27);
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(166, 20);
            this.name_textbox.TabIndex = 3;
            // 
            // phone_textbox
            // 
            this.phone_textbox.Location = new System.Drawing.Point(173, 69);
            this.phone_textbox.Name = "phone_textbox";
            this.phone_textbox.Size = new System.Drawing.Size(166, 20);
            this.phone_textbox.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Roboto Th", 12.75F);
            this.button2.Location = new System.Drawing.Point(12, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "БАЗА";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(375, 27);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(632, 594);
            this.webBrowser.TabIndex = 6;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // info_label
            // 
            this.info_label.AutoSize = true;
            this.info_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.info_label.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.info_label.Font = new System.Drawing.Font("Roboto Th", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info_label.ForeColor = System.Drawing.Color.MediumBlue;
            this.info_label.Location = new System.Drawing.Point(63, 186);
            this.info_label.Name = "info_label";
            this.info_label.Size = new System.Drawing.Size(2, 21);
            this.info_label.TabIndex = 7;
            this.info_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // log_label
            // 
            this.log_label.AutoSize = true;
            this.log_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.log_label.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.log_label.Font = new System.Drawing.Font("Roboto Th", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log_label.ForeColor = System.Drawing.Color.MidnightBlue;
            this.log_label.Location = new System.Drawing.Point(16, 186);
            this.log_label.Name = "log_label";
            this.log_label.Size = new System.Drawing.Size(41, 21);
            this.log_label.TabIndex = 8;
            this.log_label.Text = "Лог:";
            this.log_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // app_UI
            // 
            this.ClientSize = new System.Drawing.Size(1019, 633);
            this.Controls.Add(this.log_label);
            this.Controls.Add(this.info_label);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.phone_textbox);
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
        private System.Windows.Forms.TextBox phone_textbox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Label info_label;
        private System.Windows.Forms.Label log_label;
    }
}

