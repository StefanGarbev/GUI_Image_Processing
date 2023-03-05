using System.IO;
using System.Drawing.Imaging;
using Accord.Imaging.Filters;

namespace GUI_Image_Processing
{
    public partial class Form1 : Form
    {
        Bitmap newBitmap;
        Image file;
        bool opened = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                file = Image.FromFile(openFileDialog1.FileName);
                newBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = file;
                opened = true;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = saveFileDialog1.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                if (opened)
                {
                    // C:\TestImage.Bmp
                    if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "bmp")
                    {
                        file.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
                    }

                    if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "png")
                    {
                        file.Save(saveFileDialog1.FileName, ImageFormat.Png);
                    }
                    if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "jpg")
                    {
                        file.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                    }
                }
                else
                {
                    MessageBox.Show("You need to open an image first!");
                }
            }
        }

        private void SharpFilter_Click(object sender, EventArgs e)
        {

            Bitmap sharpenImage = new Bitmap(newBitmap.Width, newBitmap.Height);

            int widht = newBitmap.Width;
            int height = newBitmap.Height;

            int[,] filterMatrix = new int[3, 3];
            filterMatrix[0, 0] = 0;
            filterMatrix[0, 1] = -1;
            filterMatrix[0, 2] = 0;
            filterMatrix[1, 0] = -1;
            filterMatrix[1, 1] = 5;
            filterMatrix[1, 2] = -1;
            filterMatrix[2, 0] = 0;
            filterMatrix[2, 1] = -1;
            filterMatrix[2, 2] = 0;

            double factor = 1.0;
            double bias = 1.0;

            Color[,] result = new Color[newBitmap.Width, newBitmap.Height];

            for (int x = 0; x < newBitmap.Width; x++)
            {
                for (int y = 0; y < newBitmap.Height; y++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;
                    Color imageColor = newBitmap.GetPixel(x, y);
                    for (int filterX = 0; filterX < 3; filterX++)
                    {
                        for (int filterY = 0; filterY < 3; filterY++)
                        {
                            int imageX = (x - 3 / 2 + filterX + widht) % widht;
                            int imageY = (y - 3 / 2 + filterY + height) % height;
                            Color newimageColor = newBitmap.GetPixel(imageX, imageY);
                            red += newimageColor.R * filterMatrix[filterX, filterY];
                            green += newimageColor.G * filterMatrix[filterX, filterY];
                            blue += newimageColor.B * filterMatrix[filterX, filterY];
                        }
                        int r = Math.Min(Math.Max((int)(factor * red + bias), 0), 255);
                        int g = Math.Min(Math.Max((int)(factor * green + bias), 0), 255);
                        int b = Math.Min(Math.Max((int)(factor * blue + bias), 0), 255);

                        result[x, y] = Color.FromArgb(r, g, b);
                    }
                }
            }
            for (int i = 0; i < widht; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    sharpenImage.SetPixel(i, j, result[i, j]);
                }
            }
            pictureBox1.Image = sharpenImage;
        }

        private void blur3x3Filter_Click(object sender, EventArgs e)
        {
            Bitmap gaussianBlurImage = new Bitmap(newBitmap.Width, newBitmap.Height);
            int widht = newBitmap.Width;
            int height = newBitmap.Height;

            int lenght = 3;
            double sigma = 2;

            double[,] Kernel = new double[lenght, lenght];
            double sumTotal = 0;


            int kernelRadius = lenght / 2;
            double distance = 0;


            double calculatedEuler = 1.0 /
            (2.0 * Math.PI * Math.Pow(sigma, 2));


            for (int filterY = -kernelRadius; filterY <= kernelRadius; filterY++)
            {
                for (int filterX = -kernelRadius; filterX <= kernelRadius; filterX++)
                {
                    distance = ((filterX * filterX) + (filterY * filterY)) / (2 * (sigma * sigma));

                    Kernel[filterY + kernelRadius, filterX + kernelRadius] = calculatedEuler * Math.Exp(-distance);

                    sumTotal += Kernel[filterY + kernelRadius, filterX + kernelRadius];
                }
            }


            for (int y = 0; y < lenght; y++)
            {
                for (int x = 0; x < lenght; x++)
                {
                    Kernel[y, x] = Kernel[y, x] * (1.0 / sumTotal);
                }
            }
            // Ignoring the edges for ease of implementation
            // This will cause a thin border around the image that won't be processed

            Color[,] result = new Color[newBitmap.Width, newBitmap.Height];

            for (int x = 0; x < newBitmap.Width; x++)
            {
                for (int y = 0; y < newBitmap.Height; y++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;
                    Color imageColor = newBitmap.GetPixel(x, y);
                    for (int filterX = 0; filterX < 3; filterX++)
                    {
                        for (int filterY = 0; filterY < 3; filterY++)
                        {
                            int imageX = (x - 3 / 2 + filterX + widht) % widht;
                            int imageY = (y - 3 / 2 + filterY + height) % height;
                            Color newimageColor = newBitmap.GetPixel(imageX, imageY);
                            red += newimageColor.R * Kernel[filterX, filterY];
                            green += newimageColor.G * Kernel[filterX, filterY];
                            blue += newimageColor.B * Kernel[filterX, filterY];
                        }
                        int r = Math.Min(Math.Max((int)red, 0), 255);
                        int g = Math.Min(Math.Max((int)green, 0), 255);
                        int b = Math.Min(Math.Max((int)blue, 0), 255);

                        result[x, y] = Color.FromArgb(r, g, b);
                    }
                }
            }

            //------------------------ Calculation new image ----------------------
            for (int i = 0; i < widht; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    gaussianBlurImage.SetPixel(i, j, result[i, j]);
                }
            }
            pictureBox1.Image = gaussianBlurImage;
        }

        private void blur5x5Filter_Click(object sender, EventArgs e)
        {
            Bitmap gaussianBlurImage5x5 = new Bitmap(newBitmap.Width, newBitmap.Height);
            int widht = newBitmap.Width;
            int height = newBitmap.Height;

            int lenght = 5;
            double sigma = 5;

            double[,] Kernel = new double[lenght, lenght];
            double sumTotal = 0;


            int kernelRadius = lenght / 2;
            double distance = 0;


            double calculatedEuler = 1.0 /
            (2.0 * Math.PI * Math.Pow(sigma, 2));


            for (int filterY = -kernelRadius; filterY <= kernelRadius; filterY++)
            {
                for (int filterX = -kernelRadius; filterX <= kernelRadius; filterX++)
                {
                    distance = ((filterX * filterX) + (filterY * filterY)) / (2 * (sigma * sigma));

                    Kernel[filterY + kernelRadius, filterX + kernelRadius] = calculatedEuler * Math.Exp(-distance);

                    sumTotal += Kernel[filterY + kernelRadius, filterX + kernelRadius];
                }
            }


            for (int y = 0; y < lenght; y++)
            {
                for (int x = 0; x < lenght; x++)
                {
                    Kernel[y, x] = Kernel[y, x] * (1.0 / sumTotal);
                }
            }
            // Ignoring the edges for ease of implementation
            // This will cause a thin border around the image that won't be processed

            Color[,] result = new Color[newBitmap.Width, newBitmap.Height];

            for (int x = 0; x < newBitmap.Width; x++)
            {
                for (int y = 0; y < newBitmap.Height; y++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;
                    Color imageColor = newBitmap.GetPixel(x, y);
                    for (int filterX = 0; filterX < 5; filterX++)
                    {
                        for (int filterY = 0; filterY < 5; filterY++)
                        {
                            int imageX = (x - 3 / 2 + filterX + widht) % widht;
                            int imageY = (y - 3 / 2 + filterY + height) % height;
                            Color newimageColor = newBitmap.GetPixel(imageX, imageY);
                            red += newimageColor.R * Kernel[filterX, filterY];
                            green += newimageColor.G * Kernel[filterX, filterY];
                            blue += newimageColor.B * Kernel[filterX, filterY];
                        }
                        int r = Math.Min(Math.Max((int)red, 0), 255);
                        int g = Math.Min(Math.Max((int)green, 0), 255);
                        int b = Math.Min(Math.Max((int)blue, 0), 255);

                        result[x, y] = Color.FromArgb(r, g, b);
                    }
                }
            }

            //------------------------ Calculation new image ----------------------
            for (int i = 0; i < widht; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    gaussianBlurImage5x5.SetPixel(i, j, result[i, j]);
                }
            }
            pictureBox1.Image = gaussianBlurImage5x5;
        }

        private void OriginalImage_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = file;
        }
    }
}