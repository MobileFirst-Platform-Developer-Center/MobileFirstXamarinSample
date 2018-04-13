using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Foundation;
using UIKit;

using Xamarin.Forms;
using MobileFirst.Xamarin.iOS;
using MobileFirst.Xamarin.iOS.Push;

namespace WorklightSample.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			var splashDelay = Task.Delay (2000);

			global::Xamarin.Forms.Forms.Init ();

			App.WorklightClient =  new SampleClient ( WorklightClient.CreateInstance(),WorklightPush.Instance);

			LoadApplication (new App ());

			splashDelay.Wait ();
			
			return base.FinishedLaunching (app, options);
		}

		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
		{
			//base.RegisteredForRemoteNotifications(application, deviceToken);
			WorklightPush.Instance.SendDeviceToken(deviceToken);
			Console.WriteLine("device token :: "+deviceToken.Description);
		}

		public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
		{
			Console.WriteLine("received notification");
		}
	}
}

