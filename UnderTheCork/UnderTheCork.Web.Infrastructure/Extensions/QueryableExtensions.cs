using System;
using System.Linq;
using System.Linq.Expressions;

using AutoMapper.QueryableExtensions;

using UnderTheCork.Web.App_Start;

namespace UnderTheCork.Web.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}
