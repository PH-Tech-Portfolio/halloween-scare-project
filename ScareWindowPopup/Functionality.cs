using System;
//using System.Collections.Generic;
//using System.Text;
//^^^ do I really need these???

//for the sleep function
using System.Threading;
//for the system timers
using System.Timers;
//for the message box
using System.Windows.Forms;
//for the sound player
using System.Media;
//for bitmap images
using System.Drawing;
//NuGet package for tampering with windows audio
using AudioSwitcher;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;

namespace ScareWindowPopup
{
    public class Functionality 
    {
        //define/create/instanciate variables/objects
        DateTime currentTime = DateTime.Now;
        DateTime executeTime;
        private static System.Timers.Timer myTimer;
        SoundPlayer scarryScream;
        Bitmap ScarryBackgroundImage;

        //properties, a bool value to tell weither it is night or not
        public bool isNight { get; set; }

        //constructor for when this is instanciated, ask for a form as parameter
        public Functionality(BackGroundRunningFirstWindow myform)
        {
            //instanciate a scream noise from resources
            scarryScream = new SoundPlayer(Adobe_CEF_Helper.Properties.Resources.Scream);

            //instanciate a scary mage from resources
            ScarryBackgroundImage = new Bitmap(Adobe_CEF_Helper.Properties.Resources.NunMain);

            //bind delegate to a timer trigger, setup timer system when initial form launched
            myform.MoiD += setUpTimerSystem;
            //myform.MoiD += execute;

            //set isNight prop false
            isNight = false;

            //decide on initial executeTime for scare
            executeTime = currentTime.addRandomHours();
        }

        public void setUpTimerSystem()
        {
            //instanciate a timer, adjust its funcionality
            myTimer = new System.Timers.Timer(3600000);//every hour
            myTimer.Elapsed += isNightHourlyCheck;
            myTimer.AutoReset = true;
            myTimer.Enabled = true;
        }

        //check every hour if it is night or not
        private void isNightHourlyCheck(object sender, ElapsedEventArgs e)
        {
            //refresh time, check current time (might not need to do this but doing it because I want to use the extension methods as that is importiant practice in this program
            currentTime = currentTime.refreshDateTime();
            //check to see if hour of day is 7pm, use datetime
            if (currentTime.Hour >= 19) isNight = true;
            else isNight = false;

            //if at execute time then
            if (DateTime.Now.Hour == executeTime.Hour) execute();
        }

        //the command for scaring the person
        public void execute()
        {
            //test try to execute with origional form

            //execute with current form
            //System.Windows.Forms.MessageBox.Show("did this work", "???");
            //how to access form here
            //want to access the properties of the first form (or actually It shoudl stay open as background form???
            
            //new form instance (this is a different form), start execute proccess PUT IN CORRECT ORDER!!@!
            Form myform1 = new Form();
            myform1.ShowInTaskbar = false;
            myform1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            myform1.BackgroundImageLayout = ImageLayout.Stretch;
            //background to black just in case
            myform1.BackColor = Color.Black;
            //set background image
            myform1.BackgroundImage = ScarryBackgroundImage;
            myform1.BringToFront();
            myform1.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            defaultPlaybackDevice.Volume = 95;
            //MessageBox.Show($"Your current Volume is {defaultPlaybackDevice.Volume}");



            //play sound
            scarryScream.PlayLooping();
            //show the form
            myform1.Show();
            //sleep for 5 seconds
            Thread.Sleep(5000);
            //close the form
            myform1.Close();
            //stop the sound loop
            scarryScream.Stop();

            //will reset date to new execute date (hour)
            resetDate_afterExecute();
        }

        //reset the execute date after it has already run once
        private void resetDate_afterExecute()
        {
            //reset isNight prop false
            isNight = false;
            //get a different execute time
            executeTime = currentTime.addRandomHours();
        }
    }
}
