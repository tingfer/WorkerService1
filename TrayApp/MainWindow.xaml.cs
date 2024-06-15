using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;

namespace TrayApp
{
    public partial class MainWindow : Window
    {
        private TaskbarIcon _notifyIcon;

        public MainWindow()
        {
            InitializeComponent();

            var appLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var iconPath = Path.Combine(Path.GetDirectoryName(appLocation), "icon.ico");

            _notifyIcon = new TaskbarIcon
            {
                Icon = new Icon(iconPath),
                Visibility = Visibility.Visible
            };

            _notifyIcon.TrayMouseDoubleClick += (sender, args) => Show();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
            }

            base.OnStateChanged(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            _notifyIcon.Dispose();

            base.OnClosed(e);
        }
    }
}