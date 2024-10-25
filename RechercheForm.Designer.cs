namespace FichesJoueurs
{
    partial class RechercheForm
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
            this.rechercheTextBox = new System.Windows.Forms.TextBox();
            this.rechercheLabel = new System.Windows.Forms.Label();
            this.suivantButton = new System.Windows.Forms.Button();
            this.annulerButton = new System.Windows.Forms.Button();
            this.RechercheGroupBox = new System.Windows.Forms.GroupBox();
            this.RechercheGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // rechercheTextBox
            // 
            this.rechercheTextBox.Location = new System.Drawing.Point(104, 41);
            this.rechercheTextBox.Name = "rechercheTextBox";
            this.rechercheTextBox.Size = new System.Drawing.Size(244, 20);
            this.rechercheTextBox.TabIndex = 0;
            this.rechercheTextBox.TextChanged += new System.EventHandler(this.rechercheTextBox_TextChanged);
            // 
            // rechercheLabel
            // 
            this.rechercheLabel.AutoSize = true;
            this.rechercheLabel.Location = new System.Drawing.Point(19, 48);
            this.rechercheLabel.Name = "rechercheLabel";
            this.rechercheLabel.Size = new System.Drawing.Size(63, 13);
            this.rechercheLabel.TabIndex = 1;
            this.rechercheLabel.Text = "&Rechercher";
            // 
            // suivantButton
            // 
            this.suivantButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.suivantButton.Location = new System.Drawing.Point(451, 30);
            this.suivantButton.Name = "suivantButton";
            this.suivantButton.Size = new System.Drawing.Size(75, 23);
            this.suivantButton.TabIndex = 3;
            this.suivantButton.Text = "&Suivant";
            this.suivantButton.UseVisualStyleBackColor = true;
            this.suivantButton.Click += new System.EventHandler(this.suivantButton_Click);
            // 
            // annulerButton
            // 
            this.annulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.annulerButton.Location = new System.Drawing.Point(451, 73);
            this.annulerButton.Name = "annulerButton";
            this.annulerButton.Size = new System.Drawing.Size(75, 23);
            this.annulerButton.TabIndex = 4;
            this.annulerButton.Text = "Annuler";
            this.annulerButton.UseVisualStyleBackColor = true;
            this.annulerButton.Click += new System.EventHandler(this.annulerButton_Click);
            // 
            // RechercheGroupBox
            // 
            this.RechercheGroupBox.Controls.Add(this.rechercheLabel);
            this.RechercheGroupBox.Controls.Add(this.rechercheTextBox);
            this.RechercheGroupBox.Location = new System.Drawing.Point(21, 30);
            this.RechercheGroupBox.Name = "RechercheGroupBox";
            this.RechercheGroupBox.Size = new System.Drawing.Size(371, 100);
            this.RechercheGroupBox.TabIndex = 5;
            this.RechercheGroupBox.TabStop = false;
            // 
            // RechercheForm
            // 
            this.AcceptButton = this.suivantButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.annulerButton;
            this.ClientSize = new System.Drawing.Size(547, 153);
            this.Controls.Add(this.RechercheGroupBox);
            this.Controls.Add(this.annulerButton);
            this.Controls.Add(this.suivantButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(150, 150);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RechercheForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recherche";
            this.RechercheGroupBox.ResumeLayout(false);
            this.RechercheGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label rechercheLabel;
        private System.Windows.Forms.Button suivantButton;
        private System.Windows.Forms.Button annulerButton;
        internal System.Windows.Forms.TextBox rechercheTextBox;
        private System.Windows.Forms.GroupBox RechercheGroupBox;
    }
}