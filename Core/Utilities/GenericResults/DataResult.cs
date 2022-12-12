using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.GenericResults
{
    public class DataResult<TData> : Result, IDataResult<TData>
    {
        public DataResult(TData Data, bool IsSuccess) : base(IsSuccess)
        {
            this.Data = Data;
        }

        public DataResult(TData Data, bool IsSuccess, string Message) : base(IsSuccess, Message)
        {
            this.Data = Data;
        }


        public TData Data { get; }
    }
}
