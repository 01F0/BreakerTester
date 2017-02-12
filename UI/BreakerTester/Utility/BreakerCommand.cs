using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BreakerTester
{
    public class BreakerCommand : ICommand
    {
        private BreakerControlViewModel _breakerControlViewModel;
        private NodeMcuCommunicator _nodeMcuCommunicator;

        public BreakerCommand(NodeMcuCommunicator nodeMcuCommunicator, BreakerControlViewModel breakerControlViewModel)
        {
            _nodeMcuCommunicator = nodeMcuCommunicator;
            _breakerControlViewModel = breakerControlViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _breakerControlViewModel.AddNewOutage(DateTime.Now);

            Task.Run(() => _nodeMcuCommunicator.Send());
        }
    }
}
