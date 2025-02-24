using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Reflection;

namespace consoleapp;

public class CustomTypeProvider:DefaultDynamicLinqCustomTypeProvider
{
    private static readonly HashSet<Type> StaticTypes = new HashSet<Type>
    {
        typeof(DQ) 
    };

    public override HashSet<Type> GetCustomTypes()
    {
        var defaultTypes = base.GetCustomTypes();
        foreach (var type in StaticTypes)
        {
            defaultTypes.Add(type);
        }
        return defaultTypes;
    }
}