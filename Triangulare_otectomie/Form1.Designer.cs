namespace Triangulare_otectomie
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
            this.buttonFinish_Draw = new System.Windows.Forms.Button();
            this.buttonTriangulare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTricolorare = new System.Windows.Forms.Button();
            this.buttonArie = new System.Windows.Forms.Button();
            this.labelArie = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 447);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // buttonDraw
            // 
            this.buttonDraw.Location = new System.Drawing.Point(0, 0);
            this.buttonDraw.Name = "buttonDraw";
            this.buttonDraw.Size = new System.Drawing.Size(10, 10);
            this.buttonDraw.TabIndex = 9;
            // 
            // buttonFinish_Draw
            // 
            this.buttonFinish_Draw.Enabled = false;
            this.buttonFinish_Draw.Location = new System.Drawing.Point(1000, 15);
            this.buttonFinish_Draw.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFinish_Draw.Name = "buttonFinish_Draw";
            this.buttonFinish_Draw.Size = new System.Drawing.Size(116, 31);
            this.buttonFinish_Draw.TabIndex = 2;
            this.buttonFinish_Draw.Text = "Ultima Latura";
            this.buttonFinish_Draw.UseVisualStyleBackColor = true;
            this.buttonFinish_Draw.Click += new System.EventHandler(this.buttonFinish_Draw_Click);
            // 
            // buttonTriangulare
            // 
            this.buttonTriangulare.Enabled = false;
            this.buttonTriangulare.Location = new System.Drawing.Point(1000, 54);
            this.buttonTriangulare.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTriangulare.Name = "buttonTriangulare";
            this.buttonTriangulare.Size = new System.Drawing.Size(116, 31);
            this.buttonTriangulare.TabIndex = 3;
            this.buttonTriangulare.Text = "Triangulare";
            this.buttonTriangulare.UseVisualStyleBackColor = true;
            this.buttonTriangulare.Click += new System.EventHandler(this.buttonTriangulare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(897, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Triunghiuri:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonTricolorare
            // 
            this.buttonTricolorare.Enabled = false;
            this.buttonTricolorare.Location = new System.Drawing.Point(1000, 93);
            this.buttonTricolorare.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTricolorare.Name = "buttonTricolorare";
            this.buttonTricolorare.Size = new System.Drawing.Size(116, 31);
            this.buttonTricolorare.TabIndex = 6;
            this.buttonTricolorare.Text = "Tricolorare";
            this.buttonTricolorare.UseVisualStyleBackColor = true;
            this.buttonTricolorare.Click += new System.EventHandler(this.buttonTricolorare_Click);
            // 
            // buttonArie
            // 
            this.buttonArie.Enabled = false;
            this.buttonArie.Location = new System.Drawing.Point(1000, 132);
            this.buttonArie.Margin = new System.Windows.Forms.Padding(4);
            this.buttonArie.Name = "buttonArie";
            this.buttonArie.Size = new System.Drawing.Size(116, 31);
            this.buttonArie.TabIndex = 7;
            this.buttonArie.Text = "Arie";
            this.buttonArie.UseVisualStyleBackColor = true;
            this.buttonArie.Click += new System.EventHandler(this.buttonArie_Click);
            // 
            // labelArie
            // 
            this.labelArie.AutoSize = true;
            this.labelArie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelArie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArie.Location = new System.Drawing.Point(1000, 170);
            this.labelArie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArie.Name = "labelArie";
            this.labelArie.Size = new System.Drawing.Size(2, 22);
            this.labelArie.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 522);
            this.Controls.Add(this.labelArie);
            this.Controls.Add(this.buttonArie);
            this.Controls.Add(this.buttonTricolorare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTriangulare);
            this.Controls.Add(this.buttonFinish_Draw);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1TriangOtectomie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.Button buttonFinish_Draw;
        private System.Windows.Forms.Button buttonTriangulare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTricolorare;
        private System.Windows.Forms.Button buttonArie;
        private System.Windows.Forms.Label labelArie;
    }
}

