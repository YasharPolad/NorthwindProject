using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.GenericResults
{
    public class SuccessDataResult<TData> : DataResult<TData>
    {
        public SuccessDataResult(TData Data, string Message) : base(Data, true, Message)
        {
        }
        public SuccessDataResult(TData Data) : base(Data, true)
        {
        }

        public SuccessDataResult(string message) : base(default, true, message)
        {
        }
        public SuccessDataResult() : base(default, true)
        {
        }
    }
}
