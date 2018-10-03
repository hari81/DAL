using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DAL
{
    [Table("ApplicationStyles")]
    public class ApplicationStyle
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityCSSFile { get; set; }
        //Each of these files will be loaded in the related apps as the branding style
        //Example: '~/Content/scss/main.css' 
        //Needs to be addresses like the example
        //Exception may occur if file not exist!
        public string UCCSSFile { get; set; }
        public string UCUICSSFile { get; set; }
        public string GETCSSFile { get; set; }
        public string GETUICSSFile { get; set; }
    }
}