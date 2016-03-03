using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.DataClasses
{
    public class Statistic
    {
        double _avgMark;
        int _countUnPassedHomeWork;
        int _countPassedHomeWork;

        public Statistic(double avgMark, int countUnPassedHomeWork, int countPassedHomeWork)
        {
            _avgMark = avgMark;
            _countUnPassedHomeWork = countUnPassedHomeWork;
            _countPassedHomeWork = countPassedHomeWork;
        }

        public double AvgMark
        {
            set { _avgMark = value; }
            get { return _avgMark; }
        }

        public int CountUnPassedHomeWork
        {
            set { _countUnPassedHomeWork = value; }
            get { return _countUnPassedHomeWork; }
        }

        public int CountPassedHomeWork
        {
            set { _countPassedHomeWork = value; }
            get { return _countPassedHomeWork; }
        }
    }
}
