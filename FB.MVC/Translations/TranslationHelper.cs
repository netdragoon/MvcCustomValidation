using System;
using System.Collections.Generic;
using System.Linq;
using FB.Contracts;
using FB.Contracts.Services;

namespace FB.MVC.Translations
{
    internal class TranslationHelper
    {
        private static ILocalizationService delayedService = null;
        private static ILocalizationService Service
        {
            get
            {
                if (null == delayedService)
                {
                    delayedService = ServiceLocator.Instance.Resolve<ILocalizationService>();
                }
                return delayedService;
            }
        }
        
        public static string Translate(string snippet)
        {
            return Service.Translate(snippet);
        }
    }
}
