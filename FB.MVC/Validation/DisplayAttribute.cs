using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using FB.MVC.Translations;

namespace FB.MVC.Validation
{
    public class DisplayAttribute : DisplayNameAttribute
    {
        public string Name { get; set; }

        public override string DisplayName
        {
            get
            {
                return TranslationHelper.Translate(this.Name);
            }
        } 
    }
}
