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
		public byte[] GenerateRandomNumber(int lenght)
		{
			using (var cryptologySergvice = new RNGCryptoServiceProvider()) 
			{
				var randomNumber = new byte[lenght];
				cryptologySergvice.GetBytes(randomNumber);
				return randomNumber;
			}
		}
	}
}
