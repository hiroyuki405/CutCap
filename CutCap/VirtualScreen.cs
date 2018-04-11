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
    public partial class VirtualScreen : Form
    {
        private static Screen screen;
        private static BorderFrame _borderFrame;
        private static bool _mouseOnKeep;
        private static int _borderTop;
        private static int _borderLeft;

        public VirtualScreen()
        {
            InitializeComponent();
        }

        private void VirtualScreen_Load(object sender, EventArgs e)
        {
            _borderLeft = 0;
            _borderTop = 0;
            _mouseOnKeep = false;
            //this.
        }

        private void VirtualScreen_MouseDown(object sender, MouseEventArgs e)
        {
            _borderLeft = System.Windows.Forms.Cursor.Position.X;
            _borderTop = System.Windows.Forms.Cursor.Position.Y;
            _borderFrame = new BorderFrame();
            _borderFrame.Top = _borderTop;
            _borderFrame.Left = _borderLeft;
            _borderFrame.Show();
            _mouseOnKeep = true;
        }

        private void VirtualScreen_MouseLeave(object sender, EventArgs e)
        {
        }

        private void VirtualScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if(_mouseOnKeep)
            {
                int x = System.Windows.Forms.Cursor.Position.X;
                int y = System.Windows.Forms.Cursor.Position.Y;
                _borderFrame.Width = x - _borderLeft;
                _borderFrame.Height = y - _borderTop;
            }
        }

        private void VirtualScreen_MouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("mouseup");
            //_borderFrame.Close();
        }

        private void VirtualScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_mouseOnKeep)
            {
                _borderFrame.Close();
            }
        }
    }
}
