﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Nancy.Helpers;

using Seeker.Searching;

namespace Seeker.Model
{
    public class Paginator
    {
        public IEnumerable<PageModel> GetPages(string siteBase, SearchRequest request, SearchResult result, int shift)
        {
            var lastPageIndex = (int)Math.Ceiling(result.TotalCount / (request.Limit * 1.0)) - 1;
            var curPageIndex = (int)Math.Ceiling(request.Offset / (request.Limit * 1.0));

            var leftPageIndex = curPageIndex - shift < 0 ? 0 : curPageIndex - shift;
            var rightPageIndex = curPageIndex + shift > lastPageIndex ? lastPageIndex : curPageIndex + shift;

            List<PageModel> pages = new List<PageModel>();

            foreach (var pageIndex in Enumerable.Range(leftPageIndex, rightPageIndex - leftPageIndex + 1))
            {
                var pageModel = new PageModel((pageIndex + 1).ToString(), ConvertToUri(siteBase, request, request.Limit * pageIndex), pageIndex == curPageIndex);
                pages.Add(pageModel);
            }

            if (leftPageIndex != 0)
            {
                var pageModel = new PageModel("1", ConvertToUri(siteBase, request, 0), false);
                pages.Insert(0, pageModel);

                var dotPage = new PageModel("...", null, false, true);
                pages.Insert(1, dotPage);
            }

            if (rightPageIndex != lastPageIndex)
            {
                var dotPage = new PageModel("...", null, false, true);
                pages.Add(dotPage);

                var pageModel = new PageModel((lastPageIndex + 1).ToString(), ConvertToUri(siteBase, request, request.Limit * lastPageIndex), false);
                pages.Add(pageModel);
            }

            return pages;
        }

        private Uri ConvertToUri(string siteBase, SearchRequest request, int offset)
        {
            StringBuilder sb = new StringBuilder(string.Format("{0}", siteBase));
            sb.AppendFormat("?query={0}", request.Query);
            sb.AppendFormat("&offset={0}", offset);
            sb.AppendFormat("&limit={0}", request.Limit);
            sb.AppendFormat("&orderby={0}", request.OrderBy);

            return new Uri(HttpUtility.UrlPathEncode(sb.ToString()));
        }
    }
}
