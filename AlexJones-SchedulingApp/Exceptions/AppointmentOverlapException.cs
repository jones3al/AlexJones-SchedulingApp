using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexJones_SchedulingApp.Exceptions{
    public class AppointmentOverlapException : Exception {
        public AppointmentOverlapException(string message) : base(message){
            
        }
    }
}
