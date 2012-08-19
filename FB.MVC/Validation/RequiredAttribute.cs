using System;


namespace FB.MVC.Validation
{
    public class RequiredAttribute : BaseValidationAttribute
    {
        public RequiredAttribute()
            : base("RequiredValidationFailed", FB.Contracts.Common.ValidationKind.RequiredField)
        {
        }


    }
}
