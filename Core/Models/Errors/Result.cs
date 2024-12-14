using Core.Interfaces.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Errors
{
    public class Result<T> : IResult<T>
    {
        public virtual int ErrorCount => Errors != null ? Errors.Count : 0;

        public virtual List<IError> Errors { get ; set ; }
        public virtual bool HasErrors => Errors != null && Errors.Count > 0;
        public virtual T ResultObject { get ; set ; }
    }

    public class ResultList<T> : IResultList<T>
    {
        public virtual int ErrorCount => Errors != null ? Errors.Count : 0;

        public virtual List<IError> Errors { get; set; }
        public virtual bool HasErrors => Errors != null && Errors.Count > 0;
        public virtual List<T> ResultObject { get; set; }
    }
}
