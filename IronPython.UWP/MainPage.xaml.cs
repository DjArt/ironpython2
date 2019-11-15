using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using IronPython.Hosting;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;
using Windows.UI.Popups;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace IronPython.UWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ScriptEngine python = Python.CreateEngine();

        public MainPage()
        {
            InitializeComponent();
            python.SetSearchPaths(new[] { "Lib" });
            
        }

        private async void Run_Click(object sender, RoutedEventArgs e)
        {
            try {
                var s = python.CreateScriptSourceFromString(Script.Text);
                var c = s.Compile();
                object var = c.Execute<object>();
                string @out = var == null ? string.Empty : var.ToString();
                MessageDialog b = new MessageDialog(@out);
                await b.ShowAsync();
            }
            catch (Exception ex)
            {
                Exception.Text = ex.Message;
            }
        }

        private KeyValuePair<IEnumerator, IDisposable> TTT(CallSite a0, object a1) {
            return default;
        }
    }
}
