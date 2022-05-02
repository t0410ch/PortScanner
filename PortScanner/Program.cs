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
            
                if (true) // 端口合理
                {
                    //让输入的textbox只读，无法改变
                    
                    //创建线程，并创建ThreadStart委托对象
                    Thread process = new Thread(new ThreadStart(scan.PortScan));
                    process.Start();
                    //设置进度条的范围
                    

                    //显示框显示
                   
                }
                else
                {
                    //若端口号不合理，弹窗报错
                   // MessageBox.Show("输入错误，端口范围为[0-65536]!");
                }

            }
            catch
            {
                //若输入的端口号为非整型，则弹窗报错
                //MessageBox.Show("输入错误，端口范围为[0-65536]!");
            }
        }
    }
}
