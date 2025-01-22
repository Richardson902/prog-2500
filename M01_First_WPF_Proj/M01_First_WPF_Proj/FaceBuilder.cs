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
        public static event Action CanvasUpdateRequested;

        public  static void hairNext(ImageManager imageManager)
        {
            MessageBox.Show($"Hair images count: {imageManager.hairImages.Count}");
            imageManager.IncrementChoice(ImageManager.Category.Hair, imageManager.hairImages);

            CanvasUpdateRequested?.Invoke();
        } 

    }
}
