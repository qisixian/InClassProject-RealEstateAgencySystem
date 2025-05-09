﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RealEstateAgencySystem.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext context { get; set; }
        private DbSet<T> dbset { get; set; }

        public Repository(AppDbContext ctx)
        {
            context = ctx;
            dbset = context.Set<T>();
        }

        public int Count => dbset.Count();

        // retrieve a list of entities
        public virtual IEnumerable<T> List(QueryOptions<T> options) =>
            BuildQuery(options).ToList();

        // retrieve a single entity (3 overloads)
        public virtual T? Get(int id) => dbset.Find(id);
        public virtual T? Get(string id) => dbset.Find(id);
        public virtual T? Get(QueryOptions<T> options) =>
            BuildQuery(options).FirstOrDefault();

        // insert, update, delete, save
        public virtual void Insert(T entity) => dbset.Add(entity);
        public virtual void Update(T entity) => dbset.Update(entity);
        public virtual void Delete(T entity) => dbset.Remove(entity);
        public virtual void Save() => context.SaveChanges();

        // private helper method to build query expression
        private IQueryable<T> BuildQuery(QueryOptions<T> options)
        {
            IQueryable<T> query = dbset;
            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
            {   
                foreach (var where in options.Wheres)
                {
                    query = query.Where(where);
                }
            }
            // if (options.HasSelecter)
            // {
            //     query = query.Select(options.Selecter);
            // }
            if (options.HasOrderBy)
            {
                // if ordering by decimal, convert to double to avoid error with decimal ordering
                bool isDecimalOrderBy = 
                    (typeof(T) == typeof(SalesRecord) && options.OrderByColumn == "SalePrice") ||
                    (typeof(T) == typeof(RentalRecord) && (options.OrderByColumn == "RentalPrice" || options.OrderByColumn == "DepositPrice")) ||
                    (typeof(T) == typeof(Property) && (options.OrderByColumn == "RentalPrice" || options.OrderByColumn == "SellingPrice"));

                if (isDecimalOrderBy)
                {
                    var parameter = Expression.Parameter(typeof(T), "x");
                    var property = Expression.Property(parameter, options.OrderByColumn);
                    var convertExpr = Expression.Convert(property, typeof(double));
                    var lambda = Expression.Lambda<Func<T, double>>(convertExpr, parameter);

                    if (options.OrderByDirection == "asc")
                        query = query.OrderBy(lambda);
                    else
                        query = query.OrderByDescending(lambda);
                }
                else
                {
                    if (options.OrderByDirection == "asc")
                        query = query.OrderBy(options.OrderBy);
                    else
                        query = query.OrderByDescending(options.OrderBy);
                }
            }
            if (options.HasPaging)
            {
                query = query.PageBy(options.PageNumber, options.PageSize);
            }

            return query;
        }
    }
}
