using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace TestTask
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Button helloButton = new Button();
            helloButton.Location = new Point(100, 100);
            helloButton.Text = "Привет";
            this.Controls.Add(helloButton);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Iinput InputURL = new InputXML();
            XElement ReceivedListElemets = InputURL.InputDataUsingURL(textBox1.Text);
            if (ReceivedListElemets != null)
            {
                if(InfoText.Text != "")
                    InfoText.Text = "";
                IParserable ParseXML = new ParserXML();
                IVisualizable VisualisationXML = new VisualisationXML();
                Bitmap bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
                Bitmap asd = VisualisationXML.Visualisation(ParseXML.Parse(ReceivedListElemets), bmp);
                pictureBox1.Size = asd.Size;
                pictureBox1.Image = asd;
            }
            else
            {
                InfoText.Text = "Неправильный URL введите заново";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
