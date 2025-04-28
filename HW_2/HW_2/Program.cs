using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HW_2
{
    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll")]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr GetParent(IntPtr hWnd);


        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        const int SW_MINIMIZE = 6;
        const uint WM_CLOSE = 0x0010;

        static List<(IntPtr handle, string title)> windows = new List<(IntPtr, string)>();

        static void Main()
        {
            EnumWindows(new EnumWindowsProc(EnumWindowCallback), IntPtr.Zero);

            Console.WriteLine("Список окон:");
            for (int i = 0; i < windows.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {windows[i].title}");
            }

            Console.Write("\nВыберите окно по номеру: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > windows.Count)
            {
                Console.WriteLine("Неверный выбор!");
                return;
            }

            IntPtr selectedWindow = windows[choice - 1].handle;

            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1 - Переместить окно");
            Console.WriteLine("2 - Свернуть окно");
            Console.WriteLine("3 - Закрыть окно");
            Console.WriteLine("4 - Переименовать окно");
            Console.Write("Ваш выбор: ");

            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    Console.Write("Введите новые координаты (X Y): ");
                    var coords = Console.ReadLine().Split(' ');
                    int x = int.Parse(coords[0]);
                    int y = int.Parse(coords[1]);
                    MoveWindow(selectedWindow, x, y, 800, 600, true);
                    break;

                case "2":
                    ShowWindow(selectedWindow, SW_MINIMIZE);
                    break;

                case "3":
                    PostMessage(selectedWindow, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    break;

                case "4":
                    Console.Write("Введите новое название окна: ");
                    string newTitle = Console.ReadLine();
                    SetWindowText(selectedWindow, newTitle);
                    break;

                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }

        static bool EnumWindowCallback(IntPtr hWnd, IntPtr lParam)
        {
            if (IsWindowVisible(hWnd) && GetParent(hWnd) == IntPtr.Zero)
            {
                StringBuilder buffer = new StringBuilder(256);
                GetWindowText(hWnd, buffer, buffer.Capacity);
                string title = buffer.ToString();

                if (!string.IsNullOrWhiteSpace(title))
                {
                    windows.Add((hWnd, title));
                }
            }
            return true; 
        }

    }
}
