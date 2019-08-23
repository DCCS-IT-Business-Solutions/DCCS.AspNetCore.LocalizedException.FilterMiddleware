using DCCS.LocalizedString.NetStandard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCCS.AspNetCore.LocalizedString
{
    public static class StartupExtensions
    {
        public static void AddDccsBuildingBlockLocalizedString(this IServiceCollection serviceCollection)
        {           
            serviceCollection.AddSingleton<ITranslationProviderService, ResourceTranslationProvider>();
            serviceCollection.AddSingleton<ITranslationService, TranslationService>();
            serviceCollection.AddMvcCore(options =>
            {
                var jsonOutputFormatter = options.OutputFormatters.OfType<JsonOutputFormatter>().FirstOrDefault();
                if (jsonOutputFormatter != null)
                {
                    if (!jsonOutputFormatter.PublicSerializerSettings.Converters.Any(c => c is LocalizedStringJsonConverter))
                        jsonOutputFormatter.PublicSerializerSettings.Converters.Add(new LocalizedStringJsonConverter());
                }
                options.Filters.Add<LocalizedExceptionFilter>();
            });
        }
    }
}
