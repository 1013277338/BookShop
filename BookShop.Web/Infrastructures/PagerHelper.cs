using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookShop.Web.Infrastructures
{
    public enum PageMode
    {
        /// <summary>
        /// 普通
        /// </summary>
        Normal,
        /// <summary>
        /// 普通加数字
        /// </summary>
        Numeric
    }




    public static class PagerHelper
    {


        public static string Test(this HtmlHelper helper, string id)
        {
            TagBuilder builder = new TagBuilder("table");
            builder.GenerateId(id);
            builder.MergeAttribute("style", "width:100px;height:100px;border:1px solid red");
            return builder.ToString();
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">分页id</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="htmlAttributes">分页头标签属性</param>
        /// <param name="className">分页样式</param>
        /// <param name="mode">分页模式</param>
        /// <returns></returns>
        public static string Pager(this HtmlHelper helper, string id, int currentPageIndex, int pageSize, int recordCount, object htmlAttributes, string className, PageMode mode)
        {
            TagBuilder builder = new TagBuilder("table");
            builder.IdAttributeDotReplacement = "_";
            builder.GenerateId(id);
            builder.AddCssClass(className);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            builder.InnerHtml = GetNormalPage(currentPageIndex, pageSize, recordCount, mode);
            return builder.ToString();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">分页id</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="className">分页样式</param>
        /// <returns></returns>
        public static string Pager(this HtmlHelper helper, string id, int currentPageIndex, int pageSize, int recordCount, string className)
        {
            return Pager(helper, id, currentPageIndex, pageSize, recordCount, null, className, PageMode.Normal);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">分页id</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="recordCount">记录总数</param>
        /// <returns></returns>
        public static string Pager(this HtmlHelper helper, string id, int currentPageIndex, int pageSize, int recordCount)
        {
            return Pager(helper, id, currentPageIndex, pageSize, recordCount, null);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">分页id</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="mode">分页模式</param>
        /// <returns></returns>
        public static string Pager(this HtmlHelper helper, string id, int currentPageIndex, int pageSize, int recordCount, PageMode mode)
        {
            return Pager(helper, id, currentPageIndex, pageSize, recordCount, null, mode);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="id">分页id</param>
        /// <param name="currentPageIndex">当前页</param>
        /// <param name="pageSize">分页尺寸</param>
        /// <param name="recordCount">记录总数</param>
        /// <param name="className">分页样式</param>
        /// <param name="mode">分页模式</param>
        /// <returns></returns>
        public static string Pager(this HtmlHelper helper, string id, int currentPageIndex, int pageSize, int recordCount, string className, PageMode mode)
        {
            return Pager(helper, id, currentPageIndex, pageSize, recordCount, null, className, mode);
        }
        /// <summary>
        /// 获取普通分页
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        private static string GetNormalPage(int currentPageIndex, int pageSize, int recordCount, PageMode mode)
        {
            int pageCount = (recordCount % pageSize == 0 ? recordCount / pageSize : recordCount / pageSize + 1);
            StringBuilder url = new StringBuilder();
            url.Append(HttpContext.Current.Request.Url.AbsolutePath + "?pageIndex={0}");
            NameValueCollection collection = HttpContext.Current.Request.QueryString;
            string[] keys = collection.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].ToLower() != "pageindex")
                    url.AppendFormat("&{0}={1}", keys[i], collection[keys[i]]);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr><td>");
            sb.AppendFormat("总共{0}条记录,共{1}页,当前第{2}页&nbsp;&nbsp;", recordCount, pageCount, currentPageIndex);
            if (currentPageIndex == 1)
                sb.Append("<span id='first'>首页</span>&nbsp;");
            else
            {
                string url1 = string.Format(url.ToString(), 1);
                sb.AppendFormat("<span id='first'><a a={0}>首页</a></span>&nbsp;", url1);
            }
            if (currentPageIndex > 1)
            {
                string url1 = string.Format(url.ToString(), currentPageIndex - 1);
                sb.AppendFormat("<span id='former'><a a={0}>上一页</a></span>&nbsp;", url1);
            }
            else
                sb.Append("<span id='former'>上一页</span>&nbsp;");
            if (mode == PageMode.Numeric)
                sb.Append(GetNumericPage(currentPageIndex, pageSize, recordCount, pageCount, url.ToString()));
            if (currentPageIndex < pageCount)
            {
                string url1 = string.Format(url.ToString(), currentPageIndex + 1);
                sb.AppendFormat("<span id='next'><a a={0}>下一页</a></span>&nbsp;", url1);
            }
            else
                sb.Append("<span id='next'>下一页</span>&nbsp;");

            if (currentPageIndex == pageCount)
                sb.Append("<span id='last'>末页</span>&nbsp;");
            else
            {
                string url1 = string.Format(url.ToString(), pageCount);
                sb.AppendFormat("<span id='last'><a a={0}>末页</a></span>&nbsp;", url1);
            }
           
            return sb.ToString();
        }
        /// <summary>
        /// 获取数字分页
        /// </summary>
        /// <param name="currentPageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <param name="pageCount"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string GetNumericPage(int currentPageIndex, int pageSize, int recordCount, int pageCount, string url)
        {
            int k = currentPageIndex /10;
            int m = currentPageIndex % 10;
            StringBuilder sb = new StringBuilder();
            if (currentPageIndex / 10 == pageCount / 10) //每次只显示10个数据，只有在点到最后一个数据的时候才会生成以后的10个数据。
            {                                             //意思是只有点到10,20,30这类整数的时候才会  
                if (m == 0)    //m=0 说明总页数刚好是整数 ,已经没有下一个10页了，这是最后一页，所以k--,m=10.显示最后10页
                {
                    k--;
                    m = 10;
                }
                else      //m!=0 说明还剩几页，就是pageCount%10 剩下的几页
                    m = pageCount % 10;
            }
            else
                m = 10;   
            for (int i = k * 10 + 1; i <= k * 10 + m; i++)
            {
                if (i == currentPageIndex)
                    sb.AppendFormat("<span id="+i+"><font color=red><b>{0}</b></font></span>&nbsp;", i);
                else
                {
                    string url1 = string.Format(url.ToString(), i);
                    sb.AppendFormat("<span id="+i+"><a a={0}>{1}</a></span>&nbsp;", url1, i);
                }                
            }
            //如果还有下一页，则加上...
          //  if (currentPageIndex < pageCount)
            if(k*10+m<pageCount)
            {
                sb.Append("<span>...</span>");
            }

            return sb.ToString();
        }
    }
}