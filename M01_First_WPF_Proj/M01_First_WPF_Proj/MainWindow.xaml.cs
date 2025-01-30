using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace M01_First_WPF_Proj
{

    public partial class MainWindow : Window
    {
        // Declare commands
        private CommandHandler cmdHairNext;
        private CommandHandler cmdHairPrev;
        private CommandHandler cmdEyesNext;
        private CommandHandler cmdEyesPrev;
        private CommandHandler cmdNoseNext;
        private CommandHandler cmdNosePrev;
        private CommandHandler cmdMouthNext;
        private CommandHandler cmdMouthPrev;
        private CommandHandler cmdRandomize;
        private CommandHandler cmdClearFace;
        private CommandHandler cmdHelpKeybinds;
        private CommandHandler cmdHelpAbout;
        private CommandHandler cmdHelpImages;

        public MainWindow()
        {
            InitializeComponent();

            // Assigns the invokable to call update canvas method
            FaceBuilder.OnImagesUpdated += UpdateCanvas;

            // Loads the images at runtime
            FaceBuilder.LoadImages();

            // Sets the commands and keybindings
            InitializeKeyBindings();
        }

        // Clears canvas, and then draws image based on what flags are true
        public void UpdateCanvas()
        {
            myCanvas.Children.Clear();

            if (FaceBuilder.IsUpdateHair)
            {
                DrawImage(FaceBuilder.GetHairImage(), 0, 0);
            }

            if (FaceBuilder.IsUpdateEyes)
            {
                DrawImage(FaceBuilder.GetEyeImage(), 0, 250);
            }

            if (FaceBuilder.IsUpdateNose)
            {
                DrawImage(FaceBuilder.GetNoseImage(), 0, 500);
            }
            
            if (FaceBuilder.IsUpdateMouth)
            { 
                DrawImage(FaceBuilder.GetMouthImage(), 0, 750);
            }
        }

        // Sets the image and location to draw on the canvas
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

        // Block of code that sets up the key bindings (could prob move into some sort of list lmfao)
        private void InitializeKeyBindings()
        {
            cmdHairNext = new CommandHandler(() => FaceBuilder.HairNext(), true);
            cmdHairPrev = new CommandHandler(() => FaceBuilder.HairPrev(), true);
            cmdEyesNext = new CommandHandler(() => FaceBuilder.EyesNext(), true);
            cmdEyesPrev = new CommandHandler(() => FaceBuilder.EyesPrev(), true);
            cmdNoseNext = new CommandHandler(() => FaceBuilder.NoseNext(), true);
            cmdNosePrev = new CommandHandler(() => FaceBuilder.NosePrev(), true);
            cmdMouthNext = new CommandHandler(() => FaceBuilder.MouthNext(), true);
            cmdMouthPrev = new CommandHandler(() => FaceBuilder.MouthPrev(), true);
            cmdRandomize = new CommandHandler(() => FaceBuilder.Randomize(), true);
            cmdClearFace = new CommandHandler(() => FaceBuilder.ClearCanvas(), true);
            cmdHelpKeybinds = new CommandHandler(() => HelpManager.DisplayKeyBindings(), true);
            cmdHelpAbout = new CommandHandler(() => HelpManager.DisplayAbout(), true);
            cmdHelpImages = new CommandHandler(() => HelpManager.DisplayAddImages(), true);

            DataContext = new
            {
                nextHairCMD = cmdHairNext,
                prevHairCMD = cmdHairPrev,
                nextEyesCMD = cmdEyesNext,
                prevEyesCMD = cmdEyesPrev,
                nextNoseCMD = cmdNoseNext,
                prevNoseCMD = cmdNosePrev,
                nextMouthCMD = cmdMouthNext,
                prevMouthCMD = cmdMouthPrev,
                randomizeCMD = cmdRandomize,
                clearFaceCMD = cmdClearFace,
                helpKeybindsCMD = cmdHelpKeybinds,
                helpAboutCMD = cmdHelpAbout,
                helpImagesCMD = cmdHelpImages
            };

            InputBindings.Add(new KeyBinding(cmdRandomize, new KeyGesture(Key.R, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdClearFace, new KeyGesture(Key.C, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdHairNext, new KeyGesture(Key.D2, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdHairPrev, new KeyGesture(Key.D1, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdEyesNext, new KeyGesture(Key.W, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdEyesPrev, new KeyGesture(Key.Q, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdNoseNext, new KeyGesture(Key.S, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdNosePrev, new KeyGesture(Key.A, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdMouthNext, new KeyGesture(Key.X, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdMouthPrev, new KeyGesture(Key.Z, ModifierKeys.Control)));
        }
    }
}
