using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace BreakerTester
{
    public class BreakerControlViewModel : INotifyPropertyChanged
    {
        private List<DateTime> _outageTimes = new List<DateTime>();
        private string _breakerName;
        private ICommand _runBreakerCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }


        public ICommand RunBreakerCommand
        {
            get
            {
                return _runBreakerCommand;
            }
            set
            {
            }
        }

        public ObservableCollection<string> OutageTimeSpans
        {
            get
            {
                var timeSpans = Enumerable.Range(0, _outageTimes.Count)
                    .Where(x => x % 2 == 0).Select(y => $"{_outageTimes[y].ToString("HH:mm:ss")} - {_outageTimes[y + 1].ToString("HH:mm:ss")} ({ _outageTimes[y + 1].Subtract(_outageTimes[y])})").ToList();

                return new ObservableCollection<string>(timeSpans);
            }
        }

        public void AddNewOutage(DateTime dateTime)
        {
            _outageTimes.Add(dateTime);

            if (_outageTimes.Count % 2 == 0)
            {
                NotifyPropertyChanged(nameof(OutageTimeSpans));
            }
        }

        public string BreakerName
        {
            get
            {
                return _breakerName;
            }
            set
            {
                _breakerName = value;
                NotifyPropertyChanged(nameof(BreakerName));
            }
        }

        public BreakerControlViewModel(NodeMcuCommunicator nodeMcuCommunicator, string breakerName)
        {
            _runBreakerCommand = new BreakerCommand(nodeMcuCommunicator, this);
            BreakerName = breakerName;
        }

       

    }

}
