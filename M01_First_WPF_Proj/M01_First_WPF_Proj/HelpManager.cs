﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M01_First_WPF_Proj
{
    public static class HelpManager
    {
        private static string helpPath = "Output/chm/FaceBuilder.chm";
        private static string keybindHelp = "ShortcutKeys.htm";
        private static string aboutHelp = "Overview.htm";
        private static string imageHelp = "AddingImages.htm";


        public static void DisplayKeyBindings()
        {
            HelpNavigator navTopic = HelpNavigator.Topic;
            Help.ShowHelp(null, helpPath, navTopic, keybindHelp);
        }

        public static void DisplayAbout()
        {
            HelpNavigator navTopic = HelpNavigator.Topic;
            Help.ShowHelp(null, helpPath, navTopic, aboutHelp);
        }

        public static void DisplayAddImages()
        {
            HelpNavigator navTopic = HelpNavigator.Topic;
            Help.ShowHelp(null, helpPath, navTopic, imageHelp);
        }
    }
}
