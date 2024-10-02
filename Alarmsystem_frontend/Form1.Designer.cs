namespace POCfrontend
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblZone1 = new System.Windows.Forms.Label();
            this.lblZone2 = new System.Windows.Forms.Label();
            this.lblZone3 = new System.Windows.Forms.Label();
            this.lblZone4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(102, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "Activer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(306, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 44);
            this.button2.TabIndex = 1;
            this.button2.Text = "Deactiver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(213, 313);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 44);
            this.button3.TabIndex = 2;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblZone1
            // 
            this.lblZone1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblZone1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblZone1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZone1.Location = new System.Drawing.Point(136, 77);
            this.lblZone1.Name = "lblZone1";
            this.lblZone1.Size = new System.Drawing.Size(100, 35);
            this.lblZone1.TabIndex = 3;
            this.lblZone1.Text = "Zone1";
            this.lblZone1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZone2
            // 
            this.lblZone2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblZone2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblZone2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZone2.Location = new System.Drawing.Point(311, 77);
            this.lblZone2.Name = "lblZone2";
            this.lblZone2.Size = new System.Drawing.Size(100, 35);
            this.lblZone2.TabIndex = 4;
            this.lblZone2.Text = "Zone2";
            this.lblZone2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZone3
            // 
            this.lblZone3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblZone3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblZone3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZone3.Location = new System.Drawing.Point(136, 166);
            this.lblZone3.Name = "lblZone3";
            this.lblZone3.Size = new System.Drawing.Size(100, 35);
            this.lblZone3.TabIndex = 5;
            this.lblZone3.Text = "Zone3";
            this.lblZone3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZone4
            // 
            this.lblZone4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblZone4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblZone4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZone4.Location = new System.Drawing.Point(311, 166);
            this.lblZone4.Name = "lblZone4";
            this.lblZone4.Size = new System.Drawing.Size(100, 35);
            this.lblZone4.TabIndex = 6;
            this.lblZone4.Text = "Zone4";
            this.lblZone4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblZone4);
            this.Controls.Add(this.lblZone3);
            this.Controls.Add(this.lblZone2);
            this.Controls.Add(this.lblZone1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblZone1;
        private System.Windows.Forms.Label lblZone2;
        private System.Windows.Forms.Label lblZone3;
        private System.Windows.Forms.Label lblZone4;
    }
}

