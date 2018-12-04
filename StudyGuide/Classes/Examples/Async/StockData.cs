using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Async
{
    public class StockData
    {
        public string DataSource { get; private set; }
        public List<decimal> Prices { get; private set; }

        public StockData(string dataSource, List<decimal> prices)
        {
            this.DataSource = dataSource;
            this.Prices = prices;
        }
    }
}
