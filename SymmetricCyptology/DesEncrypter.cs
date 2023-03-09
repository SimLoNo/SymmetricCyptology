using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SymmetricCyptology
{
	public class DesEncrypter : IEncryptor
	{
		public byte[] Encrypt(byte[] message, byte[] key, byte[] iv)
		{
			using (var des = new DESCryptoServiceProvider()) {
				
				des.Mode = CipherMode.ECB;
				des.Padding = PaddingMode.PKCS7;

				des.Key = key;
				des.IV = iv;

				using (var memoryStream = new MemoryStream())
				{
					var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);

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
			using (var des = new DESCryptoServiceProvider())
			{

				des.Mode = CipherMode.ECB;
				des.Padding = PaddingMode.PKCS7;

				des.Key = key;
				des.IV = iv;

				using (var memoryStream = new MemoryStream())
				{
					var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write);

					cryptoStream.Write(message, 0, message.Length);
					cryptoStream.FlushFinalBlock();

					var decryptedBytes = memoryStream.ToArray();

					return decryptedBytes;

				}
				{

				}
			}
		}
	}
}
