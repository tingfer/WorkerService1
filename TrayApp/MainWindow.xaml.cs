using System;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;

namespace TrayApp
{
    public partial class MainWindow : Window
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;

        public MainWindow()
        {
            InitializeComponent();
            CreateTrayIcon();
        }

        private void CreateTrayIcon()
        {
            // 創建右鍵選單
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Show", null, OnShow);
            trayMenu.Items.Add("Exit", null, OnExit);

            // 創建托盤圖示
            trayIcon = new NotifyIcon();
            trayIcon.Text = "TrayApp";
            trayIcon.Icon = new Icon("icon.ico");

            // 增加右鍵選單到托盤圖示
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Visible = true;

            // 隱藏主窗口
            this.WindowState = WindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visibility = Visibility.Hidden;
        }

        private void OnShow(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            this.ShowInTaskbar = true;
            this.Visibility = Visibility.Visible;
        }

        private void OnExit(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        protected override void OnClosed(EventArgs e)
        {
            trayIcon.Dispose();
            base.OnClosed(e);
        }
    }
}