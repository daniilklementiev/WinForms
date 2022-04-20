using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WinForms.Forms
{
    public partial class HookForm : Form
    {
        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        private Size resolution;
        private Bitmap bitmap;
        #region DLL Import
        [DllImport("user32.dll",                // DLL name
            EntryPoint = "SetWindowsHookEx",    // Proc name
            CharSet = CharSet.Auto,             // Unicode/Ansi - Auto detect
            SetLastError = true)]               // Proc call changes OS error info
        private static extern                   //  all imports are: static and extern
            IntPtr                              //  return type - converted to .NET 
            SetHook(                   // Proc name (local). Rename - attribute in DLLImport
            int idHook,                         // paramenters type - converted to .NET types
            HookProc lpfnProc,                  // delegate type - for function pointers
            IntPtr hMod,                        // 
            uint dwThreadId);                   // 

        [DllImport("user32.dll", EntryPoint = "UnhookWindowsHookEx", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnSetHook(IntPtr hHook);

        [DllImport("user32.dll", EntryPoint = "CallNextHookEx", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr NextHook(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", EntryPoint = "GetModuleHandle", SetLastError = true)]
        private static extern IntPtr GetModule(String lpModuleName);

        #endregion

        private const int
            WM_KEYDOWN      = 0x100,
            WM_KEYBOARD_LL  = 13,
            WM_MOUSEMOVE    = 0x200,
            WM_LBUTTONDOWN  = 0x0201,
            WM_LBUTTONUP    = 0x0202,
            WM_RBUTTONDOWN  = 0x0204,
            WM_RBUTTONUP    = 0x0205,
            WH_MOUSE_LL     = 14;


        public HookForm()
        {
            kbHookPinned = null!;
            mouseHookPinned = null!;
            InitializeComponent();
            resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.InitialImage = bitmap;
        }

        #region Keyboard hook
        private IntPtr hKbHook;
        private HookProc kbHookPinned;
        private GCHandle kbGcHandle;

        [StructLayout(LayoutKind.Sequential)]
        struct KBDLLHOOKSTRUCT
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        private void buttonKbStart_Click(object sender, EventArgs e)
        {
            tabPage1.Text = "Keyboard (active)";
            buttonKbStart.Enabled = false;
            buttonKbStop.Enabled = true;

            using (Process currentProcess = Process.GetCurrentProcess())
            using (ProcessModule? currentModule = currentProcess.MainModule)
            {
                if (currentModule == null) return;

                kbHookPinned = KbHookProc;
                kbGcHandle = GCHandle.Alloc(kbHookPinned);

                hKbHook = SetHook(
                        WM_KEYBOARD_LL,
                        kbHookPinned,
                        GetModule(currentModule.ModuleName!),
                        0);
            }
        }

        private void buttonKbStop_Click(object sender, EventArgs e)
        {
            tabPage1.Text = "Keyboard (disactive)";
            buttonKbStart.Enabled = true;
            buttonKbStop.Enabled = false;
            UnSetHook(hKbHook);
            kbGcHandle.Free();
        }

        private IntPtr KbHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                // int keyVirtualtCode = Marshal.ReadInt32(lParam); // short version - only 1st field (32bit)
                var msgData = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);    // full version - structure marshalling

                Keys key = (Keys)msgData.vkCode; // (Keys)keyVirtualtCode;  // in short version
                richTextBoxKb.Text += key.ToString();
                if (key == Keys.LWin)
                {
                    richTextBoxKb.Text += "(rejected)";
                    return (IntPtr)1;
                }
            }

            return NextHook(hKbHook, nCode, wParam, lParam);
        }


        #endregion

        #region Mouse hook
        private IntPtr hMouseHook;
        private HookProc mouseHookPinned;
        private GCHandle mouseGcHandle;

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MsHookStruct
        {
            public POINT point;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        private int DrawMouseMap(Int32 position, Int32 minW, Int32 resolutionW, Int32 minH, Int32 resolutionH)
        {
            return (minH + (position - minW) * (resolutionW - minH) / (resolutionH - minW));
        }
        private IntPtr MsHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var msgData = Marshal.PtrToStructure<MsHookStruct>(lParam);    // full version - structure marshalling
                POINT p = (POINT)msgData.point;
                IntPtr extra = (IntPtr)msgData.dwExtraInfo;
                uint msData = (uint)msgData.mouseData;

                switch ((int)wParam)
                {
                    case WM_LBUTTONDOWN: listBoxMs.Items.Add($"L: x = {p.x}, y = {p.y} | extra = {extra} | msdata = {msData}"); break;
                    case WM_RBUTTONDOWN: listBoxMs.Items.Add($"R: x = {p.x}, y = {p.y} | extra = {extra} | msdata = {msData}"); break;
                    case WM_MOUSEMOVE:
                        int x = DrawMouseMap(p.x, 0, resolution.Width, 0, pictureBox1.Width);
                        int y = DrawMouseMap(p.y, 0, resolution.Height, 0, pictureBox1.Height);

                        bitmap.SetPixel(x, y, Color.Black);
                        pictureBox1.Image = bitmap;
                        break;
                }
            }

            return NextHook(hMouseHook, nCode, wParam, lParam);
        }

        private void buttonMsStart_Click(object sender, EventArgs e)
        {
            tabPage2.Text = "Mouse (active)";
            buttonMsStart.Enabled = false;
            buttonMsStop.Enabled = true;
            using (Process currentProcess = Process.GetCurrentProcess())
            using (ProcessModule? currentModule = currentProcess.MainModule)
            {
                if (currentModule == null) return;

                mouseHookPinned = MsHookProc;
                mouseGcHandle = GCHandle.Alloc(mouseHookPinned);

                hMouseHook = SetHook(
                        WH_MOUSE_LL,
                        mouseHookPinned,
                        GetModule(currentModule.ModuleName!),
                        0);
            }
        }

        private void buttonMsStop_Click(object sender, EventArgs e)
        {
            tabPage2.Text = "Mouse (disactive)";
            buttonMsStart.Enabled = true;
            buttonMsStop.Enabled = true;
            mouseGcHandle.Free();
            UnSetHook(hMouseHook);
        }

        #endregion
    }
}

/* Унаследованный код - термин, характеризующий "устаревший" код, созданный при
помощи старых технологий. Также - код, созданный на предыдущих этапах другой
командой.
 Рассмотрим пример использования кода, созданного на Ассемблере, из DLL WinAPI
- Вызов из "нашего" кода процедур из "унаследованного" кода
- Вызов из "унаследованного" кода "наших" процедур/методов
- Передача данных между контекстами ("кучами") двух кодов

В качестве примера - системные хуки (встраивание дополнительных обработчиков
системных событий) 
- вызов методов (процедур) из DLL
- вызов наших методов из системной области
- передача параметров событий из системной области в .NET (и обратно)

 * */
