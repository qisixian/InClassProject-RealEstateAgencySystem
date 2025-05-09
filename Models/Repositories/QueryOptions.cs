﻿using System.Linq.Expressions;

namespace RealEstateAgencySystem.Models
{
    public class QueryOptions<T>
    {
        // public properties for sorting, filtering, and paging
        public Expression<Func<T, Object>> OrderBy { get; set; } = null!;
        // public Expression<Func<T, bool>> Where { get; set; } = null!;
        public List<Expression<Func<T, bool>>> Wheres { get; set; } = new List<Expression<Func<T, bool>>>();

        public Expression<Func<T, Object>>? Selecter { get; set; } = null!;
        public string OrderByDirection { get; set; } = "asc";  // default
        public string OrderByColumn { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        /* Code for working with Include strings */
        private string[] includes = Array.Empty<string>();

        // public write-only property for Include strings – accepts a string, converts it to
        // a string array, and stores in private string array field
        public string Includes
        {
            set => includes = value.Replace(" ", "").Split(',');
        }

        // public get method for Include strings - returns private string array, or
        // empty string array if private backing field is null
        public string[] GetIncludes() => includes;

        // read-only properties 
        public bool HasWhere => Wheres != null && Wheres.Count > 0;
        public bool HasSelecter => Selecter != null;
        public bool HasOrderBy => OrderBy != null;
        public bool HasPaging => PageNumber > 0 && PageSize > 0;

    }

}
