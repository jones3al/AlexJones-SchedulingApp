using System;

namespace AlexJones_SchedulingApp.Exceptions
{
    public class AppointmentOverlapException : Exception {
        public AppointmentOverlapException(string message) : base(message){
            
        }
    }
}
