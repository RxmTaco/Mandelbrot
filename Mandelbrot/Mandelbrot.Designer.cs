namespace Mandelbrot
{
    partial class Mandelbrot
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.zoomValue = new System.Windows.Forms.TextBox();
            this.export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1000, 1000);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseWheel);
            // 
            // zoomValue
            // 
            this.zoomValue.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.zoomValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zoomValue.ForeColor = System.Drawing.SystemColors.Control;
            this.zoomValue.Location = new System.Drawing.Point(12, 975);
            this.zoomValue.Name = "zoomValue";
            this.zoomValue.Size = new System.Drawing.Size(100, 13);
            this.zoomValue.TabIndex = 2;
            this.zoomValue.Text = "5";
            this.zoomValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zoomValue_KeyPress);
            // 
            // export
            // 
            this.export.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.export.ForeColor = System.Drawing.SystemColors.Control;
            this.export.Location = new System.Drawing.Point(913, 965);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(75, 23);
            this.export.TabIndex = 3;
            this.export.Text = "EXPORT";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // Mandelbrot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Controls.Add(this.export);
            this.Controls.Add(this.zoomValue);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mandelbrot";
            this.Text = "Mandelbrot";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Mandelbrot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox zoomValue;
        private System.Windows.Forms.Button export;
    }
}