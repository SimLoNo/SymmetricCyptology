using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricCyptology
{
	public interface IEncryptor // Making the encryption based on an interface, to comply with the DRY concept.
	{
		byte[] Encrypt(byte[] message, byte[] key, byte[] iv);
		byte[] Decrypt(byte[] message, byte[] key, byte[] iv);

	}
}
