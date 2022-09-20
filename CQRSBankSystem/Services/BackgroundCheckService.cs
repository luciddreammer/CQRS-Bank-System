using CQRSBankSystem.Data.DBContext;
using CQRSBankSystem.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSBankSystem.Services
{
    public class BackgroundCheckService : BackgroundService
    {
        private CQRSBankSystemContext contextSecond;
        private MoneyService _moneyService;

        public BackgroundCheckService( IServiceProvider serviceProvider)
        {
            contextSecond = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<CQRSBankSystemContext>();
            _moneyService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<MoneyService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stopToken)
        {
            //Twój kod startujący zaczyna się tu
            while (!stopToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(1000, stopToken);
                    var someRecord = contextSecond.Events.FirstOrDefault(s => s.Status == "FirstVerificationPassed");
                    if(someRecord != null)
                    {
                        _moneyService.NewMoneyTransfer(someRecord);
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
