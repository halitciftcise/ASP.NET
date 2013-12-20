using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        public interface IMeyve {
            double Fiyati { get; }
            string Hazirla();
            string Anavatani();
        }
        class Elma : IMeyve {
            public string Hazirla()
            {
                return "yıkayıp soyunuz ...";
            }
            public string Anavatani() {
                return "Amerika'dan gelmiştir.";
            }
            public double Fiyati { get { return 5; } }

        }
        class Armut : IMeyve
        {
            public string Hazirla()
            {
                return "yıkayıp doğramayanız ...";
            }
            public string Anavatani()
            {
                return "Afrika'dan gelmiştir.";
            }
            public double Fiyati { get { return 5; } }

        }
        class Erik : IMeyve {
            public string Hazirla() {
                return "yıkayınız. .. ";
            }
            public string Anavatani() {
                return "Mars'tan gelmiştir.";
            }
            public double Fiyati { get { return 4.2; } }
        }
        //Factory'ye herkes ulaşabilir.
        public class Factory {
            public static IMeyve CreateInstance(string adi) {
                IMeyve meyve;
                if (adi == "elma") meyve = new Elma();
                else if (adi == "armut") meyve = new Armut();
                else if (adi == "erik") meyve = new Erik();
                else meyve = null;// null yerine aslında en güzeli bir DefaultMeyve tanımlamak ve onu döndürmektir.
                                   //Yoksa bu metoddan null dönmesi demek çağıran client'in null kontrol'ü yapması,
                                   //yapmazsa da NullReferenceException'a toslaması demektir.
                return meyve;
            }
        }
        static void Main(string[] args)
        {
            IMeyve meyve1 = Factory.CreateInstance("elma");
            IMeyve meyve2 = Factory.CreateInstance("armut");
            IMeyve meyve3 = Factory.CreateInstance("erik");
            IMeyve meyve4 = Factory.CreateInstance("muz");//null a dikkat...

            Console.WriteLine(meyve1.Anavatani() + meyve1.Hazirla() +meyve1.Fiyati + "TL 'dir");
            Console.WriteLine(meyve2.Anavatani() + meyve2.Hazirla() + meyve2.Fiyati + "TL 'dir");
            Console.WriteLine(meyve3.Anavatani() + meyve3.Hazirla() + meyve3.Fiyati + "TL 'dir");
            //iptal ettik, çünkü kullanmaya kalkarsak "muz" durumunda meyve bulunamayacak ve
            //muz yerine NullReferenceException yiyeceğiz!
            //Console.WriteLine(meyve4.Anavatani() + meyve4.Hazirla() + meyve4.Fiyati + " TL'dir");

            Console.ReadKey();
        }
    }
}
