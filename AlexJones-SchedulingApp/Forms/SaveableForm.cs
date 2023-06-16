using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlexJones_SchedulingApp.Models;

namespace AlexJones_SchedulingApp {
    public class SaveableForm : Form 
    {
        protected User formOwner;
        public event EventHandler FormSaved;

        protected virtual void OnFormSaved() 
        {
            FormSaved?.Invoke(null, EventArgs.Empty);
        }
    }
}
