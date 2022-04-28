namespace RsaImplementation.Abstract;

public interface IAsymEncrypter
{
    /// <summary>
    /// Encrypt clear text
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    string Encrypt(string text);
    /// <summary>
    /// Decrypt encrypted text
    /// </summary>
    /// <param name="encryptedText"></param>
    /// <returns></returns>
    string Decrypt(string encryptedText);
}