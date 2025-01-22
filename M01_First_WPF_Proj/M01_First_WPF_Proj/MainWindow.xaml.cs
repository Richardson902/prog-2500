using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace M01_First_WPF_Proj
{

    public partial class MainWindow : Window
    {

        private ImageManager imageManager = new ImageManager();
        CommandHandler cmdHairNext;




        public MainWindow()
        {
            InitializeComponent();

            // Initialize ImageManager
            imageManager.LoadImages("../../images/hair", "../../images/eyes", "../../images/nose", "../../images/mouth");

             cmdHairNext = new CommandHandler(() => FaceBuilder.hairNext(imageManager), true);

        DataContext = new
            {
                nextHairCMD = cmdHairNext
            };

            InputBindings.Add(new KeyBinding(cmdHairNext, new KeyGesture(Key.R, ModifierKeys.Control)));

            FaceBuilder.CanvasUpdateRequested += UpdateCanvas;
            
        }

        public void UpdateCanvas()
        {
            myCanvas.Children.Clear();

            DrawImage(imageManager.GetHairImage(), 0, 0);
            DrawImage(imageManager.GetEyeImage(), 0, 250);
            DrawImage(imageManager.GetNoseImage(), 0, 500);
            DrawImage(imageManager.GetMouthImage(), 0, 750);

        }

        private void DrawImage(BitmapImage image, double left, double top)
        {
            if (image != null)
            {
                Image img = new Image { Source = image };
                Canvas.SetLeft(img, left);
                Canvas.SetTop(img, top);
                myCanvas.Children.Add(img);
            }
        }

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            //// Get the button that was pressed
            //if (sender is Button clickedButton)
            //{
            //    HandleButtonPress(clickedButton);
            //}
        }

        // Method to randomize the indexes
        private void RandomizeChoice(object sender, RoutedEventArgs e)
        {
            imageManager.RandomizeIndexes();
        }
    }
}
