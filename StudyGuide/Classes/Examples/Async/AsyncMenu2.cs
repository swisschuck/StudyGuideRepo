using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Async
{
    public class AsyncMenu2
    {
        #region fields

        private int _oneSecondsInMilliSeconds = 1000;
        private int _threeSecondsInMilliSeconds = 3000;
        private int _fiveSecondsInMilliSeconds = 5000;
        private SimpleAsyncClass2 _SAC;

        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public AsyncMenu2()
        {
            _SAC = new SimpleAsyncClass2();
        }
        #endregion constructors


        #region public methods

        public void RunAsyncMenu()
        {
            Console.Clear();
            printAsyncMenu();

            do
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        RunASimpleTask();
                        break;

                    case "2":
                        RunClosureExample();
                        break;

                    case "3":
                        RunFacadeVsCodeTaskExample();
                        break;

                    case "4":
                        RunWaitForTasksToComplete();
                        break;

                    case "5":
                        RunWaitForTasksToComplete2();
                        break;

                    case "6":
                        RunWaitForTasksToComplete3();
                        break;

                    case "7":
                        RunWaitForTasksToCompleteOneByOne();
                        break;

                    case "8":
                        RunContinueWith();
                        return;

                    case "9":
                        RunTaskExceptionHandling();
                        return;

                    case "10":
                        RunTaskExceptionHandling2();
                        return;

                    case "11":
                        RunTaskExceptionHandling3();
                        return;

                    case "12":
                        RunMultiTaskExceptionHandling();
                        return;

                    case "13":
                        RunCancellingTasks();
                        return;

                    case "14":
                        return;

                    case "0":
                        // go back to previous menu
                        return;

                    default:
                        return;

                }
                Console.WriteLine(string.Empty);
                printAsyncMenu();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);


        }
        #endregion public methods


        #region private methods

        private void RunPassingParametersToAsyncMethod()
        {
            SimpleAsyncClass2 SAC2 = new SimpleAsyncClass2();
            Task parameterTask = SAC2.AsyncMethodWithParameter("some string");
        }

        private void RunCancellingTasks()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            int count = 0;
            int numberOfTasksToRun = 3;
            List<Task<string>> listOfTasks = new List<Task<string>>();
            SimpleAsyncClass2 SAC2 = new SimpleAsyncClass2();

            for (int index = 0; index < numberOfTasksToRun; index++)
            {
                if (index == 0)
                {
                    listOfTasks.Add(SAC2.LongRunningAsyncMethod1(ct));
                }
                else if (index == 1)
                {
                    listOfTasks.Add(SAC2.LongRunningAsyncMethod2(ct));
                }
                else if (index == 2)
                {
                    listOfTasks.Add(SAC2.ShortRunningAsyncMethod1(ct));
                }

            }

            while (listOfTasks.Count > 0)
            {
                int completedTaskIndex = Task.WaitAny(listOfTasks.ToArray());

                // log errors, retry, skip and move on, etc code here
                Console.WriteLine(listOfTasks[completedTaskIndex].Result);

                count++;

                // cancel after the second task completes
                if (count == 2)
                {
                    // cancel the tasks via the token
                    Console.WriteLine("Cancelling Tasks");
                    cts.Cancel();
                    listOfTasks.Clear();
                }
                else
                {
                    listOfTasks.RemoveAt(completedTaskIndex);
                }

            }

            Console.WriteLine("All tasks complete");

        }


        private void RunMultiTaskExceptionHandling()
        {
            try
            {
                Console.WriteLine("Multi Task Exception started");
                SimpleAsyncClass2 SAC2 = new SimpleAsyncClass2();

                Task failedTask = SAC2.TaskMethodThatWillFail();
                Task failedTask2 = SAC2.TaskMethodThatWillFail2();
                Task successfulTask = SAC2.AsyncMethod1();

                Task[] taskArray = { failedTask, failedTask2, successfulTask };
                Task.WaitAll(taskArray);

                Console.WriteLine("Multi Task Exception complete");
            }
            catch (AggregateException e)
            {
                foreach (Exception ex in e.InnerExceptions)
                {
                    Console.WriteLine("Tasking Error: " + ex.Message);
                }
            }
        }


        private void RunTaskExceptionHandling3()
        {
            try
            {
                Console.WriteLine("taskWithException started");
                SimpleAsyncClass2 SAC2 = new SimpleAsyncClass2();
                Task failedTask = SAC2.TaskMethodThatWillFail();
                failedTask.Wait();
                Console.WriteLine("taskWithException complete");
            }
            catch (AggregateException e)
            {
                Console.WriteLine("AggregateException: " + e.InnerException.Message);
            }
        }


        private void RunTaskExceptionHandling2()
        {
            // this will still fail despite being wrapped in a try catch because we are not observing the Task's exception
            Task<int> taskWithException = null;

            try
            {
                taskWithException = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("taskWithException started");

                    int someNumber = int.Parse("$");
                    Console.WriteLine("taskWithException complete");
                    return someNumber;
                });
            }
            catch (AggregateException aggregateException)
            {
                Console.WriteLine(String.Format("Task Exception: {0}", taskWithException.Exception.ToString()));
            }


            taskWithException.Wait();
            Console.WriteLine(String.Format("Task Result: {0}", taskWithException.Result));
            Console.WriteLine(String.Format("Task Exception: {0}", taskWithException.Exception.ToString()));

        }


        private void RunTaskExceptionHandling()
        {
            // this will fail no matter what

            Task<int> taskWithException = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("taskWithException started");

                int someNumber = int.Parse("$");
                Console.WriteLine("taskWithException complete");
                return someNumber;
            });

            //taskWithException.Wait();
            Console.WriteLine(String.Format("Task Result: {0}", taskWithException.Result));
            Console.WriteLine(String.Format("Task Exception: {0}", taskWithException.Exception.ToString()));

        }


        private void RunContinueWith()
        {
            // Use ContinueWith() When we want the completion of a task to trigger another task or 
            // when we need one task to complete before anoher can start

            int someNumber1 = 0;
            int someNumber2 = 0;
            int someNumber3 = 0;
            float average;


            Task initializeTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("initializeTask started");
                someNumber1 = 3;
                someNumber2 = 3;
                someNumber3 = 10;
            });

            Task<int> addNumbersTask = Task.Factory.StartNew(() =>
            {
                // here is one way to tell a task to wait on another but its not best practice
                initializeTask.Wait();

                Console.WriteLine("addNumbersTask started");
                return someNumber1 + someNumber2 + someNumber3;
            });

            // antecedent - a thing or event that existed before or logically precedes another.
            // its a reference to the task your calling ContinueWith on
            addNumbersTask.ContinueWith((antecedent) =>
            {
                Console.WriteLine("commpute average started");
                average = antecedent.Result / 3;
                Console.WriteLine(String.Format("average: {0}", average.ToString()));
            });


        }


        private void RunWaitForTasksToCompleteOneByOne()
        {
            // this is a good pattern to use when:
            // - You are wanting to handle (retry, log error, discard) failed tasks as they happen.
            // - when you want to overlapp computation with result processing


            int numberOfTasksToRun = 5;
            List<Task<string>> listOfTasks = new List<Task<string>>();
            SimpleAsyncClass2 SAC2 = new SimpleAsyncClass2();

            for (int index = 0; index < numberOfTasksToRun; index++)
            {
                if (index % 2 == 0)
                {
                    listOfTasks.Add(SAC2.AsyncMethod1());
                }
                else
                {
                    listOfTasks.Add(SAC2.AsyncMethod2());
                }

            }

            while (listOfTasks.Count > 0)
            {
                int completedTaskIndex = Task.WaitAny(listOfTasks.ToArray());

                // log errors, retry, skip and move on, etc code here
                Console.WriteLine(listOfTasks[completedTaskIndex].Result);

                listOfTasks.RemoveAt(completedTaskIndex);
            }

            Console.WriteLine("All tasks complete");

        }


        private void RunWaitForTasksToComplete3()
        {
            Task<string> task1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task1 started");
                Thread.Sleep(_threeSecondsInMilliSeconds);
                return "task1 complete";
            });

            Task<string> task2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task2 started");
                Thread.Sleep(_fiveSecondsInMilliSeconds);
                return "task2 complete";
            });

            Task<string> task3 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task3 started");
                Thread.Sleep(_oneSecondsInMilliSeconds);
                return "task3 complete";
            });

            Task[] taskArray = { task1, task2, task3 };

            //Task.WaitAny(taskArray); // will complete after the first task in the array completes
            // Console.WriteLine(taskArray[0].Result);
            Task.WaitAll(taskArray);

            // using the .Result on a task makes an implicit call to Task.Wait()
            Console.WriteLine(task1.Result);
            Console.WriteLine(task2.Result);
            Console.WriteLine(task3.Result);

        }


        private void RunWaitForTasksToComplete2()
        {
            Task<string> task1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task1 started");
                Thread.Sleep(_threeSecondsInMilliSeconds);
                return "task1 complete";
            });

            Task<string> task2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task2 started");
                Thread.Sleep(_fiveSecondsInMilliSeconds);
                return "task2 complete";
            });

            Task<string> task3 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task3 started");
                Thread.Sleep(_oneSecondsInMilliSeconds);
                return "task3 complete";
            });

            // using the .Result on a task makes an implicit call to Task.Wait()
            Console.WriteLine(task1.Result);
            Console.WriteLine(task2.Result);
            Console.WriteLine(task3.Result);

        }


        private void RunWaitForTasksToComplete()
        {
            Task task1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task1 started");
                Thread.Sleep(_threeSecondsInMilliSeconds);
                Console.WriteLine("task1 complete");
            });

            Task task2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task2 started");
                Thread.Sleep(_fiveSecondsInMilliSeconds);
                Console.WriteLine("task2 complete");
            });

            Task task3 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("task3 started");
                Thread.Sleep(_oneSecondsInMilliSeconds);
                Console.WriteLine("task3 complete");
            });

            // using the .Wait() method on the task will tell the containing method to wait for the task to complete before continuing synchronously
            task1.Wait();
            task2.Wait();
            task3.Wait();

            Console.WriteLine("All tasks complete");

        }


        private void RunFacadeVsCodeTaskExample()
        {
            List<int> listOfNumbers = new List<int>() { 5, 20, 35, 99, 1000 };
            decimal result = 0;


            #region Code Tasks
            Task additionTask = Task.Factory.StartNew(() =>
            {

                Console.WriteLine("Starting additionTask code task");

                foreach (int number in listOfNumbers)
                {
                    result += number;
                }

                Console.WriteLine(String.Format("Addition Result: {0}", result.ToString()));
                Console.WriteLine("additionTask code task complete");
            });


            Task averageTask = Task.Factory.StartNew(() =>
            {
                result = 0;
                Console.WriteLine("Starting averageTask code task");

                foreach (int number in listOfNumbers)
                {
                    result += number;
                }

                result = result / listOfNumbers.Count;

                Console.WriteLine(String.Format("Average Result: {0}", result.ToString()));

                Console.WriteLine("averageTask code task complete");
            });

            #endregion Code Tasks


            #region Facade Tasks

            // didnt get a full understanding of this, come back to it.

            #endregion Facade Tasks

        }


        private void RunClosureExample()
        {
            // closer variables are passed by reference and are stored in a complier generated class but can be used by async methods.
            // The capability for a function or method to reference a non-local value, is called closure.

            int outsideOfTaskScopeNumber = 2;
            int additionResult = 0;

            Task.Factory.StartNew(() =>
            {
                int insideOfTaskScopeNumber = 2;
                //Thread.Sleep(_threeSecondsInMilliSeconds);
                additionResult = insideOfTaskScopeNumber + outsideOfTaskScopeNumber;
                Console.WriteLine(String.Format("Addition Result: {0}", additionResult));
            });

        }


        private void RunASimpleTask()
        {
            string result = string.Empty;

            Task myFirstTask = new Task(() =>
            {
                Console.WriteLine("myFirstTask Started");
                Thread.Sleep(_threeSecondsInMilliSeconds);
                result = "myFirstTask Completed";
            });

            Task mySecondTask = myFirstTask.ContinueWith((firstTask) =>
            {
                Console.WriteLine(result);
                return;
            });

            myFirstTask.Start();
        }




        private void printAsyncMenu()
        {
            Console.WriteLine("Async Menu:");
            Console.WriteLine("----------------------");
            Console.WriteLine("1) A simple task");
            Console.WriteLine("2) Closure Variable Example");
            Console.WriteLine("3) Fasade Vs Code Tasks");
            Console.WriteLine("4) Wait For Tasks To Complete");
            Console.WriteLine("5) Wait For Tasks To Complete 2");
            Console.WriteLine("6) Wait For Tasks To Complete 3");
            Console.WriteLine("7) Wait All One By One");
            Console.WriteLine("8) Continue With");
            Console.WriteLine("9) Task Exception Handling 1");
            Console.WriteLine("10) Task Exception Handling 2");
            Console.WriteLine("11) Task Exception Handling 3");
            Console.WriteLine("12) Multi Task Exception Handling 3");
            Console.WriteLine("13) Task Cancelling");
            Console.WriteLine("14) Passing parameters");
            Console.WriteLine("0) Back Home");
        }

        // some comment here
        #endregion private methods

    }
}
