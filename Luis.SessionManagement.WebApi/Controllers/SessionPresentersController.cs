using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Luis.SessionManagement.WebApi.Handlers;
using Luis.SessionManagement.WebApi.Models;

namespace Luis.SessionManagement.WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:8688,http://localhost:1841", headers: "*", methods: "*")]
    public class SessionPresentersController : ApiController
    {
        private SessionContext db = new SessionContext();
        private readonly ISessionPresenterHandler _sessionPresenterHandler;

        public SessionPresentersController(ISessionPresenterHandler sessionPresenterHandler)
        {
            _sessionPresenterHandler = sessionPresenterHandler;
        }

        // GET: api/SessionPresenters
        public async Task<IHttpActionResult> GetSessionPresenters()
        {
            var sessionPresenters = await _sessionPresenterHandler.GetPresentersAsync();
            return Ok(sessionPresenters.ToContract());
        }

        // GET: api/SessionPresenters/5
        [ResponseType(typeof(SessionPresenter))]
        public async Task<IHttpActionResult> GetSessionPresenter(int id)
        {
            SessionPresenter sessionPresenter = await db.SessionPresenters.FindAsync(id);
            if (sessionPresenter == null)
            {
                return NotFound();
            }

            return Ok(sessionPresenter);
        }

        // PUT: api/SessionPresenters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSessionPresenter(int id, SessionPresenter sessionPresenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sessionPresenter.Id)
            {
                return BadRequest();
            }

            db.Entry(sessionPresenter).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionPresenterExists(id))
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

        // POST: api/SessionPresenters
        [ResponseType(typeof(SessionPresenter))]
        public async Task<IHttpActionResult> PostSessionPresenter(SessionPresenter sessionPresenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SessionPresenters.Add(sessionPresenter);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sessionPresenter.Id }, sessionPresenter);
        }

        // DELETE: api/SessionPresenters/5
        [ResponseType(typeof(SessionPresenter))]
        public async Task<IHttpActionResult> DeleteSessionPresenter(int id)
        {
            SessionPresenter sessionPresenter = await db.SessionPresenters.FindAsync(id);
            if (sessionPresenter == null)
            {
                return NotFound();
            }

            db.SessionPresenters.Remove(sessionPresenter);
            await db.SaveChangesAsync();

            return Ok(sessionPresenter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SessionPresenterExists(int id)
        {
            return db.SessionPresenters.Count(e => e.Id == id) > 0;
        }
    }
}