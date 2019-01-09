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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFStudyGuide.Examples.Animations
{
    /// <summary>
    /// Interaction logic for Animations.xaml
    /// </summary>
    public partial class Animations : UserControl
    {
        public Animations()
        {
            InitializeComponent();
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 850;
            animation.Duration = new Duration(TimeSpan.Parse("0:0:5")); // hours, mintues, seconds
            animation.AutoReverse = true;
            animation.RepeatBehavior = new RepeatBehavior(TimeSpan.Parse("0:0:20"));
            myEllipse.BeginAnimation(Canvas.LeftProperty, animation);
        }
    }
}
