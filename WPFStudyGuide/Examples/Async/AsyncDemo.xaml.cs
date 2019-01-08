using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFStudyGuide.Examples.Async
{
    /// <summary>
    /// Interaction logic for AsyncDemo.xaml
    /// </summary>
    public partial class AsyncDemo : UserControl
    {
        public AsyncDemo()
        {
            InitializeComponent();
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked");
            ComputeStuff();
        }

        private async void ComputeStuff()
        {
            for (int x = 0; x < 5; x++)
            {
                var sum = 0.0;
                MessageToUser.Text = "Computing...";

                await Task.Run(() =>
                {
                    for (int i = 1; i < 200000000; i++)
                    {
                        sum += Math.Sqrt(i);
                    }
                });

                MessageToUser.Text = "Sum = " + sum;


                await Task.Run(() =>
                {
                    for (int i = 1; i < 200000000; i++)
                    {
                        sum += Math.Sqrt(i);
                    }
                });

                MessageToUser.Text = "Sum = " + sum;


                await Task.Run(() =>
                {
                    for (int i = 1; i < 200000000; i++)
                    {
                        sum += Math.Sqrt(i);
                    }
                });

                MessageToUser.Text = "Sum = " + sum;


                await Task.Run(() =>
                {
                    for (int i = 1; i < 200000000; i++)
                    {
                        sum += Math.Sqrt(i);
                    }
                });

                MessageToUser.Text = "Sum = " + sum;


            }
        }
    }
}
