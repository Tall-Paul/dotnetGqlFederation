using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQL.Utilities.Federation;
using GraphQLBasketService.Models;
using GraphQLBasketService.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphQLBasketService
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
            services.AddSingleton<UserStore>();
            services.AddSingleton<BasketStore>();

            services.                     
            AddGraphQL()
                // Add required services for de/serialization
                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { }); // For .NET Core 3+ 
                services.AddTransient<ISchema>(s =>
                {



                    var basketstore = s.GetRequiredService<BasketStore>();
                    var userstore = s.GetRequiredService<UserStore>();

                    return FederatedSchema.For(@"
                        extend type Query {
                            Basket(id: ID!): Basket 
                        }

                        type Basket @key(fields: ""id""){ 
                            id: ID! 
                            user: User
                            products: [Product]
                        }

                        extend type User @key(fields: ""id"") {
                            id: ID! @external
                            basket: Basket
                        }

                        extend type Product @key(fields: ""id""){
                            id: ID! @external
                        }

                        
                    ", _ =>
                    {
                        _.ServiceProvider = s;
                        _.Types.Include<Query>();
                        //_.Types.Include<Basket>();
                       
                        _.Types.For("User").ResolveReferenceAsync(context =>
                        {

                            var userid = (String)context.Arguments["id"];

                            
                            return userstore.GetUserById(userid);


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