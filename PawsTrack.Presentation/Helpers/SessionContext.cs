using PawsTrack.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawsTrack.Presentation.Helpers
{
    /// <summary>
    /// Lightweight in-memory session store.
    /// Set after a successful login and cleared on logout.
    /// All forms that need to know "who is logged in" read from here.
    /// This avoids threading session state through constructor parameters on every form.
    /// </summary>
    public static class SessionContext
    {
        public static LoggedInUserDto? CurrentUser { get; private set; }

        public static bool IsLoggedIn => CurrentUser is not null;

        public static void SetUser(LoggedInUserDto user)
        {
            CurrentUser = user ?? throw new ArgumentNullException(nameof(user));
        }

        public static void Clear()
        {
            CurrentUser = null;
        }
    }
}
