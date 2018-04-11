
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace CutCap
{
    /// <summary>
    /// 押下キー管理マネージャー
    /// </summary>
    class KeyManager
    {
        /// <summary>
        /// キーボード押下中のリスト一覧
        /// </summary>
        static private ArrayList _PressKeyListNow;

        private const int LISTSIZE_MAXIMUM = 10;
        
        /// <summary>
        /// キー押下中リストを取得する。
        /// </summary>
        /// <returns></returns>
        public ArrayList getPressKeyList() { return _PressKeyListNow; }

        public KeyManager()
        {
            _PressKeyListNow = new ArrayList();
        }

        /// <summary>
        /// 新しくキーボードを押下したときの処理
        /// </summary>
        /// <param name="keyCode">押下キー</param>
        /// <returns>押下リスト上限フラグ</returns>
        public bool addKeyDown(int keyCode)
        {
            try
            {
                bool exitst = false; //キーリストの有無

                //同時押下数が上限を超えているかチェック
                if (_PressKeyListNow.Count >= LISTSIZE_MAXIMUM)
                {
                    return true;
                }

                //重複チェック
                foreach (int num in _PressKeyListNow)
                {
                    if (keyCode == num)
                    {
                        exitst = true;
                        break;
                    }
                }

                //リスト更新処理
                if (!exitst)
                {
                    Debug.Print("Press: "+keyCode.ToString());
                    _PressKeyListNow.Add(keyCode);
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// キーアップ時に押下キーリストを更新する。
        /// </summary>
        /// <param name="keycode"></param>
        public void removeKeyUp(int keycode)
        {
            bool exitst = false;
            int index = 0;

            //押下リストのキーが離されたらリストから削除する
            foreach (int num in _PressKeyListNow)
            {
                if (keycode == num)
                {
                    exitst = true;
                    break;
                }
                index++;
            }

            if(exitst)
            {
                _PressKeyListNow.RemoveAt(index);
            }
        }
        
        /// <summary>
        /// 押下リストクリア
        /// </summary>
        public void ClearKeyList()
        {
            _PressKeyListNow = new ArrayList();
        }


        /// <summary>
        /// 特定のキーを押下中リストから検索する。
        /// </summary>
        /// <param name="keycode">検索対象キーコード</param>
        /// <returns></returns>
        public bool searchKeyCode(int keycode)
        {
            foreach(int num in _PressKeyListNow)
            {
                if (num == keycode)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 特定のキーを押下中リストから検索する。
        /// </summary>
        /// <param name="keycode">検索対象キーコード</param>
        /// <returns></returns>
        public bool searchKeyCode(ArrayList keycode)
        {
            int count = 0;

            //検索対象がない場合の対策
            if(keycode.Count <= 0)
                return false;
            
            foreach (int num in keycode)
            {
                foreach (int target in _PressKeyListNow)
                {
                    if (target == num)
                    {
                        count++;
                        break;
                    }
                }
            }
            Debug.Print("重複した数：" + count.ToString());
            return (count >= keycode.Count);                
        }
    }
}
