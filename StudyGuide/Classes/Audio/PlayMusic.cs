
using System;
using System.Media;
namespace StudyGuide.Classes.Audio
{
    public class PlayMusic
    {
        #region fields
        #endregion fields

        #region properties
        #endregion properties

        #region constructors
        #endregion constructors

        #region public methods

        public void PlaySong(string filePath)
        {
            try
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = "C:\\Users\\Owner\\Documents\\Visual Studio 2013\\Projects\\StudyGuide\\StudyGuide\\Media\\Music\\GetoBoys-Still instrumental.wav";
                player.Play();
            }
            catch (Exception ex)
            {

            }

        }
        #endregion public methods

        #region private methods
        #endregion private methods

    }//close class
}// close namespace
