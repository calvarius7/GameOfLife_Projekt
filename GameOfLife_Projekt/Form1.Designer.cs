namespace GameOfLife_Projekt
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
            this.start = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatsLabel = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.CoordinatesLabel = new System.Windows.Forms.Label();
            this.StatsHead = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(10, 12);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 1;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(120, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(15, 15);
            this.panel1.TabIndex = 0;
            // 
            // StatsLabel
            // 
            this.StatsLabel.AutoSize = true;
            this.StatsLabel.BackColor = System.Drawing.Color.LightGray;
            this.StatsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatsLabel.Location = new System.Drawing.Point(10, 138);
            this.StatsLabel.Name = "StatsLabel";
            this.StatsLabel.Size = new System.Drawing.Size(2, 15);
            this.StatsLabel.TabIndex = 2;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(10, 41);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 3;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.Stopbutton_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(10, 70);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 4;
            this.Reset.Text = "reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // CoordinatesLabel
            // 
            this.CoordinatesLabel.AutoSize = true;
            this.CoordinatesLabel.Location = new System.Drawing.Point(7, 437);
            this.CoordinatesLabel.Name = "CoordinatesLabel";
            this.CoordinatesLabel.Size = new System.Drawing.Size(63, 13);
            this.CoordinatesLabel.TabIndex = 5;
            this.CoordinatesLabel.Text = "Coordinates";
            // 
            // StatsHead
            // 
            this.StatsHead.AutoSize = true;
            this.StatsHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatsHead.Location = new System.Drawing.Point(7, 125);
            this.StatsHead.Name = "StatsHead";
            this.StatsHead.Size = new System.Drawing.Size(63, 13);
            this.StatsHead.TabIndex = 6;
            this.StatsHead.Text = "Statistics:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StatsHead);
            this.Controls.Add(this.CoordinatesLabel);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.StatsLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.start);
            this.Name = "Form1";
            this.Text = "GameOfLife";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label StatsLabel;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Label CoordinatesLabel;
        private System.Windows.Forms.Label StatsHead;
    }
}

