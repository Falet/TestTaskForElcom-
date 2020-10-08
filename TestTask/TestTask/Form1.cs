using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TestTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Iinput InputURL = new InputXML();
            InputURL.InputDataUsingURL("https://raw.githubusercontent.com/kizeevov/elcomplusfiles/main/config.xml");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Button helloButton = new Button();
            helloButton.Location = new System.Drawing.Point(100, 100);
            helloButton.Text = "Привет";
            this.Controls.Add(helloButton);
            textBox1.Text = "Привет";
        }
    }
}
