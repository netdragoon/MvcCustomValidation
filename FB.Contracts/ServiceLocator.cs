using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FB.Contracts
{
    public class ServiceLocator
    {
        private static bool initialized = false;
        private static InitializedInstance app;

        public static void Initialize(string lang, Func<IServiceLocator> ioCfactory)
        {
            app = new InitializedInstance(lang, ioCfactory);
        }

        private static InitializedInstance Application
        {
            get
            {
                if (false == initialized)
                    throw new InvalidOperationException("Cannot use ServiceLocator before initialization.");

                return app;
            }
        }

        public static IServiceLocator Instance
        {
            get
            {
                return Application.Locator;
            }
        }

        public static string Lang
        {
            get { return Application.DefaultLanguage; }
            set
            {
                Application.DefaultLanguage = value;
                Application.Locator.Resolve<FB.Contracts.Services.ILocalizationService>()
                    .SetLanguage(value);
            }
        }

        private class InitializedInstance
        {
            public string DefaultLanguage { get; set; }
            private Lazy<IServiceLocator> locator;

            public InitializedInstance(string lang, Func<IServiceLocator> ioCfactory)
            {
                DefaultLanguage = lang;
                locator = new Lazy<IServiceLocator>(
                        ioCfactory, false
                    );
                ServiceLocator.initialized = true;
            }

            public IServiceLocator Locator
            {
                get
                {
                    return locator.Value;
                }
            }
        }
    }
}
