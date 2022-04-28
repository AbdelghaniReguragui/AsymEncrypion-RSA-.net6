using System.Security.Cryptography;
using System.Text;
using RsaImplementation.Abstract;

namespace RsaImplementation.Implementation;

public class RsaEncrypter : IAsymEncrypter
{
    private readonly string _publicKey;
    private readonly string _privateKey;
    private readonly int _keySize;

    public RsaEncrypter(string publicKey, string privateKey, int keySize)
    {
        _publicKey = publicKey;
        _privateKey = privateKey;
        _keySize = keySize;
    }

    /// <summary>
    /// Encrypt function implementation by RSA algorithm
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public string Encrypt(string text)
    {
        byte[] encrypted;
        var bytesToEncrypt = Encoding.UTF8.GetBytes(text);
        using (var rsa = new RSACryptoServiceProvider(_keySize))
        {
            try
            {
                var publicKeyBytes = Convert.FromBase64String(_publicKey);
                rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);
                encrypted = rsa.Encrypt(bytesToEncrypt, true);
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }

        return Convert.ToBase64String(encrypted);
    }

    /// <summary>
    /// Decrypt function implementation by RSA algorithm
    /// </summary>
    /// <param name="encryptedText"></param>
    /// <returns></returns>
    public string Decrypt(string encryptedText)
    {
        byte[] decryptedData;
        byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        {
            try
            {
                var privateKey = Convert.FromBase64String(_privateKey);
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.ImportPkcs8PrivateKey(privateKey, out _);
                    decryptedData = rsa.Decrypt(dataToDecrypt, true);
                }
            }
            finally
            {
                RSA.PersistKeyInCsp = false;
            }
        }
        return Encoding.UTF8.GetString(decryptedData);
    }
}