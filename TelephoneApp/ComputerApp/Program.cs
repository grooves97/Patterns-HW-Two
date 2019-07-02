using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerApp
{
    public interface IBuilder
    {
        void BuildVideoCardPart();
        void BuildSoundCardPart();
        void BuildTunerPart();
        void BuildProcessorPart();
        void BuildMotherboardPart();
    }

    public class DellBuilder : IBuilder
    {
        private Product _product = new Product();

        public DellBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void BuildVideoCardPart()
        {
            this._product.Add("VideoCard dell");
        }
        public void BuildSoundCardPart()
        {
            this._product.Add("SoundCard dell");
        }
        public void BuildTunerPart()
        {
            this._product.Add("Tuner dell");
        }
        public void BuildProcessorPart()
        {
            this._product.Add("Processor dell");
        }

        public void BuildMotherboardPart()
        {
            this._product.Add("Motherboard dell");
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

    public class SonyBuilder : IBuilder
    {
        private Product _product = new Product();

        public SonyBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void BuildVideoCardPart()
        {
            this._product.Add("VideoCard sony");
        }
        public void BuildSoundCardPart()
        {
            this._product.Add("SoundCard sony");
        }
        public void BuildTunerPart()
        {
            this._product.Add("Tuner sony");
        }
        public void BuildProcessorPart()
        {
            this._product.Add("Processor sony");
        }

        public void BuildMotherboardPart()
        {
            this._product.Add("Motherboard sony");
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
            this._builder.BuildMotherboardPart();
            this._builder.BuildProcessorPart();
        }

        public void Standard()
        {
            this._builder.BuildMotherboardPart();
            this._builder.BuildProcessorPart();
            this._builder.BuildTunerPart();
        }
        public void StandardPlus()
        {
            this._builder.BuildMotherboardPart();
            this._builder.BuildProcessorPart();
            this._builder.BuildTunerPart();
            this._builder.BuildSoundCardPart();
        }
        public void Lux()
        {
            this._builder.BuildMotherboardPart();
            this._builder.BuildProcessorPart();
            this._builder.BuildTunerPart();
            this._builder.BuildSoundCardPart();
            this._builder.BuildVideoCardPart();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            DellBuilder fordBuilder = new DellBuilder();
            director.Builder = fordBuilder;

            Console.WriteLine("Basic product:");
            director.Basic();
            Console.WriteLine(fordBuilder.GetProduct().ListParts());

            Console.WriteLine("Standard  product:");
            director.Standard();
            Console.WriteLine(fordBuilder.GetProduct().ListParts());

            Console.WriteLine("Standard plus product:");
            director.StandardPlus();
            Console.WriteLine(fordBuilder.GetProduct().ListParts());

            Console.WriteLine("Lux full featured product:");
            director.Lux();
            Console.Write(fordBuilder.GetProduct().ListParts());

            Console.WriteLine("\n");

            //Toyota builder
            SonyBuilder toyotaBuilder = new SonyBuilder();
            director.Builder = toyotaBuilder;

            Console.WriteLine("Basic product:");
            director.Basic();
            Console.WriteLine(toyotaBuilder.GetProduct().ListParts());

            Console.WriteLine("Standard  product:");
            director.Standard();
            Console.WriteLine(toyotaBuilder.GetProduct().ListParts());

            Console.WriteLine("Standard plus product:");
            director.StandardPlus();
            Console.WriteLine(toyotaBuilder.GetProduct().ListParts());

            Console.WriteLine("Lux full featured product:");
            director.Lux();
            Console.Write(toyotaBuilder.GetProduct().ListParts());
        }
    }
}
