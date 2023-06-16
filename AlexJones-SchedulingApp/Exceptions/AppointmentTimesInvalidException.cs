using System;

namespace AlexJones_SchedulingApp.Exceptions
{
    public class AppointmentTimesInvalidException : Exception {
        public AppointmentTimesInvalidException() : base("Appointment Times Invalid") {

        }

        public AppointmentTimesInvalidException(string message) : base(message) {

        }
    }
}
