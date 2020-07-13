using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Utilities.Federation;
using GraphQLAddressService.Middleware;
using GraphQLAddressService.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphQLAddressService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<Query>();
            services.AddSingleton<AnyScalarGraphType>();
            services.AddSingleton<ServiceGraphType>();
            services.AddLogging(builder => builder.AddConsole());
            services.AddSingleton<AddressTypeStore>();
            services.AddSingleton<GraphQLAddressService.Models.AddressStore>();
            services.AddSingleton<UserTypeStore>();

            services.
            AddGraphQL()
                // Add required services for de/serialization
                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { }); // For .NET Core 3+ 
            services.AddTransient<ISchema>(s =>
            {

                var addressstore = s.GetRequiredService<AddressTypeStore>();
                var userstore = s.GetRequiredService<UserTypeStore>();



                return FederatedSchema.For(@"
                        extend type Query {
                            Address(Id: ID!): Address
                        }
                    
                        type Address @key(fields: ""id"") {
                            id: ID!
                            address1: String
                            address2: String
                            address3: String
                            postCode: String
                        }

                        extend type User @key(fields: ""id""){
                            id: ID! @external
                            address: Address
                        }
                        
                    ", _ =>
                {
                    _.ServiceProvider = s;
                    _.Types.Include<Query>();
                    _.Types.For("User").ResolveReferenceAsync(context =>
                    {
                        Console.WriteLine("################ resolving address for user #############");
                        var userid = (String)context.Arguments["id"];
                        Console.WriteLine("########### user id " + userid + "###############");
                        Console.WriteLine(userstore.getUserById(userid).Address.PostCode);


                        return userstore.getUserByIdAsync(userid);


                    });

                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseGraphQLPlayground();

            app.UseGraphQL<ISchema>();


        }
    }
}

