using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FB.Contracts.Services;
using FB.Contracts.Common;

namespace FB.MVC.Validation
{
    public class StringLengthAttribute : BaseValidationAttribute
    {
        public int MaximumLength { get; set; }
        public int MinimumLength { get; set; }

        public StringLengthAttribute(int maxLength)
            : base("StringLengthValidationFailed", Contracts.Common.ValidationKind.StringLength)
        {
            this.MaximumLength = maxLength;
        }

        protected override IValidator CreateValidator()
        {
            IValidator validator;
            string validatorMetadata = this.ValidatorKind.ToMetadata();
            validator = FB.Contracts.ServiceLocator.Instance.Resolve<IValidator>(validatorMetadata,
                            new Dictionary<string, object> { 
                                { "minLength", MinimumLength },
                                { "maxLength", MaximumLength },
                            }
                        );
            return validator;
        }
    }
}
