using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator
{
    public static class Generator
    {
        private static readonly Random Random = new Random();

        public static string GeneratePassword()
        {
            var len = Random.Next(6, 21);

            var password = new char[len];

            var permutation = RandomSet(len, len).ToArray();
            
            // underscore
            password[permutation[0]] = '_';
            password[permutation[1]] = RandomLetter(true);
            password[permutation[2]] = RandomLetter(true);

            for (var i = 3; i < Math.Min(len, 8); i++)
            {
                var idx = permutation[i];
                if (!(idx > 0 && char.IsDigit(password[idx - 1]) || idx + 1 < len && char.IsDigit(password[idx + 1])))
                {
                    password[idx] = RandomDigit();
                }
            }

            for (var i = 0; i < len; i++)
            {
                if (password[i] == default)
                {
                    password[i] = RandomLetter();
                }
            }

            return new string(password);
        }

        private static char RandomDigit()
        {
            return (char)('0' + Random.Next(10));
        }
        private static char RandomLetter(bool upper = false)
        {
            int first = upper ? 'A' : 'a';
            return (char)(first + Random.Next(26));
        }

        private static IEnumerable<int> RandomSet(int n, int k)
        {
            var randomSet = Enumerable.Range(0, k)
                .Select(_ => Random.Next(n - k))
                .OrderBy(i => i)
                .Select((i, idx) => i + idx)
                .OrderBy(_ => Random.Next()); // random shuffle

            return randomSet;
        }
    }
}