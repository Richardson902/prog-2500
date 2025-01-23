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
        private CommandHandler cmdEyesNext;
        private CommandHandler cmdEyesPrev;
        private CommandHandler cmdNoseNext;
        private CommandHandler cmdNosePrev;
        private CommandHandler cmdMouthNext;
        private CommandHandler cmdMouthPrev;

        public MainWindow()
        {
            InitializeComponent();

            FaceBuilder.OnImagesUpdated += UpdateCanvas;
            FaceBuilder.LoadImages();

            cmdHairNext = new CommandHandler(() => FaceBuilder.HairNext(), true);
            cmdHairPrev = new CommandHandler(() => FaceBuilder.HairPrev(), true);
            cmdEyesNext = new CommandHandler(() => FaceBuilder.EyesNext(), true);
            cmdEyesPrev = new CommandHandler(() => FaceBuilder.EyesPrev(), true);
            cmdNoseNext = new CommandHandler(() => FaceBuilder.NoseNext(), true);
            cmdNosePrev = new CommandHandler(() => FaceBuilder.NosePrev(), true);
            cmdMouthNext = new CommandHandler(() => FaceBuilder.MouthNext(), true);
            cmdMouthPrev = new CommandHandler(() => FaceBuilder.MouthPrev(), true);

            DataContext = new
            {
                nextHairCMD = cmdHairNext,
                prevHairCMD = cmdHairPrev,
                nextEyesCMD = cmdEyesNext,
                prevEyesCMD = cmdEyesPrev,
                nextNoseCMD = cmdNoseNext,
                prevNoseCMD = cmdNosePrev,
                nextMouthCMD = cmdMouthNext,
                prevMouthCMD = cmdMouthPrev
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
