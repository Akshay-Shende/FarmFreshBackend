using Core.Enumeration;
using Core.Interfaces.Errors;
using Core.Models.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class IResultExtension
    {
        public static IError AddError<T>(this IResult<T> result, ErrorType errorType, string key, string message )
        {
            if (result.Errors == null)
            {
                result.Errors = new List<IError>();
            }
            var error = new Error
            {
                ErrorType= errorType,
                Key= key,
                Message= message
            };

            if (error != null)
            {
                result.Errors.Add(error);
            }
            return error;
        }
    }
}
