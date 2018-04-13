using System;
using Xamarin.Forms;

namespace WorklightSample
{
	public class CommandCell : ViewCell
	{
		//[Preserve(Conditional = true)]
		public CommandCell ()
		{
			var image = new Image {
				WidthRequest = 30,
				HeightRequest = 30
			};
			image.SetBinding (Image.SourceProperty, new Binding ("Image"));

			var label = new Label {
				TextColor = Xamarin.Forms.Color.Black,
				VerticalOptions = LayoutOptions.Center
			};
			label.SetBinding (Label.TextProperty, new Binding ("Command"));

			var viewLayout = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness (20, 0, 0, 0),
				Spacing = 25,
				Children = { image, label }
			};
			View = viewLayout;
		}
	}

	class PreserveAttribute : System.Attribute
	{
		public bool Conditional { get; set; }
	}
}

