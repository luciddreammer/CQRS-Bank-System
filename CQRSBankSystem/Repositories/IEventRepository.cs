using CQRSBankSystem.Data.Models;
using CQRSBankSystem.Data.ViewModels;

namespace CQRSBankSystem.Repositories
{
    public interface IEventRepository
    {
        void AddEvent(EventsVM singleEvent);
        bool DataVerification(Event singleEvent);
        void CancelEvent(Event singleEvent);
        void ConfirmEvent(Event singleEvent);
    }
}
