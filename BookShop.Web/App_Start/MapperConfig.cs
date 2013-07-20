using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using AutoMapper;
using BookShop.Services.EntityModels;
using BookShop.Web.Models;


namespace BookShop.Web
{
    public class MapperConfig
    {
        public static void RegisterMapper()
        {         
           Mapper.CreateMap<Users,UserView>();

           Mapper.CreateMap<Books, BooksView>();

          
        }

        /// <summary>
        /// Convert the nullable integer to integer array.
        /// </summary>
        /// <param name="sources"></param>
        /// <returns>An array of integer if any nullable integer is supplied, otherwise return empty array.</returns>
        private static int[] ToArray(params int?[] sources)
        {
            Contract.Ensures(Contract.Result<int[]>() != null);

            if (sources != null)
            {
                return sources.Where(item => item.HasValue)
                              .Select(item => item.Value)
                              .ToArray();
            }

            return new int[0];
        }
    }
}