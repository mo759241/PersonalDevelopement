using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter06_Practice
{
    class Que
    {
        private char[] charQue;          // キューの要素を保持する配列
        private int putIndex, getIndex;  // キューの要素をputしたりgetするときの添え字


        /// <summary>
        /// コンストラクタ - 要素数を指定したキューの初期化
        /// </summary>
        /// <param name="elementNum">非循環キューの要素数</param>
        public Que(int elementNum)
        {
            charQue = new char[elementNum + 1];
            putIndex = getIndex = 0;
        }

        /// <summary>
        /// コンストラクタ - 初期値を指定したキューの初期化
        /// </summary>
        /// <param name="charArray">キューの初期値</param>
        public Que(char[] charArray)
        {
            /* 
             * 配列は参照型変数であるため、charArrayを直接代入すると呼び出し元の実引数の値も変わってしまう。
             * したがって、新たに配列を作成してそこに値を代入する。
            */
            charQue = new char[charArray.Length + 1];
            putIndex = getIndex = 0;

            for (var i = 0; i < charArray.Length; i++)
                PutCharQue(charArray[i]);
        }

        /// <summary>
        /// コンストラクタ - Queインスタンスのコピーを作成
        /// </summary>
        /// <param name="que">コピー元のQueインスタンス</param>
        public Que(Que que)
        {
            getIndex = que.getIndex;
            putIndex = que.putIndex;
            charQue = new char[que.charQue.Length + 1];

            for (var i = getIndex + 1; i <= putIndex; i++)
                charQue[i] = que.charQue[i];
        }

        /// <summary>
        /// 非循環キューに要素を追加する
        /// </summary>
        /// <param name="value">追加する要素値</param>
        public void PutCharQue(char value)
        {
            if (putIndex == charQue.Length - 1)
            {
                Console.WriteLine("--------- Que is full.");
                return;
            }

            charQue[putIndex] = value;
            putIndex++;
        }

        /// <summary>
        /// 非循環キューの値を取得する
        /// </summary>
        /// <returns>取得した値（取得できなかった場合は0を返す）</returns>
        public char GetCharQue()
        {
            if (getIndex == putIndex)
            {
                Console.WriteLine("--------- Que is empty.");
                return (char)0;
            }

            getIndex++;
            return charQue[getIndex];
        }


    }
}
