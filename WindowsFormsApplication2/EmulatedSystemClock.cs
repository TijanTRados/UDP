using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class EmulatedSystemClock
    {
        private DateTime startTime;
        private double jitter;

        public EmulatedSystemClock()
        {
            startTime = DateTime.Now;
            Random r = new Random();

            jitter = r.Next(-20, 20);
        }

        public DateTime currentTime()
        {
            DateTime current = DateTime.Now;
            return startTime;

        }
    }
}
