using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Simple_Geometric_Tracker
{
    public partial class MainForm : Form
    {

        //Simple Object Detection --

        private string baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Shape List");
        private VideoCapture capture;
        private Mat frame = new Mat();
        private bool videoLoaded = false;

        public MainForm()
        {
            InitializeComponent();
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;
            pbVideo.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void loadVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Video Files|*.mp4;*.avi;*.mov;*.mkv";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                capture?.Dispose();
                capture = new VideoCapture(openFileDialog1.FileName);

                if (!capture.IsOpened)
                {
                    MessageBox.Show("Could not open video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                videoLoaded = true;
                MessageBox.Show("Video loaded. Click 'Start Tracking' to begin.", "Ready");
            }
        }

        private void selecLoadPicturToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            capture.Read(frame);
            if (frame.IsEmpty)
            {
                timer1.Stop();
                return;
            }

            Image<Bgr, byte> image = frame.ToImage<Bgr, byte>();

            // Preprocessing
            var gray = image.Convert<Gray, byte>();
            var thresh = gray.ThresholdBinary(new Gray(100), new Gray(255));
            var inverted = thresh.Not();
            image.SetValue(new Bgr(0, 0, 0), inverted);

            var contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
            CvInvoke.FindContours(thresh, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            int targetSides = GetSelectedShapeSides();
            if (targetSides < 0) return;

            string selectedShape = cbShape.SelectedItem?.ToString();

            for (int i = 0; i < contours.Size; i++)
            {
                var contour = contours[i];
                double area = CvInvoke.ContourArea(contour);
                if (area < 500) continue;

                // Simplify shape
                var hull = new Emgu.CV.Util.VectorOfPoint();
                CvInvoke.ConvexHull(contour, hull, true);

                var approx = new Emgu.CV.Util.VectorOfPoint();
                double epsilon = 0.04 * CvInvoke.ArcLength(hull, true);
                CvInvoke.ApproxPolyDP(hull, approx, epsilon, true);

                int vertices = approx.Size;

                if (targetSides == 0)
                {
                    double perimeter = CvInvoke.ArcLength(contour, true);
                    double circularity = 4 * Math.PI * area / (perimeter * perimeter);

                    if (vertices < 8 || circularity < 0.75)
                        continue;
                }
                else
                {
                    if (vertices != targetSides)
                        continue;

                    // Square special check
                    if (targetSides == 4 && selectedShape.Equals("Square", StringComparison.OrdinalIgnoreCase))
                    {
                        Point[] pts = approx.ToArray();
                        double[] sides = new double[4];
                        for (int j = 0; j < 4; j++)
                        {
                            double dx = pts[(j + 1) % 4].X - pts[j].X;
                            double dy = pts[(j + 1) % 4].Y - pts[j].Y;
                            sides[j] = Math.Sqrt(dx * dx + dy * dy);
                        }

                        double avg = sides.Average();
                        bool isSquare = sides.All(s => Math.Abs(s - avg) <= avg * 0.1);
                        if (!isSquare) continue;
                    }
                }

                // Draw result
                CvInvoke.Polylines(image, approx, true, new MCvScalar(0, 255, 0), 2);
                Point labelPoint = approx[0];
                CvInvoke.PutText(image, selectedShape, labelPoint, FontFace.HersheySimplex, 0.6, new MCvScalar(0, 0, 255), 2);
            }

            pbVideo.Image?.Dispose();
            pbVideo.Image = image.ToBitmap();
        }

        private void btnStartTracking_Click(object sender, EventArgs e)
        {
            if (!videoLoaded || capture == null)
            {
                MessageBox.Show("Please load a video first using File > Open.", "No Video Loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbShape.SelectedItem == null)
            {
                MessageBox.Show("Please select a shape to detect.", "No Shape Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Rewind
            capture.Set(CapProp.PosFrames, 0);

            timer1.Start();
        }

        private void cbShape_Click(object sender, EventArgs e)
        {
            LoadShapeList();
        }

        private void LoadShapeList()
        {
            cbShape.Items.Clear();
            string xmlPath = Path.Combine(baseDirectory, "shapes.xml");

            if (!File.Exists(xmlPath)) return;

            XElement root = XElement.Load(xmlPath);

            foreach (var shape in root.Elements("Shape"))
            {
                string name = shape.Element("Name")?.Value;
                if (!string.IsNullOrEmpty(name))
                {
                    cbShape.Items.Add(name);
                }
            }

            if (cbShape.Items.Count > 0)
                cbShape.SelectedIndex = 0;
        }

        private int GetSelectedShapeSides()
        {
            string selectedShape = cbShape.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedShape)) return -1;

            string xmlPath = Path.Combine(baseDirectory, "shapes.xml");
            if (!File.Exists(xmlPath)) return -1;

            XElement root = XElement.Load(xmlPath);
            var match = root.Elements("Shape")
                .FirstOrDefault(el => el.Element("Name")?.Value == selectedShape);

            if (match != null && int.TryParse(match.Element("Sides")?.Value, out int sides))
                return sides;

            return -1;
        }

        private void addShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShapeAddForm shapeForm = new ShapeAddForm();
            shapeForm.ShowDialog();
            LoadShapeList();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtFrameRate.Text.Trim(), out int fps) && fps > 0)
            {
                timer1.Interval = 1000 / fps;
                MessageBox.Show($"Frame rate set to {fps} FPS (Interval: {timer1.Interval} ms)", "Frame Rate Updated");
            }
            else
            {
                MessageBox.Show("Please enter a valid number greater than 0.", "Invalid Frame Rate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
