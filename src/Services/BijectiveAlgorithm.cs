using System.Linq;

namespace UrlMinifier.Services
{
    public class BijectiveAlgorithm
    {
        public static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static readonly int Base = Alphabet.Length;

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
            var result = -1;

            foreach (var item in value)
            {
                result = result * Base + Alphabet.IndexOf(item);
            }

            return result;
        }
    }
}
