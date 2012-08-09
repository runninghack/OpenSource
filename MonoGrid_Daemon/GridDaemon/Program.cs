using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace GridDaemon
{
    partial class Program
    {
        [System.STAThread()]
        static void Main(string[] args)
        {
            //检测配置文件是否存在
            ConfigHelper.ConfigStart();


            try
            {
                //System.Uri uri = new Uri (typeof(string).Assembly.CodeBase);
                //string RuntimePath = System.IO.Path.GetDirectoryName (uri.LocalPath);
                //string strInstallUtilPath = System.IO.Path.Combine (RuntimePath, "InstallUtil.exe");

                foreach (string arg in System.Environment.GetCommandLineArgs())
                {
                    Console.WriteLine(arg);
                    //if (arg == "/install") {
                    //    System.Diagnostics.Process.Start (strInstallUtilPath, "\"" + System.Windows.Forms.Application.ExecutablePath + "\"");
                    //    return;
                    //} else if (arg == "/uninstall") {
                    //    System.Diagnostics.Process.Start (strInstallUtilPath, "/u \"" + System.Windows.Forms.Application.ExecutablePath + "\"");
                    //    return;
                    //} else
                    if (arg == "/client")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("以客户端形式运行！");
                        Console.ForegroundColor = ConsoleColor.Black;
                        //启动客户端
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                        using (GridClient frm = new GridClient())
                        {
                            Application.Run(frm);
                            frm.ShowDialog();
                        }
                        return;
                    }
                    else (arg=="/service")
                    {
                        MainService service = new MainService();
                        service.Update();
                    }

                }
            }
            catch (Exception ext)
            {
                Console.WriteLine(ext.ToString());
                return;
            }


        }
    }
}
