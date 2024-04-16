using Confluent.Kafka;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System;
using Balance.App.Data;

namespace Balance.App.Worker
{
    public class WorkerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public WorkerService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BalanceDbContext>();

                var conf = new ConsumerConfig
                {
                    GroupId = "wallet",
                    BootstrapServers = "kafka:29092",
                    AutoOffsetReset = AutoOffsetReset.Earliest,
                    ReceiveMessageMaxBytes = 1213486160,
                };
                using var c = new ConsumerBuilder<Ignore, string>(conf).Build();
                {
                    c.Subscribe("balances");

                    var cts = new CancellationTokenSource();
                    Console.CancelKeyPress += (_, e) =>
                    {
                        e.Cancel = true;
                        cts.Cancel();
                    };

                    try
                    {
                        while (!stoppingToken.IsCancellationRequested)
                        {
                            try
                            {
                                var cr = c.Consume(stoppingToken);

                                var balance = JsonSerializer.Deserialize<Model.Balance>(cr.Message.Value);

                                var accountFrom = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == Guid.Parse(balance.Payload.AccountIdFrom), stoppingToken);
                                var accountTo = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == Guid.Parse(balance.Payload.AccountIdTo), stoppingToken);

                                if (accountFrom != null && accountTo != null)
                                {
                                    accountFrom.Balance = balance.Payload.BalanceAccountIdFrom;
                                    accountTo.Balance = balance.Payload.BalanceAccountIdTo;

                                    await dbContext.SaveChangesAsync(stoppingToken);
                                }
                                else
                                {
                                    Console.WriteLine("Conta não encontrada.");
                                }
                            }
                            catch (ConsumeException e)
                            {
                                Console.WriteLine($"Erro ocorrido: {e.Error.Reason}");
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        c.Close();
                    }
                }
            }
        }
    }
}
