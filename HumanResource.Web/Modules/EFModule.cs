using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HumanResource.Data.EntityFramework;

namespace HumanResource.Web.Modules
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(HumanResourceDbContext)).As(typeof(IContext)).InstancePerLifetimeScope();
        }
    }
}