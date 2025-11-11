using System;
using System.Windows.Forms;

namespace FormsUI
{
    public static class SessionManager
    {
        private static System.Windows.Forms.Timer _timer;
        private static DateTime _lastActivity;
        private static int _sessionTimeoutMinutes = 10;
        private static bool _isActive = false;

        public static string CurrentUserName { get; private set; }
        public static string CurrentUserRole { get; private set; }
        public static int CurrentUserId { get; private set; }
        public static DateTime LoginTime { get; private set; }

        public static event EventHandler SessionExpired;

        public static void StartSession(int userId, string userName, string userRole)
        {
            CurrentUserId = userId;
            CurrentUserName = userName;
            CurrentUserRole = userRole;
            LoginTime = DateTime.Now;
            _lastActivity = DateTime.Now;
            _isActive = true;

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 5000; 
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        public static void UpdateActivity()
        {
            _lastActivity = DateTime.Now;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            if (!_isActive) return;

            if ((DateTime.Now - _lastActivity).TotalMinutes >= _sessionTimeoutMinutes)
            {
                _isActive = false;
                _timer.Stop();
                SessionExpired?.Invoke(null, EventArgs.Empty);
            }
        }

        public static void EndSession()
        {
            _isActive = false;
            _timer?.Stop();
            CurrentUserName = null;
            CurrentUserRole = null;
            CurrentUserId = 0;
        }

        public static bool IsSessionActive() => _isActive;

        public static TimeSpan GetSessionDuration() => DateTime.Now - LoginTime;
        public static TimeSpan GetTimeUntilTimeout()
        {
            var remaining = _sessionTimeoutMinutes - (DateTime.Now - _lastActivity).TotalMinutes;
            return TimeSpan.FromMinutes(Math.Max(0, remaining));
        }
    }
}
