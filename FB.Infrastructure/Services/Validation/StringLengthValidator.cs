using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FB.Contracts.Services;

namespace FB.Infrastructure.Services.Validation
{
    public class StringLengthValidator : IValidator
    {
        public int MinimumLength { get; protected set; }
        public int MaximumLength { get; protected set; }

        public StringLengthValidator(int minLength, int maxLength)
        {
            this.MinimumLength = minLength;
            this.MaximumLength = maxLength;
        }

        public bool IsValid(object value)
        {
            string sValue = value as string;
            if (null != sValue)
            {
                return sValue.Length >= MinimumLength && sValue.Length <= MaximumLength; 
            }

            return true;
        }
    }
}
