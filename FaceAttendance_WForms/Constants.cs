using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceAttendance_WForms
{
    public static class Constants
    {
        public enum RequestIntents
        {
            INTENT_REQ_FACE_ID = 0x1,
            INTENT_REQ_FETCH_NEWLY_INSERTED_FACES_DATA = 0x2,
            INTENT_REQ_USERS_DATA = 0x3,
            INTENT_REQ_INSERT_FACE_DATA = 0x4,
            INTENT_REQ_DELETE_FACE_DATA = 0x5,
            INTENT_REQ_UPDATE_ATTENDANCE_DATA = 0x10
        }
    }
}
