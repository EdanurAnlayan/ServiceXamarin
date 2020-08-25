using Newtonsoft.Json;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServiceXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        string username;
        string password;
        public ListPage(List<SectionDetails> myArrays, string userName, string Password)
        {
            InitializeComponent();
            username = userName;
            password = Password;
            listview.ItemsSource = myArrays;
            this.BindingContext = this;
            this.IsBusy = false;
            this.LogOut.Clicked += LogOut_Clicked;
            this.Refresh.Clicked += Refresh_Clicked;
        }

        private async void LogOut_Clicked(object sender, EventArgs e)
        {
            this.IsBusy = true;
            await Navigation.PushModalAsync(new MainPage());
        }

        private async void Refresh_Clicked(object sender, EventArgs e)
        {
            this.IsBusy = true;
            var result = LoginService.Login(username, password);
            var taskModels = JsonConvert.DeserializeObject<List<SectionDetails>>(result);
            await Navigation.PushModalAsync(new ListPage(taskModels,username,password));
        }
    }
}