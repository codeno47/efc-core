using EFC.Framework.Common.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFC.Framework.Extensions
{
    public static class PaginationExtensions
    {
        public static string ToPagenationJson<TInstance>(this List<TInstance> collection, int currentPage,
            int pageSize)
        {
            if (currentPage > 0 && pageSize > 0 && collection != null)
            {
                var totalCount = collection.Count;
                int TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var items = collection.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                var jsonToReturn = JsonConvert.SerializeObject(items);

                var previousPage = currentPage > 1 ? "Yes" : "No";

                var nextPage = currentPage < TotalPages ? "Yes" : "No";

                return PageModelMapper.Map(totalCount, pageSize, currentPage, TotalPages, previousPage, nextPage);
            }

            return null;
        }
    }
}
