using DotNetPlcInterface;
using PNLBaseInterface;
using S7NPInterface;
using Sharp7Interface;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace PlcNetLibraries
{
    public partial class Form1 : Form
    {
        private IPlcNetLibrariesBaseInterface _currentInterface;

        public Form1()
        {
            InitializeComponent();

            libraryBindingSource.Add(new Library(0, "s7netplus"));
            libraryBindingSource.Add(new Library(1, "sharp7"));
            libraryBindingSource.Add(new Library(2, "DotNetSiemensPLCToolBoxLibrary"));
        }

        private void bConnect_Click(object sender, EventArgs e)
        {
            if (!tIpAddress.Text.IsStringIpAddress() || !tRack.Text.IsStringInteger() || !tSlot.Text.IsStringInteger())
            {
                MessageBox.Show("Connection parameters in wrong format(s) !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Library selectedLibrary = (Library)cLibrarySelect.SelectedItem;

            if (selectedLibrary == null)
            {
                MessageBox.Show("Choose library first !", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (selectedLibrary.Id)
            {
                case 0:
                    _currentInterface = new PlcNetS7NetPlusInterface(tIpAddress.Text, Convert.ToInt32(tRack.Text), Convert.ToInt32(tSlot.Text));
                    break;
                case 1:
                    _currentInterface = new PlcNetSharp7Interface(tIpAddress.Text, Convert.ToInt32(tRack.Text), Convert.ToInt32(tSlot.Text));
                    break;
                case 2:
                    _currentInterface = new DotNetPlcSiemensInterface(tIpAddress.Text, Convert.ToInt32(tRack.Text), Convert.ToInt32(tSlot.Text));
                    break;
                default:
                    break;
            }

            if (_currentInterface == null) return;

            _currentInterface.ConnectedHandler += _currentInterface_ConnectedHandler;
            _currentInterface.DisconnectedHandler += _currentInterface_DisconnectedHandler;
            _currentInterface.ErrorHandler += _currentInterface_ErrorHandler;
            _currentInterface.DataReadHandler += _currentInterface_DataReadHandler;

            _currentInterface.Connect();
        }

        private void _currentInterface_DataReadHandler(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                tCurrentValue.Text = _currentInterface.GetLastReadedValue().ToString();
            }));
        }

        private void _currentInterface_ErrorHandler(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                var lastError = _currentInterface.PlcLastErrorMessage;

                MessageBox.Show(lastError, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }));
        }

        private void _currentInterface_DisconnectedHandler(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                lCState.BackColor = Color.Red;
                lCState.Text = "NOT CONNECTED";

            }));
        }

        private void _currentInterface_ConnectedHandler(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                lCState.BackColor = Color.LawnGreen;
                lCState.Text = "CONNECTED";

            }));
        }

        private void bSet_Click(object sender, EventArgs e)
        {
            if (!tSetPoint.Text.IsStringInteger())
            {
                MessageBox.Show("Invalid value", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _currentInterface?.SetSetPoint(Convert.ToInt32(tSetPoint.Text));
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            _currentInterface?.SetStart();
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            _currentInterface?.SetStop();
        }

        private void bDisconnect_Click(object sender, EventArgs e)
        {
            _currentInterface?.Disconnect();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _currentInterface?.Disconnect();
        }

        private void tRack_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateTextBoxForInteger(tRack);
        }

        private void tSlot_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateTextBoxForInteger(tSlot);
        }

        private void tSetPoint_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateTextBoxForInteger(tSetPoint);
        }

        private void ValidateTextBoxForInteger(TextBox source)
        {
            if (source.Text.IsStringInteger())
            {
                errorProvider1.SetError(source, "");
            }
            else
            {
                errorProvider1.SetError(source, "Not an IP Address.");
            }
        }

        private void ValidateTextBoxForIpAddress(TextBox source)
        {
            if (source.Text.IsStringIpAddress())
            {
                errorProvider1.SetError(source, "");
            }
            else
            {
                errorProvider1.SetError(source, "Not an IP Address.");
            }
        }

        private void tIpAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateTextBoxForIpAddress(tIpAddress);
        }



    }
}
