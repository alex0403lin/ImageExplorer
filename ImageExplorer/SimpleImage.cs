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
using Emgu.CV.ImgHash;
using System.Runtime.InteropServices;

namespace ImageExplorer
{
    public partial class SimpleImage : UserControl
    {
        Image<Bgra, byte> ImgInput;
        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();
        Form1 f1;
        PictureBox pb1 = new PictureBox();
        bool isPHashCompare;
        public SimpleImage(Form1 form1)
        {
            InitializeComponent();
            this.f1 = form1;
            setIntilControl();
        }

        private void setIntilControl()
        {
            panelRomoveControls();
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;
            panel1.Controls.Add(pb1);
            hideThresholdingControls();

        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isPHashCompare)
            {
                setIntilControl();
            }
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                originalImage();
                hideThresholdingControls();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
            sfd.Title = "Save an Image File";
            sfd.FileName = "Image";
            if (isPHashCompare)
            {
                setIntilControl();
            }
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
            if (isPHashCompare)
            {
                setIntilControl();
            }
            if (pb1.Image != null)
            {
                originalImage();
            }
            else
            {
                MessageBox.Show("Please open the image.", "Please");
            }

        }

        private void dropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pb1.Image = null;
            hideThresholdingControls();
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isPHashCompare)
            {
                setIntilControl();
            }
            if (pb1.Image != null)
            {
                Image<Gray, Byte> grayImg = new Image<Gray, byte>(ImgInput.Bitmap);
                pb1.Image = grayImg.ToBitmap();
                hideThresholdingControls();
            }
            else
            {
                MessageBox.Show("Please open the image.", "Please");
            }
        }

        private void thresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isPHashCompare)
            {
                setIntilControl();
            }
            if (pb1.Image != null)
            {
                showThresholdingControls();
                f1.Size = new Size(pb1.Image.Width + 150, pb1.Image.Height + 100);
            }
            else
            {
                MessageBox.Show("Please open the image.", "Please");
            }
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

        private void PHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isPHashCompare)
            {
                setIntilControl();
            }
            if (pb1.Image != null )
            {
                originalImage();
                var alg = new PHash();
                var hashResult = new Mat();
                //Compute the hash
                alg.Compute(ImgInput, hashResult);
        
                // Get the data from the unmanage memeory
                var data = new byte[hashResult.Width * hashResult.Height];
                Marshal.Copy(hashResult.DataPointer, data, 0, hashResult.Width * hashResult.Height);

                // Concatenate the Hex values representation
                var hashHex = BitConverter.ToString(data).Replace("-", string.Empty);
                // hashHex has the hex values concatenation as string;
                toolStripStatusLabel1.Text = "PHash: " + hashHex;
                hideThresholdingControls();
            }
            else
            {
                MessageBox.Show("Please open the image.", "Please");
            }
        }

        private void originalImage()
        {
            ImgInput = new Image<Bgra, byte>(ofd.FileName);
            toolStripStatusLabel1.Text = "Image Path: " + ofd.FileName;
            pb1.Image = ImgInput.Bitmap;
            f1.Size = new Size(pb1.Image.Width + 50, pb1.Image.Height + 100);
        }

        private void hideThresholdingControls()
        {
            trackBar1.Hide();
            lblThresholding.Hide();
        }

        private void showThresholdingControls()
        {
            trackBar1.Show();
            lblThresholding.Show();
        }

        private void panelRomoveControls()
        {
            panel1.Controls.Clear();
        }

        private void pHashCompareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelRomoveControls();
            PHashCompare phc = new PHashCompare();
            phc.Dock = DockStyle.Fill;
            panel1.Controls.Add(phc);
            f1.Size = new Size(500, 500);
            isPHashCompare = true;
        }
    }
}
