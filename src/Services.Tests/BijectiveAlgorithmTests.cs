using Xunit;

namespace UrlMinifier.Services.Tests
{
    public class BijectiveAlgorithmTests
    {
        private static readonly BijectiveAlgorithm BijectiveAlgorithm = new BijectiveAlgorithm();

        [Theory]
        [InlineData(-1, "")]
        [InlineData(0, "a")]
        [InlineData(1, "b")]
        [InlineData(61, "9")]
        [InlineData(62, "ba")]
        [InlineData(63, "bb")]
        [InlineData(19158, "e9a")]
        public void EncodeTest(int value, string expectedResult)
        {
            var result = BijectiveAlgorithm.Encode(value);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("", -1)]
        [InlineData("a", 0)]
        [InlineData("b", 1)]
        [InlineData("9", 61)]
        [InlineData("ba", 62)]
        [InlineData("bb", 63)]
        [InlineData("e9a", 19158)]
        public void DecodeTest(string value, int expectedResult)
        {
            var result = BijectiveAlgorithm.Decode(value);

            Assert.Equal(expectedResult, result);
        }
    }
}
