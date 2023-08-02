using System.Threading;
using static System.Console;

namespace TheAtlanticBank.Common;

public class LoadEffect
{
    public static void Load()
    {
        do
        {
            for(int i = 0; i < 3; i++)
            {
                Write(".");
                Thread.Sleep(1000);
            }
        }
        while(DateTime.Now.Millisecond < 6);
    }
}