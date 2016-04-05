using System.Data.SqlTypes;

namespace LibCaptcha {

    public interface ICaptcha {

        int Current { get; }

        int Next();

    }

}