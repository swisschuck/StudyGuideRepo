using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Async
{
    public class SimpleAsyncClass2
    {
        #region fields

        private int _oneSecondsInMilliSeconds = 1000;
        private int _threeSecondsInMilliSeconds = 3000;
        private int _fiveSecondsInMilliSeconds = 5000;
        private int _tenSecondsInMilliSeconds = 10000;
        private int _thirtySecondsInMilliSeconds = 30000;
        private int _sixtySecondsInMilliSeconds = 60000;

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


        public async Task<string> AsyncMethodWithParameter(string returnString)
        {
            Console.WriteLine("Starting AsyncMethod3 method...");

            var myTask = await Task.Run(() =>
            {
                Task.Delay(_fiveSecondsInMilliSeconds);
                return returnString;

            });

            return myTask;
        }


        public async Task TaskMethodThatWillFail()
        {
            Task failingTask;

            try
            {
                failingTask = Task.Run(() =>
                {
                    throw new ArgumentNullException();
                });
                await failingTask;
            }
            catch (ArgumentNullException e)
            {
                Exception[] list = new Exception[] { e };
                throw new AggregateException("ArgumentNullException Exception rethrown as Aggregate", list);
            }
            return;
        }

        public async Task TaskMethodThatWillFail2()
        {
            Task failingTask;

            try
            {
                failingTask = Task.Run(() =>
                {
                    throw new OverflowException();
                });
                await failingTask;
            }
            catch (OverflowException e)
            {
                Exception[] list = new Exception[] { e };
                throw new AggregateException("OverflowException Exception rethrown as Aggregate", list);
            }
            return;
        }



        public async Task<string> LongRunningAsyncMethod1(CancellationToken cancellationToken)
        {
            Console.WriteLine("Starting LongRunningAsyncMethod1 method...");

            var myTask = await Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("LongRunningAsyncMethod1 method cancelled...");
                }
                Thread.Sleep(_tenSecondsInMilliSeconds);
                return "a LongRunningAsyncMethod1 complete";

            }, cancellationToken);

            return myTask;
        }


        public async Task<string> LongRunningAsyncMethod2(CancellationToken cancellationToken)
        {
            Console.WriteLine("Starting LongRunningAsyncMethod2 method...");

            var myTask = await Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                Thread.Sleep(_thirtySecondsInMilliSeconds);
                return "a LongRunningAsyncMethod2 complete";

            }, cancellationToken);

            return myTask;
        }


        public async Task<string> ShortRunningAsyncMethod1(CancellationToken cancellationToken)
        {
            Console.WriteLine("Starting ShortRunningAsyncMethod1 method...");

            var myTask = await Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("ShortRunningAsyncMethod1 method cancelled...");
                }
                Thread.Sleep(_threeSecondsInMilliSeconds);
                return "a ShortRunningAsyncMethod1 complete";

            }, cancellationToken);

            return myTask;
        }

        #endregion public methods


        #region private methods

        #endregion private methods
    }
}
