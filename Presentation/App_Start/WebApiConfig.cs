using Business.Application;
using Business.Domain;
using Business.Entity;
using Infrastructure;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Lifetime;

namespace Presentation
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes

            var container = new UnityContainer();

            container.RegisterType<IMemberApplicationService, MemberApplicationService>();
            container.RegisterType<IBlogApplicationService, BlogApplicationService>();
            container.RegisterType<IArticleApplicationService, ArticleApplicationService>();

            container.RegisterType<IMemberRepository, MemberRepository>();
            container.RegisterType<IBlogSpaceRepository, BlogSpaceRepository>();
            container.RegisterType<IArticleRepository, ArticleRepository>();

            container.RegisterType<IMemberDomainService, MemberDomainService>();
            container.RegisterType<IBlogSpaceDomainService, BlogSpaceDomainService>();
            container.RegisterType<IArticleDomainService, ArticleDomainService>();

            config.DependencyResolver = new UnityDependencyResolver(container);
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
