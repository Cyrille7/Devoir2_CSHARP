﻿namespace FichesJoueurs
{
    partial class JoueurForm
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
            this.telephoneLabel = new System.Windows.Forms.Label();
            this.prenomTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.nomLabel = new System.Windows.Forms.Label();
            this.telephoneMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.infoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // telephoneLabel
            // 
            this.telephoneLabel.AutoSize = true;
            this.telephoneLabel.Location = new System.Drawing.Point(23, 88);
            this.telephoneLabel.Name = "telephoneLabel";
            this.telephoneLabel.Size = new System.Drawing.Size(61, 13);
            this.telephoneLabel.TabIndex = 11;
            this.telephoneLabel.Text = "Téléphone:";
            // 
            // prenomTextBox
            // 
            this.prenomTextBox.Location = new System.Drawing.Point(89, 55);
            this.prenomTextBox.Name = "prenomTextBox";
            this.prenomTextBox.Size = new System.Drawing.Size(286, 20);
            this.prenomTextBox.TabIndex = 9;
            this.prenomTextBox.TextChanged += new System.EventHandler(this.JoueurFormTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Prénom";
            // 
            // nomTextBox
            // 
            this.nomTextBox.Location = new System.Drawing.Point(89, 24);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(286, 20);
            this.nomTextBox.TabIndex = 7;
            this.nomTextBox.TextChanged += new System.EventHandler(this.JoueurFormTextBox_TextChanged);
            // 
            // nomLabel
            // 
            this.nomLabel.AutoSize = true;
            this.nomLabel.Location = new System.Drawing.Point(23, 27);
            this.nomLabel.Name = "nomLabel";
            this.nomLabel.Size = new System.Drawing.Size(32, 13);
            this.nomLabel.TabIndex = 6;
            this.nomLabel.Text = "Nom:";
            // 
            // telephoneMaskedTextBox
            // 
            this.telephoneMaskedTextBox.Location = new System.Drawing.Point(89, 86);
            this.telephoneMaskedTextBox.Mask = "(999) 000-0000";
            this.telephoneMaskedTextBox.Name = "telephoneMaskedTextBox";
            this.telephoneMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.telephoneMaskedTextBox.TabIndex = 12;
            this.telephoneMaskedTextBox.TextChanged += new System.EventHandler(this.JoueurFormTextBox_TextChanged);
            // 
            // infoRichTextBox
            // 
            this.infoRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoRichTextBox.HideSelection = false;
            this.infoRichTextBox.Location = new System.Drawing.Point(89, 119);
            this.infoRichTextBox.Name = "infoRichTextBox";
            this.infoRichTextBox.Size = new System.Drawing.Size(286, 196);
            this.infoRichTextBox.TabIndex = 13;
            this.infoRichTextBox.Text = "";
            this.infoRichTextBox.SelectionChanged += new System.EventHandler(this.RichTextBox_SelectionChanged);
            this.infoRichTextBox.TextChanged += new System.EventHandler(this.JoueurFormTextBox_TextChanged);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(27, 119);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(28, 13);
            this.infoLabel.TabIndex = 14;
            this.infoLabel.Text = "Info:";
            // 
            // JoueurForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 333);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.infoRichTextBox);
            this.Controls.Add(this.telephoneMaskedTextBox);
            this.Controls.Add(this.telephoneLabel);
            this.Controls.Add(this.prenomTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nomTextBox);
            this.Controls.Add(this.nomLabel);
            this.Name = "JoueurForm";
            this.Text = "Joueur";
            this.Activated += new System.EventHandler(this.JoueurForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Joueur_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label telephoneLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nomLabel;
        private System.Windows.Forms.Label infoLabel;
        internal System.Windows.Forms.TextBox prenomTextBox;
        internal System.Windows.Forms.TextBox nomTextBox;
        internal System.Windows.Forms.MaskedTextBox telephoneMaskedTextBox;
        internal System.Windows.Forms.RichTextBox infoRichTextBox;
    }
}