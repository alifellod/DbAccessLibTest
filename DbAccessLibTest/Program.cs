using System;
using System.Threading;
using System.Windows.Forms;

namespace DbAccessLibTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ThreadExceptionHandler handler = new ThreadExceptionHandler();
            Application.ThreadException += handler.Application_ThreadException;
            Application.Run(new FrmContainer());

        }
        /// 
        /// 处理程序异常
        /// 
        internal class ThreadExceptionHandler
        {
            public void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
            {
                try
                {
                    var ex = e.Exception;
                    string errorMessage = "发生错误，是否终止程序，错误信息：\n\n" +
                    ex.Message + "\n\n" + ex.GetType() +
                    "\n\nStack Trace:\n" + ex.StackTrace;

                    if (MessageBox.Show(errorMessage, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                        Application.Exit();
                }
                catch
                {
                    try
                    {
                        MessageBox.Show("严重错误", "严重错误",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
                    }
                    finally
                    {
                        Application.Exit();
                    }
                }
            }
        }
    }
}
