using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SIS_September2020
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;
        private TimeSpan timeSpan;
        private ICollection<string> lapsList;

        public Chronometer()
        {
            this.lapsList = new HashSet<string>();
            this.stopwatch = new Stopwatch();
            this.timeSpan = new TimeSpan();
        }

        public void Start()
        {
            stopwatch.Start();
        }

        public void Stop()
        {            
            timeSpan = stopwatch.Elapsed;
        }

        public string Lap()
        {
            TimeSpan ts = stopwatch.Elapsed;            
            var result = string.Format($"" +
                $"{ts.Minutes:D2}" +
                $":{ts.Seconds:D2}" +
                $":{ts.Milliseconds:D4}");
            lapsList.Add(result);
            return result;
        }

        public List<string> Laps => lapsList.ToList();

        public string GetTime 
            => string.Format("{0:D2}:{1:D2}:{2:D4}", 
                timeSpan.Minutes, 
                timeSpan.Seconds, 
                timeSpan.Milliseconds);            

        public void Reset()
        {            
            stopwatch.Reset();
            lapsList.Clear();
        }        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;

            sb.AppendLine("Laps:");
            foreach (var lap in lapsList)
            {                
                sb.AppendLine($"{count}. {lap}");
                count++;
            }

            return sb.ToString();
        }
    }
}
