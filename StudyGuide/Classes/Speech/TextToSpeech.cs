
using System.Speech.Synthesis;
namespace StudyGuide.Classes.Speech
{
    public class TextToSpeech
    {
        #region fields
        #endregion fields

        #region properties
        #endregion properties

        #region constructors

        public TextToSpeech()
        {

        }

        #endregion constructors

        #region public methods

        private static void Rap()
        {

            SpeechSynthesizer SS = new SpeechSynthesizer();
            SS.Volume = 100;

            SS.Speak("Back up in your ass with the resurrection");
            SS.Speak("It's the group harder than an erection");
            SS.Speak("That shows no affection");
            SS.Speak("They wanna ban us on Capitol Hill");
            SS.Speak("Cause it's Die muthafuckas, die muthafuckas! still");

            SS.Speak("All along it was the Geto, nothing but the Geto");
            SS.Speak("Taking short steps one foot at a time and keep my head low");
            SS.Speak("And never let go");
            SS.Speak("Cause if I let go");
            SS.Speak("Then I'll be spineless");
            SS.Speak("I'm going insane!");

            SS.Speak("I think my mind just goes outta control");
            SS.Speak("And judge your subjects muthafuckas read about");
            SS.Speak("I touch on the shit that they be leavin' out");
            SS.Speak("I seen this muthafucka's 9 smokin");
            SS.Speak("I seen the same nigga with the 9 die with his eyes open");
            SS.Speak("And simply what this means is");
            SS.Speak("He didn't know that every dog had his day");
            SS.Speak("Until he seen his");
            SS.Speak("I bet you muthafuckas will too");
            SS.Speak("Because its Die muthafucka, die muthafucka! still, fool");


            SS.Speak("Die muthafuckas, die muthafuckas! still fool");
            SS.Speak("Die muthafuckas, die muthafuckas! still");
            SS.Speak("Die muthafuckas, die muthafuckas! still fool");
            SS.Speak("Die muthafuckas, die muthafuckas! still");
            SS.Speak("Die muthafuckas, die muthafuckas! still fool");
            SS.Speak("Die muthafuckas, die muthafuckas! still");
        }
        #endregion public methods

        #region private methods
        #endregion private methods




    }// close class
}// close namespace
