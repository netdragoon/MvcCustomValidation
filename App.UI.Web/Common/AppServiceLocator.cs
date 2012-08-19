using System;
using System.Collections.Generic;
using FB.Contracts.Services;
using TinyIoC;
using FB.Contracts.Common;

namespace App.UI.Web.Common
{
    public class AppServiceLocator : FB.Contracts.IServiceLocator
    {
        public T Resolve<T>() where T : class
        {
            return TinyIoC.TinyIoCContainer.Current.Resolve<T>();
        }

        public T Resolve<T>(string name) where T : class
        {
            return TinyIoC.TinyIoCContainer.Current.Resolve<T>(name);
        }

        public T Resolve<T>(string name, IDictionary<string, object> namedParams) where T : class
        {
            return TinyIoC.TinyIoCContainer.Current.Resolve<T>(name,
                            TinyIoC.NamedParameterOverloads.FromIDictionary(namedParams));
        }


        public static void Bootstrap(string defaultLang)
        {
            FB.Contracts.ServiceLocator.Initialize(
                defaultLang,
                () => new Common.AppServiceLocator()
            );

            var container = TinyIoCContainer.Current;

            container.Register<ILocalizationService,
                               FB.Infrastructure.Services.Localization.LocalizationService>()
                     .AsPerRequestSingleton();

            #region Validators

            container.Register<IValidator,
                               FB.Infrastructure.Services.Validation.RequiredFieldValidator>(
                               ValidationKind.RequiredField.ToMetadata())
                     .AsSingleton();


            container.Register<IValidator>((tinyCtnr, namedParams) =>
                        new FB.Infrastructure.Services.Validation.StringLengthValidator((int)namedParams["minLength"], (int)namedParams["maxLength"]),
                        ValidationKind.StringLength.ToMetadata()
            );

                               
                
               
                     //.AsSingleton();

            #endregion
            
        }

    }
}