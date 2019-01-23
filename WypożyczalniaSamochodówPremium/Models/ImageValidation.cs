using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WypożyczalniaSamochodówPremium.Models
{
    [MetadataType(typeof(Image))]
    public partial class Image
    {
    }

    public class ImagValidation
    {

        [DisplayName("Zdjęcia")]
        public Image ImageData { get; set; }
    }
}