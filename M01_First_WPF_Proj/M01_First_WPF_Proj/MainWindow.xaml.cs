using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace M01_First_WPF_Proj
{

    public partial class MainWindow : Window
    {
        List<BitmapImage> hairImages = new List<BitmapImage>();
        List<BitmapImage> eyeImages = new List<BitmapImage>();
        List<BitmapImage> noseImages = new List<BitmapImage>();
        List<BitmapImage> mouthImages = new List<BitmapImage>();

        private int hairIndex = -1;
        private int eyeIndex = -1;
        private int noseIndex = -1;
        private int mouthIndex = -1;

        private bool updateHair = false;
        private bool updateEyes = false;
        private bool updateNose = false;
        private bool updateMouth = false;

        Random random = new Random();


        public MainWindow()
        {
            InitializeComponent();
            
            // Call the load method to populate the lists
            LoadCategoryImages("../../images/hair", hairImages);
            LoadCategoryImages("../../images/eyes", eyeImages);
            LoadCategoryImages("../../images/nose", noseImages);
            LoadCategoryImages("../../images/mouth", mouthImages);
        }

        // Method to populate the lists with BM images based on whatever is in the folders.
        private static void LoadCategoryImages(string folderPath, List<BitmapImage> imageList)
        {
            try
            {
                // Populate imageFiles with all of the files with specified file extensions in folder path
                string[] imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly)
                                                .Where(file => file.EndsWith(".png") ||
                                                               file.EndsWith(".jpg"))
                                                .ToArray();
                
                // For each image file, create a bitmap image and add it to the list that was passed
                foreach (string file in imageFiles)
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(file, UriKind.Relative);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    imageList.Add(bitmap);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading images from {folderPath}: {ex.Message}");
            }
        }

        public void MyImageMethod()
        {
            // Create new image objects
            Image imgHair = new Image();
            Image imgEyes = new Image();
            Image imgNose = new Image();
            Image imgMouth = new Image();

            // Draw the hair on the canvas
            if (hairIndex >= 0 && updateHair)
            {
                imgHair.Source = hairImages[hairIndex];
                Canvas.SetLeft(imgHair, 0);
                Canvas.SetTop(imgHair, 0); // Images are 250H so incrementing this by 250 aligns them properly
                myCanvas.Children.Add(imgHair);

                updateHair = false;
            }

            //Draw the eyes on the canvas
            if (eyeIndex >= 0 && updateEyes)
            {
                imgEyes.Source = eyeImages[eyeIndex];
                Canvas.SetLeft(imgEyes, 0);
                Canvas.SetTop(imgEyes, 250);
                myCanvas.Children.Add(imgEyes);

                updateEyes = false;
            }

            // Draw the nose on the canvas
            if (noseIndex >= 0 && updateNose)
            {
                imgNose.Source = noseImages[noseIndex];
                Canvas.SetLeft(imgNose, 0);
                Canvas.SetTop(imgNose, 500);
                myCanvas.Children.Add(imgNose);

                updateNose = false;
            }

            // Draw the mouth on the canvas
            if (mouthIndex >= 0 && updateMouth)
            {
                imgMouth.Source = mouthImages[mouthIndex];
                Canvas.SetLeft(imgMouth, 0);
                Canvas.SetTop(imgMouth, 750);
                myCanvas.Children.Add(imgMouth);

                updateMouth = false;
            }
        }

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            // Get the button that was pressed
            if (sender is Button clickedButton)
            {
                HandleButtonPress(clickedButton);
            }
        }

        // Method to update the respective index based on what button was pressed (should clean up).
        private void HandleButtonPress(Button button)
        {
            switch (button.Name)
            {
                case "hair_next":
                    hairIndex = IncrementChoice(hairIndex, hairImages);
                    updateHair = true;
                    break;
                case "hair_prev":
                    hairIndex = DecrementChoice(hairIndex, hairImages);
                    updateHair = true;
                    break;
                case "eyes_next":
                    eyeIndex = IncrementChoice(eyeIndex, eyeImages);
                    updateEyes = true;
                    break;
                case "eyes_prev":
                    eyeIndex = DecrementChoice(eyeIndex, eyeImages);
                    updateEyes = true;
                    break;
                case "nose_next":
                    noseIndex = IncrementChoice(noseIndex, noseImages);
                    updateNose = true;
                    break;
                case "nose_prev":
                    noseIndex = DecrementChoice(noseIndex, noseImages);
                    updateNose = true;
                    break;
                case "mouth_next":
                    mouthIndex = IncrementChoice(mouthIndex, mouthImages);
                    updateMouth = true;
                    break;
                case "mouth_prev":
                    mouthIndex = DecrementChoice(mouthIndex, mouthImages);
                    updateMouth = true;
                    break;
                case "randomize":
                    RandomizeChoice();
                    break;
                default:
                    break;
            }

            MyImageMethod();
        }

        // Method to incremenet indexes for their respective lists
        private static int IncrementChoice(int index, List<BitmapImage> imageList)
        {
            if (index < 0 || index >= imageList.Count - 1)
            {
                return 0;
            }

            return index + 1;
        }

        // Method to decremenet indexes for their respective lists
        private static int DecrementChoice(int index, List<BitmapImage> imageList)
        {
            if (index <= 0) {

                return imageList.Count - 1;
            }

            return index - 1;
        }

        // Method to randomize the indexes
        private void RandomizeChoice()
        {
            hairIndex = random.Next(0, hairImages.Count);
            eyeIndex = random.Next(0, eyeImages.Count);
            noseIndex = random.Next(0, noseImages.Count);
            mouthIndex = random.Next(0, mouthImages.Count);

            updateHair = updateEyes = updateNose = updateMouth = true;
        }
    }
}
