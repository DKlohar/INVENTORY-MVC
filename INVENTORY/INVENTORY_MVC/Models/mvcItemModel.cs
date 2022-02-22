using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INVENTORY_MVC.Models
{
    public class mvcItemModel
    {
        [DisplayName("NO")]
        public int ITEM_NO { get; set; }

        [Required(ErrorMessage = "This Field is Required")]

        [DisplayName("NAME")]
        public string ITEM_NAME { get; set; }

        [DisplayName("PRICE")]
        public decimal ITEM_PRICE { get; set; }

        [DisplayName("DESCRIPTION")]
        public string ITEM_DESCRIPTION { get; set; }
    }
}