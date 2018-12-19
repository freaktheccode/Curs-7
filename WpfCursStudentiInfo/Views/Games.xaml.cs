using System.Windows.Controls;
using WpfNew.ViewModels;

namespace WpfNew.Views
{
    /// <summary>
    /// Interaction logic for Games.xaml
    /// </summary>
    public partial class Games : UserControl
    {
        /// <summary>
        /// Public constructor that set the DataContext.
        /// </summary>
        public Games()
        {
            InitializeComponent();

            DataContext = new GamesViewModel();
        }
    }
}
