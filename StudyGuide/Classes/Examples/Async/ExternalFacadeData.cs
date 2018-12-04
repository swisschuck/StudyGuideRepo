using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Async
{
    public class ExternalFacadeData
    {
        #region fields
        /// <summary>
        /// External method for checking internet access:
        /// </summary>
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods


        /// <summary>
        /// C# callable method to check internet access
        /// </summary>
        public static bool IsConnectedToInternet()
        {
            int Description;
            return InternetGetConnectedState(out Description, 0);
        }

        /// <summary>
        /// Returns last 10 years of historical data for given stock symbol.
        /// </summary>
        /// <param name="symbol">stock ticker symbol, e.g. 'msft'</param>
        /// <returns></returns>
        public static StockData GetHistoricalData(string symbol, int numYearsOfHistory)
        {
            //
            // If we have an internet connection, download data live, otherwise check the cache
            // and see if we have the data available...
            //
            if (IsConnectedToInternet())
            {
                return GetDataFromInternet(symbol, numYearsOfHistory);
            }
            else
            {
                //return GetDataFromFileCache(symbol, numYearsOfHistory);
                return null;
            }
        }



        #endregion public methods


        #region private methods

        /// <summary>
        /// Tries to download historial data from 3 different web sites, in parallel.  The data
        /// returned is from the first site that responds.  Sites used:  nasdaq, yahoo, and msn 
        /// (although msn only provides a year of weekly data, so others are preferred).
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="numYearsOfHistory"></param>
        /// <returns></returns>
        private static StockData GetDataFromInternet(string symbol, int numYearsOfHistory)
        {
            //
            // Start tasks to retrieve data from each site:
            //
            Task<StockData> yahooTask = Task.Factory.StartNew(() =>
            {
                StockData yahoo = GetDataFromYahoo(symbol, numYearsOfHistory);
                return yahoo;
            }
            );

            Task<StockData> nasdaqTask = Task.Factory.StartNew(() =>
            {
                StockData nasdaq = GetDataFromNasdaq(symbol, numYearsOfHistory);
                return nasdaq;
            }
            );

            Task<StockData> msnTask = Task.Factory.StartNew(() =>
            {
                StockData msn = GetDataFromMsn(symbol, numYearsOfHistory);
                return msn;
            }
            );

            //
            // Now wait for the first one to return data:
            //
            Task<StockData>[] tasksArray = { yahooTask, nasdaqTask, msnTask };
            int index = Task.WaitAny(tasksArray);

            return tasksArray[index].Result;

            // all failed:
            throw new ApplicationException("all web sites failed");
        }

        /// <summary>
        /// Downloads data from Yahoo.
        /// </summary>
        private static StockData GetDataFromYahoo(string symbol, int numYearsOfHistory)
        {
            System.Diagnostics.Debug.WriteLine("Yahoo initiated on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            //
            // finance.yahoo.com, data format:
            //
            //   Date (YYYY-MM-DD),Open,High,Low,Close,Volume,Adj Close
            //
            DateTime today = DateTime.Now;

            string url = string.Format("http://ichart.finance.yahoo.com/table.csv?s={0}&d={1}&e={2}&f={3}&g=d&a={1}&b={2}&c={4}&ignore=.csv",
                symbol,
                today.Month - 1,
                today.Day - 1,
                today.Year,
                today.Year - numYearsOfHistory);

            //
            // Fire off web request:
            //
            HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(url);
            WebRequestObject.Timeout = 15 * 1000 /*15 secs*/;
            WebResponse Response = WebRequestObject.GetResponse();

            //
            // We have response, now open data stream and process the data:
            //
            System.Diagnostics.Debug.WriteLine("Yahoo processed on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            string dataSource = string.Format("http://finance.yahoo.com, daily Adj Close, {0} years", numYearsOfHistory);

            List<decimal> prices = GetData(Response, new char[] { ',' }, 6 /*Adj Close*/);

            if (prices.Count == 0)
                throw new ApplicationException("site returned no data");

            return new StockData(dataSource, prices);
        }


        /// <summary>
        /// Downloads data from Nasdaq.
        /// </summary>
        private static StockData GetDataFromNasdaq(string symbol, int numYearsOfHistory)
        {
            System.Diagnostics.Debug.WriteLine("Nasdaq initiated on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            //
            // nasdaq.com, data format:
            //
            //   Date (MM-DD-YYYY)\tOpen\tHigh\tLow\tClose\tVolume\t
            //
            string url = string.Format("http://charting.nasdaq.com/ext/charts.dll?2-1-14-0-0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0|0,0,0,0,0-5120-03NA000000{0}-&SF:4|5-WD=539-HT=395--XXCL-",
                symbol);

            //
            // Fire off web request:
            //
            HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(url);
            WebRequestObject.Timeout = 15 * 1000 /*15 secs*/;
            WebResponse Response = WebRequestObject.GetResponse();

            //
            // We have response, now open data stream and process the data:
            //
            System.Diagnostics.Debug.WriteLine("Nasdaq processed on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            string dataSource = string.Format("http://nasdaq.com, daily Close, {0} years", numYearsOfHistory);

            List<decimal> prices = GetData(Response, new char[] { '\t' }, 4 /*Close*/);

            if (prices.Count == 0)
                throw new ApplicationException("site returned no data");

            return new StockData(dataSource, prices);
        }


        /// <summary>
        /// Downloads data from MSN.
        /// 
        /// NOTE: MSN only returns 1 year of data, and weekly, so this result is not preferred.
        /// </summary>
        private static StockData GetDataFromMsn(string symbol, int numYearsOfHistory)
        {
            System.Diagnostics.Debug.WriteLine("MSN initiated on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            //
            // MSN, data format:
            //
            //   Date (MM-DD-YYYY),Open,High,Low,Close,Volume
            //
            // NOTE: MSN only provides one year of historical data, and only by week.
            //
            string url = string.Format("http://moneycentral.msn.com/investor/charts/chartdl.aspx?C1=0&C2=1&height=258&width=612&CE=0&symbol={0}&filedownloadbt.x=1",
                symbol);

            //
            // Fire off web request:
            //
            HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(url);
            WebRequestObject.Timeout = 15 * 1000 /*15 secs*/;
            WebResponse Response = WebRequestObject.GetResponse();

            //
            // We have response, now open data stream and process the data:
            //
            System.Diagnostics.Debug.WriteLine("MSN processed on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            string dataSource = "http://moneycentral.msn.com, weekly Close, 1 year";

            List<decimal> prices = GetData(Response, new char[] { ',' }, 4 /*Close*/);

            if (prices.Count == 0)
                throw new ApplicationException("site returned no data");

            return new StockData(dataSource, prices);
        }


        /// <summary>
        /// Opens given data stream and reads the data; could be from the web, or a local file.
        /// Note that the given Response stream is closed for you before returning.
        /// </summary>
        /// <param name="Response">stream to read (closed upon completion)</param>
        /// <param name="separators">char(s) that delimit data fields</param>
        /// <param name="dataIndex">0-based index of price field of interest (open, close, etc.)</param>
        /// <returns></returns>
        private static List<decimal> GetData(WebResponse Response, char[] separators, int dataIndex)
        {
            //
            // Open data stream and download/read the data:
            //
            try
            {
                List<decimal> prices = new List<decimal>();

                using (Stream WebStream = Response.GetResponseStream())
                {
                    using (StreamReader Reader = new StreamReader(WebStream))
                    {

                        //
                        // Read data stream:
                        //
                        while (!Reader.EndOfStream)
                        {
                            string record = Reader.ReadLine();
                            string[] tokens = record.Split(separators);

                            //
                            // valid records start with a date:
                            //
                            DateTime date;
                            decimal data;

                            if (DateTime.TryParse(tokens[0], out date))
                                if (Decimal.TryParse(tokens[dataIndex], out data))
                                    prices.Add(data);
                        }//while

                    }//using--Reader
                }//using--WebStream

                //
                // return list of historical prices:
                //
                return prices;

            }
            finally
            {
                try // ensure response stream is closed before return:
                {
                    Response.Close();
                }
                catch
                { /*ignore*/ }
            }
        }
        #endregion private methods
    }
}
