using TheAtlanticBank.Entities;

namespace TheAtlanticBank.Data;

public class DataStore
{
    public static List<Customer> customers { get; set; } = new List<Customer>();
    public static List<Account> accounts { get; set;} = new List<Account>();
    public static List<Transaction> transactions { get; set; } = new List<Transaction>();
}
