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
	ConsoleKeyInfo key = Console.ReadKey();
	switch (key.Key)
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
if (selectedEncryption == "DES")
{
	var key = rngGenerator.GenerateRandomNumber(8);
	var iv = rngGenerator.GenerateRandomNumber(8);
	DesEncrypter encrypter = new DesEncrypter();
    Console.WriteLine($"Oprindelig besked: {original}");
    var encryptedMessage = encrypter.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
    Console.WriteLine($"Kryptered besked: {Convert.ToBase64String(encryptedMessage)}");
    var decryptedMessage = encrypter.Decrypt(encryptedMessage, key, iv);
    Console.WriteLine($"Dekryptered besked: {Encoding.UTF8.GetString(decryptedMessage)}");

}
if (selectedEncryption == "3DES")
{
	var key = rngGenerator.GenerateRandomNumber(16);
	var iv = rngGenerator.GenerateRandomNumber(8);
	TrippleDes encrypter = new TrippleDes();
	Console.WriteLine($"Oprindelig besked: {original}");
	var encryptedMessage = encrypter.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
	Console.WriteLine($"Kryptered besked: {Convert.ToBase64String(encryptedMessage)}");
	var decryptedMessage = encrypter.Decrypt(encryptedMessage, key, iv);
	Console.WriteLine($"Dekryptered besked: {Encoding.UTF8.GetString(decryptedMessage)}");

}
if (selectedEncryption == "AES")
{
	var key = rngGenerator.GenerateRandomNumber(32);
	var iv = rngGenerator.GenerateRandomNumber(16);
	AesEncrypter encrypter = new AesEncrypter();
	Console.WriteLine($"Oprindelig besked: {original}");
	var encryptedMessage = encrypter.Encrypt(Encoding.UTF8.GetBytes(original), key, iv);
	Console.WriteLine($"Kryptered besked: {Convert.ToBase64String(encryptedMessage)}");
	var decryptedMessage = encrypter.Decrypt(encryptedMessage, key, iv);
	Console.WriteLine($"Dekryptered besked: {Encoding.UTF8.GetString(decryptedMessage)}");

}
