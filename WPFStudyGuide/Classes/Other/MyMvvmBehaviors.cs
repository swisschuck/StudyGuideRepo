using System.Windows;
using WPFStudyGuide.ViewModels.Other;

namespace WPFStudyGuide.Classes.Other
{
    public class MyMvvmBehaviors
    {
        #region fields
        #endregion fields


        #region properties

        public static readonly DependencyProperty LoadedMethodNameProperty =
                        DependencyProperty.RegisterAttached("LoadedMethodName",
                        typeof(string),
                        typeof(AttachedPropertiesExampleViewModel),
                        new PropertyMetadata(null, OnLoadedMethodNameChanged));

        #endregion properties


        #region constructors

        public MyMvvmBehaviors()
        {
        }

        #endregion constructors


        #region public methods

        public static string GetLoadedMethodName(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(LoadedMethodNameProperty);
        }

        public static void SetLoadedMethodName(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(LoadedMethodNameProperty, value);
        }

        #endregion public methods


        #region private methods

        private static void OnLoadedMethodNameChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            FrameworkElement frameworkElement = dependencyObject as FrameworkElement;

            if (frameworkElement != null)
            {
                frameworkElement.Loaded += (parameter, routedEventArgs) =>
                {
                    var viewModel = frameworkElement.DataContext;

                    if (viewModel == null)
                    {
                        return;
                    }

                    var methodInfo = viewModel.GetType().GetMethod(args.NewValue.ToString());

                    if (methodInfo != null)
                    {
                        methodInfo.Invoke(viewModel, null);
                    }
                };
            }
        }

        #endregion private methods
    }
}
