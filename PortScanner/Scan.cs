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
    class Scan
    {
        //主机地址
        private static string hostAddress;
        //起始端口
        private static int start;
        //终止端口
        private static int end;
        //端口号
        private static int port;
        //定义线程对象
        private Thread scanThread;
        //定义端口状态数据（开放则为true，否则为false）
        private bool[] done = new bool[65535];
        private bool OK;
        private int cishu;
        TrojanJudge Trojan = new TrojanJudge();
        public void PortScan()
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("请输入你想扫描的IP地址：");
            hostAddress = Console.ReadLine();
            start = 0;
            end = 65535;
            Console.WriteLine("开始扫描！");
            Console.WriteLine("*********************************************");
            double x;
            cishu = 0;
            //循环抛出线程扫描端口
            for (int i = start; i <= end; i++)
            {
                x = (double)(i - start + 1) / (end - start + 1);
                port = i;
                //使用该端口的扫描线程
                scanThread = new Thread(new ThreadStart(NScan));
                scanThread.Start();
                //使线程睡眠
                System.Threading.Thread.Sleep(100);
            }
            while (!OK)
            {
                OK = true;
                for (int i = start; i <= end; i++)
                {
                    if (!done[i])
                    {
                        OK = false;
                        break;
                    }
                }
                System.Threading.Thread.Sleep(1000);
            }
        }


        /// <summary>
        /// 扫描某个端口
        /// </summary>
        private void NScan()
        {
            int portnow = port;
            //创建线程变量
            Thread Threadnow = scanThread;
            //扫描端口，成功则写入信息
            done[portnow] = true;
            //创建TcpClient对象，TcpClient用于为TCP网络服务提供客户端连接
            TcpClient objTCP = null;
            try
            {
                //用于TcpClient对象扫描端口
                objTCP = new TcpClient(hostAddress, portnow);
                if(Trojan.PortCheck(port)==-999)
                Console.Write(string.Format("端口{0}开放！不是木马端口特征！", port));
                else
                    Console.Write(string.Format("端口{0}开放！WARNING：木马端口特征，请注意查杀！", port));
            }
            catch
            {
                
                //未扫描到，则会抛出错误
                if (cishu == 0)
                {
                    cishu++;
                    Console.Write("+");
                }else if(cishu==1)
                {
                    cishu++;
                    Console.Write("-");
                }
                else
                {
                    cishu = 0;
                    Console.Write("-");
                }
                

            }
        }
    }
}
