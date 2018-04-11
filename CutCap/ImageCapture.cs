using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace CutCap
{
    class ImageCapture
    {
        private static Point _startPoint;
        private static Point _endPoint;
        //private static Image _image;

        /// <summary>
        /// 描画開始地点
        /// </summary>
        public Point StartPoint {
            set { _startPoint = value; }
            get { return _startPoint; }
        }

        /// <summary>
        /// 描画終了地点
        /// </summary>
        public Point EndPoint
        {
            set { _endPoint = value; }
            get { return _endPoint; }

        }

        public ImageCapture()
        {

        }

        /// <summary>
        /// 座標指定処理
        /// </summary>
        public void SetCaptureImage()
        {
            
        }

        /// <summary>
        /// キャプチャーデータクリア
        /// </summary>
        public void ClearCapture()
        {
            _startPoint = new Point();
            _endPoint = new Point();
        }
        
        /// <summary>
        /// イメージキャプチャー処理
        /// </summary>
        /// <param name="rect">対象範囲</param>
        /// <returns>キャプチャー画像</returns>
        public Image GetCaptureImage()
        {
            // 指定された範囲と同サイズのBitmapを作成する
            int X = _startPoint.X;
            int Y = _startPoint.Y;
            int width = _endPoint.X - _startPoint.X;
            int height = _endPoint.Y - _startPoint.Y;

            Rectangle rect = new Rectangle(X, Y, width, height);
            Image img = new Bitmap(
                            rect.Width,
                            rect.Height,
                            PixelFormat.Format32bppArgb);

            // Bitmapにデスクトップのイメージを描画する
            using (Graphics g = Graphics.FromImage(img))
            {
                g.CopyFromScreen(
                    rect.X,
                    rect.Y,
                    0,
                    0,
                    rect.Size,
                    CopyPixelOperation.SourceCopy);
            }

            return img;
        }

    }
}
