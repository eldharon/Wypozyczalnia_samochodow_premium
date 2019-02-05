using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class UserListViewModel
    {
        public Guid UserHash { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}