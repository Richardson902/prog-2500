using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace M01_First_WPF_Proj
{
    public  static class FaceBuilder
    {
        private static ImageManager imageManager = new ImageManager();

        public static event Action OnImagesUpdated;

        public static void LoadImages()
        {
            imageManager.LoadImages("../../images/hair", "../../images/eyes", "../../images/nose", "../../images/mouth");
        }

        public static void HairNext()
        {
            imageManager.Increment(ImageManager.Category.Hair);
            OnImagesUpdated?.Invoke();


        }

        public static void HairPrev()
        {
            imageManager.Decrement(ImageManager.Category.Hair);
            OnImagesUpdated?.Invoke();


        }

        public static BitmapImage GetHairImage() => imageManager.GetHairImage();
        public static BitmapImage GetEyeImage() => imageManager.GetEyeImage();
        public static BitmapImage GetNoseImage() => imageManager.GetNoseImage();
        public static BitmapImage GetMouthImage() => imageManager.GetMouthImage();
    }
}
