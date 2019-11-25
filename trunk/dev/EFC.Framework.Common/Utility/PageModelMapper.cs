using EFC.Framework.Common.Dtos;
using Newtonsoft.Json;

namespace EFC.Framework.Common.Utility
{
    public class PageModelMapper
    {
        public static string Map(int totalCount, int pageSize, int currentPage, int totalPages, string previousPage, string nextPage)
        {
            var model =  new PageModel
            {
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = currentPage,
                TotalPages = totalPages,
                PreviousPage = previousPage,
                NextPage = nextPage
            };

            return JsonConvert.SerializeObject(model);
        }
    }
}
