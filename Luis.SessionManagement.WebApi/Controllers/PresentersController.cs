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
    public class PresentersController : ApiController
    {
        private SessionContext db = new SessionContext();
        private readonly IPresenterHandler _presenterHandler;

        public PresentersController(IPresenterHandler presenterHandler)
        {
            _presenterHandler = presenterHandler;
        }

        // GET: api/Presenters
        public async Task<IHttpActionResult> GetPresenters()
        {
            var presenterList = await _presenterHandler.GetPresentersAsync();
            return Ok(presenterList.ToContract());  
        }

        // GET: api/Presenters/5
        [ResponseType(typeof(Presenter))]
        public async Task<IHttpActionResult> GetPresenter(int id)
        {
            var session = await _presenterHandler.GetPresenterAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(session.ToContract());
        }

        // PUT: api/Presenters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPresenter(int id, Presenter presenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != presenter.Id)
            {
                return BadRequest();
            }

            db.Entry(presenter).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresenterExists(id))
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

        // POST: api/Presenters
        [ResponseType(typeof(Presenter))]
        public async Task<IHttpActionResult> PostPresenter(Presenter presenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Presenters.Add(presenter);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = presenter.Id }, presenter);
        }

        // DELETE: api/Presenters/5
        [ResponseType(typeof(Presenter))]
        public async Task<IHttpActionResult> DeletePresenter(int id)
        {
            Presenter presenter = await db.Presenters.FindAsync(id);
            if (presenter == null)
            {
                return NotFound();
            }

            db.Presenters.Remove(presenter);
            await db.SaveChangesAsync();

            return Ok(presenter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PresenterExists(int id)
        {
            return db.Presenters.Count(e => e.Id == id) > 0;
        }
    }
}