using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace FormsUI
{
    public class ActivityTracker
    {
        private Form _form;

        public ActivityTracker(Form form)
        {
            _form = form;
            AttachEventHandlers();
        }

        private void AttachEventHandlers()
        {
            _form.MouseMove += OnActivity;
            _form.KeyPress += OnActivity;
            _form.Click += OnActivity;

            // Attach to all child controls
            foreach (Control control in _form.Controls)
            {
                AttachToControl(control);
            }
        }

        private void AttachToControl(Control control)
        {
            control.MouseMove += OnActivity;
            control.KeyPress += OnActivity;
            control.Click += OnActivity;

            if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    AttachToControl(child);
                }
            }
        }

        private void OnActivity(object sender, EventArgs e)
        {
            SessionManager.UpdateActivity();
        }
    }
}
