using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CutCap
{
    public partial class ImageBoard : Form
    {
        private static Image _image;

        public ImageBoard(Image image)
        {
            _image = image;
            InitializeComponent();
        }

        private void ImageBoard_Load(object sender, EventArgs e)
        {
            Bitmap canvas = new Bitmap(_image.Width, _image.Height);

            Graphics g = Graphics.FromImage(canvas);

            g.DrawImage(_image, 0, 0, _image.Width, _image.Height);
            //Imageオブジェクトのリソースを解放する
            _image.Dispose();
            g.Dispose();
            pictureBox1.Image = canvas;
        }
    }
}
