using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using FB.MVC.Translations;
using FB.Contracts.Common;
using FB.Contracts;


namespace FB.MVC.Validation
{
    public class BaseValidationAttribute : ValidationAttribute
    {
        protected readonly string ErrorMessageSnippet;
        protected readonly ValidationKind ValidatorKind;

        public BaseValidationAttribute(string errorMessageSnippet, ValidationKind kind)
        {
            this.ErrorMessageSnippet = errorMessageSnippet;
            this.ValidatorKind = kind;
        }

        public override string FormatErrorMessage(string name)
        {
            string sSnippet = string.IsNullOrEmpty(ErrorMessage)
                            ? ErrorMessageSnippet : ErrorMessage;

            return string.Format(TranslationHelper.Translate(sSnippet),
                TranslationHelper.Translate(name));
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isValid = IsValid(value);
            if (isValid)
            {
                return ValidationResult.Success;
            }

            var memberName = false == string.IsNullOrEmpty(validationContext.DisplayName)
                                    ? validationContext.DisplayName : validationContext.MemberName;

            return new ValidationResult(FormatErrorMessage(memberName));
        }

        public override bool IsValid(object value)
        {
            return CreateValidator().IsValid(value);
        }


        protected virtual FB.Contracts.Services.IValidator CreateValidator()
        {
            string validatorMetadata = this.ValidatorKind.ToMetadata();
            return ServiceLocator.Instance.Resolve<FB.Contracts.Services.IValidator>(validatorMetadata);
        }
    }
}