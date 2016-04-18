using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Configuration;
using System.Threading.Tasks;

namespace Korsbarsgarden.classes
{
    public enum Supported_HA
    {
        SHA256
    }

    public class Encryption : System.Web.UI.Page
    {
        public string ComputeHash(string text, Supported_HA hash, byte[] salt)
        {
            int minSaltLength = 4;
            int maxSaltLength = 12;

            byte[] SaltBytes = null;

            if (salt != null)
            {
                SaltBytes = salt;
            }
            else
            {
                Random rnd = new Random();
                int SaltLength = rnd.Next(minSaltLength, maxSaltLength);

                SaltBytes = new byte[SaltLength];

                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetNonZeroBytes(SaltBytes);
                rng.Dispose();
            }

            byte[] plainData = ASCIIEncoding.UTF8.GetBytes(text);
            byte[] plainDataAndSalt = new byte[plainData.Length + SaltBytes.Length];

            for (int i = 0; i < plainData.Length; i++)
            {
                plainDataAndSalt[i] = plainData[i];
            }
            for (int j = 0; j < SaltBytes.Length; j++)
            {
                plainDataAndSalt[plainData.Length + j] = SaltBytes[j];
            }

            byte[] hashValue = null;

            switch (hash)
            {
                case Supported_HA.SHA256:
                    SHA256Managed sha = new SHA256Managed();
                    hashValue = sha.ComputeHash(plainDataAndSalt);
                    sha.Dispose();
                    break;
            }

            byte[] result = new byte[hashValue.Length + SaltBytes.Length];

            for (int i = 0; i < hashValue.Length; i++)
            {
                result[i] = hashValue[i];
            }
            for (int j = 0; j < SaltBytes.Length; j++)
            {
                result[hashValue.Length + j] = SaltBytes[j];
            }

            return Convert.ToBase64String(result);
        }

        public bool Confirm(string plainText, string hashValue, Supported_HA hash)
        {
            byte[] hashBytes = Convert.FromBase64String(hashValue);

            int hashSize = 0;

            switch (hash)
            {
                case Supported_HA.SHA256:
                    hashSize = 32;
                    break;
            }

            byte[] saltBytes = new byte[hashBytes.Length - hashSize];

            for (int x = 0; x < saltBytes.Length; x++)
            {
                saltBytes[x] = hashBytes[hashSize + x];
            }

            string NewHash = ComputeHash(plainText, hash, saltBytes);

            return (hashValue == NewHash);
        }
    }
}