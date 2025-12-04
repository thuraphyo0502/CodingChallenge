using CodingChallenge.Modules;

namespace CodingChallengeTests.Modules
{
    public class OldPhoneKeyPadTests
    {
        [Fact]
        public void ShouldIgnoreDelaysAndResetKeyPress()
        {
            string input = "222 2 22#";
            string result = OldPhoneKeyPad.ConvertToText(input);
            Assert.Equal("CAB", result);
        }

        [Fact]
        public void ShouldConvertNumbersToLetters()
        {
            string input = "33#";
            string result = OldPhoneKeyPad.ConvertToText(input);
            Assert.Equal("E", result);
        }

        [Fact]
        public void ShouldHandleBackspace()
        {
            string input = "227*#";
            string result = OldPhoneKeyPad.ConvertToText(input);
            Assert.Equal("B", result);
        }

        [Fact]
        public void ShouldHandleMultiKeySequences()
        {
            string input = "4433555 555666096667775553#";
            string result = OldPhoneKeyPad.ConvertToText(input);
            Assert.Equal("HELLO WORLD", result);
        }

        [Fact]
        public void ShouldHandleMultiKeySequencesWithBackspace()
        {
            string input = "8 88777444666*664#";
            string result = OldPhoneKeyPad.ConvertToText(input);
            Assert.Equal("TURING", result);
        }

        [Fact]
        public void ShouldHandleInvalidInput()
        {
            string input = string.Empty;
            string result = OldPhoneKeyPad.ConvertToText(input);
            Assert.Equal(string.Empty, result);
        }
    }
}
