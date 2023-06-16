using System;

namespace AlexJones_SchedulingApp.Exceptions
{
    public class AppointmentOutsideBusinessHoursException : Exception {
        public AppointmentOutsideBusinessHoursException() : base("Appointment is outside scheduled business hours. Please reschedule.") {

        }
    }
}
