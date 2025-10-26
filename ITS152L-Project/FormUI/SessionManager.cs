using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FormsUI
{
    public static class SessionManager
    {
        private static System.Timers.Timer _inactivityTimer;
        private static DateTime _lastActivity;
        private static int _sessionTimeoutMinutes = 30; // 30 minutes timeout
        private static bool _isSessionActive = false;

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
            _isSessionActive = true;
            _lastActivity = DateTime.Now;

            // Initialize inactivity timer
            if (_inactivityTimer == null)
            {
                _inactivityTimer = new System.Timers.Timer(60000); // Check every minute
                _inactivityTimer.Elapsed += CheckInactivity;
            }

            _inactivityTimer.Start();
        }

        public static void EndSession()
        {
            _inactivityTimer?.Stop();
            CurrentUserName = null;
            CurrentUserRole = null;
            CurrentUserId = 0;
            _isSessionActive = false;
        }

        public static void UpdateActivity()
        {
            _lastActivity = DateTime.Now;
        }

        private static void CheckInactivity(object sender, ElapsedEventArgs e)
        {
            if (_isSessionActive)
            {
                TimeSpan inactiveTime = DateTime.Now - _lastActivity;

                if (inactiveTime.TotalMinutes >= _sessionTimeoutMinutes)
                {
                    _inactivityTimer.Stop();
                    _isSessionActive = false;
                    SessionExpired?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        public static bool IsSessionActive()
        {
            return _isSessionActive;
        }

        public static TimeSpan GetSessionDuration()
        {
            return DateTime.Now - LoginTime;
        }

        public static TimeSpan GetTimeUntilTimeout()
        {
            TimeSpan inactiveTime = DateTime.Now - _lastActivity;
            double remainingMinutes = _sessionTimeoutMinutes - inactiveTime.TotalMinutes;
            return TimeSpan.FromMinutes(Math.Max(0, remainingMinutes));
        }
    }
}
