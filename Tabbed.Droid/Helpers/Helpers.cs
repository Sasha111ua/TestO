using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OmnicTabs.Core;
using Java.IO;
using Android.Provider;

namespace OmnicTabs.Droid.Helpers
{
     class Helpers : Activity
    {
         Java.IO.File file;
          void SavePicture(string imageUrl)
         {
             var dir = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "DcimDemo");
             if (!dir.Exists())
             {
                 dir.Mkdirs();
             }
             Intent intent = new Intent(MediaStore.ActionImageCapture);
             file = new File(dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
             intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(file));
             StartActivityForResult(intent, 0);

         }
          protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
          {
              base.OnActivityResult(requestCode, resultCode, data);

              if (resultCode == Result.Canceled) return;

              // make it available in the gallery
              Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
              if (file != null)
              {
                  Android.Net.Uri contentUri = Android.Net.Uri.FromFile(file);
                  mediaScanIntent.SetData(contentUri);
                  SendBroadcast(mediaScanIntent);

                  // display in ImageView. We will resize the bitmap to fit the display
                  // Loading the full sized image will consume to much memory 
                  // and cause the application to crash.
                  /*int height = _imgView.Height;
                  int width = Resources.DisplayMetrics.WidthPixels;
                  using (Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height))
                  {
                      _imgView.SetImageBitmap(bitmap);
                  }*/
              }
          } 

    }
}