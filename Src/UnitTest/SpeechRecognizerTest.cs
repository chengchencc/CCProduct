using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    public class SpeechRecognizerTest
    {
        [Fact]
        public void test()
        {
            // Create a new SpeechRecognitionEngine instance.
            SpeechRecognizer recognizer = new SpeechRecognizer();

            // Create a simple grammar that recognizes "red", "green", or "blue".
            Choices colors = new Choices();
            colors.Add(new string[] { "red", "green", "blue" });

            // Create a GrammarBuilder object and append the Choices object.
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(colors);

            // Create the Grammar instance and load it into the speech recognition engine.
            Grammar g = new Grammar(gb);
            recognizer.LoadGrammar(g);

            // Register a handler for the SpeechRecognized event.
            recognizer.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
        }

        // Create a simple handler for the SpeechRecognized event.
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var result = "Speech recognized: " + e.Result.Text;
            //MessageBox.Show("Speech recognized: " + e.Result.Text);
        }
    }

    class Program
    {
        // Indicate whether asynchronous recognition has finished.
        static bool completed;
        [Fact]
        public  void MainTest()
        {
            using (SpeechRecognitionEngine recognizer =
              new SpeechRecognitionEngine())
            {
                
                // Create and load the exit grammar.
                Grammar exitGrammar = new Grammar(new GrammarBuilder("B"));
                exitGrammar.Name = "Exit Grammar";
                recognizer.LoadGrammar(exitGrammar);

                // Create and load the dictation grammar.
                Grammar dictation = new DictationGrammar();
                dictation.Name = "Dictation Grammar";
                recognizer.LoadGrammar(dictation);

                // Attach event handlers to the recognizer.
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(
                    SpeechRecognizedHandler);
                recognizer.RecognizeCompleted +=
                  new EventHandler<RecognizeCompletedEventArgs>(
                    RecognizeCompletedHandler);

                // Assign input to the recognizer.
                recognizer.SetInputToDefaultAudioDevice();

                // Begin asynchronous recognition.
                Console.WriteLine("Starting recognition...");
                completed = false;
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                // Wait for recognition to finish.
                while (!completed)
                {
                    Thread.Sleep(333);
                }
                Console.WriteLine("Done.");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void SpeechRecognizedHandler(
          object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("  Speech recognized:");
            string grammarName = "<not available>";
            if (e.Result.Grammar.Name != null &&
              !e.Result.Grammar.Name.Equals(string.Empty))
            {
                grammarName = e.Result.Grammar.Name;
            }
            Console.WriteLine("    {0,-17} - {1}",
              grammarName, e.Result.Text);

            if (grammarName.Equals("Exit Grammar"))
            {
                ((SpeechRecognitionEngine)sender).RecognizeAsyncCancel();
            }
        }

        static void RecognizeCompletedHandler(
          object sender, RecognizeCompletedEventArgs e)
        {
            Console.WriteLine("  Recognition completed.");
            completed = true;
        }
    }
}
