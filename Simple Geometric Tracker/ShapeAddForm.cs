using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Simple_Geometric_Tracker
{
    public partial class ShapeAddForm : Form
    {

        private string baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Shape List");
        public ShapeAddForm()
        {
            InitializeComponent();
        }

        private void txtSides_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string shapeName = txtShapeName.Text.Trim();
            string sidesText = txtSides.Text.Trim();

            if (string.IsNullOrEmpty(shapeName) || !int.TryParse(sidesText, out int sides))
            {
                MessageBox.Show("Please enter a valid shape name and number of sides.");
                return;
            }

            // Ensure folder exists
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }

            string xmlPath = Path.Combine(baseDirectory, "shapes.xml");

            XElement root;
            if (File.Exists(xmlPath))
            {
                root = XElement.Load(xmlPath);
            }
            else
            {
                root = new XElement("Shapes");
            }

            // Avoid duplicates
            bool exists = root.Elements("Shape")
                .Any(el => el.Element("Name")?.Value.Equals(shapeName, StringComparison.OrdinalIgnoreCase) == true);

            if (exists)
            {
                MessageBox.Show("This shape already exists.");
                return;
            }

            XElement newShape = new XElement("Shape",
                new XElement("Name", shapeName),
                new XElement("Sides", sides)
            );

            root.Add(newShape);
            root.Save(xmlPath);

            MessageBox.Show("Shape saved successfully.");
            this.Close();
        }
    }
}
