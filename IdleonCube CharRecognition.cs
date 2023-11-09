// Initialize the Tesseract engine
   using Tesseract;
   

        using (var engine = new TesseractEngine(@"path-to-tessdata", "eng", EngineMode.Default))
        {
        using (var image = Pix.LoadFromFile(@"screenCapture")) //kle sm hotu d bi sm screencapture from the other part of code dubu but no worki, commentin da launcha for now
        {
            using (var page = engine.Process(image))
            {
               string recognizedText = page.GetText();

              if (recognizedText.Contains("6"))
              {
                 // Do something when the character is recognized
              }
            }
        }
        }