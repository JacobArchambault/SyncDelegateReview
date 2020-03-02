using static System.Console;
using static System.Threading.Thread;

namespace SyncDelegateReview
{
    public delegate int BinaryOp(int x, int y);

    class Program
    {        
        static void Main()
        {
            WriteLine("***** Sync Delegate Review *****");

            // Print out the ID of the executing thread.
            WriteLine("Main() invoked on thread {0}.", CurrentThread.ManagedThreadId);

            // Invoke Add() in a synchronous manner.
            BinaryOp b = new BinaryOp(Add);

            // Could also write b.Invoke(10, 10);
            int answer = b(10, 10);

            // These lines will not execute until the Add() method has completed.
            WriteLine("Doing more work in Main()!");
            WriteLine("10 + 10 is {0}.", answer);
            ReadLine();
        }

        static int Add(int x, int y)
        {
            // Print out the ID of the executing thread.
            WriteLine("Add() invoked on thread {0}.", CurrentThread.ManagedThreadId);

            // Pause to simulate a lengthy operation.
            Sleep(5000);
            return x + y;
        }
    }
}
