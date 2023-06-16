using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexJones_SchedulingApp.Events
{
    public class SelectFormEventArgs : EventArgs
    {
        public SaveableForm ChildForm { get; }

        public SelectFormEventArgs(SaveableForm childForm = null) => ChildForm = childForm;
    }
}
