using System;
using System.Collections.Generic;
using System.Text;

namespace EFC.Framework.Common.Dtos
{
    public class PageModel
    {
        private const int maxPageSize = 20;

        public int PageNumber { get; set; } = 1;

        private int pageSize { get; set; } = 10;

        public int PageSize
        {

            get { return pageSize; }
            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public int TotalCount { get;  set; }
        public int CurrentPage { get;  set; }
        public int TotalPages { get;  set; }
        public string PreviousPage { get;  set; }
        public string NextPage { get;  set; }
    }
}
