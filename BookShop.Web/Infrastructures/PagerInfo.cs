using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.Infrastructures
{
    public class PagerInfo
    {
        public int RecordCount { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class NewsInfo
    {
        public int ID { get; set; }
        public string  Title { get; set; }
        public string UserName { get; set; }
        public DateTime AddTime { get; set; }
    }

    public class PagerQuery<TPager, TEntityList>
    {
        public TPager Pager { get; set; }
        public TEntityList EntityList { get; set; }

        public PagerQuery(TPager pager, TEntityList entityList)
        {
            this.Pager = pager;
            this.EntityList = entityList;
        }
    }
}