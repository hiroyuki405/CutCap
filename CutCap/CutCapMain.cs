using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HongliangSoft.Utilities.Gui;
using System.Collections;
using System.Diagnostics;

namespace CutCap
{
    public partial class CutCapMain : Form
    {
        /// <summary>
        /// 処理状態ステート
        /// </summary>
        enum state
        {
            none = 0,
            keyPress,
            mouseDrag,
            mouseDrop,
        }

        /// <summary>
        /// キャプチャーモード
        /// </summary>
        enum mode
        {
            save = 0,
            clip,
        }

        private static KeyboardHook _keyboardHook;
        private static MouseHook _mouseHook;
        private static KeyManager _keyManager;
        private static ArrayList _pressTarget_clip;
        private static ArrayList _pressTarget_save;
        private static ImageCapture _imageCapture;
        private static Image _image;
        private static VirtualScreen[] _virtualScreen;
        private static mode _mode;

        private static state _state;

        public CutCapMain()
        { 
            InitializeComponent();
            _state = state.none;
            _mode = mode.clip;
            _keyboardHook = new KeyboardHook();
            _mouseHook = new MouseHook();
            _pressTarget_clip = new ArrayList();
            _pressTarget_save = new ArrayList();
            _keyManager = new KeyManager();
            _imageCapture = new ImageCapture();
            _keyboardHook.KeyboardHooked += new KeyboardHookedEventHandler(keyboardHook1_KeyboardHooked);
            _mouseHook.MouseHooked += new MouseHookedEventHandler(mouseHook_MouseHooked);

            //後で修正予定
            _pressTarget_clip.Add(162);
            _pressTarget_clip.Add(160);
            _pressTarget_clip.Add(164);
            _pressTarget_clip.Add(52);

            _pressTarget_save.Add(160);
            _pressTarget_save.Add(164);
            _pressTarget_save.Add(52);
            //_PressTarget.Add((int)Keys.C);
        }

        /// <summary>
        /// マウス押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouseHook_MouseHooked(object sender, HongliangSoft.Utilities.Gui.MouseHookedEventArgs e)
        {
            //ドラッグ時
            if(_state == state.keyPress && e.Message == MouseMessage.LDown)
            {
                _imageCapture.StartPoint = e.Point;
                _state = state.mouseDrag;
            }

            //ドロップ時
            if(_state == state.mouseDrag && e.Message == MouseMessage.LUp)
            {
                _state = state.none; //状態ステート更新
                CloseVirtualScreen(); //仮想スクリーンをすべて削除
                _imageCapture.EndPoint = e.Point; //キャプチャの終点を指定
                _image = _imageCapture.GetCaptureImage(); //キャプチャイメージ取得
                _imageCapture.ClearCapture(); //保持しているキャプチャイメージを破棄
                if (_mode == mode.clip)
                {
                    Clipboard.SetDataObject(_image, true); //クリップボードにキャプチャをコピー
                }
                else if(_mode == mode.save)
                {
                    string path = Properties.Settings.Default.save_path;
                    if( path.Length <= 0)
                    {

                        MessageBox.Show("設定から保存先を指定してください。",
                                        "エラー",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        return;
                    }
                    string date = path + "\\" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";
                    
                    _image.Save(date);
                }
                //MessageBox.Show("キャプチャしました");
                //var v = new ImageBoard(_image);
                //v.Show();
            }
        }
        
        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            Application.Exit();
        }

        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var config = new Config();
            config.ShowDialog();
        }

        private void keyboardHook1_KeyboardHooked(object sender, HongliangSoft.Utilities.Gui.KeyboardHookedEventArgs e)
        {
            try
            {
                Debug.Print(e.KeyCode.ToString("d"));
                if(_state != state.none)
                {
                    return;
                }

                if (e.UpDown == KeyboardUpDown.Down)
                {
                    //Debug.Print("keydown"+ e.KeyCode.ToString("d"));
                    _keyManager.addKeyDown(int.Parse(e.KeyCode.ToString("d")));
                }
                if (e.UpDown == KeyboardUpDown.Up)
                {
                    //Debug.Print("keyup" + e.KeyCode.ToString("d"));
                    _keyManager.removeKeyUp(int.Parse(e.KeyCode.ToString("d")));
                }

                //if( _keyManager.searchKeyCode((int)Keys.B))

                //クリップボードにキャプチャ
                if (_keyManager.searchKeyCode(_pressTarget_clip))
                {
                    _state = state.keyPress;
                    _mode = mode.clip;
                    _keyManager.ClearKeyList();
                    //仮想スクリーンを展開する
                    ShowVirtualScreen();
                }

                //フォルダにキャプチャイメージを保存
                else if (_keyManager.searchKeyCode(_pressTarget_save))
                {
                    _state = state.keyPress;
                    _mode = mode.save;
                    _keyManager.ClearKeyList();
                    //仮想スクリーンを展開する
                    ShowVirtualScreen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 仮想スクリーンを展開する。
        /// </summary>
        private void ShowVirtualScreen()
        {
            _virtualScreen = new VirtualScreen[Screen.AllScreens.Count()];
            Screen[] screen = Screen.AllScreens;
            int n = 0;
            foreach(VirtualScreen scrn in _virtualScreen)
            {
                _virtualScreen[n] = new VirtualScreen();
                _virtualScreen[n].Location = screen[n].Bounds.Location;
                _virtualScreen[n].Show();
                n++;
            }
        }

        /// <summary>
        /// 仮想スクリーンを全て閉じる
        /// </summary>
        private void CloseVirtualScreen()
        {
            foreach(VirtualScreen scrn in _virtualScreen)
            {
                scrn.Close();
            }
        }

        private void CutCapMain_Load(object sender, EventArgs e)
        {             
        }
        
    }
}
    