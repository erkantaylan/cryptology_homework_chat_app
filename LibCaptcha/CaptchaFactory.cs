using System;

namespace LibCaptcha {

    public class CaptchaFactory {

        private readonly ICaptcha _captcha;
        
        public CaptchaFactory(ICaptcha captcha) {
            this._captcha = captcha;
        }

        public int GiveNumber() {
            return this._captcha.Next();
        }
        
    }

}