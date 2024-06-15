using System;
using System.Diagnostics;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private static int _count;

        public MainWindow()
        {
            InitializeComponent();

            // 獲取啟動參數
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                _count = args.Length - 1;
                ArgumentsTextBlock.Text = "Arguments received: " + string.Join(" ", args, 1, args.Length - 1);
            }
            else
            {
                ArgumentsTextBlock.Text = "No arguments received.";
            }
        }

        private void RestartWithArguments_Click(object sender, RoutedEventArgs e)
        {
            // string arguments = "argument1 argument2"; // 這裡可以根據需求動態設置參數
            _count++;
            var arguments = "";
            for (var i = 0; i < _count; i++)
            {
                arguments += $"arg{i} ";
            }

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
            startInfo.Arguments = arguments;

            // 啟動新的進程
            Process.Start(startInfo);

            // 關閉當前應用程式
            System.Threading.Thread.Sleep(3000);
            Application.Current.Shutdown();
        }
    }
}