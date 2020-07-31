using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeFundsApi.Interface;
using FreeFundsApi.Models;
using FreeFundsApi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FreeFundsApi.Concrete
{
    public class AllTransactionConcrete : IAllTransaction
    {

        private readonly DatabaseContext context;
        public AllTransactionConcrete(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<AllTransaction> GetTransactionbyIdAsync(int TransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AllTransaction>> GetTransactionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<long> InsertTransactionAsync(AllTransaction transaction)
        {
            using (var DBtransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var currentBal = await context.Users.Where(aa => aa.UserId == transaction.UserId).Select(aa => aa.CurrentBal).FirstOrDefaultAsync();
                    transaction.CurrentBal = currentBal;
                    await context.AllTransactions.AddAsync(transaction);
                    long transactionID = await context.SaveChangesAsync();
                    if (transactionID > 0)
                    {
                        await context.PaymentTransactions.AddAsync(new PaymentTransaction
                        {
                            CreatedDate = DateTime.Now,
                            TransactionAmount = transaction.TransactionAmount,
                            TransactionId = transactionID,
                            UserID = transaction.CreatedBy
                        });

                        long paymnetId = await context.SaveChangesAsync();
                        if (paymnetId > 0)
                        {
                            await DBtransaction.CommitAsync();
                        }
                        else
                        {
                            await DBtransaction.RollbackAsync();
                        }
                        return transactionID;
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    await DBtransaction.RollbackAsync();
                    throw;
                }
            }

        }

    }
}
