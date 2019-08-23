using DCCS.LocalizedString.NetStandard;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
                options.Filters.Add<LocalizedExceptionFilter>()
            );
        }
    }
}
