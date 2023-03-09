using SymmetricCyptology;
using System.Text;

Console.WriteLine("Indtast den besked du ønsker at kryptere.");
string original = Console.ReadLine();
string selectedEncryption = null;

do
{
	Console.Clear();
	Console.WriteLine("Indtast hvilken algorithme du vil kryptere med.");
	Console.WriteLine("1: DES");
	Console.WriteLine("2: 3DES");
	Console.WriteLine("3: AES");
	ConsoleKeyInfo SelectedOption= Console.ReadKey();
	switch (SelectedOption.Key)
	{
		case ConsoleKey.D1:
			selectedEncryption = "DES";
			break;
		case ConsoleKey.D2:
			selectedEncryption = "3DES";
			break;
		case ConsoleKey.D3:
			selectedEncryption = "AES";
			break;

		default:
			break;
	}

} while (selectedEncryption is null);
Console.Clear();
NumberGenerator rngGenerator = new NumberGenerator();
IEncryptor encryptor = null;
byte[] key = null;
byte[] iv = null;
if (selectedEncryption == "DES")
{
	key = rngGenerator.GenerateRandomNumber(8);
	iv = rngGenerator.GenerateRandomNumber(8);
	encryptor = new DesEncrypter();

}
if (selectedEncryption == "3DES")
{
	key = rngGenerator.GenerateRandomNumber(16);
	iv = rngGenerator.GenerateRandomNumber(8);
	encryptor = new TrippleDes();

}
if (selectedEncryption == "AES")
{
	key = rngGenerator.GenerateRandomNumber(32);
	iv = rngGenerator.GenerateRandomNumber(16);
	encryptor = new AesEncrypter();

}



Console.WriteLine($"Oprindelig besked: {original}");
var encryptedMessage = encryptor.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
Console.WriteLine($"Kryptered besked: {Convert.ToBase64String(encryptedMessage)}");

bool DecryptionAnswered = false;
string decryptedMessage = "";
do
{
	Console.WriteLine("Vil du dekryptere beskeden? \n 1: Ja \n 2: Nej");
	ConsoleKeyInfo keyInfo = Console.ReadKey();
	Console.WriteLine();
	switch (keyInfo.Key)
	{
		case ConsoleKey.D1:
			DecryptionAnswered = true;
			var decryptedBytes = encryptor.Decrypt(encryptedMessage, key, iv);
			decryptedMessage = Encoding.UTF8.GetString(decryptedBytes);
			break;
		case ConsoleKey.D2:
			DecryptionAnswered = true;
			break;
		default:
			break;
	}

} while (DecryptionAnswered == false);

if (decryptedMessage != "")
{
	Console.WriteLine($"Dekryptered besked: {decryptedMessage}");
}
