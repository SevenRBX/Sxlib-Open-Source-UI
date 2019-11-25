using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sxlib;
using sxlib.Specialized;

namespace Side_SynX
{
    public partial class Form1 : Form
    {
        public static string ThisDirectory = Directory.GetCurrentDirectory(); // Gets the directory of the form

        public bool Attached;

        public bool Loaded;

        public Form1()
        {
            InitializeComponent();


            Stuff.Lib = SxLib.InitializeWinForms(this, ThisDirectory); //Initialize the form and sxlib
            Stuff.Lib.LoadEvent += this.SxLoadEvent;
            Stuff.Lib.Load(); //load sxlib
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void SxLoadEvent(SxLibBase.SynLoadEvents Event, object whatever)
        {
            //This tells you the loading of synapse
            switch (Event)
            {
                case SxLibBase.SynLoadEvents.CHECKING_WL:
                    label1.Text = "Checking Whitelist...";
                    break;
                case SxLibBase.SynLoadEvents.CHANGING_WL:
                case SxLibBase.SynLoadEvents.DOWNLOADING_DLLS:
                    break;
                case SxLibBase.SynLoadEvents.DOWNLOADING_DATA:
                    label1.Text = "Downloading Data...";
                    return;
                case SxLibBase.SynLoadEvents.CHECKING_DATA:
                    label1.Text = "Checking Data...";
                    return;
                case SxLibBase.SynLoadEvents.READY:
                    label1.Text = "Ready to Attach!";
                    this.Loaded = true;
                    return;
                default:
                    return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stuff.Lib.Attach();
            Stuff.Lib.AttachEvent += this.SxAttachEv;
        }

        private void SxAttachEv(SxLibBase.SynAttachEvents Event, object whatever)
        {
            // This is basically the switch that'll make the label change according to the status of Synapse is in while injecting.
            switch (Event)
            {
                case SxLibBase.SynAttachEvents.CHECKING:
                    label1.Text = "Checking...";
                    return;
                case SxLibBase.SynAttachEvents.INJECTING:
                    label1.Text = "Injecting...";
                    return;
                case SxLibBase.SynAttachEvents.CHECKING_WHITELIST:
                    label1.Text = "Checking Whitelist...";
                    return;
                case SxLibBase.SynAttachEvents.SCANNING:
                    label1.Text = "Scanning...";
                    return;
                case SxLibBase.SynAttachEvents.READY:
                    label1.Text = "Ready!";
                    this.Attached = true;
                    return;
                case SxLibBase.SynAttachEvents.FAILED_TO_ATTACH:
                    label1.Text = "Failed to attach";
                    return;
                case SxLibBase.SynAttachEvents.FAILED_TO_FIND:
                    label1.Text = "Failed to find roblox!";
                    return;
                case SxLibBase.SynAttachEvents.NOT_RUNNING_LATEST_VER_UPDATING:
                    label1.Text = "Updating...";
                    return;
                case SxLibBase.SynAttachEvents.NOT_INJECTED:
                    label1.Text = "Not injected!";
                    break;
                case SxLibBase.SynAttachEvents.ALREADY_INJECTED:
                    label1.Text = "Already Injected!";
                    break;
                default:
                    return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stuff.Lib.Execute(richTextBox1.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
