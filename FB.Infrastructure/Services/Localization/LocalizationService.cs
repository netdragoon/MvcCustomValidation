using System;
using System.Collections.Generic;
using System.Linq;
using FB.Contracts.Services;

namespace FB.Infrastructure.Services.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private static readonly Dictionary<string, string> plTranslations = new Dictionary<string, string>
        {
            { "User name", "Nazwa użytkownika" },
            { "Email address", "Adres email" },
            { "Password", "Hasło" },
            { "Confirm password", "Potwierdź hasło"},
            { "Remember me?", "Pamiętaj mnie?" },
            { "RequiredValidationFailed", "Pole {0} jest wymagane" },
            { "StringLengthValidationFailed", "{0} musi mieć długość między {1} a {2}" },

        };

        private static readonly Dictionary<string, string> enTranslations = new Dictionary<string, string>
        {
            { "RequiredValidationFailed", "Field {0} is required" },
            { "StringLengthValidationFailed", "Field {0} length has to be between {1} and {2}" },

        };

        public LocalizationService()
        {
            Lang = FB.Contracts.ServiceLocator.Lang;
        }

        string ILocalizationService.Translate(string snippet)
        {
            Dictionary<string, string> vocabulary;
            switch (this.Lang)
            {
                case "en-US":
                case "en-GB":
                    vocabulary = enTranslations;
                    break;


                default:
                    vocabulary = plTranslations;
                    break;
            }

            string translation;
            vocabulary.TryGetValue(snippet, out translation);
            return translation ?? snippet;
        }


        public string Lang
        {
            get;
            protected set;
        }

        public void SetLanguage(string lang)
        {
            this.Lang = lang;
        }
    }
}
