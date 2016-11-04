using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;

namespace CuratorJournal.Logic.EnumWork
{
    public static class EnumWork
    {
        public static void AttachObject<TEnity>(this DbSet<TEnity> dbSet, TEnity entity) where TEnity : class
        {
            if (entity != null)
            {
                dbSet.Attach(entity);
            }
        }

        /// <summary>
        /// Fills tables for IRussianEnums with enum values.
        /// </summary>
        public static void PopulateRussianEnums(this DbContext context)
        {
            foreach (PropertyInfo propertyInfo in context.GetType().GetProperties())
            {
                Type propertyType = propertyInfo.PropertyType;
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                {
                    Type objType = propertyType.GetGenericArguments()[0];
                    if (typeof(IRussianEnum).IsAssignableFrom(objType))
                    {
                        dynamic dbSet = propertyInfo.GetValue(context);
                        PopulateRussianEnum(context, dbSet);
                    }
                }
            }
        }

        private static void PopulateRussianEnum<TEnum>(DbContext context, DbSet<TEnum> dbSet) where TEnum : class, IRussianEnum
        {
            var items = RussianEnumUtils.GetValues<TEnum>().ToArray();
            dbSet.AddOrUpdate(items);
            foreach (var obj in items)
            {
                if (context.Entry(obj).State == EntityState.Unchanged)
                {
                    context.Entry(obj).State = EntityState.Modified;
                }
            }
        }

        /// <summary>
        /// Attaches all known IRussianEnums values to the context.
        /// </summary>
        public static void AttachRussianEnums(this DbContext db)
        {
            foreach (PropertyInfo propertyInfo in db.GetType().GetProperties())
            {
                Type propertyType = propertyInfo.PropertyType;
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                {
                    Type objType = propertyType.GetGenericArguments()[0];
                    if (typeof(IRussianEnum).IsAssignableFrom(objType))
                    {
                        dynamic dbSet = propertyInfo.GetValue(db);
                        AttachRussianEnums(dbSet);
                    }
                }
            }
        }

        private static void AttachRussianEnums<TEnum>(DbSet<TEnum> dbSet) where TEnum : class, IRussianEnum
        {
            //todo: cache values to improve performance
            foreach (TEnum value in RussianEnumUtils.GetValues<TEnum>())
            {
                dbSet.Attach(value);
            }
        }
    }
}
