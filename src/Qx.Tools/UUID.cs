using System;
using System.Security.Cryptography;

namespace Qx.Tools
{
    /// <summary>
    /// Universally unique identifier
    /// </summary>
    public class UUID
    {
        public static string NewUUID()
        {
            return UniqueIdGenerator.Instance().GetBase32UniqueId(10);
        }

        /// <summary>
        /// http://jopinblog.wordpress.com/2009/02/04/a-shorter-friendlier-guiduuid-in-net/
        /// </summary>
        public class UniqueIdGenerator
        {
            private static readonly UniqueIdGenerator _instance;

            private static readonly char[] _characters =
            {
                // 0, 1, O, and I omitted intentionally giving 32 (2^5) symbols
                '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',
                'X', 'Y', 'Z'
            };

            private readonly RNGCryptoServiceProvider _rngCryptoServiceProvider;

            static UniqueIdGenerator()
            {
                _instance = new UniqueIdGenerator();
            }

            private UniqueIdGenerator()
            {
                _rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            }

            public static UniqueIdGenerator Instance()
            {
                return _instance;
            }

            public string GetBase32UniqueId(int numberOfDigits)
            {
                return GetBase32UniqueId(new byte[0], numberOfDigits);
            }

            public string GetBase32UniqueId(byte[] basisBytes, int numberOfDigits)
            {
                int byteCount = 16;

                byte[] randomBytes = new byte[byteCount - basisBytes.Length];
                _rngCryptoServiceProvider.GetBytes(randomBytes);

                byte[] bytes = new byte[byteCount];
                Array.Copy(basisBytes, 0, bytes, byteCount - basisBytes.Length, basisBytes.Length);
                Array.Copy(randomBytes, 0, bytes, 0, randomBytes.Length);

                ulong lo = (((ulong) BitConverter.ToUInt32(bytes, 8)) << 32) | BitConverter.ToUInt32(bytes, 12);
                ulong hi = (((ulong) BitConverter.ToUInt32(bytes, 0)) << 32) | BitConverter.ToUInt32(bytes, 4);
                ulong mask = 0x1F;

                char[] characters = new char[26];
                int characterIndex = 25;

                ulong work = lo;
                for (int i = 0; i < 26; i++)
                {
                    if (i == 12)
                    {
                        work = ((hi & 0x01) << 4) & lo;
                    }
                    else if (i == 13)
                    {
                        work = hi >> 1;
                    }

                    byte digit = (byte) (work & mask);
                    characters[characterIndex] = _characters[digit];
                    characterIndex--;
                    work = work >> 5;
                }

                return new string(characters, 26 - numberOfDigits, numberOfDigits);
            }
        }
    }
}