using SymmetricCyptology;
using System.Text;

// The user writes the text they want to have encrypted.
Console.WriteLine("Indtast den besked du ønsker at kryptere.");
string original = Console.ReadLine();
string selectedEncryption = null; // a variable used to contain the selected algorithm below.

do
{
	// The user will select which encryption algorithm they want to use.
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
Console.Clear(); // Cleans up the console.
NumberGenerator rngGenerator = new NumberGenerator(); // Instanciated the RNG generator that will generate the key and iv.
IEncryptor encryptor = null; // A variable used to contain the class of the selected algorithm.
byte[] key = null;
byte[] iv = null;
if (selectedEncryption == "DES") // If the user  selected DES, generate a key and iv, and instanciate the DesEncrypter.
{
	key = rngGenerator.GenerateRandomNumber(8);
	iv = rngGenerator.GenerateRandomNumber(8);
	encryptor = new DesEncrypter();

}
if (selectedEncryption == "3DES") // If the user seleced TripleDes, generate a key and iv, and instanciate the TrippleDes, that I forgot to name encrypter.
{
	key = rngGenerator.GenerateRandomNumber(16);
	iv = rngGenerator.GenerateRandomNumber(8);
	encryptor = new TrippleDes();

}
if (selectedEncryption == "AES") // If the user selected AES, generate key, iv and instanciate the AesEncrypter.
{
	key = rngGenerator.GenerateRandomNumber(32);
	iv = rngGenerator.GenerateRandomNumber(16);
	encryptor = new AesEncrypter();

}



var encryptedMessage = encryptor.Encrypt(Encoding.UTF8.GetBytes(original), key, iv); // Encrypts the original text.

Console.WriteLine($"Oprindelig besked: {original}"); // Writes the original text.
Console.WriteLine($"Kryptered besked: {Convert.ToBase64String(encryptedMessage)}"); // Writed the encrypted text.

bool DecryptionAnswered = false; // This bool keeps track of if the user have selected an answer to the question below.
string decryptedMessage = ""; // A variable to contain the decrypted message.
do
{
	// Asks the user if they want the message decrypted.
	Console.WriteLine("Vil du dekryptere beskeden? \n 1: Ja \n 2: Nej"); 
	ConsoleKeyInfo keyInfo = Console.ReadKey();
	Console.WriteLine(); // makes a new line, after the user selected their option.
	switch (keyInfo.Key)
	{
		case ConsoleKey.D1: // If the user selected to decrypt, decrypt the message.
			DecryptionAnswered = true;
			var decryptedBytes = encryptor.Decrypt(encryptedMessage, key, iv);
			decryptedMessage = Encoding.UTF8.GetString(decryptedBytes);
			break;
		case ConsoleKey.D2: // If the user decided not to decrypt, just continue.
			DecryptionAnswered = true;
			break;
		default:
			break;
	}

} while (DecryptionAnswered == false); // Runs until the user selected to decrypt the message or not.

if (decryptedMessage != "") // If the user selected to decrypt the message, write it out on the console.
{
	Console.WriteLine($"Dekryptered besked: {decryptedMessage}");
}
