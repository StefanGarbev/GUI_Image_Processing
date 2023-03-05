namespace GUI_Image_Processing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Open = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SharpFilter = new System.Windows.Forms.Button();
            this.blur3x3Filter = new System.Windows.Forms.Button();
            this.blur5x5Filter = new System.Windows.Forms.Button();
            this.OriginalImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(12, 12);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(75, 23);
            this.Open.TabIndex = 0;
            this.Open.Text = "Open";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(110, 12);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 397);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "PPM|*.ppm|PNG|*.png|JPG|*.jpg";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "PPM|*.ppm|PNG|*.png|JPG|*.jpg";
            // 
            // SharpFilter
            // 
            this.SharpFilter.Location = new System.Drawing.Point(211, 12);
            this.SharpFilter.Name = "SharpFilter";
            this.SharpFilter.Size = new System.Drawing.Size(75, 23);
            this.SharpFilter.TabIndex = 3;
            this.SharpFilter.Text = "Sharp Filter";
            this.SharpFilter.UseVisualStyleBackColor = true;
            this.SharpFilter.Click += new System.EventHandler(this.SharpFilter_Click);
            // 
            // blur3x3Filter
            // 
            this.blur3x3Filter.Location = new System.Drawing.Point(312, 12);
            this.blur3x3Filter.Name = "blur3x3Filter";
            this.blur3x3Filter.Size = new System.Drawing.Size(75, 23);
            this.blur3x3Filter.TabIndex = 4;
            this.blur3x3Filter.Text = "Blur 3x3 Filter";
            this.blur3x3Filter.UseVisualStyleBackColor = true;
            this.blur3x3Filter.Click += new System.EventHandler(this.blur3x3Filter_Click);
            // 
            // blur5x5Filter
            // 
            this.blur5x5Filter.Location = new System.Drawing.Point(404, 12);
            this.blur5x5Filter.Name = "blur5x5Filter";
            this.blur5x5Filter.Size = new System.Drawing.Size(75, 23);
            this.blur5x5Filter.TabIndex = 5;
            this.blur5x5Filter.Text = "Blur 5x5 Filter";
            this.blur5x5Filter.UseVisualStyleBackColor = true;
            this.blur5x5Filter.Click += new System.EventHandler(this.blur5x5Filter_Click);
            // 
            // OriginalImage
            // 
            this.OriginalImage.Location = new System.Drawing.Point(500, 12);
            this.OriginalImage.Name = "OriginalImage";
            this.OriginalImage.Size = new System.Drawing.Size(110, 23);
            this.OriginalImage.TabIndex = 6;
            this.OriginalImage.Text = "Original Image";
            this.OriginalImage.UseVisualStyleBackColor = true;
            this.OriginalImage.Click += new System.EventHandler(this.OriginalImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OriginalImage);
            this.Controls.Add(this.blur5x5Filter);
            this.Controls.Add(this.blur3x3Filter);
            this.Controls.Add(this.SharpFilter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Open);
            this.Name = "Form1";
            this.Text = "GUI Image Processing ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Open;
        private Button Save;
        private PictureBox pictureBox1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private Button SharpFilter;
        private Button blur3x3Filter;
        private Button blur5x5Filter;
        private Button OriginalImage;
    }
}