using System;

class EncodeDecode
{
    static void Main()
    {
        string encrypt = Console.ReadLine();
        string cypher = Console.ReadLine();
        string decrypt = string.Empty;

        for (int i = 0; i < encrypt.Length; i++)
        {
            char decryptLetter = (char)(encrypt[i] ^ cypher[i % cypher.Length]);

            decrypt += decryptLetter;
        }
        Console.WriteLine(decrypt);
    }
}
