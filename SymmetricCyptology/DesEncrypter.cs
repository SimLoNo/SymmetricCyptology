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
				
				des.Mode = CipherMode.ECB; // Sets the method to encrypt the individual parts of the message.
				des.Padding = PaddingMode.PKCS7; // Sets the method used to fill blank spots in the text.

				des.Key = key;
				des.IV = iv;

				using (var memoryStream = new MemoryStream())
				{
					var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write); // Sets up a cryptoStream to encrypt the message.

					cryptoStream.Write(message, 0, message.Length); // Encrypts the message
					cryptoStream.FlushFinalBlock(); // flashes the part of the blocks that contains the block keys from RAM.

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
					var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write); // Sets up a cryptoStream to decrypt the message.

					cryptoStream.Write(message, 0, message.Length); // Decrypts the message
					cryptoStream.FlushFinalBlock(); // flashes the part of the blocks that contains the block keys from RAM.

					var decryptedBytes = memoryStream.ToArray();

					return decryptedBytes;

				}
				{

				}
			}
		}
	}
}
