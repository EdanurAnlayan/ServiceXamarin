# ServiceXamarin
Call web service with basic authentication.

In MainPage xaml, there are 2 entry and a button. I use information from here for basic authentication. Calling service has username and password.If username or password is wrong,
service return that and catch block return this to us.Basic authentication and calling service codes are in LoginService class. When login is succesfull, open other page is LoginPage.In this page listview is created to our model. In this list, services
data is showed.But this data is json data in service.So, in button where is in MainPage, i turned list object with json deserialize and put listview.As a result, datas are listed
in screen when you login successfully.
