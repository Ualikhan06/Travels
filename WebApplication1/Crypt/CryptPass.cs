using System.Text;

namespace WebApplication1.Crypt
{
    public class CryptPass
    {
        //шифрование
        public string Encod(string password)
        {
            try
            {
                byte[] encByte = new byte[password.Length];
                encByte = Encoding.UTF8.GetBytes(password);
                string CryptoPass = Convert.ToBase64String(encByte);
                return CryptoPass;

            }
            catch (Exception e)
            {

                throw new Exception("Error in encode" + e.Message);
            }
        }
    }
}
