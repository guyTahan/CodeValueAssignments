using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{

    [Serializable]
    public class InsufficientFundsException : Exception
    {
        private int _accID;

        public int AccID
        {
            get { return _accID; }
        }
        private int _amount;

        public int Amount
        {
            get { return _amount; }
        }
        public InsufficientFundsException(int acc, int amount)
        {
            _accID = acc;
            _amount = amount;
        }

        public InsufficientFundsException() { }
        public InsufficientFundsException(string message) : base(message) { }
        public InsufficientFundsException(string message, Exception inner) : base(message, inner) { }
        protected InsufficientFundsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
