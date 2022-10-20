using DevExpress.XtraEditors;
using PeekPoker.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Be.Windows.Forms;
using JRPC_Client;
using XDevkit;
using System.Text.RegularExpressions;
using System.IO;

namespace DMONET
{
    // could be wrong, but Thanks to 360Haven for the original PeekNPoke Source Code! <3
    public partial class PeekNPoke : DevExpress.XtraEditors.XtraForm
    {
        private readonly AutoCompleteStringCollection _data = new AutoCompleteStringCollection();
        private byte[] _old;
        JRPC JRPC = new JRPC();

        private RealTimeMemory _rtm; //DLL is now in the Important File Folder
        public PeekNPoke()
        {
            InitializeComponent();
            ChangeNumericMaxMin();
        }





        private void PeekNPoke_Load(object sender, EventArgs e)
        {
            JRPC.Connect();
            ipAddressTextBox.Text = JRPC.XboxIP();
        }




        private void FixTheAddresses(object sender, EventArgs e)
        {
            var Sender = sender as TextBox;
            {
                if (Sender != null)
                    try
                    {
                        if (Sender.Text == "") //If the users wiped the box we fill it with 4(00), an empty box is bad.
                        {
                            Sender.Text = "00000000";
                            return;
                        }

                        if (Sender == peekPokeAddressTextBox) //Address specific formatting. [32 Bit Address, no "0x"]
                        {
                            string math = Sender.Text.Contains("+") ? "+" : "-";
                            //Checks for addition or subtraction symbol, defaults to subtract which is harmless if its not there.
                            Sender.Text = Sender.Text.ToUpper().StartsWith("0X")
                                              ? (Sender.Text.ToUpper().Substring(2).Trim())
                                              : Sender.Text.ToUpper().Trim();
                            //If has 0x remove it, set to upper and traim spaces.
                            string[] adrsample = Sender.Text.Split(Convert.ToChar(math));
                            //Now we check for addition commands
                            if (adrsample.Length >= 2)
                            {
                                var adrhex = ((uint)new UInt32Converter().ConvertFromString("0x" + adrsample[0]));
                                //Formats address to have 4 bytes and be hex.
                                if (!adrsample[1].Contains("0x"))
                                    adrsample[1] = ("0x" + adrsample[1]); //Preps for conversion.
                                var adrhex2 = ((uint)new UInt32Converter().ConvertFromString(adrsample[1]));
                                //Formats address to have 4 bytes and be hex.
                                Sender.Text = math == "+"
                                                  ? (adrhex + adrhex2).ToString("X8")
                                                  : (adrhex - adrhex2).ToString("X8");
                            }

                            if (!Functions.IsHex(Sender.Text))
                            //Last check to see if its usable, if not the users an idiot.
                            {
                                while (Sender.Text.Length < 8) //pad out the address
                                {
                                    Sender.Text = ("0" + Sender.Text);
                                }
                                //Sender.Text = (Sender.Text.ToString("X8"));
                                //ShowMessageBox("Input must be hex.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            return; //End of Addressbox Specific code
                        }
                        if (!Functions.IsHex(Sender.Text))
                        {
                            Sender.Text = Sender.Text.ToUpper().StartsWith("0X")
                                              ? (Sender.Text.ToUpper().Substring(2))
                                              : ((uint)new UInt32Converter().ConvertFromString(Sender.Text)).ToString(
                                                  "X");
                        }
                    }
                    catch (Exception)
                    {

                    }
            }
        }

        private void Connect(object a)
        {
            if (ipAddressTextBox.Text.ToUpper() == "DEBUG") //For debugging PP without a connection to xbox
            {
                return; //Bypass needing to connect to xbox for debugging purposes.
            }
            try
            {
                if (!Regex.IsMatch(ipAddressTextBox.Text, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b"))
                //Checks if valid IP
                {
                    MessageBox.Show(" IP Address is not valid!");
                    return;
                }

                _rtm = new RealTimeMemory(ipAddressTextBox.Text, 0, 0); //initialize real time memory


                if (!_rtm.Connect())
                {
                    throw new Exception("Connection Failed!");
                }
                JRPC.XNotify("Connected to PeekNPoker");
            }
            catch (Exception)
            {

            }
        }

        private void ChangeNumericMaxMin()
        {
            if (isSigned.Checked)
            {
                NumericInt8.Maximum = SByte.MaxValue;
                NumericInt8.Minimum = SByte.MinValue;
                NumericInt16.Maximum = Int16.MaxValue;
                NumericInt16.Minimum = Int16.MinValue;
                NumericInt32.Maximum = Int32.MaxValue;
                NumericInt32.Minimum = Int32.MinValue;
            }
            else
            {
                NumericInt8.Maximum = Byte.MaxValue;
                NumericInt8.Minimum = Byte.MinValue;
                NumericInt16.Maximum = UInt16.MaxValue;
                NumericInt16.Minimum = UInt16.MinValue;
                NumericInt32.Maximum = UInt32.MaxValue;
                NumericInt32.Minimum = UInt32.MinValue;
            }
        }
        private void AutoComplete()
        {
            peekPokeAddressTextBox.AutoCompleteCustomSource = _data; //put the auto complete data into the textbox
            int count = _data.Count;
            for (int index = 0; index < count; index++)
            {
                string value = _data[index];
                //if the text in peek or poke text box is not in autocomplete data - Add it
                if (!ReferenceEquals(value, peekPokeAddressTextBox.Text))
                    _data.Add(peekPokeAddressTextBox.Text);
            }
        }

        private void SetHexBoxByteProvider(DynamicByteProvider value)
        {
            if (hexBox.InvokeRequired)
                Invoke((MethodInvoker)(() => SetHexBoxByteProvider(value)));
            else
            {
                hexBox.ByteProvider = value;
            }
        }

        private void SetHexBoxRefresh()
        {
            if (hexBox.InvokeRequired)
                Invoke((MethodInvoker)(SetHexBoxRefresh));
            else
            {
                hexBox.Refresh();
            }
        }
        private string GetTextBoxText(Control control)
        {
            //recursion
            string returnVal = "";
            if (control.InvokeRequired)
                control.Invoke((MethodInvoker)
                               delegate { returnVal = GetTextBoxText(control); });
            else
                return control.Text;
            return returnVal;
        }
        private void Peek()
        {
            try
            {
                if (string.IsNullOrEmpty(GetTextBoxText(peekLengthTextBox)) ||
                    Convert.ToUInt32(GetTextBoxText(peekLengthTextBox), 16) == 0)
                    throw new Exception("Invalid peek length!");
                if (string.IsNullOrEmpty(GetTextBoxText(peekPokeAddressTextBox)) ||
                    Convert.ToUInt32(GetTextBoxText(peekPokeAddressTextBox), 16) == 0)
                    throw new Exception("Address cannot be 0 or null");
                //convert peek result string values to byte

                byte[] retValue =
                    Functions.StringToByteArray(_rtm.Peek(GetTextBoxText(peekPokeAddressTextBox),
                                                          GetTextBoxText(peekLengthTextBox),
                                                          GetTextBoxText(peekPokeAddressTextBox),
                                                          GetTextBoxText(peekLengthTextBox)));
                var buffer = new DynamicByteProvider(retValue) { IsWriteByte = true }; //object initilizer

                _old = new byte[buffer.Bytes.Count];
                buffer.Bytes.CopyTo(_old);

                SetHexBoxByteProvider(buffer);
                SetHexBoxRefresh();

                MessageBox.Show("Peak Success");
            }
            catch (Exception)
            {


            }
        }
        private DynamicByteProvider GetHexBoxByteProvider()
        {
            //recursion
            var returnVal = new DynamicByteProvider(new byte[] { 0, 0, 0, 0 });
            if (hexBox.InvokeRequired)
                hexBox.Invoke((MethodInvoker)
                              delegate { returnVal = GetHexBoxByteProvider(); });
            else
                return (DynamicByteProvider)hexBox.ByteProvider;
            return returnVal;
        }
        private void Poke()
        {
            try
            {
                uint dumplength = (uint)hexBox.ByteProvider.Length / 2;
                _rtm.DumpOffset = Functions.Convert(GetTextBoxText(peekPokeAddressTextBox)); //Set the dump offset
                _rtm.DumpLength = dumplength; //The length of data to dump

                DynamicByteProvider buffer = GetHexBoxByteProvider();
                if (fillCheckBox.Checked)
                {
                    for (int i = 0; i < dumplength; i++)
                    {
                        uint value = Convert.ToUInt32(peekPokeAddressTextBox.Text, 16);
                        string address = string.Format((value + i).ToString("X8"));
                        _rtm.Poke(address, String.Format("{0,0:X2}", Convert.ToByte(fillValueTextBox.Text, 16)));
                        
                    }
                    MessageBox.Show("Poke Success");
                }
                else
                {
                    for (int i = 0; i < buffer.Bytes.Count; i++)
                    {
                        if (buffer.Bytes[i] == _old[i]) continue;

                        uint value = Convert.ToUInt32(peekPokeAddressTextBox.Text, 16);
                        string address = string.Format((value + i).ToString("X8"));
                        _rtm.Poke(address, String.Format("{0,0:X2}", buffer.Bytes[i]));
                        peekPokeFeedBackTextBox.Text = "Poke Success";
                    }
                }

            }
            catch (Exception)
            {

            }
        }


        private void peekButton_Click(object sender, EventArgs e)
        {
            AutoComplete(); //run function
            Peek();
        }

        private void pokeButton_Click(object sender, EventArgs e)
        {
            AutoComplete(); //run function
            Poke();
        }

        private void ChangeNumericValue()
        {
            if (hexBox.ByteProvider == null) return;
            List<byte> buffer = hexBox.ByteProvider.Bytes;
            if (isSigned.Checked)
            {
                NumericInt8.Value = (buffer.Count - hexBox.SelectionStart) > 0
                                        ? Functions.ByteToSByte(hexBox.ByteProvider.ReadByte(hexBox.SelectionStart))
                                        : 0;
                NumericInt16.Value = (buffer.Count - hexBox.SelectionStart) > 1
                                         ? Functions.BytesToInt16(
                                             buffer.GetRange((int)hexBox.SelectionStart, 2).ToArray())
                                         : 0;
                NumericInt32.Value = (buffer.Count - hexBox.SelectionStart) > 3
                                         ? Functions.BytesToInt32(
                                             buffer.GetRange((int)hexBox.SelectionStart, 4).ToArray())
                                         : 0;

                NumericFloatTextBox.Clear();
                float f = (buffer.Count - hexBox.SelectionStart) > 3
                              ? Functions.BytesToSingle(buffer.GetRange((int)hexBox.SelectionStart, 4).ToArray())
                              : 0;
                NumericFloatTextBox.Text = f.ToString();
            }
            else
            {
                NumericInt8.Value = (buffer.Count - hexBox.SelectionStart) > 0
                                        ? buffer[(int)hexBox.SelectionStart]
                                        : 0;
                NumericInt16.Value = (buffer.Count - hexBox.SelectionStart) > 1
                                         ? Functions.BytesToUInt16(
                                             buffer.GetRange((int)hexBox.SelectionStart, 2).ToArray())
                                         : 0;
                NumericInt32.Value = (buffer.Count - hexBox.SelectionStart) > 3
                                         ? Functions.BytesToUInt32(
                                             buffer.GetRange((int)hexBox.SelectionStart, 4).ToArray())
                                         : 0;

                NumericFloatTextBox.Clear();
                float f = (buffer.Count - hexBox.SelectionStart) > 3
                              ? Functions.BytesToSingle(buffer.GetRange((int)hexBox.SelectionStart, 4).ToArray())
                              : 0;
                NumericFloatTextBox.Text = f.ToString();
            }
            byte[] prev = Functions.HexToBytes(peekPokeAddressTextBox.Text);
            int address = Functions.BytesToInt32(prev);
            SelAddress.Text = string.Format((address + (int)hexBox.SelectionStart).ToString("X8"));
        }
        private void ChangedNumericValue(object numfield)
        {
            if (hexBox.SelectionStart >= hexBox.ByteProvider.Bytes.Count) return;
            if (numfield.GetType() == typeof(NumericUpDown))
            {
                var numeric = (NumericUpDown)numfield;
                switch (numeric.Name)
                {
                    case "NumericInt8":
                        if (isSigned.Checked)
                        {
                            Console.WriteLine(((sbyte)numeric.Value).ToString("X2"));
                            hexBox.ByteProvider.WriteByte(hexBox.SelectionStart,
                                                          Functions.HexToBytes(((sbyte)numeric.Value).ToString("X2"))[0
                                                              ]);
                        }
                        else
                        {
                            hexBox.ByteProvider.WriteByte(hexBox.SelectionStart,
                                                          Convert.ToByte((byte)numeric.Value));
                        }
                        break;

                    case "NumericInt16":
                        for (int i = 0; i < 2; i++)
                        {
                            hexBox.ByteProvider.WriteByte(hexBox.SelectionStart + i, isSigned.Checked
                                                                                         ? Functions.Int16ToBytes(
                                                                                             (short)numeric.Value)[i]
                                                                                         : Functions.UInt16ToBytes(
                                                                                             (ushort)numeric.Value)[i]);
                        }
                        break;

                    case "NumericInt32":
                        for (int i = 0; i < 4; i++)
                        {
                            hexBox.ByteProvider.WriteByte(hexBox.SelectionStart + i, isSigned.Checked
                                                                                         ? Functions.Int32ToBytes(
                                                                                             (int)numeric.Value)[i]
                                                                                         : Functions.UInt32ToBytes(
                                                                                             (uint)numeric.Value)[i]);
                        }
                        break;
                }
            }
            else
            {
                var textbox = (TextBox)numfield;
                for (int i = 0; i < 4; i++)
                {
                    hexBox.ByteProvider.WriteByte(hexBox.SelectionStart + i,
                                                  Functions.FloatToByteArray(Convert.ToSingle(textbox.Text))[i]);
                }
            }
            hexBox.Refresh();
        }

        private void IsSignedCheckedChanged(object sender, EventArgs e)
        {
            ChangeNumericMaxMin();
            ChangeNumericValue();
        }

        private void NumericIntKeyPress(object sender, KeyPressEventArgs e)
        {
            if (hexBox.ByteProvider != null)
            {
                ChangedNumericValue(sender);
            }
        }

        private void NumericValueChanged(object sender, EventArgs e)
        {
            if (hexBox.ByteProvider != null)
            {
                ChangedNumericValue(sender);
            }
        }

        private void NewPeek()
        {
            //Clean up
            peekPokeAddressTextBox.Text = "C0000000";
            peekLengthTextBox.Text = "FF";
            SelAddress.Clear();
            peekPokeFeedBackTextBox.Clear();
            NumericInt8.Value = 0;
            NumericInt16.Value = 0;
            NumericInt32.Value = 0;
            NumericFloatTextBox.Text = "0";
            hexBox.ByteProvider = null;
            hexBox.Refresh();
        }
        private void newPeekButton_Click(object sender, EventArgs e)
        {
            NewPeek();
        }

        private void freezeButton_Click(object sender, EventArgs e)
        {
            try
            {
                _rtm.StopCommand();
                unfreezeButton.Enabled = true;
                freezeButton.Enabled = false;
            }
            catch (Exception)
            {
                unfreezeButton.Enabled = false;
                freezeButton.Enabled = true;
            }
        }

        private void unfreezeButton_Click(object sender, EventArgs e)
        {
            try
            {
                _rtm.StartCommand();
                unfreezeButton.Enabled = false;
                freezeButton.Enabled = true;
            }
            catch (Exception)
            {
                unfreezeButton.Enabled = true;
                freezeButton.Enabled = false;
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(Connect);
        }

        private void hexBox_SelectionStartChanged(object sender, EventArgs e)
        {
            ChangeNumericValue(); //When you select an offset on the hexbox

            if (hexBox.ByteProvider == null) return;
            byte[] prev = Functions.HexToBytes(peekPokeAddressTextBox.Text);
            int address = Functions.BytesToInt32(prev);
            SelAddress.Text = string.Format((address + (int)hexBox.SelectionStart).ToString("X8"));
        }

        private void hexBox_MouseUp(object sender, MouseEventArgs e)
        {
            ChangeNumericValue(); //When you select an offset on the hexbox

            if (hexBox.ByteProvider == null) return;
            byte[] prev = Functions.HexToBytes(peekPokeAddressTextBox.Text);
            int address = Functions.BytesToInt32(prev);
            SelAddress.Text = string.Format((address + (int)hexBox.SelectionStart).ToString("X8"));
        }

        private void hexBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                hexBox.CopyHex();
                e.SuppressKeyPress = true;
            }
        }
    }
}