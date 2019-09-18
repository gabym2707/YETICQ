using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YETI
{
    public static class Seguridad
    {
        public static string Encriptar(this string cadenaEncriptar)
        {
            string result = string.Empty;
            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(cadenaEncriptar);
            result = Convert.ToBase64String(encrypted);
            return result;
        }
        public static string Desencriptar(this string cadenaDesencriptar)
        {
            string result = string.Empty;
            byte[] decrypted = Convert.FromBase64String(cadenaDesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decrypted);
            return result;
        }
    }
}