using System;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace TestTask
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Iinput InputURL = new InputXML();
            XElement ReceivedListElemets = InputURL.InputDataUsingURL(textBox1.Text);
            if (ReceivedListElemets != null)
            {
                if (InfoText.Text != "")
                    InfoText.Text = "";
                IParserable ParseXML = new ParserXML();
                IVisualizable VisualisationXML = new VisualisationXML();
                Bitmap Canvas = VisualisationXML.Visualisation(ParseXML.Parse(ReceivedListElemets), 38);
                PictureBoxTree.Size = Canvas.Size;
                PictureBoxTree.Image = Canvas;
            }
            else
            {
                InfoText.Text = "Неправильный URL введите заново";
            }
        }
    }
}
