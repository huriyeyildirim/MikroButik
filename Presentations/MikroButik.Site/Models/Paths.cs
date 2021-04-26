using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroButik.Site.Models
{
    public static class Paths
    {
        private static string CategoriesRoot { get => "Categories"; }
        public static string AllCategories { get => $"{CategoriesRoot}/GetAll"; }
        public static string AddCategory { get => $"{CategoriesRoot}/add"; }
        public static string SingleCategories { get => $"{CategoriesRoot}/GetAll?id="; }

        private static string ProductsRoot { get => "Products"; }
        public static string AllProducts { get => $"{ProductsRoot}/GetAll"; }
        public static string AddProducts { get => $"{ProductsRoot}/add"; }
        public static string SingleProducts { get => $"{ProductsRoot}/GetSingle?id="; }

        

        private static string OrdersRoot { get => "Orders"; }
        public static string AllOrders { get => $"{OrdersRoot}/GetAll"; }
        public static string AddOrders { get => $"{OrdersRoot}/add"; }
        public static string SingleOrders { get => $"{OrdersRoot}/GetAll?id="; }

   

        private static string UsersRoot { get => "Users"; }
        public static string AllUsers { get => $"{UsersRoot}/GetAll"; }
        public static string AddUsers { get => $"{UsersRoot}/add"; }
        public static string SingleUsers { get => $"{UsersRoot}/GetAll?id="; }
    }

}
