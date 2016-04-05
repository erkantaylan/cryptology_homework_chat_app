using System;

namespace LibCaptcha {

    public class CaptchaGenerator {

        private readonly ICaptcha _captcha;
        
        public CaptchaGenerator(ICaptcha captcha) {
            this._captcha = captcha;
        }

        public int GiveNumber() {
            return this._captcha.Next();
        }
        
    }

}