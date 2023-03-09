using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricCyptology
{
	public class TrippleDes : IEncryptor
	{
		public byte[] Encrypt(byte[] message, byte[] key, byte[] iv)
		{
			using (var tripleDes = new TripleDESCryptoServiceProvider())
			{

				tripleDes.Mode = CipherMode.ECB;
				tripleDes.Padding = PaddingMode.PKCS7;

				tripleDes.Key = key;
				tripleDes.IV = iv;

				using (var memoryStream = new MemoryStream())
				{
					var cryptoStream = new CryptoStream(memoryStream, tripleDes.CreateEncryptor(), CryptoStreamMode.Write);

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
			using (var tripleDes = new TripleDESCryptoServiceProvider())
			{

				tripleDes.Mode = CipherMode.ECB;
				tripleDes.Padding = PaddingMode.PKCS7;

				tripleDes.Key = key;
				tripleDes.IV = iv;

				using (var memoryStream = new MemoryStream())
				{
					var cryptoStream = new CryptoStream(memoryStream, tripleDes.CreateDecryptor(), CryptoStreamMode.Write);

					cryptoStream.Write(message, 0, message.Length);
					cryptoStream.FlushFinalBlock();

					return memoryStream.ToArray();

				}
			}
		}
	}
}
