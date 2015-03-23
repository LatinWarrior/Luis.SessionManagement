using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Luis.SessionManagement.WebApi.Models;

namespace Luis.SessionManagement.WebApi.Handlers
{
    public interface IPresenterHandler
    {
        Task<Presenter> GetPresenterAsync(int presenterId);
        Task<List<Presenter>> GetPresentersAsync();
        Task<Presenter> AddPresenterAsync(Presenter presenter);
        Task<Presenter> UpdatePresenterAsync(int presenterId, Presenter presenter);
        bool PresenterExists(int presenterId);
        Task<Presenter> DeletePresenterAsync(int presenterId);
    }

    public class PresenterHandler : IPresenterHandler
    {
        private readonly SessionContext _sessionContext;

        public PresenterHandler(SessionContext sessionContext)
        {
            _sessionContext = sessionContext;
        }

        public async Task<Presenter> GetPresenterAsync(int presenterId)
        {
            var presenter = await _sessionContext.Presenters.FindAsync(presenterId);
            return presenter;                        
        }

        public async Task<List<Presenter>> GetPresentersAsync()
        {
            var presenters = await _sessionContext.Presenters.ToListAsync();
            return presenters;
        }

        public async  Task<Presenter> AddPresenterAsync(Presenter presenter)
        {
            _sessionContext.Presenters.Add(presenter);

            await _sessionContext.SaveChangesAsync();

            return presenter;
        }

        public async Task<Presenter> UpdatePresenterAsync(int presenterId, Presenter presenter)
        {
            var existingPresenter = await _sessionContext.Presenters.FindAsync(presenterId);

            if (existingPresenter == null)
            {
                return null;
            }

            presenter.UpdateDate = DateTime.UtcNow;
            presenter.CreateDate = existingPresenter.CreateDate;
            //_sessionContext.Entry(session).State = EntityState.Modified;

            _sessionContext.Presenters.AddOrUpdate(presenter);

            await _sessionContext.SaveChangesAsync();

            return existingPresenter;
        }

        public bool PresenterExists(int presenterId)
        {
            return _sessionContext.Presenters.Any(e => e.Id == presenterId);
        }

        public async Task<Presenter> DeletePresenterAsync(int presenterId)
        {
            var existingPresenter = await _sessionContext.Presenters.FindAsync(presenterId);

            if (existingPresenter == null)
            {
                return null;
            }

            _sessionContext.Presenters.Remove(existingPresenter);
            await _sessionContext.SaveChangesAsync();

            return existingPresenter;
        }
    }
}