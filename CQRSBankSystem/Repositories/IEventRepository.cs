using CQRSBankSystem.Data.Enums;
using CQRSBankSystem.Data.Models;
using CQRSBankSystem.Data.ViewModels;

namespace CQRSBankSystem.Repositories
{
    public interface IEventRepository
    {
        Event AddEvent(TypeOfOperationEnum typeOfOperation, double ammount, int toId, string cookie);
        string DataVerification(Event singleEvent);
        void CancelEvent(Event singleEvent, string reason);
        void ConfirmEvent(Event singleEvent);
    }
}
