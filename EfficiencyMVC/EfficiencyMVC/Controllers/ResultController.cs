using AspNetIdentity2.Controllers;
using EfficiencyMVC.Interfaces;
using EfficiencyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EfficiencyMVC.Controllers
{
    [Authorize]
    public class ResultController : ApplicationBaseController
    {

        public readonly IResultCalculatorRepository _repo;

        public ResultController(IResultCalculatorRepository repo)
        {
            _repo = repo;
        }


        // GET: Result
        public ActionResult Index()
        {
            return View(_repo.GetWhere(x => x.Id > 0));
        }

        // GET: Result/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Result result = _repo.GetWhere(x => x.Id == id.Value).FirstOrDefault();

            if (result == null)
            {
                return HttpNotFound();
            }

            return View(result);
        }

        // GET: Result/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Result/Create
        [HttpPost]
        public ActionResult Create(Result result)
        {

            if (ModelState.IsValid)
            {
                _repo.Create(result);
                return RedirectToAction("Index");
            }
                return View(result);
            
        }

        // GET: Result/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Result result = _repo.GetWhere(r => r.Id == id.Value).FirstOrDefault();
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: Result/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Result/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

            Result result = _repo.GetWhere(r => r.Id == id.Value).FirstOrDefault();
            if (result == null)
            {
                return HttpNotFound();
            }

            return View(result);
        }

        // POST: Result/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
                Result result = _repo.GetWhere(r => r.Id == id).FirstOrDefault();
                _repo.Delete(result);
                return RedirectToAction("Index");   
        }
    }
}
