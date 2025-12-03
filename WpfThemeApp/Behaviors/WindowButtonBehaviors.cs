using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace WpfThemeApp.Behaviors
{
    public static class WindowButtonBehaviors
    {
        // Existing Minimize, MaximizeRestore, Close properties...
        // Minimize
        public static readonly DependencyProperty MinimizeProperty =
            DependencyProperty.RegisterAttached("Minimize", typeof(bool), typeof(WindowButtonBehaviors),
                new PropertyMetadata(false, OnMinimizeChanged));

        public static void SetMinimize(UIElement element, bool value) => element.SetValue(MinimizeProperty, value);
        public static bool GetMinimize(UIElement element) => (bool)element.GetValue(MinimizeProperty);

        private static void OnMinimizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Button btn && (bool)e.NewValue)
            {
                btn.Click += (s, _) =>
                {
                    var window = Window.GetWindow(btn);
                    if (window != null) window.WindowState = WindowState.Minimized;
                };
            }
        }

        // Maximize/Restore
        public static readonly DependencyProperty MaximizeRestoreProperty =
            DependencyProperty.RegisterAttached("MaximizeRestore", typeof(bool), typeof(WindowButtonBehaviors),
                new PropertyMetadata(false, OnMaximizeRestoreChanged));

        public static void SetMaximizeRestore(UIElement element, bool value) => element.SetValue(MaximizeRestoreProperty, value);
        public static bool GetMaximizeRestore(UIElement element) => (bool)element.GetValue(MaximizeRestoreProperty);

        private static void OnMaximizeRestoreChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Button btn && (bool)e.NewValue)
            {
                btn.Click += (s, _) =>
                {
                    var window = Window.GetWindow(btn);
                    if (window != null)
                    {
                        window.WindowState = window.WindowState == WindowState.Normal
                            ? WindowState.Maximized
                            : WindowState.Normal;
                    }
                };
            }
        }

        // Close
        public static readonly DependencyProperty CloseProperty =
            DependencyProperty.RegisterAttached("Close", typeof(bool), typeof(WindowButtonBehaviors),
                new PropertyMetadata(false, OnCloseChanged));

        public static void SetClose(UIElement element, bool value) => element.SetValue(CloseProperty, value);
        public static bool GetClose(UIElement element) => (bool)element.GetValue(CloseProperty);

        private static void OnCloseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Button btn && (bool)e.NewValue)
            {
                btn.Click += (s, _) =>
                {
                    var window = Window.GetWindow(btn);
                    window?.Close();
                };
            }
        }



        // Double-click on title bar

        //public static readonly DependencyProperty EnableTitleBarDoubleClickProperty =
        //    DependencyProperty.RegisterAttached("EnableTitleBarDoubleClick", typeof(bool), typeof(WindowButtonBehaviors),
        //        new PropertyMetadata(false, OnEnableTitleBarDoubleClickChanged));

        //public static void SetEnableTitleBarDoubleClick(UIElement element, bool value) =>
        //    element.SetValue(EnableTitleBarDoubleClickProperty, value);

        //public static bool GetEnableTitleBarDoubleClick(UIElement element) =>
        //    (bool)element.GetValue(EnableTitleBarDoubleClickProperty);

        //private static void OnEnableTitleBarDoubleClickChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is Grid grid && (bool)e.NewValue)
        //    {
        //        grid.MouseLeftButtonDown += (s, args) =>
        //        {
        //            if (args.ClickCount == 2)
        //            {
        //                var window = Window.GetWindow(grid);
        //                if (window != null)
        //                {
        //                    window.WindowState = window.WindowState == WindowState.Normal
        //                        ? WindowState.Maximized
        //                        : WindowState.Normal;
        //                }
        //            }
        //            else if (args.ClickCount == 1)
        //            {
        //                // Allow dragging the window
        //                var window = Window.GetWindow(grid);
        //                window?.DragMove();
        //            }
        //        };
        //    }
        //}
    }
}