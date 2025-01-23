﻿using System;
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

        public static void EyesNext()
        {
            imageManager.Increment(ImageManager.Category.Eye);
            OnImagesUpdated?.Invoke();
        }

        public static void EyesPrev()
        {
            imageManager.Decrement(ImageManager.Category.Eye);
            OnImagesUpdated?.Invoke();
        }

        public static void NoseNext()
        {
            imageManager.Increment(ImageManager.Category.Nose);
            OnImagesUpdated?.Invoke();
        }

        public static void NosePrev()
        {
            imageManager.Decrement(ImageManager.Category.Nose);
            OnImagesUpdated?.Invoke();
        }

        public static void MouthNext()
        {
            imageManager.Increment(ImageManager.Category.Mouth);
            OnImagesUpdated?.Invoke();
        }

        public static void MouthPrev()
        {
            imageManager.Decrement(ImageManager.Category.Mouth);
            OnImagesUpdated?.Invoke();
        }

        public static BitmapImage GetHairImage() => imageManager.GetHairImage();
        public static BitmapImage GetEyeImage() => imageManager.GetEyeImage();
        public static BitmapImage GetNoseImage() => imageManager.GetNoseImage();
        public static BitmapImage GetMouthImage() => imageManager.GetMouthImage();
    }
}
