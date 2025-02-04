using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FaceBuilderApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set 
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }


        public ICommand HairNextCommand { get; }
        public ICommand HairPrevCommand { get; }
        public ICommand EyesNextCommand { get; }      
        public ICommand EyesPrevCommand { get; }
        public ICommand NoseNextCommand { get; }
        public ICommand NosePrevCommand { get; }
        public ICommand MouthNextCommand { get; }
        public ICommand MouthPrevCommand { get; }
        public ICommand RandomizeCommand { get; }
        public ICommand ClearFaceCommand { get; }
        public ICommand HelpKeybindsCommand { get; }
        public ICommand HelpAboutCommand { get; }
        public ICommand HelpImagesCommand { get; }
        public ICommand MoreHelpCommand { get; }

        public ViewModel()
        {
            HairNextCommand = new CommandHandler(() => FaceBuilder.HairNext(), true);
            HairPrevCommand = new CommandHandler(() => FaceBuilder.HairPrev(), true);
            EyesNextCommand = new CommandHandler(() => FaceBuilder.EyesNext(), true);
            EyesPrevCommand = new CommandHandler(() => FaceBuilder.EyesPrev(), true);
            NoseNextCommand = new CommandHandler(() => FaceBuilder.NoseNext(), true);
            NosePrevCommand = new CommandHandler(() => FaceBuilder.NosePrev(), true);
            MouthNextCommand = new CommandHandler(() => FaceBuilder.MouthNext(), true);
            MouthPrevCommand = new CommandHandler(() => FaceBuilder.MouthPrev(), true);
            RandomizeCommand = new CommandHandler(() => FaceBuilder.Randomize(), true);
            ClearFaceCommand = new CommandHandler(() => FaceBuilder.ClearCanvas(), true);
            HelpKeybindsCommand = new CommandHandler(() => HelpManager.DisplayKeyBindings(), true);
            HelpAboutCommand = new CommandHandler(() => HelpManager.DisplayAbout(), true);
            HelpImagesCommand = new CommandHandler(() => HelpManager.DisplayAddImages(), true);
            MoreHelpCommand = new CommandHandler(() => HelpManager.OpenAdditionHelp(), true);

            FirstName = "Jimmy";
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
