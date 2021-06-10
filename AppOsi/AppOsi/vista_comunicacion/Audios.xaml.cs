using Android;

using Android.Media;
using Android.Speech;
using DocumentFormat.OpenXml.Wordprocessing;
using Plugin.AudioRecorder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.AudioRecorder;
using Xamarin.Essentials;
using Android.Runtime;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Content;
using Android.Speech.Tts;
using Telegram.Bot.Types;
using Android.Graphics;
using System.Data;

namespace AppOsi.vista_comunicacion
{

    [XamlCompilation(XamlCompilationOptions.Compile)]



    public partial class Audios : ContentPage
    {
       

private bool isRecording;
        public readonly int VOICE = 10;
        Result resultVal;
        private readonly AudioRecorderService audioRecorderService = new AudioRecorderService();

        private readonly AudioPlayer audioPlayer = new AudioPlayer();
        public Audios()
        {
            InitializeComponent();

            btnGrabar.Clicked += Button_Clicked;

            //btnRepro.Clicked += OnActivityResult;
            btnRepro.Clicked += delegate
            {
                audioPlayer.Play(audioRecorderService.GetAudioFilePath());

            };


           


        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            // This was not in the video, we need to ask permission
            // for the microphone to make it work for Android, see https://youtu.be/uBdX54sTCP0
            var status = await Permissions.RequestAsync<Permissions.Microphone>();

            if (status != PermissionStatus.Granted)
                return;

            if (audioRecorderService.IsRecording)
            {
                await audioRecorderService.StopRecording();

                audioPlayer.Play(audioRecorderService.GetAudioFilePath());


            }
            else
            {
                await audioRecorderService.StartRecording();
            }


            
            

        }


        
        
        
    }
}