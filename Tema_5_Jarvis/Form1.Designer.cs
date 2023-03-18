namespace Tema_5_Jarvis
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.buttonDeseneaza = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Location = new System.Drawing.Point(15, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1085, 511);
            this.panel1.TabIndex = 0;
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(15, 13);
            this.buttonDraw.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(177, 28);
            this.buttonDraw.TabIndex = 2;
            this.buttonDraw.Text = "Genereaza Puncte";
            this.buttonDraw.UseVisualStyleBackColor = true;
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click_1);
            // 
            // buttonDeseneaza
            // 
            this.buttonDeseneaza.Location = new System.Drawing.Point(200, 13);
            this.buttonDeseneaza.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeseneaza.Name = "buttonDeseneaza";
            this.buttonDeseneaza.Size = new System.Drawing.Size(267, 28);
            this.buttonDeseneaza.TabIndex = 3;
            this.buttonDeseneaza.Text = "Deseneaza Invelitoarea Convexa";
            this.buttonDeseneaza.UseVisualStyleBackColor = true;
            this.buttonDeseneaza.Click += new System.EventHandler(this.buttonDeseneaza_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 580);
            this.Controls.Add(this.buttonDeseneaza);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "ConvexHullJarvis";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonDeseneaza;
    }
}
