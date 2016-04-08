using System;
using System.Text;

namespace LibCaptcha {

    public class MidSquare : ICaptcha {

        public MidSquare(int startValue) {
            Current = startValue;
        }

        public static int Current { get; private set; }

        public int Next() {
            if (!IsValidValue(Current)) {
                Current %= 10000;
            }
            var square = GetSquare(Current);
            Current = GetMiddle(square.ToString());
            return Current;
        }

        private int GetMiddle(string value) {
            value = ComplateTo8Digits(value);
            value = value.Substring(2, 4);
            return Convert.ToInt32(value);
        }

        private string ComplateTo8Digits(string value) {
            if (value.Length > 7) {
                return value;
            }
            var sb = new StringBuilder();
            for (var i = 0; i < 8 - value.Length; i++) {
                sb.Append("0");
            }
            sb.Append(value);
            return sb.ToString();
        }

        private static int GetSquare(int initialValue) {
            return initialValue * initialValue;
        }

        private bool IsValidValue(int initialValue) {
            return initialValue < 10000;
        }

    }

}