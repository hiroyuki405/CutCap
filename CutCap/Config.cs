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

using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace CutCap
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }
        

        private void Config_Load(object sender, EventArgs e)
        {
            this.checkBox_wakeup.Checked = CheckStartUp();
            this.textBox_savepath.Text = Properties.Settings.Default.save_path.ToString();

        }
        
        private void button_dialog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "フォルダを指定してください。";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                string filePath = fbd.SelectedPath;
                this.textBox_savepath.Text = filePath;
            }
        }

        private void button_Accept_Click(object sender, EventArgs e)
        {
            if(this.checkBox_wakeup.Checked)
            {
                CreateShortCut();
            }
            else
            {
                DeleteShortCut();
            }
            string path = this.textBox_savepath.Text;
            Properties.Settings.Default.save_path = path;
            Properties.Settings.Default.Save();
            MessageBox.Show("設定を保存しました。",
                            "情報",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void DeleteShortCut()
        {
            //スタートアップ登録していなければ処理しない
            if (!CheckStartUp())
                return;

            String ShortcutFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\CutCap.lnk";

            if (!System.IO.File.Exists(ShortcutFilePath))
            {
                return;
            }

            MessageBox.Show("削除");
            System.IO.File.Delete(ShortcutFilePath);
        }

        private void CreateShortCut()
        {
            //スタートアップ登録済みであれば処理しない
            if (CheckStartUp())
                return;

            String ShortcutFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\CutCap.lnk";
            MessageBox.Show(ShortcutFilePath);
            //起動するアプリケーションを指定
            String app = Path.GetFileName(Application.ExecutablePath);
            //WshShellを作成
            MessageBox.Show(app);
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();

            //ショートカットファイルのパスを指定してWshShortcutオブジェクトを作成
            IWshRuntimeLibrary.IWshShortcut ShortcutFile = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(ShortcutFilePath);

            //ショートカットのリンク先 を指定
            ShortcutFile.TargetPath = app;

            //コマンドライン引数を指定
            ShortcutFile.Arguments = "";

            //作業フォルダを指定
            //ショートカットを作成するプログラムを実行したフォルダを指定
            ShortcutFile.WorkingDirectory = Application.StartupPath;

            //ショートカットキーを設定 
            //ShortcutFile.Hotkey = "F3";

            //実行時の大きさを指定（1：通常　3：最大化　7：最小化）
            //ShortcutFile.WindowStyle = 3;

            //コメント 
            ShortcutFile.Description = "";

            //アイコンのパスを指定
            //（自分のEXEファイルのインデックス0のアイコンにする）
            //※指定しなければexeの標準のアイコンになる
            //ShortcutFile.IconLocation = app + ",0";

            //ショートカットファイルを作成する
            ShortcutFile.Save();

            //Wshオブジェクトを破棄する
            System.Runtime.InteropServices.Marshal.ReleaseComObject(ShortcutFile);
        }

        /// <summary>
        /// スタートアップに登録されているか確認する
        /// </summary>
        /// <returns></returns>
        private bool CheckStartUp()
        {
            String ShortcutFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\CutCap.lnk";
            return (System.IO.File.Exists(ShortcutFilePath));
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
