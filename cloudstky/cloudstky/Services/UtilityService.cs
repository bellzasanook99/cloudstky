using cloudstky.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cloudstky.Services
{
    public class UtilityService
    {
        public static class ModelStateExtensions
        {
            public static IEnumerable<Error> AllErrors( ModelStateDictionary modelState)
            {
                var result = new List<Error>();
                var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                                                .Select(x => new { x.Key, x.Value.Errors });

                foreach (var erroneousField in erroneousFields)
                {
                    var fieldKey = erroneousField.Key;
                    var fieldErrors = erroneousField.Errors
                                       .Select(error => new Error(fieldKey, error.ErrorMessage));
                    result.AddRange(fieldErrors);
                }

                return result;
            }
        }
    }
}
