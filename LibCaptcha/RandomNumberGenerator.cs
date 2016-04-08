using System;

namespace LibCaptcha {

    public class RandomNumberGenerator {

        private CaptchaFactory generator { get; set; }

        public RandomNumberGenerator() {
            var midSquare = GetMidSquare();
            generator = new CaptchaFactory(midSquare);
        }

        public int GiveMe4DigitNumber() {
            return generator.GiveNumber();
        }

        private static MidSquare GetMidSquare() {
            var startValue = GetMinSecond();
            //int startValue = GiveMeRandomNumber(9999);
            var midSquare = new MidSquare(startValue);
            return midSquare;
        }

        private static int GiveMeRandomNumber(int number) {
            return new Random().Next(number);
        }

        private static int GetMinSecond() {
            var minute = DateTime.Now.Millisecond.ToString();
            var second = DateTime.Now.Second.ToString();
            return int.Parse($"{second}{minute}");
        }

    }

}