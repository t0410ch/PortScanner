using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace PortScanner
{

    class Program
    {
         static void Main(string[] args)
        {
            Scan scan = new Scan();
            try
            {
                    Thread process = new Thread(new ThreadStart(scan.PortScan));
                    process.Start();    

            }
            catch
            {

            }
        }
    }
}
