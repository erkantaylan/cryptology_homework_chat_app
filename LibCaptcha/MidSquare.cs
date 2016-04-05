using System;
using System.Linq;
using System.Text;

namespace LibCaptcha {

    public class MidSquare : ICaptcha{

        public int Current { get; private set; }

        public MidSquare(int startValue) {
            this.Current = startValue;
        }

        public int Next() {
            if (!IsValidValue(this.Current)) {
                throw new Exception("Invalid Value");
            }
            var square = GetSquare(this.Current);
            this.Current = GetMiddle(square.ToString());
            return this.Current;
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
            for (int i = 0; i < 8 - value.Length; i++) {
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