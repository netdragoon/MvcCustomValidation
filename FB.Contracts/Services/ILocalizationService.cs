using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB.Contracts.Services
{
    public interface ILocalizationService
    {
        string Lang { get; }

        string Translate(string snippet);

        void SetLanguage(string lang);
    }
}
