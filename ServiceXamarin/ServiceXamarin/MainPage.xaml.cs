
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServiceXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            this.IsBusy = false;
            this.ButtonLogin.Clicked += ButtonLogin_Clicked;
        }
        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                this.IsBusy = true;
                string userName = EntryUsername.Text;
                string password = EntryPassword.Text;
                var result = LoginService.Login(userName, password);
                var taskModels = JsonConvert.DeserializeObject<List<SectionDetails>>(result);
                
                await Navigation.PushModalAsync(new ListPage(taskModels,userName,password));
               
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error",ex.Message, "OK");
            }
        }
    }
}
