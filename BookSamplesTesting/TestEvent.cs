using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSamplesTesting
{
    class TestEvent
    {
        public static void StartTest()
        {
            Stock stock = new Stock("THPW");
            stock.Price = 27.10M;
            Console.WriteLine("\nEventTest\n---------\nValue before: "+stock.Price);
            // Register with the PriceChanged event
            stock.PriceChanged += stock_PriceChanged;
            stock.Price = 31.59M;
            Console.WriteLine("Value after: "+ stock.Price);
            Console.WriteLine("Value before: " + stock.Price);
            stock.Price = 36.7M;
            Console.WriteLine("Value after: " + stock.Price);
        }
        static void stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            decimal percent = (e.NewPrice - e.LastPrice) / e.LastPrice;
            if (percent > 0.15M)
                Console.WriteLine(String.Format("Alert, {0:#.0}% stock price increase!", percent*100));
        }
        public class PriceChangedEventArgs : System.EventArgs
        {
            public readonly decimal LastPrice;
            public readonly decimal NewPrice;
            public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
            {
                LastPrice = lastPrice;
                NewPrice = newPrice;
            }
        }
        public class Stock
        {
            string symbol; decimal price;

            public Stock(string symbol)
            {
                this.symbol = symbol;
            }
            public event EventHandler<PriceChangedEventArgs> PriceChanged;
            protected virtual void OnPriceChanged(PriceChangedEventArgs е)
            {
                if (PriceChanged != null) PriceChanged(this, е);
            }
            public decimal Price
            {
                get
                {
                    return price;
                }
                set
                {
                    if (price == value) return;
                    OnPriceChanged(new PriceChangedEventArgs (price, value));
                    price = value;
                }
            }
        }       
    }
}
