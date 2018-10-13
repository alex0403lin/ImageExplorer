using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageExplorer
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        SimpleImage si; 
        public Form1()
        {
            InitializeComponent();
            si = new SimpleImage(this);
            si.Dock = DockStyle.Fill;
            panel1.Controls.Add(si);
        }

    }
}
