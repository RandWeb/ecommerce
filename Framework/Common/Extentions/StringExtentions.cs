using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Extentions
{
    public static class StringExtentions
    {
        public static string AesEncrypt(this string txt,string key)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("Key Cannot be null");
            return EncryptProvider.AESEncrypt(txt,key);
        }
        public static string AesDecrypt(this string txt,string key)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException("Key Cannot be null");
            return EncryptProvider.AESDecrypt(txt,key);
        }
    }
}
