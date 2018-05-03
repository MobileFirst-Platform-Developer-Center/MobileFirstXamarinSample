using System;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using Worklight;
using System.Text;

namespace MobileFirstSample
{
	public class HomePage : ContentPage
	{
		#region Fields
		private RelativeLayout indicatorLayout = null;
		private ListView listView = null;
		private ActivityIndicator activityIndicator = null;
		bool busy = false;

		#endregion

		public static HomePage _this; 

		#region Constructors
		public HomePage ()
		{
			_this = this;
			BackgroundColor = Color.XamarinLightGray.ToFormsColor ();
			Title = "MobileFirst Sample";

			var activityIndicatorColor = new Xamarin.Forms.Color (Color.XamarinGray.R, Color.XamarinGray.G, Color.XamarinGray.B, .4);

			activityIndicator = new ActivityIndicator{
				Color = Xamarin.Forms.Color.Black,
				BackgroundColor = new Xamarin.Forms.Color (0, 0, 0, 0),
				IsRunning = false,
				IsVisible = true
			};

			listView = new ListView {
				RowHeight = 40,
				BackgroundColor = Xamarin.Forms.Color.White,
				VerticalOptions = LayoutOptions.Start
			};

			listView.ItemsSource = new [] {
				//new CommandItem { Command = "Connect", Image = "connect.png", ItemSelected = OnConnect },
				new CommandItem { Command = "Call unprotected adapter", Image = "invoke.png", ItemSelected = OnUnprotectedInvoke },
				new CommandItem { Command = "Call protected adapter", Image = "invoke.png", ItemSelected = OnProtectedInvoke },
                new CommandItem {Command = "Login", Image = "invoke.png", ItemSelected = OnLogin},
                new CommandItem {Command = "Logout", Image = "invoke.png", ItemSelected = OnLogout},
				new CommandItem { Command = "Register Device", Image = "subscribe.png", ItemSelected = OnRegister },
				new CommandItem { Command = "Unregister Device", Image = "unsubscribe.png", ItemSelected = OnUnregister },
				new CommandItem { Command = "Subscribe to Push", Image = "subscribe.png", ItemSelected = OnSubscribe },
				new CommandItem { Command = "Unsubscribe from Push", Image = "unsubscribe.png", ItemSelected = OnUnSubscribe },
				new CommandItem { Command = "Get All Subscriptions", Image = "issubscribed.png", ItemSelected = OnGetSubscriptions },
				new CommandItem { Command = "Get All Tags", Image = "issubscribed.png", ItemSelected = OnGetTags },
				new CommandItem { Command = "JSONStore destroy", Image = "logactivity.png", ItemSelected = OnDestroyJSONStore },
				new CommandItem { Command = "Open JSONStore Collection", Image = "logactivity.png", ItemSelected = OnJSONStoreOpenCollection },
				new CommandItem { Command = "Add Data to JSONStore", Image = "logactivity.png", ItemSelected = OnAddDataToJSONStore },
				new CommandItem { Command = "Retrieve all Data", Image = "logactivity.png", ItemSelected = OnRetrieveAllDataFromJSONStore },
				new CommandItem { Command = "Retrieve Filtered Data", Image = "logactivity.png", ItemSelected = OnRetrieveFilteredDataFromJSONStore },
			};

			listView.ItemTemplate = new DataTemplate(typeof(CommandCell));

			listView.ItemSelected += (sender, e) => {
				if (e.SelectedItem == null) return;

				(e.SelectedItem as CommandItem).ItemSelected ();
				listView.SelectedItem = null; 
			};

			Content = CreateLayout (activityIndicatorColor);
		}

		#endregion

		#region Properties
		private bool Busy {
			get {
				return busy;
			} 
			set {

				if (busy != value) {
					busy = value;
					if (busy) {
						listView.IsVisible = true;
						listView.IsEnabled = false;
						// TODO: Uncomment after bug https://bugzilla.xamarin.com/show_bug.cgi?id=32068 is fixed.
						// Also see https://forums.xamarin.com/discussion/comment/139670#Comment_139670
						//activityIndicator.IsRunning = true;
						indicatorLayout.IsVisible = true;
					} 
					else {
						listView.IsVisible = true;
						listView.IsEnabled = true;
						// TODO: Uncomment after bug https://bugzilla.xamarin.com/show_bug.cgi?id=32068 is fixed.
						// Also see https://forums.xamarin.com/discussion/comment/139670#Comment_139670
						//activityIndicator.IsRunning = false;
						indicatorLayout.IsVisible = false;
					}
				}

			}
		}
		#endregion

		#region Layout Methods
		private RelativeLayout CreateLayout (Xamarin.Forms.Color activityIndicatorColor)
		{
			var relativeLayout = new RelativeLayout ();
			indicatorLayout = new RelativeLayout {
				IsVisible = false
			};

			indicatorLayout.Children.Add (new ContentView {
				BackgroundColor = activityIndicatorColor
			}, Constraint.Constant (0), Constraint.Constant (0), 
				Constraint.RelativeToParent (parent => parent.Width), 
				Constraint.RelativeToParent (parent => parent.Height));

			 indicatorLayout.Children.Add (activityIndicator, 
				Constraint.RelativeToParent (parent => parent.Width / 2 - 25), 
				Constraint.RelativeToParent (parent => parent.Height / 2 - 25), 
				Constraint.Constant (50), Constraint.Constant (50));

			relativeLayout.Children.Add (listView, Constraint.Constant (0), Constraint.Constant (0));
			relativeLayout.Children.Add (indicatorLayout, Constraint.Constant (0), Constraint.Constant (0), 
				Constraint.RelativeToParent (parent => parent.Width), 
				Constraint.RelativeToParent (parent => parent.Height));

			return relativeLayout;
		}
		#endregion

		#region Selection Handlers
		private async void OnUnprotectedInvoke ()
		{
			ShowWorking();
			var result = await App.WorklightClient.UnprotectedInvokeAsync();
			await HandleResult(result, "Unprotected adapter invocation Result", true);
		}

		private async void OnProtectedInvoke ()
		{
			ShowWorking();
			var result = await App.WorklightClient.ProtectedInvokeAsync();
			await HandleResult(result, "Protected adapter invocation Result", true);
		}
        private async void OnLogout ()
        {
            ShowWorking();
            String rr = await App.WorklightClient.OnLogout();
            var result = new WorklightResult();
            result.Message = rr;
            await HandleResult(result, "Logout result", true);
        }
        private async void OnLogin()
        {
            ShowWorking();
            String rr = await App.WorklightClient.OnLogin();
            var result = new WorklightResult();
            result.Message = rr;
            await HandleResult(result, "Login result", true);
        }
		private  async void OnRegister()
		{
			ShowWorking();
			var result = await App.WorklightClient.RegisterAsync();
			await HandleResult(result, "Register Device Result", true);
		}

		private async void OnUnregister()
		{
			ShowWorking();
			var result = await App.WorklightClient.UnregisterAsync();
			await HandleResult(result, "Unregister Device Result", true);
		}

		private async void OnSubscribe()
		{
			ShowWorking();
			var result = await App.WorklightClient.SubscribeAsync ();
			await HandleResult(result, "Subscribe Result");
		}

		private async void OnUnSubscribe()
		{
			ShowWorking();
			var result = await App.WorklightClient.UnSubscribeAsync();
			await HandleResult(result, "Unsubcribe Result", true);
		}

		private async void OnGetSubscriptions()
		{
			ShowWorking();
			var result = await App.WorklightClient.GetSubscriptionsAsync();
			await HandleResult(result, "Get Subscriptions Result", true);
		}

		private async void OnGetTags()
		{
			ShowWorking();
			var result = await App.WorklightClient.GetTagsAsync();
			await HandleResult(result, "Get Tags Result", true);
		}

		private void OnIsPushEnabled()
		{
			DisplayAlert("Push Status", String.Format("Push {0} supported", (App.WorklightClient.IsPushSupported) ? "Is" : "Isn't"),"OK");
		}

		private void OnDestroyJSONStore()
		{
			DisplayAlert("Destroy JSONStore Status", String.Format("JSONStore was {0} destroyed", (App.WorklightClient.client.JSONStoreService.JSONStore.Destroy()) ? "successfully" : "not"),"OK");
		}

		private void OnJSONStoreOpenCollection()
		{
			List<WorklightJSONStoreCollection> collectionList = new List<WorklightJSONStoreCollection>();
			WorklightJSONStoreCollection collection = App.WorklightClient.client.JSONStoreService.JSONStoreCollection ("people");
			Dictionary<string, WorklightJSONStoreSearchFieldType> searchFieldDict = new Dictionary<string, WorklightJSONStoreSearchFieldType> ();
			//WorklightJSONStoreSearchFieldType searchFied = App.WorklightClient.client.JSONStoreService.JSONStore.se
			searchFieldDict.Add ("name",WorklightJSONStoreSearchFieldType.String);
			collection.SearchFields = searchFieldDict;
			searchFieldDict = collection.SearchFields;
			collectionList.Add( collection);

			DisplayAlert("JSONStore Open Collection Status",
				String.Format("JSONStore Person Collection was {0} opened",
					(App.WorklightClient.client.JSONStoreService.JSONStore.OpenCollections(collectionList)) ? "successfully" : "not"),"OK");
		}

		private void OnAddDataToJSONStore()
		{
			JArray data = new JArray();
			JObject val =  JObject.Parse( " {\"name\" : \"Chethan\", \"laptop\" : 23.546} ");
			JObject val2 =   JObject.Parse( " {\"name\" : \"Ajay\", \"laptop\" : [ \"hellow\", 234.23, true] } ");
			JObject val3 =  JObject.Parse( " {\"name\" : \"Srihari\", \"laptop\" : true} ");
			data.Add(val);
			data.Add (val2);
			data.Add(val3);
			WorklightJSONStoreCollection collection = App.WorklightClient.client.JSONStoreService.JSONStore.GetCollectionByName ("people");
			if (collection != null)
				collection.AddData (data);
			else
				DisplayAlert ("JSONStore addData", "Open JSONstore collection before attempting to add data","OK");
		}

		private void OnRetrieveAllDataFromJSONStore()
		{
			WorklightJSONStoreCollection collection = App.WorklightClient.client.JSONStoreService.JSONStore.GetCollectionByName ("people");
			if (collection != null) {
				JArray outArr = collection.FindAllDocuments ();
				DisplayAlert ("All JSONStore Data",
					String.Format ("JSONStore Person data is:{0}",
						outArr.ToString ()), "OK");
			}else
				DisplayAlert ("JSONStore RetrieveData", "Open JSONstore collection before attempting to retrieve data","OK");
		}

		private void OnRetrieveFilteredDataFromJSONStore()
		{
//			JsonObject outArr = App.WorklightClient.client.JSONStoreService.JSONStoreCollection("people").FindDocumentByID(1);
			WorklightJSONStoreQueryPart[] queryParts = new WorklightJSONStoreQueryPart[1];
			queryParts [0] = App.WorklightClient.client.JSONStoreService.JSONStoreQueryPart();
			queryParts [0].AddLike ("name","Chethan");
			WorklightJSONStoreCollection collection = App.WorklightClient.client.JSONStoreService.JSONStore.GetCollectionByName("people");
			if (collection != null) {
				JArray outArr = collection.
				FindDocumentsWithQueryParts (queryParts);
				DisplayAlert ("Filtered JSONStore Data",
					String.Format ("JSONStore Person data is {0}",
						outArr != null ? outArr.ToString () : "not available"), "OK");
			}else
				DisplayAlert ("JSONStore RetrieveData", "Open JSONstore collection before attempting to retrieve data","OK");
		}

		#endregion

		#region private methods
		private async Task HandleResult(WorklightResult result, String title, bool ShowOnSuccess = false)
		{
			Busy = false;

			if (result.Success)
			{
				if (ShowOnSuccess)
				{
					await Navigation.PushAsync (new ResultPage(result) {
						Title = title,
					});
				}
				else
				{
					await DisplayAlert(title,result.Message, "OK");
				}

			}
			else
			{
				await Navigation.PushAsync (new ResultPage(result) {
					Title = title,
				});
			}
		}

		private async void ShowWorking(int timeout = 150)
		{
			Busy = true;

			await Task.Delay(TimeSpan.FromSeconds(timeout));

			if (Busy)
			{
				Busy = false;
				await DisplayAlert("Timeout", "Call timed out", "OK");

			}

		}

		internal async void ShowAlert(string title, string message, string cancel)
		{
			await DisplayAlert(title, message, cancel);
		}

		#endregion
	}
}

