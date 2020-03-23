using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class FormEditor : Form
    {
        public FormEditor()
        {
            InitializeComponent();
        }

        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(openFileDialog1.FileName);
                pictureBoxSource.BackgroundImage = bmp;
            }
        }

        private void MenuItemBrightness_Click(object sender, EventArgs e)
        {
            Bitmap tempBmp = new Bitmap(pictureBoxSource.BackgroundImage);

            for (int x = 0; x < tempBmp.Size.Width; x++)
                for (int y = 0; y < tempBmp.Size.Height; y++)
                {
                    Color c = tempBmp.GetPixel(x, y);
                    Color newColor = Color.FromArgb(c.A, Math.Min(255, c.R + 100), Math.Min(c.G + 100, 255), Math.Min(c.B + 100, 255));
                    tempBmp.SetPixel(x, y, newColor);
                }
            pictureBoxEditor.Image = tempBmp;

        }
    }
}
