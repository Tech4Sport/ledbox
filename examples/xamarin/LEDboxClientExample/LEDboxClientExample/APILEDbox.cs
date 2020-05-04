using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LEDboxClientExample
{
    public class APILEDbox
    {
        Socket socket;
        Thread listen;
        public event EventHandler<JObject> EventMessageReceived;

        public APILEDbox()
        {
        }

        public bool connect(string ip)
        {

            IPAddress host = IPAddress.Parse(ip);
            int port = 8889;

            socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            IAsyncResult result = socket.BeginConnect(host, port, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(2000, true);

            if (socket.Connected)
            {
                Console.WriteLine("Connection established");
                //start listener
                listen = new Thread(onMessageReceived);
                listen.Name = "TCP Listener";
                listen.Start();
                return true;
            }
            else
            {
                Console.WriteLine("Connection Error");
                return false;
            }
        }

        void onMessageReceived()
        {
            byte[] bytes = new byte[2048];
            while (true)
            {
                try
                {

                    int bytesRec = socket.Receive(bytes);
                    JObject data = DecompressString(bytes);
                    if(EventMessageReceived!=null)
                        EventMessageReceived(this, data);
                    ProcessMessage(data);

                }
                catch
                {
                    Console.WriteLine("connection broken");
                    continue;
                }

            }
        }

        public void SendMessage (JObject data)
        {
            string message = JsonConvert.SerializeObject(data);
            socket.Send(CompressString(message));

        }


        void ProcessMessage(JObject data)
        {
            Console.Write(data.ToString());
            // .. your code to process the message request

        }

        byte[] CompressString(string message)
        {

            var bytes = Encoding.Default.GetBytes(message);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new System.IO.Compression.GZipStream(mso, System.IO.Compression.CompressionMode.Compress))
                {
                    msi.CopyTo(gs);
                }

                return mso.ToArray();
            }
        }

        JObject DecompressString(byte[] message)
        {

            using (var msi = new MemoryStream(message))
            using (var mso = new MemoryStream())
            {
                using (var gs = new System.IO.Compression.GZipStream(msi, System.IO.Compression.CompressionMode.Decompress))
                {
                    gs.CopyTo(mso);
                }

                string result = Encoding.ASCII.GetString(mso.ToArray());
                JObject jo = JsonConvert.DeserializeObject<JObject>(result);

                return jo;
            }
        }

    }
}
