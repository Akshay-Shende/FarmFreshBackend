using Core.Enumeration;
using Core.Interfaces.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Errors
{
    public class Error : IError
    {
        public ErrorType ErrorType { get; set; }
        public string Key { get; set ; }
        public string Message { get ; set ; }
    }
}
