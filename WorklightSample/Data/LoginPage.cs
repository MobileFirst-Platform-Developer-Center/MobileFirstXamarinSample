using System;
using System.Threading;
using Xamarin.Forms;

namespace WorklightSample
{
	public class LoginPage : ContentPage
	{
		private Button b = new Button { Text = "Login" };
		public LoginPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Login" },
					b
				}
			};

			b.Clicked += OnLogin;
		}

		public void OnLogin(object sender, EventArgs e)
		{
			//Navigation.PopAsync ();
			CustomChallengeHandler.mre.Set();
		}
	}
}


