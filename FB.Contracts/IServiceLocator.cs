using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FB.Contracts
{
    public interface IServiceLocator
    {
        T Resolve<T>() where T : class;

        T Resolve<T>(string name) where T : class;

        T Resolve<T>(string name, IDictionary<string, object> namedParams)
             where T : class;


    }
}
