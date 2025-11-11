using System;
using System.Windows.Forms;

namespace FormsUI
{
    public class ActivityTracker
    {
        private readonly Form _form;

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

            foreach (Control child in control.Controls)
            {
                AttachToControl(child);
            }
        }

        private void OnActivity(object sender, EventArgs e)
        {
            SessionManager.UpdateActivity();
        }
    }
}
