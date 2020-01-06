using Microsoft.Extensions.Configuration;
using OrderMicroService.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService
{
    public static class ConfigurationExtensions
    {
        public static ExternalUrl GetExternalUrls(this IConfiguration configuration)
        {
            var result = configuration.GetSection(nameof(ExternalUrl)).Get<ExternalUrl>();
           return result;
        }
    }
}
