﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using HumanResource.Domain;

namespace HumanResource.Data.EntityFramework
{
    public interface IContext
    {
        IDbSet<Role> Roles { get; set; }
        IDbSet<User> Users { get; set; }
        IDbSet<Department> Departments { get; set; }
        IDbSet<Position> Positions { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }

    public class HumanResourceDbContext : DbContext, IContext
    {
       public HumanResourceDbContext()
            : base("HumanResourceContext")
       {
           //this.Configuration.LazyLoadingEnabled = false; 
       }

       public IDbSet<Role> Roles { get; set; }
       public IDbSet<User> Users { get; set; }
       public IDbSet<Department> Departments { get; set; }
       public IDbSet<Position> Positions { get; set; }

       public override int SaveChanges()
       {
           var entities = ChangeTracker.Entries().Where(x => x.Entity is AuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

           var currentUsername = HttpContext.Current != null && HttpContext.Current.User != null
               ? HttpContext.Current.User.Identity.Name
               : "Anonymous";

           foreach (var entity in entities)
           {
               if (entity.State == EntityState.Added)
               {
                   ((AuditableEntity)entity.Entity).CreatedDate = DateTime.Now;
                   ((AuditableEntity)entity.Entity).CreatedBy = currentUsername;
               }
               else
               {
                   ((AuditableEntity)entity.Entity).ModifiedDate = DateTime.Now;
                   ((AuditableEntity)entity.Entity).ModifiedBy = currentUsername;
               }
           }

           return base.SaveChanges();
       }
    }
}
