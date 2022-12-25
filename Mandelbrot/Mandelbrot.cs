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

        int bound = 15;
        int iterations = 200;
        float zoom = 1.0f;

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
                        var aa = a * a - b * b;
                        var bb = 2 * a * b;

                        a = aa + ca;
                        b = bb + cb;

                        if(Math.Abs( a + b ) > bound)
                        {
                            break;
                        }

                        n++;
                    }

                    //var R = ExtensionMethods.Map(n, 0, iterations, 0, 255);
                    //var G = ExtensionMethods.Map(n, 0, iterations, 0, 255);
                    //var B = ExtensionMethods.Map(n, 0, iterations, 0, 255);
                    /*
                    if(n < 0.3f * iterations && n > 0.1f * iterations)
                    {
                        R = ExtensionMethods.Map(n, 0, iterations, 100, 255);
                    }
                    if (n < 0.6f * iterations && n > 0.3f * iterations)
                    {
                        G = ExtensionMethods.Map(n, 0, iterations, 100, 255);
                    }
                    if (n < 0.9f * iterations && n > 0.6f * iterations)
                    {
                        B = ExtensionMethods.Map(n, 0, iterations, 100, 255);
                    }
                    */
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
                zoomValue.Text = ("z:" + zoom.ToString());
                zoomValue.Update();
                DrawMandelbrot(zoom);
            }
            else
            {
                zoom -= 0.1f;
                zoomValue.Text = ("z:" + zoom.ToString());
                zoomValue.Update();
                DrawMandelbrot(zoom);
            }
            
        }
}
}
