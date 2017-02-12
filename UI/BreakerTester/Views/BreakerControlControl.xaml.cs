using System.Windows.Controls;

namespace BreakerTester
{
    /// <summary>
    /// Interaction logic for BreakerControl.xaml
    /// </summary>
    public partial class BreakerControl : StackPanel
    {

        public BreakerControl()
        {
            InitializeComponent();

            DataContext = new BreakerControlViewModel(new NodeMcuCommunicator(App.PhaseAddressCounter++), $"BREAKER {App.PhaseAddressCounter}");
        }
    }

}
