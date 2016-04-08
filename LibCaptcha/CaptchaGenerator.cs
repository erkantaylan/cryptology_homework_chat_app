using System.Diagnostics;
using System.Text;

namespace LibCaptcha {

    public class CaptchaGenerator {

        private readonly int asciiLetterBegin = 65;
        private readonly int asciiNumberBegin = 48;
        private readonly int digitCount = 10;
        private readonly int letterCount = 26;

        public string GetCaptcha(int length) {
            var sb = new StringBuilder();
            var randomGenerator = new RandomNumberGenerator();

            for (var i = 0; i < length; i++) {
                var number = randomGenerator.GiveMe4DigitNumber();
                sb.Append(ConverToASCII(number));
            }

            return sb.ToString();
        }

        private char ConverToASCII(int number) {
            number = LimitToASCII(number);
            if (number < this.digitCount) {
                return (char) ShiftToDigit(number);
            }
            return (char) ShiftToLetter(DecreaseToLetters(number));
        }

        private int DecreaseToLetters(int number) {
            return number - this.digitCount;
        }

        private int ShiftToDigit(int number) {
            return (number + this.asciiNumberBegin);
        }

        private int ShiftToLetter(int number) {
            Debug.WriteLineIf(number > this.letterCount, number.ToString());
            return (number + this.asciiLetterBegin);
        }

        private int LimitToASCII(int number) {
            return number % (this.letterCount + this.digitCount);
        }

    }

}