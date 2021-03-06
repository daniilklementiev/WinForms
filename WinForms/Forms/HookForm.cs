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
        private Size resolution;                            // screen resolution
        private Bitmap bitmap;                              // bitmap const for save image
        private Dictionary<Keys, Keys> replacedButtons;     // replaced buttons
        private KeysConverter keyConverter;                 // convert key to keys
        
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

        /// <summary>
        /// Create system message(s) and sending them
        /// </summary>
        /// <param name="nInputs">Number of messages</param>
        /// <param name="inputs">Messages (structures INPUT) array</param>
        /// <param name="inpSize">Array memory size</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SendInput", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint SendMessages(uint nInputs, INPUT[] inputs, int inpSize);
        
        #endregion

        private const int
            WM_KEYDOWN = 0x100,        // keydown const
            WM_KEYBOARD_LL = 13,           // keyboard low const
            WM_MOUSEMOVE = 0x200,        // mousemove const
            WM_LBUTTONDOWN = 0x0201,       // left mouse button down const
            WM_LBUTTONUP = 0x0202,       // left mouse button up const
            WM_RBUTTONDOWN = 0x0204,       // right mouse button down const
            WM_RBUTTONUP = 0x0205,       // right mouse button up const
            WH_MOUSE_LL = 14;           // mouse low const


        public HookForm()
        {
            kbHookPinned = null!;                                                // keyboard hook in memory
            mouseHookPinned = null!;                                             // mouse hook in memory
            InitializeComponent();
            resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;  // get screen resolution
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);          // creating bitmap wtih picturebox sizes
            pictureBox1.InitialImage = bitmap;                                   // initialize picture box image
            replacedButtons = new Dictionary<Keys, Keys>();                      // create dictionary for replaced buttons
            keyConverter = new KeysConverter();                                  // create keys converter
        }

        private void HookForm_Load(object sender, EventArgs e)
        {
            
        }


        #region Keyboard hook
        private IntPtr hKbHook;         // hook for keyboard
        private HookProc kbHookPinned;  // keyboard hook memory
        private GCHandle kbGcHandle;    // gc handle for keyboard hook

       
       
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
                kbGcHandle = GCHandle.Alloc(kbHookPinned);  // block keyboard hook

                hKbHook = SetHook(                          // set hook
                        WM_KEYBOARD_LL,
                        kbHookPinned,
                        GetModule(currentModule.ModuleName!),
                        0);
                this.ActiveControl = null;
            }
        }

        private void buttonKbStop_Click(object sender, EventArgs e)
        {
            tabPage1.Text = "Keyboard (disactive)";
            buttonKbStart.Enabled = true;
            buttonKbStop.Enabled = false;
            UnSetHook(hKbHook);                 // unset hook
            kbGcHandle.Free();                  // free gc memory
            this.ActiveControl = null;
        }

        private IntPtr KbHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                // int keyVirtualtCode = Marshal.ReadInt32(lParam);                 // short version - only 1st field (32bit)
                var msgData = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);      // full version - structure marshalling

                Keys key = (Keys)msgData.vkCode; // (Keys)keyVirtualtCode;          // in short version
                richTextBoxKb.Text += key.ToString();
                if (key == Keys.LWin)                                               // left windows button  
                {
                    richTextBoxKb.Text += "(rejected)";
                    return (IntPtr)1;
                }

                // ****************** Key(s) replace demo ******************
                // cycle that replace all keys from listbox 
                foreach (var repKey in replacedButtons)
                {
                    if (key == repKey.Key)
                    {
                        // new system message
                        INPUT inp = new INPUT
                        {
                            Type = 1  // Keyboard message
                        };
                        inp.Data.Keyboard.Vk = (ushort)repKey.Value;
                        inp.Data.Keyboard.Scan = 0;
                        inp.Data.Keyboard.Flags = 0;    // 0 - keyDown; 2 - keyUp
                        inp.Data.Keyboard.Time = 0;
                        inp.Data.Keyboard.ExtraInfo = IntPtr.Zero;

                        INPUT[] msgs = new INPUT[] { inp };  // For SendInput array needed

                        
                        SendMessages(1, msgs, Marshal.SizeOf(typeof(INPUT)));

                        // Log info
                        richTextBoxKb.Text += $"({repKey.Key.ToString()} --> {repKey.Value.ToString()})";

                        // delete current message
                        return (IntPtr)1;
                    }
                }
            }

            return NextHook(hKbHook, nCode, wParam, lParam);
        }
        private void textBoxSourceKey_KeyDown(object sender, KeyEventArgs e)
        {
            // process keys in textbox
            e.Handled = true;
            e.SuppressKeyPress = true;
            var tb = sender as TextBox;
            if (tb != null)
                tb.Text = e.KeyData.ToString();
        }

        private void buttonAddReplace_Click(object sender, EventArgs e)
        {
            // check if key is already in list
            if (textBoxSourceKey.Text != String.Empty && textBoxTargetKey.Text != String.Empty)
            {
                // if no - add to list
                if (!replacedButtons.ContainsKey((Keys)keyConverter.ConvertFromString(textBoxSourceKey.Text)))
                {
                    // Convert name of key to Keys type and add replacing to dictionary
                    Keys replacedKeySource = (Keys)keyConverter.ConvertFromString(textBoxSourceKey.Text);
                    Keys replacedKeyTarget = (Keys)keyConverter.ConvertFromString(textBoxTargetKey.Text);
                    replacedButtons[replacedKeySource] = replacedKeyTarget;
                    listBoxReplaces.Items.Add($"{textBoxSourceKey.Text} --> {textBoxTargetKey.Text}");
                }
                else
                {
                    MessageBox.Show("This key already replaced. Try another");
                }
            }
        }        


        #endregion

        #region Mouse hook
        private IntPtr hMouseHook;          // mouse hook
        private HookProc mouseHookPinned;   // mouse hook in memory
        private GCHandle mouseGcHandle;     // mouse gc handle

        
        private int DrawMouseMap(Int32 position, Int32 minW, Int32 resolutionW, Int32 minH, Int32 resolutionH)
        {
            return (minH + (position - minW) * (resolutionW - minH) / (resolutionH - minW)); // process value for map (picture box)
        }
        private IntPtr MsHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var msgData = Marshal.PtrToStructure<MsHookStruct>(lParam);  // full version - structure marshalling
                POINT p = (POINT)msgData.point;                              // get point from struct
                IntPtr extra = (IntPtr)msgData.dwExtraInfo;                  // extra data from struct
                uint msData = (uint)msgData.mouseData;                       // mouse data from struct

                switch ((int)wParam)
                {
                    case WM_LBUTTONDOWN: listBoxMs.Items.Add($"L: x = {p.x}, y = {p.y} | extra = {extra} | msdata = {msData}"); break;  // process left mouse button
                    case WM_RBUTTONDOWN: listBoxMs.Items.Add($"R: x = {p.x}, y = {p.y} | extra = {extra} | msdata = {msData}"); break;  // process right mouse button
                    case WM_MOUSEMOVE:
                        int x = DrawMouseMap(p.x, 0, resolution.Width, 0, pictureBox1.Width);    // get x pos for map
                        int y = DrawMouseMap(p.y, 0, resolution.Height, 0, pictureBox1.Height);  // get y pos for map

                        bitmap.SetPixel(x, y, Color.Black); // set pixel in bitmap map
                        pictureBox1.Image = bitmap;         // set bitmap in picturebox
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

                mouseHookPinned = MsHookProc;                     // remember mouse hook
                mouseGcHandle = GCHandle.Alloc(mouseHookPinned);  // block hook

                hMouseHook = SetHook(                             // set hook
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
            mouseGcHandle.Free();               // free memory aftet process hook
            UnSetHook(hMouseHook);              // unset hook
        }

        #endregion

        #region Structures
        [StructLayout(LayoutKind.Sequential)]
        struct KBDLLHOOKSTRUCT
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }   // keyboard dll struct

        [StructLayout(LayoutKind.Sequential)]
        struct POINT                        // point struct for mouse
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MsHookStruct                 // mouse hook struct
        {
            public POINT point;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct INPUT
        {
            public uint Type;
            public MOUSEKEYBDHARDWAREINPUT Data;
        }




        [StructLayout(LayoutKind.Explicit)]
        internal struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public HARDWAREINPUT Hardware;
            [FieldOffset(0)]
            public KEYBDINPUT Keyboard;
            [FieldOffset(0)]
            public MOUSEINPUT Mouse;
        }




        [StructLayout(LayoutKind.Sequential)]
        internal struct HARDWAREINPUT
        {
            public uint Msg;
            public ushort ParamL;
            public ushort ParamH;
        }



        [StructLayout(LayoutKind.Sequential)]
        internal struct KEYBDINPUT
        {
            public ushort Vk;
            public ushort Scan;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEINPUT
        {
            public int X;
            public int Y;
            public uint MouseData;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
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
