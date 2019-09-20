using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace base64
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private void EncodeButton_Click(object sender, EventArgs e)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(textBox.Text);
            outputBox.Text =  System.Convert.ToBase64String(plainTextBytes);
        }

        private void DecodeButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(textBox.Text);
                outputBox.Text = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch
            {
                outputBox.Text = "Invaild input";
            }
        }
    }
}
