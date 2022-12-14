using BIZ;
using GUI.Usercontrols;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBIZ BIZ;

        UserControlCustomer UCCostumer;
        UserControlCustomerEdit UCCostumerEdit;
        UserControlOrderMeat UCOrderMeat;
        UserControlOrderMeatEdit UCOrderMeatEdit;

        public MainWindow()
        {
            InitializeComponent();
            BIZ = new ClassBIZ();
            MainGrid.DataContext = BIZ;

            UCCostumerEdit = new UserControlCustomerEdit(BIZ, LeftGrid);
            UCCostumer = new UserControlCustomer(BIZ, LeftGrid, UCCostumerEdit);
            UCOrderMeatEdit = new UserControlOrderMeatEdit(BIZ, RightGrid);
            UCOrderMeat = new UserControlOrderMeat(BIZ, RightGrid, UCOrderMeatEdit);

            LeftGrid.Children.Add(UCCostumer);
            RightGrid.Children.Add(UCOrderMeat);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await BIZ.GetApiRates();
        }
    }
}
