using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutCap
{
    class SoundPlayer
    {
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern int mciSendString(String command,
        StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        private static string _soundShutter = ".//sound.shutter.mp3";
        private static string _aliasName = "MediaFile";

        public SoundPlayer()
        {

        }

        /// <summary>
        /// カメラのシャッター音を再生する。
        /// </summary>
        public void playShutter()
        {
            string cmd = "open \"" + _soundShutter + "\" type mpegvideo alias " + _aliasName;
            if (mciSendString(cmd, null, 0, IntPtr.Zero) != 0)
                return;

            cmd = "play " + _aliasName;
            mciSendString(cmd, null, 0, IntPtr.Zero);
        }
        
    }
}
