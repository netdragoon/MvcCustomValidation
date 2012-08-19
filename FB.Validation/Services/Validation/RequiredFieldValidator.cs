using System;
using System.Collections.Generic;
using System.Linq;
using FB.Contracts.Services;

namespace FB.Infrastructure.Services.Validation
{
    public class RequiredFieldValidator : IValidator
    {
        public bool IsValid(object value)
        {
            return null != value && false == string.IsNullOrEmpty(value.ToString());
        }
    }
}
