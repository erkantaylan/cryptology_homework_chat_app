using System;

namespace LibCaptcha {

    public static class ChangeMyname {

        public static int GiveMe4DigitNumber() {
            var midSquare = GetMidSquare();
            CaptchaGenerator generator = new CaptchaGenerator(midSquare);
            return generator.GiveNumber();
        }

        private static MidSquare GetMidSquare() {
            int startValue = GiveMeRandomNumber(9999);
            var midSquare = new MidSquare(startValue);
            return midSquare;
        }

        private static int GiveMeRandomNumber(int number) {
            return new Random().Next(number);
        }

    }

}