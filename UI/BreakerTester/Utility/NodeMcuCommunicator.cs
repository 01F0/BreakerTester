using System.Net.Sockets;

namespace BreakerTester
{
    public class NodeMcuCommunicator
    {
        private int _address;

        public NodeMcuCommunicator(int address)
        {
            _address = address;
        }

        public void Send()
        {
            using (var tcpClient = new TcpClient("localhost", 23))
            {
                using (var stream = tcpClient.GetStream())
                {
                    stream.Write(new byte[] { (byte)_address }, 0, 1);

                    stream.Close();
                }

                tcpClient.Close();
            }
        }
    }
}
