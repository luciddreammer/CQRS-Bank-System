using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Data.Models;
using CQRSBankSystem.Data.ViewModels;

namespace CQRSBankSystem.Repositories
{
    public class EventRepository : IEventRepository
    {
        private CQRSBankSystemContext _context;

        public EventRepository(CQRSBankSystemContext context)
        {
            _context = context;
        }

        void IEventRepository.AddEvent(EventsVM singleEvent)
        {

        }
        bool IEventRepository.DataVerification(Event singleEvent)
        {
            return false;
        }
        void IEventRepository.CancelEvent(Event singleEvent)
        {

        }
        void IEventRepository.ConfirmEvent(Event singleEvent)
        {

        }
    }
}
