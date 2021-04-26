using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

public enum ServiceTypes
{
    Scoped,
    Transient,
    Singleton

}

public class OriginalNaming : JsonNamingPolicy
{
    public override string ConvertName(string name) =>
       name;
}
public static class Extenstions
{
    public static IServiceCollection AddJsonSettings(this IServiceCollection services)
    {

        object p = services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.PropertyNamingPolicy = new OriginalNaming();
        });
        return services;
    }




    public static IServiceCollection AddFromAsm<T>(this IServiceCollection services,Assembly asm, ServiceTypes SType) {     
       var types = asm.GetTypes().Where(tx => tx.GetInterfaces().Any(tx=> tx == typeof(T)) && tx.IsClass && !tx.IsAbstract);

        foreach (var item in types)
        {
            switch (SType)
            {
                case ServiceTypes.Scoped:
                    services.AddScoped(item);
                    break;
                case ServiceTypes.Transient:
                    services.AddTransient(item);
                    break;
                case ServiceTypes.Singleton:
                    services.AddSingleton(item);
                    break;
                default:
                    break;
            }
        }
        return services;
    }

    public static IServiceCollection AddFromAsm(this IServiceCollection services, Type TType, Assembly asm, ServiceTypes SType)
    {

        var TTY = TType.GetGenericArguments();
        var TTYX = TType.GetGenericTypeDefinition();

        var types = asm.GetTypes().Where(tx => tx.GetInterfaces().Any(tx => tx == TType) && tx.IsClass && !tx.IsAbstract);

        foreach (var item in types)
        {
            switch (SType)
            {
                case ServiceTypes.Scoped:
                    services.AddScoped(item);
                    break;
                case ServiceTypes.Transient:
                    services.AddTransient(item);
                    break;
                case ServiceTypes.Singleton:
                    services.AddSingleton(item);
                    break;
                default:
                    break;
            }
        }
        return services;
    }
}

