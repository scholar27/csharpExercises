namespace Kundenverwaltung
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.such_button = new System.Windows.Forms.Button();
            this.suchfeld = new System.Windows.Forms.TextBox();
            this.button_change = new System.Windows.Forms.Button();
            this.button_create = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // such_button
            // 
            this.such_button.Location = new System.Drawing.Point(112, 164);
            this.such_button.Name = "such_button";
            this.such_button.Size = new System.Drawing.Size(75, 23);
            this.such_button.TabIndex = 0;
            this.such_button.Text = "Suche";
            this.such_button.UseVisualStyleBackColor = true;
            this.such_button.Click += new System.EventHandler(this.such_button_Click);
            // 
            // suchfeld
            // 
            this.suchfeld.Location = new System.Drawing.Point(206, 164);
            this.suchfeld.Name = "suchfeld";
            this.suchfeld.Size = new System.Drawing.Size(506, 20);
            this.suchfeld.TabIndex = 2;
            // 
            // button_change
            // 
            this.button_change.Location = new System.Drawing.Point(112, 282);
            this.button_change.Name = "button_change";
            this.button_change.Size = new System.Drawing.Size(75, 23);
            this.button_change.TabIndex = 3;
            this.button_change.Text = "Ändern";
            this.button_change.UseVisualStyleBackColor = true;
            this.button_change.Click += new System.EventHandler(this.button_change_Click);
            // 
            // button_create
            // 
            this.button_create.Location = new System.Drawing.Point(344, 282);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(75, 23);
            this.button_create.TabIndex = 4;
            this.button_create.Text = "Erstellen";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(587, 282);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "Löschen";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Suche nach Einträgen in der Datenbank (Volltextsuche)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Um die Datenbank anzupassen, klicken Sie auf den jeweiligen Button";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.button_change);
            this.Controls.Add(this.suchfeld);
            this.Controls.Add(this.such_button);
            this.Name = "Form1";
            this.Text = "Kundenverwaltungssystem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.Button such_button;
        private System.Windows.Forms.TextBox suchfeld;
        private System.Windows.Forms.Button button_change;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

