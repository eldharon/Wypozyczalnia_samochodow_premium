using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WypożyczalniaSamochodówPremium.Models
{
    public class StatusSelectList
    {
        static readonly IDictionary<string, string> Status = new Dictionary<string, string>
        {
            {"nowe","nowe" },
            {"w realizacji","w realizacji" },
            {"zrealizowane","zrealizowan" },
            {"anulowane", "anulowane" }
        };

        public static IDictionary<string, string> StatusList
        {
            get { return Status; }
        }
    }
}