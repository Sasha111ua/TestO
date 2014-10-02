using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Droid.Views;
using OmnicTabs.Core.ViewModels;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace OmnicTabs.Droid.Views
{
    [Activity(Label = "View for GrandChildViewModel")]
    public class GrandChildView : MvxActivity
    {
        Button _buttonSave;
        MvxImageView _imageView;
        string _imageUrl;

        WebClient _webClient;

        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ZoomedImageView);
            _buttonSave = FindViewById<Button>(Resource.Id.button1);
            _buttonSave.Click += DownloadAsync;
            _imageView = FindViewById<MvxImageView>(Resource.Id.advisor_message_picture);
            _imageUrl = _imageView.ImageUrl;
        }

        async void DownloadAsync(object sender, System.EventArgs e)
        {
            _webClient = new WebClient();
            var url = new Uri(_imageUrl);
            byte[] bytes = null;
            try
            {
                bytes =  await _webClient.DownloadDataTaskAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine(e.ToString());
                return;
            }
            string documentsPath = (new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim), "Camera")).AbsolutePath;
            string localFilename = "image.png";
            string localPath = System.IO.Path.Combine(documentsPath, localFilename);

            FileStream fs = new FileStream(localPath, FileMode.OpenOrCreate);
            await fs.WriteAsync(bytes, 0, bytes.Length);

            fs.Close();

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            if (localPath != null)
            {
                Android.Net.Uri contentUri = Android.Net.Uri.FromFile(new Java.IO.File(localPath));
                mediaScanIntent.SetData(contentUri);
                SendBroadcast(mediaScanIntent);
            }

            BitmapFactory.Options options = new BitmapFactory.Options();
            options.InJustDecodeBounds = true;
             BitmapFactory.DecodeFile(localPath, options);

            options.InSampleSize = options.OutWidth > options.OutHeight ? options.OutHeight / _imageView.Height : options.OutWidth / _imageView.Width;
            options.InJustDecodeBounds = false;

            Bitmap bitmap =  BitmapFactory.DecodeFile(localPath, options);

            _imageView.SetImageBitmap(bitmap);
        }
        
    }
    [Activity(Label = "View for Child1ViewModel")]
    public class Child1View : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Child1View);
        }
    }
    [Activity(Label = "View for Child2ViewModel")]
    public class Child2View : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Child2View);
        }
    }
    [Activity(Label = "View for Child3ViewModel")]
    public class Child3View : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Child3View);
        }
    }

    [Activity(Label = "View for OmnicTabsViewModel")]
    public class OmnicTabsView : MvxTabActivity
    {
        protected OmnicTabsViewModel FirstViewModel
        {
            get { return base.ViewModel as OmnicTabsViewModel; }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.OmnicTabsView);


            TabHost.TabSpec spec;
            Intent intent;

            spec = TabHost.NewTabSpec("child1");
            spec.SetIndicator("1");
            spec.SetContent(this.CreateIntentFor(FirstViewModel.Child1));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("child2");
            spec.SetIndicator("2");
            spec.SetContent(this.CreateIntentFor(FirstViewModel.Child2));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("child3");
            spec.SetIndicator("3", Resources.GetDrawable(Resource.Drawable.Tab_Tweets));
            spec.SetContent(this.CreateIntentFor(FirstViewModel.Child3));
            TabHost.AddTab(spec);
        }
    }
}