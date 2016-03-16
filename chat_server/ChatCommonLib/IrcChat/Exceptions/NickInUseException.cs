using System;
using System.Runtime.Serialization;

namespace ChatCommonLib.IrcChat.Exceptions {
    /// <summary>
    /// This exception is thrown by Chat server if a user wants to login 
    /// with a nick that is being used by another user.
    /// </summary>
    [Serializable]
    public class NickInUseException : ApplicationException {

        public NickInUseException(SerializationInfo serializationInfo, StreamingContext context) :base(serializationInfo, context) {
            
        }

        public NickInUseException(string message) : base(message) {
            
        }
    }

}