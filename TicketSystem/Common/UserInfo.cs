using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketSystem.Common
{
    class UserInfo
    {
        private static int userId;
        public static int UserId
        {
            get { return UserInfo.userId; }
            set { UserInfo.userId = value; }
        }

        private static string userName;
        public static string UserName
        {
            get { return UserInfo.userName; }
            set { UserInfo.userName = value; }
        }

        private static string fullName;
        public static string FullName
        {
            get { return UserInfo.fullName; }
            set { UserInfo.fullName = value; }
        }

        private static string role;
        public static string Role
        {
            get { return UserInfo.role; }
            set { UserInfo.role = value; }
        }
    }
}
