namespace XiaoTa
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    public class ConsoleStyle
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);

        private const int HwndTopmost = -1;
        private const int SwpNomove = 0x0002;
        private const int SwpNosize = 0x0001;

        /// <summary>
        /// 控制台获取焦点
        /// </summary>
        public static void ConsoleStick()
        {
            IntPtr hWnd = Process.GetCurrentProcess().MainWindowHandle;

            SetWindowPos(hWnd,
                new IntPtr(HwndTopmost),
                0, 0, 0, 0,
                SwpNomove | SwpNosize);
        }
    }
}
