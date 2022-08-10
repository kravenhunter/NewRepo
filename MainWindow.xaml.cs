using System;
using System.Collections;
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

namespace WpfTEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ArrayList myDataList;
        private string currentItemText;
        private int currentItemIndex;
        public MainWindow()
        {
            InitializeComponent();
             myDataList = LoadListBoxData();
            LeftListBox.ItemsSource = myDataList;
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            listbox1.Items.Add(textBox1.Text);
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            listbox1.Items.RemoveAt(listbox1.Items.IndexOf(listbox1.SelectedItem));
        }
        private ArrayList LoadListBoxData()
        {
            ArrayList itemsList = new ArrayList();
            itemsList.Add("Coffie");
            itemsList.Add("Tea");
            itemsList.Add("Orange Juice");
            itemsList.Add("Milk");           
            return itemsList;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeftListBox.SelectedValue != null)
            {
                // Find the right item and it's value and index
                currentItemText = LeftListBox.SelectedValue?.ToString();
                currentItemIndex = LeftListBox.SelectedIndex;
                RightListBox.Items.Add(currentItemText);
                if (myDataList != null)
                {
                    myDataList.RemoveAt(currentItemIndex);
                }
                // Refresh data binding
                ApplyDataBinding();
            }
           
        }
        ///<summary>
        /// Refreshes data binding
        ///</summary>
        private void ApplyDataBinding()
        {
            LeftListBox.ItemsSource = null;
            // Bind ArrayList with the ListBox
            LeftListBox.ItemsSource = myDataList;
        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
          
            if (RightListBox.SelectedValue !=  null)
            {
                currentItemText = RightListBox.SelectedValue?.ToString();
                currentItemIndex = RightListBox.SelectedIndex;
                // Add RightListBox item to the ArrayList
                myDataList.Add(currentItemText);
                RightListBox.Items.RemoveAt(RightListBox.Items.IndexOf(RightListBox.SelectedItem));
                // Refresh data binding
                ApplyDataBinding();
            }
           
        }
    }
}
