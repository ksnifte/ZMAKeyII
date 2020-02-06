using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Linq;

namespace ZMAKeyII
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // import the function in your class
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);


        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        private string commandBuffer = "";
        private KeysConverter kc = new KeysConverter();

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                // INTERCEPT LETTERS & NUMBERS TO PUT INTO THE TEXT FIELD
                case Key.A: case Key.B: case Key.C: case Key.D: case Key.E: case Key.F:
                case Key.G: case Key.H: case Key.I: case Key.J: case Key.K: case Key.L:
                case Key.M: case Key.N: case Key.O: case Key.P: case Key.Q: case Key.R:
                case Key.S: case Key.T: case Key.U: case Key.V: case Key.W: case Key.X:
                case Key.Y: case Key.Z: case Key.D0: case Key.D1: case Key.D2: case Key.D3:
                case Key.D4: case Key.D5: case Key.D6: case Key.D7: case Key.D8: case Key.D9:
                case Key.NumPad0: case Key.NumPad1: case Key.NumPad2: case Key.NumPad3:
                case Key.NumPad4: case Key.NumPad5: case Key.NumPad6: case Key.NumPad7:
                case Key.NumPad8: case Key.NumPad9:
                    {
                        commandBuffer += getKeyString(e.Key);
                        break;
                    }

                // INTERCEPT COMMAND KEYS
                case Key.Up: { commandBuffer += " cm "; break; }

                // INTERCEPT ENTER
                case Key.Enter:
                    {
                        Console.WriteLine(commandBuffer);

                        Process p = Process.GetProcessesByName("ESKey").FirstOrDefault();

                        if (p != null)
                        {
                            IntPtr curr = GetForegroundWindow();
                            IntPtr h = p.MainWindowHandle;
                            SetForegroundWindow(h);
                            SendKeys.SendWait(commandBuffer);
                            SendKeys.SendWait("{Enter}");
                            SetForegroundWindow(curr);
                        }

                        commandBuffer = "";
                        break;
                    }
                default:
                    {
                        Thread.Sleep(100);
                        break;
                    }
            }
        }


        private String getKeyString(Key key)
        {
            switch (key)
            {
                case Key.A: { return "A"; }
                case Key.B: { return "B"; }
                case Key.C: { return "C"; }
                case Key.D: { return "D"; }
                case Key.E: { return "E"; }
                case Key.F: { return "F"; }
                case Key.G: { return "G"; }
                case Key.H: { return "H"; }
                case Key.I: { return "I"; }
                case Key.J: { return "J"; }
                case Key.K: { return "K"; }
                case Key.L: { return "L"; }
                case Key.M: { return "M"; }
                case Key.N: { return "N"; }
                case Key.O: { return "O"; }
                case Key.P: { return "P"; }
                case Key.Q: { return "Q"; }
                case Key.R: { return "R"; }
                case Key.S: { return "S"; }
                case Key.T: { return "T"; }
                case Key.U: { return "U"; }
                case Key.V: { return "V"; }
                case Key.W: { return "W"; }
                case Key.X: { return "X"; }
                case Key.Y: { return "Y"; }
                case Key.Z: { return "Z"; }

                case Key.D0: case Key.NumPad0: { return "0"; }
                case Key.D1: case Key.NumPad1: { return "1"; }
                case Key.D2: case Key.NumPad2: { return "2"; }
                case Key.D3: case Key.NumPad3: { return "3"; }
                case Key.D4: case Key.NumPad4: { return "4"; }
                case Key.D5: case Key.NumPad5: { return "5"; }
                case Key.D6: case Key.NumPad6: { return "6"; }
                case Key.D7: case Key.NumPad7: { return "7"; }
                case Key.D8: case Key.NumPad8: { return "8"; }
                case Key.D9: case Key.NumPad9: { return "9"; }

                default: { return ""; }
            }
        }


    }
}