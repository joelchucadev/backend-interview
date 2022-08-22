using Code.Handlers.RequestModel;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Handlers
{
    public static class Config
    {
        public static IServiceCollection RegisterRequestHandlers(this IServiceCollection services)
        {
            return services .AddMediatR(typeof(Config).Assembly);
        }
    }
}
