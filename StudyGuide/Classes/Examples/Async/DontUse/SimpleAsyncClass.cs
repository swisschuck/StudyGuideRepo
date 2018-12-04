using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Async
{
    public class SimpleAsyncClass
    {
        // This class was from the first course i took on pluralsite on async coding, i didnt like it very much but wanted to keep the code for reference

        #region fields

        private int _oneSecondsInMilliSeconds = 1000;
        private int _threeSecondsInMilliSeconds = 3000;
        private int _fiveSecondsInMilliSeconds = 5000;
        private int _tenSecondsInMilliSeconds = 10000;

        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods


        public async Task<string> ASimpleAsyncTaskReturnMethod()
        {
            Console.WriteLine("Starting ASimpleAsyncTaskReturnMethod method...");

            var myTask = await Task.Run(() =>
            {
                int count = 1;
                for (int i = 0; i < _tenSecondsInMilliSeconds; i++)
                {
                    if (i % 1000 == 0)
                    {
                        Console.WriteLine(String.Format("{0}...", count.ToString()));
                        count++;
                    }
                }
                return "a ASimpleAsyncTaskReturnMethod complete";

            });

            return myTask;
        }


        public async Task ASimpleAsyncTaskMethod()
        {
            Console.WriteLine("Starting ASimpleAsyncTaskMethod method...");

            var myTask = Task.Run(() =>
            {
                int count = 1;
                for (int i = 0; i < _tenSecondsInMilliSeconds; i++)
                {
                    if (i % 1000 == 0)
                    {
                        Console.WriteLine(String.Format("{0}...", count.ToString()));
                        count++;
                    }
                }

                return "ASimpleAsyncTaskMethod Complete";
            });

            await myTask.ContinueWith((myTaskFromAbove) =>
            {
                Console.WriteLine(myTaskFromAbove.Result);
                return;
            });
        }


        // DONT EVER DO AN async void! this is just here as a threading example
        public async void ASimpleAsyncMethod()
        {
            Console.WriteLine("Starting ASimpleAsyncMethod method...");

            var myTask = Task.Run(() =>
            {
                int count = 1;
                for (int i = 0; i < _tenSecondsInMilliSeconds; i++)
                {
                    if (i % 1000 == 0)
                    {
                        Console.WriteLine(String.Format("{0}...", count.ToString()));
                        count++;
                    }
                }

                return "ASimpleAsyncMethod Complete";
            });

            await myTask.ContinueWith((myTaskFromAbove) =>
            {
                Console.WriteLine(myTaskFromAbove.Result);
            });
        }




        public async Task<string> AsyncMethod1()
        {
            Console.WriteLine("Starting AsyncMethod1 method...");

            var myTask = await Task.Run(() =>
            {
                Task.Delay(_oneSecondsInMilliSeconds);
                return "a AsyncMethod1 complete";

            });

            return myTask;
        }


        public async Task<string> AsyncMethod2()
        {
            Console.WriteLine("Starting AsyncMethod2 method...");

            var myTask = await Task.Run(() =>
            {
                Task.Delay(_threeSecondsInMilliSeconds);
                return "a AsyncMethod2 complete";

            });

            return myTask;
        }


        public async Task<string> AsyncMethod3()
        {
            Console.WriteLine("Starting AsyncMethod3 method...");

            var myTask = await Task.Run(() =>
            {
                Task.Delay(_fiveSecondsInMilliSeconds);
                return "a AsyncMethod3 complete";

            });

            return myTask;
        }


        #endregion public methods


        #region private methods


        #endregion private methods
    }
}
