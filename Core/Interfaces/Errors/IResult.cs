using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Errors
{
    public interface IResult<T>
    {
        int ErrorCount { get; }
        List<IError> Errors { get; set; }
        bool HasErrors { get; }
        T ResultObject { get; set; }
    }

    public interface IResultList<T>
    {
        int ErrorCount { get; }
        List<IError> Errors { get; set; }
        bool HasErrors { get; }
        List<T> ResultObject { get; set; }
    }
}
