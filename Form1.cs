using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrowserPrivateModeSwitcher.Properties;
using Microsoft.Win32;

namespace BrowserPrivateModeSwitcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();

            keyInput inputWin = new keyInput();
            if (Settings.Default.settingKey == 0)
            {
                inputWin.SetText(0);
            }
            if (inputWin.ShowDialog() == DialogResult.OK)
            {
                if (inputWin.GetText() == Settings.Default.settingKey)
                {
                    this.MainInitialize();
                }
                else
                {
                    this.Close();
                    return;
                }
            }
            else
            {
                this.Close();
                return;
            }
        }

        private void MainInitialize()
        {
            RegistryKey regIE = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Internet Explorer\Privacy");
            RegistryKey regEdge = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\MicrosoftEdge\Main");
            RegistryKey regChrome = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Google\Chrome");
            switch (regIE.GetValue("EnableInPrivateBrowsing", 0x1))
            {
                case 0x0:
                    {
                        this.comboBox2.SelectedIndex = 1;
                    }
                    break;
                default:
                    {
                        this.comboBox2.SelectedIndex = 0;
                    }
                    break;
            }
            switch (regEdge.GetValue("AllowInPrivate", 0x1))
            {
                case 0x0:
                    {
                        this.comboBox3.SelectedIndex = 1;
                    }
                    break;
                default:
                    {
                        this.comboBox3.SelectedIndex = 0;
                    }
                    break;
            }
            switch (regChrome.GetValue("IncognitoModeAvailability", 0x0))
            {
                case 0x1:
                    {
                        this.comboBox4.SelectedIndex = 1;
                    }
                    break;
                default:
                    {
                        this.comboBox4.SelectedIndex = 0;
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistryKey regIE = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Internet Explorer\Privacy");
            RegistryKey regEdge = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\MicrosoftEdge\Main");
            RegistryKey regChrome = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Google\Chrome");
            switch (this.comboBox2.SelectedIndex)
            {
                //許可
                case 0:
                    {
                        regIE.SetValue("EnableInPrivateBrowsing", 0x1);
                    }
                    break;
                //不許可
                case 1:
                    {
                        regIE.SetValue("EnableInPrivateBrowsing", 0x0);
                    }
                    break;
            }
            switch (this.comboBox3.SelectedIndex)
            {
                case 0:
                    {
                        regEdge.SetValue("AllowInPrivate", 0x1);
                    }
                    break;
                case 1:
                    {
                        regEdge.SetValue("AllowInPrivate", 0x0);
                    }
                    break;
            }
            switch (this.comboBox4.SelectedIndex)
            {
                case 0:
                    {
                        regChrome.SetValue("IncognitoModeAvailability", 0x0);
                    }
                    break;
                case 1:
                    {
                        regChrome.SetValue("IncognitoModeAvailability", 0x1);
                    }
                    break;
            }

            if (this.maskedTextBox1.Text != "")
            {
                Settings.Default.settingKey = int.Parse(this.maskedTextBox1.Text);
                Settings.Default.Save();
            }

            MessageBox.Show("Settings were saved.");
            this.Close();
        }
    }
}
