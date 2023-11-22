using KLO128.Calculator.Domain.Models.Entities;
using System.Security.Cryptography;
using System.Text;

namespace KLO128.Calculator.Domain.Services.Impl
{
    public class CryptoDomainService : ICryptoDomainService
    {
        //Fake password
        private readonly string secret;

        public CryptoDomainService(string secret)
        {
            this.secret = secret;
        }

        public string Decrypt(string input)
        {
            using (var aes = Init())
            {
                while (input.Length % 4 != 0)
                {
                    input += '=';
                }

                var bytes = Encoding.UTF8.GetBytes(input);
                return Encoding.UTF8.GetString(aes.CreateDecryptor().TransformFinalBlock(bytes, 0, bytes.Length));
            }
        }

        public string Encrypt(string input)
        {
            using (var aes = Init())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                return Encoding.UTF8.GetString(aes.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
            }
        }

        public string GetBase64String(string input)
        {
            var ret = new StringBuilder();

            ret.Append(Convert.ToBase64String(Encoding.UTF8.GetBytes(input)));

            while (ret.Length % 4 != 0)
            {
                ret.Append('=');
            }

            return ret.ToString();
        }

        public string AsyncEncrypt(string input)
        {
            using (var md5 = AsyncInit())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                return Encoding.UTF8.GetString(md5.ComputeHash(bytes, 0, bytes.Length));
            }
        }

        private MD5 AsyncInit()
        {
            return MD5.Create();
        }

        private Aes Init()
        {
            var aes = Aes.Create();
            if (secret != null)
            {
                var secret = "secretPassword1234";
                //aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Key = Encoding.UTF8.GetBytes(secret).ToArray();
                aes.IV = new byte[] { 0xd, 5, 3, 0xb, 8, 0xa, 7, 7, 8, 9, 1, 2, 0xc, 0xd, 0x11, 0xf };
                aes.Padding = PaddingMode.Zeros;
                aes.Mode = CipherMode.CBC;
            }
            else
            {
                //aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Key = Encoding.UTF8.GetBytes("secretPassword1234").ToArray();
                aes.IV = new byte[] { 0xd, 5, 3, 0xb, 8, 0xa, 7, 7, 8, 9, 1, 2, 0xc, 0xd, 0x11, 0xf };
                aes.Padding = PaddingMode.Zeros;
                aes.Mode = CipherMode.CBC;
            }

            return aes;
        }

        public string GetNewAccessToken(CalcHistory calcHistory)
        {
            return GetBase64String(AsyncEncrypt($"{calcHistory.Guid}|{calcHistory.CreatedDate}"));
        }
    }
}
