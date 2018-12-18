using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;



namespace FormData.Security
{
    public class UserAccount
    {


        /// <summary>
        /// Generate a SHA Hash for entered value
        /// </summary>
        /// <param name="value">Password to hash</param>
        /// <returns>Hashed Value</returns>
        public static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var bytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(bytes);

            //string builder uses System.Text
            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2")); //convert to two decimals
            }

            return sb.ToString();
        }

        public static int GetUserId()
        {
            var authCookies =  HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(authCookies.Value);

            return Convert.ToInt16(ticket.Name);
        }
    }
}