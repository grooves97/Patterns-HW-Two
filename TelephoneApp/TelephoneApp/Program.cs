using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneApp
{
    public interface IBuilder
    {
        void BuildBodypart();
        void BuildBatteryPlusPart();
        void BuildCoverPart();
    }

    public class SamsungBuilder : IBuilder
    {
        private Product _product = new Product();

        public SamsungBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void BuildBodypart()
        {
            this._product.Add("Body samsung");
        }

        public void BuildBatteryPlusPart()
        {
            this._product.Add("Battery plus samsung");
        }

        public void BuildCoverPart()
        {
            this._product.Add("Cover samsung");
        }

        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }

    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2);

            return "Product parts: " + str + "\n";
        }
    }

    public class NokiaBuilder : IBuilder
    {
        private Product _product = new Product();

        public NokiaBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void BuildBodypart()
        {
            this._product.Add("Body nokia");
        }

        public void BuildBatteryPlusPart()
        {
            this._product.Add("Battery plus samsung");
        }

        public void BuildCoverPart()
        {
            this._product.Add("Cover nokia");
        }

        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }

    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void Basic()
        {
            this._builder.BuildBodypart();
        }

        public void Standard()
        {
            this._builder.BuildBodypart();
            this._builder.BuildCoverPart();
        }
        public void Lux()
        {
            this._builder.BuildBodypart();
            this._builder.BuildCoverPart();
            this._builder.BuildBatteryPlusPart();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            SamsungBuilder samsungBuilder = new SamsungBuilder();
            director.Builder = samsungBuilder;

            Console.WriteLine("Basic product:");
            director.Basic();
            Console.WriteLine(samsungBuilder.GetProduct().ListParts());

            Console.WriteLine("Standard  product:");
            director.Standard();
            Console.WriteLine(samsungBuilder.GetProduct().ListParts());

            Console.WriteLine("Lux full featured product:");
            director.Lux();
            Console.Write(samsungBuilder.GetProduct().ListParts());

            Console.WriteLine("\n");

            //Nokia builder
            NokiaBuilder nokiaBuilder = new NokiaBuilder();
            director.Builder = nokiaBuilder;

            Console.WriteLine("Basic product:");
            director.Basic();
            Console.WriteLine(nokiaBuilder.GetProduct().ListParts());

            Console.WriteLine("Standard  product:");
            director.Standard();
            Console.WriteLine(nokiaBuilder.GetProduct().ListParts());

            Console.WriteLine("Lux full featured product:");
            director.Lux();
            Console.WriteLine(nokiaBuilder.GetProduct().ListParts());
        }
    }
}
