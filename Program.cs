using System;
using System.Security.Cryptography;
using System.Text;

namespace codenation_criptografia_kroton
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultEncrypt = JulioCesarEncryption(" a ligeira raposa marrom saltou sobre o cachorro cansado", 5);
            System.Console.WriteLine(resultEncrypt);
            byte[] data = Encoding.ASCII.GetBytes(resultEncrypt);

            foreach (var item in data)
            {
                System.Console.WriteLine(item);
            }


            System.Console.WriteLine(data);
            byte[] result;
            SHA1 shaM = new SHA1Managed();
            result = shaM.ComputeHash(data);
            SHA1 sha = new SHA1CryptoServiceProvider(); 
            result = sha.ComputeHash(data);

            System.Console.WriteLine(result);
            string hashString = string.Empty;
            foreach (var item in result)
            {
                hashString+=string.Format("{0:x2}", item);
            }

            System.Console.WriteLine(hashString);
        }

        static string JulioCesarEncryption(string textToEncrypt, int encryptionInterval)
        {

            StringBuilder textEncrypt = new StringBuilder();

            char[] characterToEncryptArray = textToEncrypt.ToLower().ToCharArray();

            foreach (var character in characterToEncryptArray)
            {
                textEncrypt.Append(EncryptionRule(character, encryptionInterval));
            }

            return textEncrypt.ToString();
        }
        static char EncryptionRule(char characterToEncrypt, int encryptionInterval)
        {
            int encryptedCharacter = 0;
            int asciiCharacterNumber = Convert.ToInt32(characterToEncrypt);
            int normalizedEncryptionInterval = encryptionInterval % 26;
            System.Console.WriteLine($"Resto: {normalizedEncryptionInterval}");

            if (asciiCharacterNumber >= 97 && asciiCharacterNumber <= 122)
            {
                encryptedCharacter = (asciiCharacterNumber + normalizedEncryptionInterval) > 122 ? (asciiCharacterNumber - 26 + normalizedEncryptionInterval) : (asciiCharacterNumber + normalizedEncryptionInterval);
                return Convert.ToChar(encryptedCharacter);
            }
            else
            {
                return characterToEncrypt;
            }


        }
    }
}
