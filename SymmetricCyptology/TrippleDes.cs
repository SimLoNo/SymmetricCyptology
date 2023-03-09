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

				tripleDes.Mode = CipherMode.ECB; // Sets the method to encrypt the individual parts of the message.
				tripleDes.Padding = PaddingMode.PKCS7; // Sets the method used to fill blank spots in the text.

				tripleDes.Key = key;
				tripleDes.IV = iv;

				using (var memoryStream = new MemoryStream())
				{
					var cryptoStream = new CryptoStream(memoryStream, tripleDes.CreateEncryptor(), CryptoStreamMode.Write); // Sets up a cryptoStream to encrypt the message.

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
			using (var tripleDes = new TripleDESCryptoServiceProvider())
			{

				tripleDes.Mode = CipherMode.ECB; // Sets the method to encrypt the individual parts of the message.
				tripleDes.Padding = PaddingMode.PKCS7; // Sets the method used to fill blank spots in the text.

				tripleDes.Key = key;
				tripleDes.IV = iv;

				using (var memoryStream = new MemoryStream())
				{
					var cryptoStream = new CryptoStream(memoryStream, tripleDes.CreateDecryptor(), CryptoStreamMode.Write); // Sets up a cryptoStream to decrypt the message.

					cryptoStream.Write(message, 0, message.Length); // Decrypts the message
					cryptoStream.FlushFinalBlock(); // flashes the part of the blocks that contains the block keys from RAM.

					return memoryStream.ToArray();

				}
			}
		}
	}
}
