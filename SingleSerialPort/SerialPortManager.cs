using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleSerialPort
{
   
        class SerialPortManager
        {
            private SerialPort _port1;
            public SerialPortManager(string portName1)
            {
                _port1 = new SerialPort(portName1);

            }
            public void ConfigurePorts()
            {
                _port1.BaudRate = 9600;
                _port1.Parity = Parity.None;
                _port1.StopBits = StopBits.One;
                _port1.DataBits = 8;
                _port1.Open();
               
            }

            public async Task ReadWriteDataInParallel()
            {
                await Task.WhenAll(
                    Task.Run(() => ReadData(_port1)),
                    Task.Run(() => WriteData(_port1))
                );
            }

            private void ReadData(SerialPort port)
            {
                while (true)
                {
                    try
                    {
                        string data = port.ReadLine();
                        Console.WriteLine($"Data received from {port.PortName}: {data}");
                    }
                    catch (TimeoutException) { }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error reading data from {port.PortName}: {ex.Message}");
                    }
                }
            }

            private void WriteData(SerialPort port)
            {
                while (true)
                {
                    try
                    {
                        string data = Console.ReadLine();
                        port.WriteLine(data);
                        Console.WriteLine($"Data sent to {port.PortName}: {data}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error writing data to {port.PortName}: {ex.Message}");
                    }
                }
            }
        }
    }
