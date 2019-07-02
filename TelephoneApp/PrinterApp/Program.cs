using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterApp
{
    public abstract class Printer
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

    public class PrinterCanon : Printer
    {
        public override IProduct FactoryMethod()
        {
            return new Canon();
        }
    }

    public class PrinterHP : Printer
    {
        public override IProduct FactoryMethod()
        {
            return new HP();
        }
    }

    public class Canon : IProduct
    {
        public string Operation()
        {
            return "Canon perl paper";
        }
    }

    public class HP : IProduct
    {
        public string Operation()
        {
            return "HP offset paper";
        }
    }

    class ClientWindowDialog
    {
        public void Main()
        {
            Console.WriteLine("App: Launched with the canon Printer");
            ClientCode(new PrinterCanon());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the hp Printer");
            ClientCode(new PrinterHP());
        }

        public void ClientCode(Printer creator)
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
