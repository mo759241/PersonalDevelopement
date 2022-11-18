using System;

namespace Chapter05_Practice
{
    class Code
    {
        public string StringEncode(string str, string key)
        {
            var keyLength = key.Length;
            var encodedStr = "";

            Console.WriteLine("message：" + str);
            for (var i = 0; i < str.Length; i++)
                encodedStr += (char)(str[i] ^ key[i % keyLength]);
            Console.WriteLine("Encoded Message：" + encodedStr);

            return encodedStr;
        }

        public string StringDecode(string str, string key)
        {
            var keyLength = key.Length;
            var decodedStr = "";

            for (var i = 0; i < str.Length; i++)
                decodedStr += (char)(str[i] ^ key[i % keyLength]);
            Console.WriteLine("Decoded Message：" + decodedStr);
            return decodedStr;
        }
    }
}
