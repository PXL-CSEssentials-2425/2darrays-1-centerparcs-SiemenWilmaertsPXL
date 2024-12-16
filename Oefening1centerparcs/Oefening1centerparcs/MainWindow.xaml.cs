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

namespace Oefening1centerparcs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int[] _numberOfDays = new int[] { 1, 2, 5, 7, 8, 12, 14, 21 };
        private string[,] _houseWithPrice = new string[5, 2] {
        { "2 personen", "80" },
        { "4 personen", "120" } ,
        { "4 personen lux", "140" } ,
        { "6 personen", "180" },
        { "8 personen", "200"}
};
        public MainWindow()
        {
            InitializeComponent();
            fillComboBox();
        }

        private void amountDaysComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Berekening();

        }

        private void typeWoning_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Berekening();
        }
        private void Berekening()
        {
            if (typeWoningComboBox.SelectedIndex >= 0 && amountDaysComboBox.SelectedIndex >= 0)
            {
                int.TryParse(_houseWithPrice[typeWoningComboBox.SelectedIndex, 1], out int costPerHouse);

                int result = costPerHouse * _numberOfDays[amountDaysComboBox.SelectedIndex];
                //int result = costPerHouse * (int)amountDaysComboBox.SelectedValue;
                // prijsTextBox.Text = result.ToString($"C");
                prijsTextBox.Text = $"{result:C2}";
            }
        }
        private void fillComboBox()
        {
            ComboBoxItem item = new ComboBoxItem();
            for (int i = 0; i < _numberOfDays.Length; i++)
            {
                item.Content = _numberOfDays[i].ToString();
                amountDaysComboBox.Items.Add(item);
                item = new ComboBoxItem();
            }
            for (int i = 0; i < _houseWithPrice.GetLength(0); i++)
            {
                item.Content = _houseWithPrice[i, 0].ToString();
                typeWoningComboBox.Items.Add(item);
                item = new ComboBoxItem();
            }
        }

    }
}