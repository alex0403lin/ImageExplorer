using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace ImageExplorer
{
    public partial class SimpleImage : UserControl
    {
        Image<Bgra, byte> ImgInput;
        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();
        Form1 f1;
        PictureBox pb1;
        public SimpleImage(Form1 form1)
        {
            InitializeComponent();
            this.f1 = form1;
            setIntilControl();
        }

        private void setIntilControl()
        {
            pb1 = new PictureBox();
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;
            panel1.Controls.Add(pb1);
            trackBar1.Hide();
            lblThresholding.Hide();

        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ImgInput = new Image<Bgra, byte>(ofd.FileName);
                toolStripStatusLabel1.Text = "Image Path: " + ofd.FileName;
                pb1.Image = ImgInput.Bitmap;
                f1.Size = new Size(pb1.Image.Width+50, pb1.Image.Height + 100);
                trackBar1.Hide();
                lblThresholding.Hide();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
            sfd.Title = "Save an Image File";
            sfd.FileName = "Image";
            if (pb1.Image != null)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    switch (sfd.FilterIndex)
                    {
                        case 1:
                            pb1.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 2:
                            pb1.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case 3:
                            pb1.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case 4:
                            pb1.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please open the image.", "Please");
            }
        }

        private void originalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pb1.Image != null)
            {
                ImgInput = new Image<Bgra, byte>(ofd.FileName);
                toolStripStatusLabel1.Text = "Image Path: " + ofd.FileName;
                pb1.Image = ImgInput.Bitmap;
                f1.Size = new Size(pb1.Image.Width + 50, pb1.Image.Height + 100);
                trackBar1.Hide();
                lblThresholding.Hide();
            }
            else
            {
                MessageBox.Show("Please open the image.", "Please");
            }

        }

        private void dropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pb1.Image = null;
            trackBar1.Hide();
            lblThresholding.Hide();
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pb1.Image != null)
            {
                Image<Gray, Byte> grayImg = new Image<Gray, byte>(ImgInput.Bitmap);
                pb1.Image = grayImg.ToBitmap();
                trackBar1.Hide();
                lblThresholding.Hide();
            }
            else
            {
                MessageBox.Show("Please open the image.", "Please");
            }
        }

        private void thresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trackBar1.Show();
            lblThresholding.Show();
            f1.Size = new Size(pb1.Image.Width + 150, pb1.Image.Height + 100);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblThresholding.Text = "Thresholding Value: " + trackBar1.Value.ToString();
            Bitmap bmp = ImgInput.Bitmap;
            //Gray image
            Image<Gray, Byte> GrayImg = new Image<Gray, Byte>(bmp);
            //Threshold value
            double xjThreshold = (double)this.trackBar1.Value;
            var xjImageBinaryzation = GrayImg.CopyBlank();
            CvInvoke.Threshold(GrayImg, xjImageBinaryzation, xjThreshold, 255, ThresholdType.Binary);
            //show picturebox
            this.pb1.Image = xjImageBinaryzation.ToBitmap();
        }
    }
}
