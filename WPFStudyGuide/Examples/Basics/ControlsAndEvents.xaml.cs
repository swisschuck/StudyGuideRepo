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

namespace WPFStudyGuide.Examples.Basics
{
    /// <summary>
    /// Interaction logic for ControlsAndEvents.xaml
    /// </summary>
    public partial class ControlsAndEvents : UserControl
    {
        public ControlsAndEvents()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("Full Name: {0}", FullNameTxtBox.Text));
            sb.AppendLine(String.Format("Sex: {0}", (bool)MaleRadio.IsChecked ? "Male" : "Female"));
            sb.AppendLine(String.Format("Own : {0}",
                        ((bool)DesktopChkbox.IsChecked ? "Desktop" : string.Empty) +
                        ((bool)LaptopChkbox.IsChecked ? "Laptop" : string.Empty) +
                        ((bool)TabletChkbox.IsChecked ? "Tablet" : string.Empty)
                      ));
            sb.AppendLine(String.Format("Job : {0}", ((ComboBoxItem)JobComboBox.SelectedItem).Content.ToString()));
            sb.AppendLine(String.Format("Delivery Date : {0}", DeliveryDateCal.SelectedDate.ToString()));

            MessageBox.Show(sb.ToString());
        }

        private void JobComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)e.AddedItems[0];
            MessageBox.Show(selectedItem.Content.ToString());
        }
    }
}
