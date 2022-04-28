# Rsa algorithm implementing in .net 6
Supports Encryption & Decryption
Takes key and text in string format and Converts them to bytes

    var privateKey = Convert.FromBase64String(_privateKey);
    var publicKeyBytes = Convert.FromBase64String(_publicKey);
    var bytesToEncrypt = Encoding.UTF8.GetBytes(text);
    
Then encrypd by the public key & decrypt by the private key
Returns encrypted text / decrypted text in string format (Base6)

# Encrypt method
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
    
# Decrypt method
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

# N.B: Public key, private key, and key size are initializing the first in the constructor
    
    private readonly string _publicKey;
    private readonly string _privateKey;
    private readonly int _keySize;
    public RsaEncrypter(string publicKey, string privateKey, int keySize)
    {
        _publicKey = publicKey;
        _privateKey = privateKey;
        _keySize = keySize;
    }
