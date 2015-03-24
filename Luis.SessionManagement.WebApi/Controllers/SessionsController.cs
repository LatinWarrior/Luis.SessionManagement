using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Luis.SessionManagement.WebApi.Handlers;
using Newtonsoft.Json;
using C = Luis.SessionManagement.WebApi.Contracts;
using M = Luis.SessionManagement.WebApi.Models;

namespace Luis.SessionManagement.WebApi.Controllers
{
    [EnableCors(origins: "http://localhost:8688,http://localhost:1841", headers: "*", methods: "*")]
    public class SessionsController : ApiController
    {        
        private readonly ISessionHandler _sessionHandler;

        public SessionsController(ISessionHandler sessionHandler)
        {
            _sessionHandler = sessionHandler;
        }

        // GET: api/Sessions
        public async Task<IHttpActionResult> GetSessions()
        {
            var sessionList = await _sessionHandler.GetSessionsAsync();            
            return Ok(sessionList.ToContract());            
        }

        // GET: api/Sessions/5
        [ResponseType(typeof(C.Session))]
        public async Task<IHttpActionResult> GetSession(int id)
        {
            var session = await _sessionHandler.GetSessionAsync(id);
            
            if (session == null)
            {
                return NotFound();
            }            

            return Ok(session.ToContract());
        }

        // PUT: api/Sessions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSession(int id, C.Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != session.Id)
            {
                return BadRequest();
            }

            var sessionExists = _sessionHandler.SessionExists(session.Id);

            if (!sessionExists)
            {
                return NotFound();
            }

            var updatedSession = await _sessionHandler.UpdateSessionAsync(id, session.ToModel());                     

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Sessions
        [ResponseType(typeof(C.Session))]
        public async Task<IHttpActionResult> PostSession(C.Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            

            var updatedSession = await _sessionHandler.AddSessionAsync(session.ToModel());

            return CreatedAtRoute("DefaultApi", new { id = session.Id }, updatedSession.ToContract());
        }

        // DELETE: api/Sessions/5
        [ResponseType(typeof(C.Session))]
        public async Task<IHttpActionResult> DeleteSession(int id)
        {
            var sessionExists = _sessionHandler.SessionExists(id);

            if (sessionExists)
            {
                return NotFound();
            }

            var session = await _sessionHandler.DeleteSessionAsync(id);

            return Ok(session.ToContract());
        }             
    }
}