﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexJones_SchedulingApp.Exceptions {
    public class AppointmentOutsideBusinessHoursException : Exception {
        public AppointmentOutsideBusinessHoursException() : base("Appointment is outside scheduled business hours. Please reschedule.") {

        }
    }
}
