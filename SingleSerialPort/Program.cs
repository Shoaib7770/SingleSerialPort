
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


namespace SingleSerialPort
{
    internal class Program
    {
        static async Task Main()
        {
           
            SerialPortManager manager = new SerialPortManager("COM1");
            manager.ConfigurePorts();
            await manager.ReadWriteDataInParallel();
        }
    }
}
