using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MathNet;
using System.Net.NetworkInformation;

namespace Mandelbrot
{
    public partial class Mandelbrot : Form
    {
        Bitmap bmp = new Bitmap(1000,1000);

        int bound = 4;
        int iterations = 200;
        float zoom = 2.0f;

        int offsetx = 0;
        int offsety = 0;

        public Mandelbrot()
        {
            InitializeComponent();
            pictureBox.Image = GetMandelbrot(zoom);
        }
        
        public void DrawMandelbrot(float zx)
        {
            pictureBox.Image = GetMandelbrot(zx);
        }
        
        Bitmap GetMandelbrot(float zoom)
        {
            for(var x = 0; x < bmp.Width; x++)
            {
                for(var y = 0; y < bmp.Height; y++)
                {
                    var z = (decimal)zoom;
                    var a = ExtensionMethods.Map(x, 0, bmp.Width, -z, z);
                    var b = ExtensionMethods.Map(y, 0, bmp.Height, -z, z);

                    var ca = a;
                    var cb = b;

                    var n = 0;

                    while(n < iterations)
                    {
                        var aa = a * a;
                        var bb = b * b;

                        var twoab = 2 * a * b;

                        //a = aa - bb - 0.7269m;  //Julia
                        //b = twoab + 0.1889m;

                        a = aa - bb + ca; //Mandelbrot
                        b = twoab + cb;

                        if (Math.Abs( a + b ) > bound)
                        {
                            break;
                        }

                        n++;
                    }
                    
                    var R = (int)((Math.Sin(n * (double)ca) + 1) * 120);
                    var G = (int)((Math.Sin(n * (double)ca + 2.094f) + 1) * 120);
                    var B = (int)((Math.Sin(n * (double)ca + 4.188f) + 1) * 120);
                    
                    if (n == iterations)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                    }

                    bmp.SetPixel(x, y, Color.FromArgb(255, R, G, B));
                }
            }

            return bmp;
        }

        private void Mandelbrot_Load(object sender, EventArgs e)
        {
            zoomValue.Text = zoom.ToString();
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            pictureBox.Focus();
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoom += 0.1f;
                zoomValue.Text = (zoom.ToString());
                zoomValue.Update();
                DrawMandelbrot(zoom);
            }
            else
            {
                zoom -= 0.1f;
                zoomValue.Text = (zoom.ToString());
                zoomValue.Update();
                DrawMandelbrot(zoom);
            }
            
        }

        private void zoomValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                zoom = float.Parse(zoomValue.Text);
                zoomValue.Text = (zoom.ToString());
                zoomValue.Update();
                DrawMandelbrot(zoom);
            }
        }

        private void export_Click(object sender, EventArgs e)
        {
            //export image
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files (*.png)|*.png";
            saveFileDialog.FileName = "Mandelbrot";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        this.pictureBox.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Png);
                        break;

                }

                fs.Close();
            }
        }
    }
}
