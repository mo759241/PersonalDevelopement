using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chapter11_Practice
{
    class Program
    {
        /// <summary>
        /// ファイルコピー
        /// 構文：Program [from File] [To File]
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program program = new Program();

            if (args.Length != 2)
            {
                Console.WriteLine(@"Syntax Error: Please Enter 'Chapter11_Practice [from File] [To File]'");
                return;
            }

            try
            {
                //// バイトストリームを使用したファイルのコピー
                //program.CopyFileByFileStream(args[0], args[1]);

                // 文字ストリームを使用したファイルのコピー
                program.CopyFileByStream(args[0], args[1]);

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("ファイルないよ");
                Console.WriteLine(ex);
                return;
            }
            catch (IOException ex)
            {
                Console.WriteLine("ファイル読み込めない/書き込めないよ");
                Console.WriteLine(ex);
                return;
            }
        }

        public void CopyFileByFileStream(string fromFileName, string toFileName)
        {
            int readByte;
            // コピー元ファイルのオープン
            using (FileStream fileIn = new FileStream(fromFileName, FileMode.Open))
            using (FileStream fileOut = new FileStream(toFileName, FileMode.Create))
            {
                do
                {
                    // バイト文字をコピー元から読み込む
                    readByte = fileIn.ReadByte();
                    // 読み込んだバイト文字が半角スペースの場合はハイフンに変換する
                    if (char.IsWhiteSpace((char)readByte))
                        readByte = '-';
                    // バイト文字をコピー先に書き込む
                    if (readByte != -1)
                        fileOut.WriteByte((byte)readByte);

                } while (readByte != -1);
            }
        }

        public void CopyFileByStream(string fromFileName, string toFileName)
        {
            int readChar;
            // コピー元ファイルのオープン
            using (StreamReader fileIn = new StreamReader(fromFileName))
            using (StreamWriter fileOut = new StreamWriter(toFileName))
            {
                do
                {
                    // バイト文字をコピー元から読み込む
                    readChar = fileIn.Read();
                    // 読み込んだバイト文字が半角スペースの場合はハイフンに変換する
                    if (char.IsWhiteSpace((char)readChar))
                        readChar = '-';
                    // バイト文字をコピー先に書き込む
                    if (readChar != -1)
                        fileOut.Write((char)readChar);

                } while (readChar != -1);
            }
        }
    }
}
