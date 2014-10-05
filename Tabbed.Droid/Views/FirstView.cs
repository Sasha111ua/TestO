using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Provider;
using Cirrious.MvvmCross.Droid.Views;
using OmnicTabs.Core;

namespace OmnicTabs.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}