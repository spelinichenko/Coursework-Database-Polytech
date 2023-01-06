using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace department
{
    static class crypt
    {
        public static string Encode(string text)
        {
            try
            {
                string ourText = text;
                string Return = null;
                string _key = "abcdefgh";
                string privatekey = "hgfedcba";
                byte[] privatekeyByte = { };
                privatekeyByte = Encoding.UTF8.GetBytes(privatekey);
                byte[] _keybyte = { };
                _keybyte = Encoding.UTF8.GetBytes(_key);
                byte[] inputtextbyteArray = System.Text.Encoding.UTF8.GetBytes(text);
                using (DESCryptoServiceProvider dsp = new DESCryptoServiceProvider())
                {
                    var memstr = new MemoryStream();
                    var crystr = new CryptoStream(memstr, dsp.CreateEncryptor(_keybyte, privatekeyByte), CryptoStreamMode.Write);
                    crystr.Write(inputtextbyteArray, 0, inputtextbyteArray.Length);
                    crystr.FlushFinalBlock();
                    return Convert.ToBase64String(memstr.ToArray());
                }
                return Return;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Decode(string text)
        {
            try
            {
                string ourText = text;
                string x = null;
                string _key = "abcdefgh";
                string privatekey = "hgfedcba";
                byte[] privatekeyByte = { };
                privatekeyByte = Encoding.UTF8.GetBytes(privatekey);
                byte[] _keybyte = { };
                _keybyte = Encoding.UTF8.GetBytes(_key);
                byte[] inputtextbyteArray = new byte[ourText.Replace(" ", "+").Length];
                //This technique reverses base64 encoding when it is received over the Internet.
                inputtextbyteArray = Convert.FromBase64String(ourText.Replace(" ", "+"));
                using (DESCryptoServiceProvider dEsp = new DESCryptoServiceProvider())
                {
                    var memstr = new MemoryStream();
                    var crystr = new CryptoStream(memstr, dEsp.CreateDecryptor(_keybyte, privatekeyByte), CryptoStreamMode.Write);
                    crystr.Write(inputtextbyteArray, 0, inputtextbyteArray.Length);
                    crystr.FlushFinalBlock();
                    return Encoding.UTF8.GetString(memstr.ToArray());
                }
                return x;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
