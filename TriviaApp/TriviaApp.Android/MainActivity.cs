using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using DryIoc;
using Prism.DryIoc;
using Xamarin.Forms;

namespace TriviaApp.Droid
{
	[Activity(Label = "TriviaApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			UserDialogs.Init(() => this);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App(new AndroidInitializer()));
		}
	}

	public class AndroidInitializer : IPlatformInitializer
	{
		public void RegisterTypes(IContainer container)
		{
			// Register any platform specific implementations
		}
	}
}

