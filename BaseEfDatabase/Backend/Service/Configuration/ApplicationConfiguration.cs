using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Service.Configuration
{
    public static class AppConfiguration
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "CompanyApi v1.0");
                c.RoutePrefix = String.Empty;
            });
        }
    }
}
