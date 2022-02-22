using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using INVENTORY_WEBAPI.Models;

namespace INVENTORY_WEBAPI.Controllers
{
    public class ItemsWebApiController : ApiController
    {
        private DBITEMMODEL db = new DBITEMMODEL();

        // GET: api/ItemsWebApi
        public IQueryable<ItemList> GetItemLists()
        {
            return db.ItemLists;
        }

        // GET: api/ItemsWebApi/5
        [ResponseType(typeof(ItemList))]
        public IHttpActionResult GetItemList(int id)
        {
            ItemList itemList = db.ItemLists.Find(id);
            if (itemList == null)
            {
                return NotFound();
            }

            return Ok(itemList);
        }

        // PUT: api/ItemsWebApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemList(int id, ItemList itemList)
        {

            if (id != itemList.ITEM_NO)
            {
                return BadRequest();
            }

            db.Entry(itemList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ItemsWebApi
        [ResponseType(typeof(ItemList))]
        public IHttpActionResult PostItemList(ItemList itemList)
        {

            db.ItemLists.Add(itemList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemList.ITEM_NO }, itemList);
        }

        // DELETE: api/ItemsWebApi/5
        [ResponseType(typeof(ItemList))]
        public IHttpActionResult DeleteItemList(int id)
        {
            ItemList itemList = db.ItemLists.Find(id);
            if (itemList == null)
            {
                return NotFound();
            }

            db.ItemLists.Remove(itemList);
            db.SaveChanges();

            return Ok(itemList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemListExists(int id)
        {
            return db.ItemLists.Count(e => e.ITEM_NO == id) > 0;
        }
    }
}