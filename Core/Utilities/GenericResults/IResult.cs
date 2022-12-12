using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.GenericResults
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
