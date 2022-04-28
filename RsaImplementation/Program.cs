// See https://aka.ms/new-console-template for more information
// public key 

using RsaImplementation.Abstract;
using RsaImplementation.Implementation;

string publicKey = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCNkjiSpdMk6q/o5VGnV5NZDIcnweYyioQOc0eZgvlgM0CGk50y7t1zJqGmFd7YrA0l9DUzOo/tyi9tXCsnS9sw8tkHgRhTsNVernBmVW0GcTgLjxbOW+q8wxtcBNwueBVPxDlHUwi/ouI6eaVx2nqfUgKZPWhyN7kf5/4Xj+o83QIDAQAB";
string privateKey = @"MIICdQIBADANBgkqhkiG9w0BAQEFAASCAl8wggJbAgEAAoGBAI2SOJKl0yTqr+jlUadXk1kMhyfB5jKKhA5zR5mC+WAzQIaTnTLu3XMmoaYV3tisDSX0NTM6j+3KL21cKydL2zDy2QeBGFOw1V6ucGZVbQZxOAuPFs5b6rzDG1wE3C54FU/EOUdTCL+i4jp5pXHaep9SApk9aHI3uR/n/heP6jzdAgMBAAECgYBSqCTPunHlBAFhAUMDaWZmf6IJ3HQC3kzsAvKy9n2TZVkvOdB2hHBXYx7OUcaiyxGCL2tAVdjjBUFboIyxjOCUe93qmuqYJ5+csYKMJQrUyJsLVVgRmp1l+3U0Ig1aI2XyuMK11O4axC8Y9SrrNuJKmiWWIVyh13vAwH/o5QCXIQJBANYgo44btFAmEuWH1D5lWuvU7AnHbvm+D1cEqgxchzzELlyOCEmO+REwcvRThMeoo5f/rp4xy1KnlYcTIaFg85sCQQCpQV2gvai6tjmiDlHrM5mfFE+inipTCMJzdBhrIn7RIH2iL8dBU8bElQ6EYlrj82zYJL25J1Ks/hwzNHAy4ATnAkB3slkbSFtcblwj2PEJTCkuKaEkukpL6zWyBBZ2wIaMrnHoJTF2xShvtnCcKc/QuHFyt2fKYLVy5+FLV6N2Dbc/AkADkGDMVbIL3HJyOyL2dOuzMdZLclEp1nFhxPwOpXdOKAT9OUxUz9LLqOfZWcjYK/QKyRtFntJa2i711RDXwWfZAkBX64yhBhKXpIs/YklJNSbtSvfBd9JbRmN7B/zASmyh5OBuQ1fKwADUtXHh0Xeru2AOOm8gicrEwpA21S3HsPy6";
// key size
int keySize = 1024;

// Initializes the Rsa encrypter
IAsymEncrypter rsaEncrypter = new RsaEncrypter(publicKey, privateKey, keySize);
// Text to encrypt
string text = "";
Console.WriteLine("Enter text to encrypt ");
text = Console.ReadLine();
//Console.WriteLine(""+text);
// Encrypt text
string encryptedText = rsaEncrypter.Encrypt(text);
// Print encrypted text
Console.WriteLine("The encrypted text is: "+encryptedText);
// Decrypt text
string decryptedText = rsaEncrypter.Decrypt(encryptedText);
// Print decrypted text
Console.WriteLine("The decrypted text is: "+decryptedText);