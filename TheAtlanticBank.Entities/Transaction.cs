namespace TheAtlanticBank.Entities;

public class Transaction
{
    public Transaction(int transactionId, string description, decimal amount, int accountId)
    {
        TransactionId = transactionId;
        AccId = accountId;
        Description = description;
        Amount = amount;
        DateOfTransaction = DateTime.Now.ToString("MM/dd/yyyy");
    }
    public int TransactionId { get; set; }
    public int AccId { get; set; }
    public string DateOfTransaction { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
}