using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricCyptology
{
	public class AesEncrypter : IEncryptor
	{
		public byte[] Encrypt(byte[] message, byte[] key, byte[] iv)
		{
			using (var aes = new AesCryptoServiceProvider())
			{

				aes.Mode = CipherMode.ECB;
				aes.Padding = PaddingMode.PKCS7;

				aes.Key = key;
				aes.IV = iv;

				using (var memoryStream = new MemoryStream())
				{
					var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

					cryptoStream.Write(message, 0, message.Length);
					cryptoStream.FlushFinalBlock();

					return memoryStream.ToArray();

				}
				{

				}
			}
		}


		public byte[] Decrypt(byte[] message, byte[] key, byte[] iv)
		{
			using (var aes = new AesCryptoServiceProvider())
			{

				aes.Mode = CipherMode.ECB;
				aes.Padding = PaddingMode.PKCS7;

				aes.Key = key;
				aes.IV = iv;

				using (var memoryStream = new MemoryStream())
				{
					var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

					cryptoStream.Write(message, 0, message.Length);
					cryptoStream.FlushFinalBlock();

					return memoryStream.ToArray();

				}
			}
		}
	}
}
