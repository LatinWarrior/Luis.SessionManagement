using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Luis.SessionManagement.WebApi.Models;

namespace Luis.SessionManagement.WebApi.Handlers
{
    public interface ISessionPresenterHandler
    {        
        Task<List<SessionPresenter>> GetPresentersAsync();
    }

    public class SessionPresenterHandler : ISessionPresenterHandler
    {
        private readonly SessionContext _sessionContext;

        public SessionPresenterHandler(SessionContext sessionContext)
        {
            _sessionContext = sessionContext;
        }

        public async Task<List<SessionPresenter>> GetPresentersAsync()
        {
            var sessionPresenters = await _sessionContext.SessionPresenters.ToListAsync();
            return sessionPresenters;

        }
    }
}