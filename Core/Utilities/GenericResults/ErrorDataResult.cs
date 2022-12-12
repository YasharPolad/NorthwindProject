using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.GenericResults
{
    public class ErrorDataResult<TData> : DataResult<TData>
    {
        public ErrorDataResult(TData Data, string Message) : base(Data, false, Message)
        {
        }
        public ErrorDataResult(TData Data) : base(Data, false)
        {
        }

        public ErrorDataResult(string message) : base(default, false, message)
        {
        }
        public ErrorDataResult() : base(default, false)
        {
        }
    }
}
