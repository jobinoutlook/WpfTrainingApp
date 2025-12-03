using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace WpfThemeApp2
{
    public static class CenteredMessageBox
    {
        private static IntPtr _hook;
        private static HookProc _hookProc;

        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hHook);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        private const int WH_CBT = 5;
        private const int HCBT_ACTIVATE = 5;

        public static MessageBoxResult Show(Window owner, string text, string caption)
        {
            var ownerHandle = new WindowInteropHelper(owner).Handle;
            _hookProc = (nCode, wParam, lParam) =>
            {
                if (nCode == HCBT_ACTIVATE)
                {
                    CenterWindow(ownerHandle, wParam);
                    UnhookWindowsHookEx(_hook);
                }
                return CallNextHookEx(_hook, nCode, wParam, lParam);
            };

            uint threadId = GetCurrentThreadId();
            _hook = SetWindowsHookEx(WH_CBT, _hookProc, IntPtr.Zero, threadId);

            return MessageBox.Show(owner, text, caption);
        }

        public static MessageBoxResult Show(Window owner, string text, string caption,
                                        MessageBoxButton buttons = MessageBoxButton.OK,
                                        MessageBoxImage icon = MessageBoxImage.None)
        {
            var ownerHandle = new WindowInteropHelper(owner).Handle;
            _hookProc = (nCode, wParam, lParam) =>
            {
                if (nCode == HCBT_ACTIVATE)
                {
                    CenterWindow(ownerHandle, wParam);
                    UnhookWindowsHookEx(_hook);
                }
                return CallNextHookEx(_hook, nCode, wParam, lParam);
            };

            uint threadId = GetCurrentThreadId();
            _hook = SetWindowsHookEx(WH_CBT, _hookProc, IntPtr.Zero, threadId);

            return MessageBox.Show(owner, text, caption, buttons, icon);
        }

        private static void CenterWindow(IntPtr owner, IntPtr child)
        {
            GetWindowRect(owner, out RECT ownerRect);
            GetWindowRect(child, out RECT childRect);

            int ownerWidth = ownerRect.Right - ownerRect.Left;
            int ownerHeight = ownerRect.Bottom - ownerRect.Top;
            int childWidth = childRect.Right - childRect.Left;
            int childHeight = childRect.Bottom - childRect.Top;

            int x = ownerRect.Left + (ownerWidth - childWidth) / 2;
            int y = ownerRect.Top + (ownerHeight - childHeight) / 2;

            MoveWindow(child, x, y, childWidth, childHeight, true);
        }

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();
    }
}