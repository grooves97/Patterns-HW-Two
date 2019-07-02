using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp
{
    public interface IBuilder
    {
        void BuildBodyPart();
        void BuildTankPlusPart();
        void BuildConditionerPart();
        void BuildNitroPart();
    }

    public class FordBuilder : IBuilder
    {
        private Product _product = new Product();

        public FordBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void BuildBodyPart()
        {
            this._product.Add("Body ford");
        }

        public void BuildConditionerPart()
        {
            this._product.Add("Conditioner ford");
        }

        public void BuildNitroPart()
        {
            this._product.Add("Nitro ford");
        }

        public void BuildTankPlusPart()
        {
            this._product.Add("Tank plus ford");
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

    public class ToyotaBuilder : IBuilder
    {
        private Product _product = new Product();

        public ToyotaBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void BuildBodyPart()
        {
            this._product.Add("Body toyota");
        }

        public void BuildConditionerPart()
        {
            this._product.Add("Conditioner toyota");
        }

        public void BuildNitroPart()
        {
            this._product.Add("Nitro toyota");
        }

        public void BuildTankPlusPart()
        {
            this._product.Add("Tank plus toyota");
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
            this._builder.BuildBodyPart();
        }

        public void Standard()
        {
            this._builder.BuildBodyPart();
            this._builder.BuildConditionerPart();
        }

        public void Lux()
        {
            this._builder.BuildBodyPart();
            this._builder.BuildConditionerPart();
            this._builder.BuildNitroPart();
            this._builder.BuildTankPlusPart();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            FordBuilder fordBuilder = new FordBuilder();
            director.Builder = fordBuilder;

            Console.WriteLine("Basic product:");
            director.Basic();
            Console.WriteLine(fordBuilder.GetProduct().ListParts());

            Console.WriteLine("Standard  product:");
            director.Standard();
            Console.WriteLine(fordBuilder.GetProduct().ListParts());

            Console.WriteLine("Lux full featured product:");
            director.Lux();
            Console.Write(fordBuilder.GetProduct().ListParts());

            Console.WriteLine("\n");

            //Toyota builder
            ToyotaBuilder toyotaBuilder = new ToyotaBuilder();
            director.Builder = toyotaBuilder;

            Console.WriteLine("Basic product:");
            director.Basic();
            Console.WriteLine(toyotaBuilder.GetProduct().ListParts());

            Console.WriteLine("Standard  product:");
            director.Standard();
            Console.WriteLine(toyotaBuilder.GetProduct().ListParts());

            Console.WriteLine("Lux full featured product:");
            director.Lux();
            Console.Write(toyotaBuilder.GetProduct().ListParts());
        }
    }
}
