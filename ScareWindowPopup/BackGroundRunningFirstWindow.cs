using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace ScareWindowPopup
{
    public partial class BackGroundRunningFirstWindow : Form
    {
        //define global variables/objects
        Functionality myFunctions;

        //create delegate, is for communicating with the form
        public delegate void myDelegate();
        public myDelegate MoiD;

        public BackGroundRunningFirstWindow()
        {
            InitializeComponent();

            //do not show this in taskbar
            this.ShowInTaskbar = false;

            //set the initial form state to minimized
            this.WindowState = FormWindowState.Minimized;

            //hide, visible set false of form upon construction
            this.Hide();

            //set visible to false
            this.Visible = false;

            //run methods from other classes (find a use for delegates in here)
            //test this here
            //DateTime mytime = new DateTime();
            //MessageBox.Show(mytime.ToString());
            //mytime = mytime.AddHours(5.0);
            //MessageBox.Show(mytime.ToString());

            //defin functionality at some point DON'T FORGET TO DO THIS
            myFunctions = new Functionality(this);

            //bind delegat, invoke
            MoiD.Invoke(); /*same as myShowForm()*/



            //fix this stuff later

            //Note I can't relly just copy it to the startup folder becasue then it would start after taht but it would just get another random amount of days. It would have to save its status

            //testing to place file on desktop
            //string deployPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //File.Copy(@"Adobe_CEF_Helper.Properties.Resources.NunMain", deployPath);

            //File.WriteAllBytes(@"somePathHere", Adobe_CEF_Helper.Properties.Resources.NunMain);
        }

    }
}
