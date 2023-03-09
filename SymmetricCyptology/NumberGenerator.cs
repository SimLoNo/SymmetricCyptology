using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SymmetricCyptology
{
	public class NumberGenerator
	{
		public byte[] GenerateRandomNumber(int lenght) // A method that generates random numbers for the encryption key and iv.
		{
			using (var cryptologySergvice = new RNGCryptoServiceProvider()) 
			{
				var randomNumber = new byte[lenght]; // Instanciate the byte array that keeps the generated number, with the assigned length.
				cryptologySergvice.GetBytes(randomNumber); // Generates the random number
				return randomNumber;
			}
		}
	}
}
