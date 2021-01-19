using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FirstUWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // properties of the MainPage Class
        // media element control is a control that is capable of playing back audio
        // or video
        readonly MediaElement mediaElement = new MediaElement();

        // create a speech synthesizer object and a stream 
        readonly SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        SpeechSynthesisStream speechSynthesisStream;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void PressMeButton_Click(object sender, RoutedEventArgs e)
        {
            //var messageDialog = new MessageDialog("This is a message!");
            //await messageDialog.ShowAsync();
            // create the stream from the string
            speechSynthesisStream = await speechSynthesizer.SynthesizeTextToStreamAsync(Input.Text);
            // play the synthesized data stream with the Media Element
            mediaElement.SetSource(speechSynthesisStream, speechSynthesisStream.ContentType);
            mediaElement.Play();
        }

        private void Input_GotFocus(object sender, RoutedEventArgs e)
        {
            // everytime this control gets focus the text will erase
            Input.Text = String.Empty;
        }
    }
}
