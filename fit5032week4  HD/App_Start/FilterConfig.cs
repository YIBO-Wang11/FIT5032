﻿using System.Web;
using System.Web.Mvc;

namespace fit5032week4__HD
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
