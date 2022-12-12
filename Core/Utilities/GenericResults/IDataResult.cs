using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.GenericResults
{
    public interface IDataResult<TData> : IResult
    {
        TData Data { get; }
    }
}
