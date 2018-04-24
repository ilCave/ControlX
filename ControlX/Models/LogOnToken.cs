using System;
namespace ControlX.Models
{
    public class LogOnToken
    {
        public LogOnToken()
        {
        }

        public string SessionId
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }
    }
}
