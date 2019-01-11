using Android.App;
using Android.Widget;
using Android.OS;
//using ARNative.Droid.Views.Unity;

namespace ARNative.Droid.Views.Main
{
    [Activity(Name = "com.jdiaz.arnative.MainActivity")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            var button = FindViewById<Button>(Resource.Id.button1);
            button.Click += (sender, e) => { StartActivity(typeof(UnityActivity)); };
        }
    }
}