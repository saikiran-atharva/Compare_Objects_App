using System;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompareApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();
            var obj1 = new Demo { Id = 1,Location="hyderabad"};
            var obj2 = new Demo { Id = 2,};
            var comparisonResults = GetComparisonResults(obj1, obj2);
            ComparisonGrid.ItemsSource = comparisonResults;
        }
        private List<ComparisonResult> GetComparisonResults(object obj1, object obj2)
        {
            var results = new List<ComparisonResult>();
            var properties1 = obj1.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var properties2 = obj2.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var allPropertyNames = properties1.Select(p => p.Name);
            foreach (var propName in allPropertyNames)
            {
                var prop1 = properties1.FirstOrDefault(p => p.Name == propName);
                var prop2 = properties2.FirstOrDefault(p => p.Name == propName);
                var value1 = prop1?.GetValue(obj1);
                var value2 = prop2?.GetValue(obj2);
                string status;
                if (Equals(value1, value2))
                {
                    status = "Matching";
                }
                else
                {
                    status = "Not Matching";
                }
                results.Add(new ComparisonResult
                {
                    PropertyName = propName,
                    Value1 = value1,
                    Value2 = value2,
                    Status = status
                });
            }
            return results;
        }
    }
}