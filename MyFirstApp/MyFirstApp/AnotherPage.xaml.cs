using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFirstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnotherPage : ContentPage
    {
        public AnotherPage()
        {
            InitializeComponent();
        }

        async void goBackHandler(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}