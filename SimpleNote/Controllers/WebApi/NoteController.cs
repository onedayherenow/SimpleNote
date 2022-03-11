using Microsoft.AspNet.Identity;
using SimpleNote.Models;
using SimpleNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleNote.Controllers.WebApi
{
    [Authorize]
    [RoutePrefix("api/Note")]
    public class NoteController : Controller
    {
        private bool SetStarState(int noteId, bool newState)
        {
            // Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);

            // Get the note
            var detail = service.GetNoteById(noteId);

            // Create the NoteEdit model instance with the new star state
            var updatedNote =
                new NoteEdit
                {
                    NoteId = detail.NoteId,
                    Title = detail.Title,
                    Content = detail.Content,
                    IsStarred = newState
                };

            // Return a value indicating whether the update succeeded
            return service.UpdateNote(updatedNote);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);


        // GET: Note
        public ActionResult Index()
        {
            return View();
        }
    }
}