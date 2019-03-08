using System.Speech.Synthesis;

namespace Dojon.Utils
{
    public class Speech
    {
        private SpeechSynthesizer speechSynthesizer;

        public Speech()
        {
            speechSynthesizer = new SpeechSynthesizer();
            var voices = speechSynthesizer.GetInstalledVoices();
            speechSynthesizer.SelectVoice(voices[0].VoiceInfo.Name);
        }
        public void Say(string words)
        {
            speechSynthesizer.Speak(words);
        }
    }
}
