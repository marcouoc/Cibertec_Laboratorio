using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.Model;

namespace WebDeveloper.Areas.Personnel.Controllers
{
    public class AddressController : PersonBaseController<Address>
    {
        // GET: Personnel/Address
        public ActionResult Index()
        {
            //return View(_repository.GetList().Take(15));
            return View(_repository.PaginatedList((x => x.ModifiedDate), 2, 15));
        }
   
  
        public ActionResult Details(int id)
        {
            var address = _repository.GetById(x => x.AddressID == id);
            if (address == null) return RedirectToAction("Index");
            return View(address);
        }


        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(Address address)
        {
            if (!ModelState.IsValid) return View(address);
            address.rowguid = Guid.NewGuid();
   
            _repository.Add(address);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var address = _repository.GetById(x => x.AddressID == id);
            if (address == null) return RedirectToAction("Index");
            return View(address);
        }

        [HttpPost]
        public ActionResult Edit(Address address)
        {
            if (!ModelState.IsValid) return View(address);
            _repository.Update(address);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var person = _repository.GetById(x => x.AddressID == id);
            if (person == null) return RedirectToAction("Index");
            return View(person);
        }

        [HttpPost]
        public ActionResult Delete(Address address)
        {
            address = _repository.GetById(x => x.AddressID == address.AddressID);
            _repository.Delete(address);
            return RedirectToAction("Index");
        }



    }
}