using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.ImgHash;
using Emgu.CV.Structure;

namespace ImageExplorer
{
    public partial class PHashCompare : UserControl
    {
        OpenFileDialog ofd = new OpenFileDialog();
        Mat image1;
        Mat image2;
        PHash alg = new PHash();
        public PHashCompare()
        {
            InitializeComponent();
        }

        private void btnImg1_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image1 = new Mat(ofd.FileName);
                lblImgPath1.Text = "Image1 Path: " + ofd.FileName;
            }
        }

        private void btnImg2_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image2 = new Mat(ofd.FileName);
                lblImgPath2.Text = "Image2 Path: " + ofd.FileName;
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            if (image1 != null && image2 != null)
            {
                IInputArray hashOne =  getPhashValue(image1);
                IInputArray hashTwo = getPhashValue(image2);
                double result  = alg.Compare(hashOne, hashTwo);
                lblResult.Text = "Result: " + result;
            }
            else
            {
                MessageBox.Show("Please import the image.", "Please");
            }
        }

        private Mat getPhashValue(Mat mat)
        {
            var hashResult = new Mat();
            //Compute the hash
            alg.Compute(mat, hashResult);
            return hashResult;
        }
    }
}
