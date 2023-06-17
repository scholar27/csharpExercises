namespace Kundenverwaltung
{
    partial class Form3
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
            this.button_tabelle_anprechpartner = new System.Windows.Forms.Button();
            this.button_tabelle_kunde = new System.Windows.Forms.Button();
            this.button_tabelle_ort = new System.Windows.Forms.Button();
            this.user_command_message = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_tabelle_anprechpartner
            // 
            this.button_tabelle_anprechpartner.Location = new System.Drawing.Point(57, 123);
            this.button_tabelle_anprechpartner.Name = "button_tabelle_anprechpartner";
            this.button_tabelle_anprechpartner.Size = new System.Drawing.Size(116, 23);
            this.button_tabelle_anprechpartner.TabIndex = 0;
            this.button_tabelle_anprechpartner.Text = "Ansprechpartner";
            this.button_tabelle_anprechpartner.UseVisualStyleBackColor = true;
            this.button_tabelle_anprechpartner.Click += new System.EventHandler(this.button_tabelle_ansprechpartner_Click);
            // 
            // button_tabelle_kunde
            // 
            this.button_tabelle_kunde.Location = new System.Drawing.Point(282, 123);
            this.button_tabelle_kunde.Name = "button_tabelle_kunde";
            this.button_tabelle_kunde.Size = new System.Drawing.Size(116, 23);
            this.button_tabelle_kunde.TabIndex = 1;
            this.button_tabelle_kunde.Text = "Kunde";
            this.button_tabelle_kunde.UseVisualStyleBackColor = true;
            this.button_tabelle_kunde.Click += new System.EventHandler(this.button_tabelle_kunde_Click);
            // 
            // button_tabelle_ort
            // 
            this.button_tabelle_ort.Location = new System.Drawing.Point(509, 123);
            this.button_tabelle_ort.Name = "button_tabelle_ort";
            this.button_tabelle_ort.Size = new System.Drawing.Size(116, 23);
            this.button_tabelle_ort.TabIndex = 2;
            this.button_tabelle_ort.Text = "Ort";
            this.button_tabelle_ort.UseVisualStyleBackColor = true;
            this.button_tabelle_ort.Click += new System.EventHandler(this.button_tabelle_ort_Click);
            // 
            // user_command_message
            // 
            this.user_command_message.Location = new System.Drawing.Point(57, 205);
            this.user_command_message.Name = "user_command_message";
            this.user_command_message.Size = new System.Drawing.Size(568, 20);
            this.user_command_message.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Klicken Sie auf die jeweilige Tabelle, um diese zu bearbeiten.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mit dem Eingabefeld können Sie per Volltextsuche Ihr Ergebnis einschränken";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 291);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.user_command_message);
            this.Controls.Add(this.button_tabelle_ort);
            this.Controls.Add(this.button_tabelle_kunde);
            this.Controls.Add(this.button_tabelle_anprechpartner);
            this.Name = "Form3";
            this.Text = "Tabellen des Kundenverwaltungssystems";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_tabelle_anprechpartner;
        private System.Windows.Forms.Button button_tabelle_kunde;
        private System.Windows.Forms.Button button_tabelle_ort;
        private System.Windows.Forms.TextBox user_command_message;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}