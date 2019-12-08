using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetMQ;
using NetMQ.Sockets;

namespace FaceAttendance_WForms
{
    static class MessageQueue
    {
        public static readonly RequestSocket RecognitionEngineClient = new RequestSocket(">tcp://localhost:5555");
        public static readonly RequestSocket NodeJSClient = new RequestSocket(">tcp://localhost:5556");

        public static void Send(RequestSocket socket, int intent, string message)
        {
            NetMQMessage messageFrames = new NetMQMessage(2);
            messageFrames.Append(new byte[] { (byte)intent });
            messageFrames.Append(message);

            socket.SendMultipartMessage(messageFrames);
        }

        public static void SendNonBlocking(RequestSocket socket, int intent, string message)
        {
            NetMQMessage messageFrames = new NetMQMessage(2);
            messageFrames.Append(new byte[] { (byte)intent });
            messageFrames.Append(message);

            try
            {
                socket.TrySendMultipartMessage(messageFrames);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred!");
            }
        }

        public static string Receive(RequestSocket socket)
        {
            return socket.ReceiveFrameString();
        }

        public static string ReceiveNonBlocking(RequestSocket socket)
        {
            string frameString;
            if (socket.TryReceiveFrameString(out frameString))
            {
                return frameString;
            }
            return null;
        }

    }    
}