using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Async
{
    public class AsyncMenu
    {
        // This class was from the first course i took on pluralsite on async coding, i didnt like it very much but wanted to keep the code for reference
        #region fields

        private int _oneSecondsInMilliSeconds = 1000;
        private int _threeSecondsInMilliSeconds = 3000;
        private int _fiveSecondsInMilliSeconds = 5000;
        private SimpleAsyncClass _SAC;

        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public AsyncMenu()
        {
            _SAC = new SimpleAsyncClass();
        }
        #endregion constructors


        #region public methods

        public void RunAsync()
        {
            Console.Clear();
            printAsyncMenu();

            switch (Console.ReadLine())
            {
                case "1":
                    RunThreadSleep();
                    break;

                case "2":
                    RunSimpleTaskRun();
                    break;

                case "3":
                    RunSimpleTaskRunWithException();
                    break;

                case "4":
                    RunSimpleAsyncMethod();
                    break;

                case "5":
                    RunSimpleAsyncTaskMethod();
                    break;

                case "6":
                    RunSimpleAsyncTaskReturnMethod();
                    break;

                case "7":
                    RunAsyncWhenAllTask();
                    break;

                case "8":
                    return;

                case "9":
                    return;

                case "0":
                    // go back to previous menu
                    return;

                default:
                    return;

            }
            Console.WriteLine(string.Empty);
            printAsyncMenu();
            Console.ReadLine();
        }
        #endregion public methods


        #region private methods


        private void RunAsyncWhenAllTask()
        {
            try
            {
                Console.WriteLine("starting task 1");
                Task<string> task1 = _SAC.AsyncMethod1();

                if (task1.IsCompleted)
                {
                    Console.WriteLine(task1.Result);
                }

                Console.WriteLine("starting task 2");
                Task<string> task2 = _SAC.AsyncMethod2();

                if (task2.IsCompleted)
                {
                    Console.WriteLine(task2.Result);
                }


                Console.WriteLine("starting task 3");
                Task<string> task3 = _SAC.AsyncMethod3();

                if (task3.IsCompleted)
                {
                    Console.WriteLine(task3.Result);
                }

                // couldnt get this to work, i am doing something wrong
                Task whenAllTask = Task.WhenAll(task1, task2, task3);

                if (whenAllTask.IsCompleted)
                {
                    Console.WriteLine("all tasks complete");
                    return;
                }

            }
            catch (Exception ex)
            {

            }
        }


        private void RunSimpleAsyncTaskReturnMethod()
        {
            Console.WriteLine("calling async task method");
            Task<string> myTask = _SAC.ASimpleAsyncTaskReturnMethod();
            Console.WriteLine("doing other stuff in the meantime...");

            if (myTask.IsCompleted)
            {
                Console.WriteLine(myTask.Result);
                return;
            }
        }


        private void RunSimpleAsyncTaskMethod()
        {
            Console.WriteLine("calling async task method");
            Task myTask = _SAC.ASimpleAsyncTaskMethod();
            Console.WriteLine("doing other stuff in the meantime...");

            if (myTask.IsCompleted)
            {
                Console.WriteLine("calling async task method complete");
                return;
            }
        }


        private void RunSimpleAsyncMethod()
        {
            Console.WriteLine("calling async method");
            _SAC.ASimpleAsyncMethod();
            Console.WriteLine("doing other stuff in the meantime...");
        }


        private void RunSimpleTaskRunWithException()
        {
            string errorMessage = "Oops an error occuried";

            Console.WriteLine("Starting Task.Run() using 3 seconds...");

            var myTask = Task.Run(() =>
            {
                //SimpleSleepMethod(_threeSecondsInMilliSeconds);
                throw new UnauthorizedAccessException();
                // this can be done here or in the ContinueWith below
                return "Finished 3 second thread sleep...";
            });

            myTask.ContinueWith((myTaskFromAbove) =>
            {
                if (myTaskFromAbove.IsFaulted)
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    Console.WriteLine(myTaskFromAbove.Result);
                }

            });

        }


        private void RunSimpleTaskRun()
        {
            Console.WriteLine("Starting Task.Run() using 3 seconds...");
            var myTask = Task.Run(() =>
            {
                SimpleSleepMethod(_threeSecondsInMilliSeconds);

                // this can be done here or in the ContinueWith below
                return "Finished 3 second thread sleep...";
            });

            myTask.ContinueWith((myTaskFromAbove) =>
            {
                Console.WriteLine(myTaskFromAbove.Result);
            });

        }


        private void RunThreadSleep()
        {
            Console.WriteLine("Starting Thread Sleep for 5 seconds...");
            SimpleSleepMethod(_fiveSecondsInMilliSeconds);

            //int count = 1;
            //for (int i = 0; i < millisecondSleepTime; i++)
            //{
            //    if (i % 1000 == 0)
            //    {
            //        Console.WriteLine(String.Format("{0}...", count.ToString()));
            //        count++;
            //    }
            //}

            Console.WriteLine("Finished Thread Sleep...");
        }


        private void printAsyncMenu()
        {
            Console.WriteLine("Generics:");
            Console.WriteLine("----------------------");
            Console.WriteLine("1) Thread Sleep");
            Console.WriteLine("2) Simple Task.Run");
            Console.WriteLine("3) Simple Task.Run with exception");
            Console.WriteLine("4) Simple Async Method");
            Console.WriteLine("5) Simple Async Task Method");
            Console.WriteLine("6) Simple Async Task Return Method");
            Console.WriteLine("7) When All");
            Console.WriteLine("8) ");
            Console.WriteLine("9) ");
            Console.WriteLine("0) Back Home");
        }

        private void SimpleSleepMethod(int timeToSleep)
        {
            Thread.Sleep(3000);
        }


        #endregion private methods
    }
}
