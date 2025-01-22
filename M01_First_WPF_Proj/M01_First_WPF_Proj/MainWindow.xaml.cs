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
        private CommandHandler cmdHairNext;
        private CommandHandler cmdHairPrev;




        public MainWindow()
        {
            InitializeComponent();

            FaceBuilder.OnImagesUpdated += UpdateCanvas;
            FaceBuilder.LoadImages();


            cmdHairNext = new CommandHandler(() => FaceBuilder.HairNext(), true);
            cmdHairPrev = new CommandHandler(() => FaceBuilder.HairPrev(), true);


            

        DataContext = new
            {
                nextHairCMD = cmdHairNext,
                prevHairCMD = cmdHairPrev
            };

            InputBindings.Add(new KeyBinding(cmdHairNext, new KeyGesture(Key.R, ModifierKeys.Control)));


            
        }

        public void UpdateCanvas()
        {
            myCanvas.Children.Clear();

            DrawImage(FaceBuilder.GetHairImage(), 0, 0);
            DrawImage(FaceBuilder.GetEyeImage(), 0, 250);
            DrawImage(FaceBuilder.GetNoseImage(), 0, 500);
            DrawImage(FaceBuilder.GetMouthImage(), 0, 750);

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

        }

        // Method to randomize the indexes
        private void RandomizeChoice(object sender, RoutedEventArgs e)
        {
            //imageManager.RandomizeIndexes();
        }
    }
}
