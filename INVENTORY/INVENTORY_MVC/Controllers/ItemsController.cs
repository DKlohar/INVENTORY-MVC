using INVENTORY_MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace INVENTORY_MVC.Controllers
{
    public class ItemsController : Controller
    {

        // GET: /Items/
        public ActionResult Index()
        {
            IEnumerable<mvcItemModel> itemData;
            HttpResponseMessage response = GlobalVariable.WebApliClient.GetAsync("ItemsWebApi").Result;
            itemData = response.Content.ReadAsAsync<IEnumerable<mvcItemModel>>().Result;
            
            return View(itemData);
        }


        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcItemModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApliClient.GetAsync("ItemsWebApi/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcItemModel>().Result);
            }
        }

        [HttpPost]

        public ActionResult AddOrEdit(mvcItemModel tblItem)
        {
            if (tblItem.ITEM_NO == 0)
            {
                HttpResponseMessage response = GlobalVariable.WebApliClient.PostAsJsonAsync("ItemsWebApi", tblItem).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApliClient.PutAsJsonAsync("ItemsWebApi/" + tblItem.ITEM_NO, tblItem).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApliClient.DeleteAsync("ItemsWebApi/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}