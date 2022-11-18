using Chapter10_Practice;
using System;

namespace Chapter06_Practice
{
    class Stuck
    {
        private char[] charStuck;   // スタックの要素を保持する配列
        private int stuckTopIndex;  // スタックのトップ要素を示すインデックス

        /// <summary>
        /// コンストラクタ - 要素数を指定したスタックの初期化
        /// </summary>
        /// <param name="elementNum">非循環スタックの要素数</param>
        public Stuck(int elementNum)
        {
            charStuck = new char[elementNum];
            stuckTopIndex = 0;
        }

        /// <summary>
        /// コンストラクタ - 初期値を指定したスタックの初期化
        /// </summary>
        /// <param name="charArray">スタックの初期値</param>
        public Stuck(char[] charArray)
        {
            /* 
             * 配列は参照型変数であるため、charArrayを直接代入すると呼び出し元の実引数の値も変わってしまう。
             * したがって、新たに配列を作成してそこに値を代入する。
            */
            charStuck = new char[charArray.Length];
            stuckTopIndex = 0;

            for (var i = 0; i < charArray.Length; i++)
                PushCharStuck(charArray[i]);
        }

        /// <summary>
        /// コンストラクタ - Stuckインスタンスのコピーを作成
        /// </summary>
        /// <param name="stuck">コピー元のStuckインスタンス</param>
        public Stuck(Stuck stuck)
        {
            stuckTopIndex = stuck.stuckTopIndex;
            charStuck = new char[stuck.charStuck.Length];

            for (var i = 0; i <= stuckTopIndex; i++)
                charStuck[i] = stuck.charStuck[i];
        }

        /// <summary>
        /// 非循環スタックに要素を追加する
        /// </summary>
        /// <param name="value">追加する要素値</param>
        public void PushCharStuck(char value)
        {
            if (stuckTopIndex == charStuck.Length)
                throw new FullStackException();

            charStuck[stuckTopIndex] = value;
            stuckTopIndex++;
        }

        /// <summary>
        /// 非循環スタックの値を取得する
        /// </summary>
        /// <returns>取得した値（取得できなかった場合は0を返す）</returns>
        public char PopCharStuck()
        {
            if (stuckTopIndex == 0)
                throw new EmptyStackException();

            stuckTopIndex--;
            return charStuck[stuckTopIndex];
        }


    }
}
