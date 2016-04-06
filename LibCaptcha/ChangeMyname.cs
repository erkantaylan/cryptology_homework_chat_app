using System;

namespace LibCaptcha {

    public static class ChangeMyname {

        public static int GiveMe4DigitNumber() {
            var midSquare = GetMidSquare();
            var generator = new CaptchaGenerator(midSquare);
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
            var minute = DateTime.Now.Minute.ToString();
            var second = DateTime.Now.Second.ToString();
            return int.Parse($"{second}{minute}");
        }

    }

}