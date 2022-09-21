using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Data.Dictionaires;
using CQRSBankSystem.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSBankSystem.Services
{
    public class BackgroundCheckService : BackgroundService
    {
        private CQRSBankSystemContext _context;
        private MoneyService _moneyService;

        public BackgroundCheckService( IServiceProvider serviceProvider)
        {
            _context = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<CQRSBankSystemContext>();
            _moneyService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<MoneyService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stopToken)
        {
            while (!stopToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(1000, stopToken);
                    var verifiedEvent = _context.Events.FirstOrDefault(s => s.Status == StatusDictionary.Statuses["Approved"]);
                    if(verifiedEvent != null)
                    {
                        _moneyService.NewMoneyTransfer(verifiedEvent);
                        Console.WriteLine("MoneyTransferDone");
                    }
                }
                catch (OperationCanceledException)
                {
                    return;
                }

            }
        }
    }
}
