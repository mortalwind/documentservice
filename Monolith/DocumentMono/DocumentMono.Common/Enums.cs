using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentMono.Common
{
    public class Enums
    {
        /// <summary>
        /// Users's status / Kullanıcı durumu
        /// </summary>
        public enum UserStatus
        {
            Passive = 0,
            Active = 1,
            Locked = 2
        }

        /// <summary>
        /// Approval flow step statuses / Onay akış adımları durumu
        /// </summary>
        public enum FlowStatus
        {
            New = 0,
            Pending = 1,
            Approved = 2,
            Disapproved = 3
        }
    }
}
