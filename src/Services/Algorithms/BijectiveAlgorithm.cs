using System.Linq;

namespace UrlMinifier.Services.Algorithms
{
    public class BijectiveAlgorithm
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly int Base = Alphabet.Length;

        public string Encode(int value)
        {
            if (value == 0) return Alphabet[0].ToString();

            var result = string.Empty;
            while (value > 0)
            {
                result += Alphabet[value % Base];
                value = value / Base;
            }

            return string.Join(string.Empty, result.Reverse());
        }

        public int Decode(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return -1;

            var result = 0;
            foreach (var item in value)
            {
                result = result * Base + Alphabet.IndexOf(item);
            }

            return result;
        }
    }
}
