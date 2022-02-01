using Microsoft.AspNet.Identity;
using SimpleNote.Models;
using SimpleNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleNote.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            var model = service.GetNotes();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
		{
			//check if modelstate is valid
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			//grabs current userId and calls a new note service for that user
			var service = CreateNoteService();

			if (service.CreateNote(model))
			{
				// then returns user back to the index view
				return RedirectToAction("Index");
			};
		}

		private NoteService CreateNoteService()
		{
			var userId = Guid.Parse(User.Identity.GetUserId());
			var service = new NoteService(userId);
			return service;
		}
	}
}