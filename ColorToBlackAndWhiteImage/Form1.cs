using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorToBlackAndWhiteImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var OFD = new System.Windows.Forms.OpenFileDialog(); // Get a browser to open an image file
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
           
                var originalbmp = new Bitmap(Bitmap.FromFile(OFD.FileName)); // Load the  image
                var newbmp = new Bitmap(Bitmap.FromFile(OFD.FileName)); // New image


                var bw = originalbmp.Clone(new Rectangle(0, 0, originalbmp.Width, originalbmp.Height), PixelFormat.Format1bppIndexed);
                bw.Save(OFD.FileName.Replace(".", "_BW.")); // Save the black ad white image


                for (int row = 0; row < originalbmp.Width; row++) // Indicates row number
                {
                    for (int column = 0; column < originalbmp.Height; column++) // Indicate column number
                    {
                        var colorValue = originalbmp.GetPixel(row, column); // Get the color pixel
                        var averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G)/3; // get the average for black and white
                        newbmp.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                    }
                }

                newbmp.Save(OFD.FileName.Replace(".", "_BlackAnd White.")); // Save the black ad white image

                Process.Start(OFD.FileName.Replace(".", "_BlackAnd White.")); // Open the image
            }
        }
    }
}
