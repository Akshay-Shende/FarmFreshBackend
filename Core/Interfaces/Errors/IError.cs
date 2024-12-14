using Core.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Errors
{
    public interface IError
    {
        public ErrorType ErrorType { get; set; }
        string Key     { get; set; }
        string Message { get; set; }
    }
}
