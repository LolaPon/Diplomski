using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public class ServerKlasa
    {
        Socket soket;
        Thread nit;
        public static List<NetworkStream> listaTokova = new List<NetworkStream>();

        public bool PokreniServer() 
        {
            try
            {
                soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 20000);
                soket.Bind(ep);

                ThreadStart delegat = osluskuj;
                nit = new Thread(delegat);
                nit.Start();

                return true;
            }
            catch (Exception)
            {

                return false; ;
            }
        
        }


        public bool zaustaviServer()
        {
            try
            {
                soket.Close();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void osluskuj()
        {
            while (true)
            {
                try
                {
                    soket.Listen(8);
                    Socket klijent = soket.Accept();
                    NetworkStream tok = new NetworkStream(klijent);
                    new NitKlijenta(tok);
                    listaTokova.Add(tok);
                    
                }
                catch (Exception)
                {

                }

            }

        
        }














    }
}
