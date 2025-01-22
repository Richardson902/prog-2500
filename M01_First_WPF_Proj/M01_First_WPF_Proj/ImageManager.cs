using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace M01_First_WPF_Proj
{
    public class ImageManager
    {
        public enum Category
        {
            Hair,
            Eye,
            Nose,
            Mouth
        }
        public int HairIndex { get; private set; } = -1;
        public int EyeIndex { get; private set; } = -1;
        public int NoseIndex { get; private set; } = -1;
        public int MouthIndex { get; private set; } = -1;

        private int increment = +1;
        private int decrement = -1;

        public List<BitmapImage> hairImages { get; private set; } = new List<BitmapImage>();
        public List<BitmapImage> eyeImages { get; private set; } = new List<BitmapImage>();
        public List<BitmapImage> noseImages { get; private set; } = new List<BitmapImage>();
        public List<BitmapImage> mouthImages { get; private set; } = new List<BitmapImage>();


        private Random random = new Random();

        public void LoadImages(string hairPath, string eyePath, string nosePath, string mouthPath)
        {
            LoadCategoryImages(hairPath, hairImages);
            LoadCategoryImages(eyePath, eyeImages);
            LoadCategoryImages(nosePath, noseImages);
            LoadCategoryImages(mouthPath, mouthImages);

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

        public void RandomizeIndexes()
        {
            HairIndex = random.Next(0, hairImages.Count);
            EyeIndex = random.Next(0, eyeImages.Count);
            NoseIndex = random.Next(0, noseImages.Count);
            MouthIndex = random.Next(0, mouthImages.Count);
        }

        // Get current images based on the indexes
        public BitmapImage GetHairImage() => HairIndex >= 0 ? hairImages[HairIndex] : null;
        public BitmapImage GetEyeImage() => EyeIndex >= 0 ? eyeImages[EyeIndex] : null;
        public BitmapImage GetNoseImage() => NoseIndex >= 0 ? noseImages[NoseIndex] : null;
        public BitmapImage GetMouthImage() => MouthIndex >= 0 ? mouthImages[MouthIndex] : null;

        public void IncrementChoice(Category category, List<BitmapImage> imageList)
        {
            UpdateChoice(category, increment, imageList);
        }

        public void DecrementChoice(Category category, List<BitmapImage> imageList)
        {
            UpdateChoice(category, decrement, imageList);
        }

        public void UpdateChoice(Category category, int direction, List<BitmapImage> imageList)
        {
            int index = 0;

            switch (category)
            {
                case Category.Hair:
                    index = HairIndex;
                    break;
                case Category.Eye:
                    index = EyeIndex;
                    break;
                case Category.Nose:
                    index = NoseIndex;
                    break;
                case Category.Mouth:
                    index = MouthIndex;
                    break;
            }

            if (imageList.Count > 0)
            {
                int newIndex = index + direction;

                if (newIndex < 0)
                {
                    newIndex = imageList.Count - 1; // Wrap to last image
                }
                else if (newIndex >= imageList.Count)
                {
                    newIndex = 0;
                }

                SetIndex(category, newIndex);
            }
        }

        private void SetIndex(Category category, int newIndex)
        {
            switch (category)
            {
                case Category.Hair:
                    HairIndex = newIndex;
                    break;
                case Category.Eye:
                    EyeIndex = newIndex;
                    break;
                case Category.Nose:
                    NoseIndex = newIndex;
                    break;
                case Category.Mouth:
                    MouthIndex = newIndex;
                    break;
            }
        }
    }
}
