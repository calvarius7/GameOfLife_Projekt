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
            this.StartButton = new System.Windows.Forms.Button();
            this.InitPanel = new System.Windows.Forms.Panel();
            this.StatsLabel = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.CoordinatesLabel = new System.Windows.Forms.Label();
            this.StatsHead = new System.Windows.Forms.Label();
            this.StatsGroup = new System.Windows.Forms.Panel();
            this.SpawnSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StatsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(10, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.Start_Click);
            // 
            // InitPanel
            // 
            this.InitPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InitPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.InitPanel.Location = new System.Drawing.Point(120, 0);
            this.InitPanel.Name = "InitPanel";
            this.InitPanel.Size = new System.Drawing.Size(15, 15);
            this.InitPanel.TabIndex = 0;
            // 
            // StatsLabel
            // 
            this.StatsLabel.AutoSize = true;
            this.StatsLabel.BackColor = System.Drawing.Color.LightGray;
            this.StatsLabel.Location = new System.Drawing.Point(10, 176);
            this.StatsLabel.Name = "StatsLabel";
            this.StatsLabel.Size = new System.Drawing.Size(0, 13);
            this.StatsLabel.TabIndex = 2;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(10, 41);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.Stopbutton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(10, 70);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 4;
            this.ResetButton.Text = "reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.Reset_Click);
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
            this.StatsHead.Location = new System.Drawing.Point(-3, 0);
            this.StatsHead.Name = "StatsHead";
            this.StatsHead.Size = new System.Drawing.Size(63, 13);
            this.StatsHead.TabIndex = 6;
            this.StatsHead.Text = "Statistics:";
            // 
            // StatsGroup
            // 
            this.StatsGroup.BackColor = System.Drawing.Color.LightGray;
            this.StatsGroup.Controls.Add(this.StatsHead);
            this.StatsGroup.Location = new System.Drawing.Point(10, 163);
            this.StatsGroup.Name = "StatsGroup";
            this.StatsGroup.Size = new System.Drawing.Size(124, 176);
            this.StatsGroup.TabIndex = 7;
            // 
            // SpawnSelect
            // 
            this.SpawnSelect.FormattingEnabled = true;
            this.SpawnSelect.Items.AddRange(new object[] {
            "Single",
            "Glider",
            "Pentomino",
            "SpaceShip",
            "Pulsator"});
            this.SpawnSelect.Location = new System.Drawing.Point(10, 123);
            this.SpawnSelect.Name = "SpawnSelect";
            this.SpawnSelect.Size = new System.Drawing.Size(124, 21);
            this.SpawnSelect.TabIndex = 9;
            this.SpawnSelect.Text = "Single";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Spawn Template:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpawnSelect);
            this.Controls.Add(this.CoordinatesLabel);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StatsLabel);
            this.Controls.Add(this.InitPanel);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StatsGroup);
            this.Name = "Form1";
            this.Text = "GameOfLife";
            this.StatsGroup.ResumeLayout(false);
            this.StatsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Panel InitPanel;
        private System.Windows.Forms.Label StatsLabel;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label CoordinatesLabel;
        private System.Windows.Forms.Label StatsHead;
        private System.Windows.Forms.Panel StatsGroup;
        private System.Windows.Forms.ComboBox SpawnSelect;
        private System.Windows.Forms.Label label1;
    }
}

