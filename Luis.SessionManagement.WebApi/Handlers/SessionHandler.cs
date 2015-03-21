using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Luis.SessionManagement.WebApi.Models;

namespace Luis.SessionManagement.WebApi.Handlers
{
    public interface ISessionHandler
    {
        Task<Session> GetSessionAsync(int sessionId);
        Task<List<Session>> GetSessionsAsync();
        Task<Session> AddSessionAsync(Session session);
        Task<Session> UpdateSessionAsync(int sessionId, Session session);
        bool SessionExists(int sessionId);
        Task<Session> DeleteSessionAsync(int sessionId);
    }

    public class SessionHandler : ISessionHandler
    {
        private readonly SessionContext _sessionContext;

        public SessionHandler(SessionContext sessionContext)
        {
            _sessionContext = sessionContext;
        }

        public async Task<Session> GetSessionAsync(int sessionId)
        {
            var session = await _sessionContext.Sessions.FindAsync(sessionId);
            return session;
        }

        public async Task<List<Session>> GetSessionsAsync()
        {
            var sessionList = await _sessionContext.Sessions.ToListAsync();
            return sessionList;
        }

        public async  Task<Session> AddSessionAsync(Session session)
        {
            _sessionContext.Sessions.Add(session);

            await _sessionContext.SaveChangesAsync();

            return session;
        }

        public async Task<Session> UpdateSessionAsync(int sessionId, Session session)
        {
            var existingSession = await _sessionContext.Sessions.FindAsync(sessionId);

            if (existingSession == null)
            {
                return null;
            }

            session.UpdateDate = DateTime.UtcNow;
            session.CreateDate = existingSession.CreateDate;
            //_sessionContext.Entry(session).State = EntityState.Modified;

            _sessionContext.Sessions.AddOrUpdate(session);

            await _sessionContext.SaveChangesAsync();

            return existingSession;
        }

        public bool SessionExists(int sessionId)
        {
            return _sessionContext.Sessions.Any(e => e.Id == sessionId);
        }

        public async Task<Session> DeleteSessionAsync(int sessionId)
        {
            var existingSession = await _sessionContext.Sessions.FindAsync(sessionId);

            if (existingSession == null)
            {
                return null;
            }

            _sessionContext.Sessions.Remove(existingSession);
            await _sessionContext.SaveChangesAsync();

            return existingSession;
        }        
    }
}