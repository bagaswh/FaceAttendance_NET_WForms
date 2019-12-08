using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft;
using Newtonsoft.Json;

namespace FaceAttendance_WForms
{
    struct User
    {
        public Int16 id;
        public string fullname;
        public bool attended;
    }

    public static class Users
    {
        public static readonly Dictionary<Int16, string> UsersData = new Dictionary<Int16, string>();
        public static void Load()
        {
            MessageQueue.Send(MessageQueue.NodeJSClient, 
                (int)Constants.RequestIntents.INTENT_REQ_USERS_DATA, "");
            string json = MessageQueue.Receive(MessageQueue.NodeJSClient);

            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            foreach (var user in users)
            {
                UsersData.Add(user.id, user.fullname);
            }
        }
    }
}
