﻿using System.Web;
using System.Web.Mvc;

namespace Lab.net.Practica7.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
