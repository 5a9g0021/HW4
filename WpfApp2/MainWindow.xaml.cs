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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, int> foods = new Dictionary<string, int>();
        public MainWindow()
        {
            InitializeComponent();

            AddNewFood(foods);
        }

        private void AddNewFood(Dictionary<string, int> myFood)
        {
            myFood.Add("大麥克漢堡(大)", 150);
            myFood.Add("大麥克漢堡(小)", 90);
            myFood.Add("麥香雞漢堡(大)", 140);
            myFood.Add("麥香雞漢堡(小)", 80);
            myFood.Add("雙層牛肉堡(大)", 160);
            myFood.Add("雙層牛肉堡(小)", 100);
        }

        private void PlaceOrder(object sender, TextChangedEventArgs e)
        {
            var targetTextbox = sender as TextBox;

            bool success = int.TryParse(targetTextbox.Text, out int count);
            if (!success) MessageBox.Show("請輸入整數", "輸入錯誤");
            else if (count <= 0) MessageBox.Show("請輸入正整數", "輸入錯誤");
            else
            {
                StackPanel targetStackPanel = targetTextbox.Parent as StackPanel;
                Label targetLabel = targetStackPanel.Children[0] as Label;
                string foodItem = targetLabel.Content.ToString();
                int itemPrice = foods[foodItem];
                MessageBox.Show($"{foodItem}X{count}每份{itemPrice}元,總共{itemPrice * count}元");
            }
        }
    }
}