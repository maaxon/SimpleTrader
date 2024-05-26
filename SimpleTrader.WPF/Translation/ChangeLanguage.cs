using System;
using System.Windows;

namespace SimpleTrader.WPF.Translation
{
    public class ChangeLanguage
    {
        private static string path = "F:/2course/sem4/SimpleTrader-master/SimpleTrader/SimpleTrader.WPF/Translation/Source/";

      
        public static void SwitchLanguage(Window window, string lang)
        {

            
            var dictionary = new ResourceDictionary();
            switch (lang)
            {
                case "Eng":
                    dictionary.Source = new Uri($"{path}lang.en-Us.xaml", UriKind.Absolute);
                    break;
                case "Rus":
                    dictionary.Source = new Uri($"{path}lang.ru-Ru.xaml", UriKind.Absolute);
                    break;
                default:
                    dictionary.Source = new Uri($"{path}lang.en-Us.xaml", UriKind.Absolute);
                    break;
            }
            window.Resources.MergedDictionaries.Add(dictionary);
        } 
    }
}