using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogWindowApp
{
    public abstract class WindowDialog
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            IProduct product = FactoryMethod();

            string result = "Creator: The same creator's code has just worked with "
                + product.Operation();

            return result;
        }
    }

    public interface IProduct
    {
        string Operation();
    }

    public class WindowDialogWindows : WindowDialog
    {
        public override IProduct FactoryMethod()
        {
            return new Window();
        }
    }

    public class WindowDialogBrowser : WindowDialog
    {
        public override IProduct FactoryMethod()
        {
            return new Google();
        }
    }

    public class Window : IProduct
    {
        public string Operation()
        {
            return "Windows open native";
        }
    }

    public class Google : IProduct
    {
        public string Operation()
        {
            return "Browser open HTML";
        }
    }

    class ClientWindowDialog
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the windows WindowDialog");
            ClientCode(new WindowDialogWindows());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the google WindowDialog");
            ClientCode(new WindowDialogBrowser());
        }

        public void ClientCode(WindowDialog creator)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class," +
                "but it still works.\n" + creator.SomeOperation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new ClientWindowDialog().Main();
        }
    }
}
