using System;

namespace AlexJones_SchedulingApp.Events
{
    public class SelectFormEventArgs : EventArgs
    {
        public SaveableForm ChildForm { get; }

        public SelectFormEventArgs(SaveableForm childForm = null) => ChildForm = childForm;
    }
}
