using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;


namespace MauiAppTutorial   
{
    [Activity(Theme = "@style/SplashTheme", Label = "LiftTrack", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait, LaunchMode = LaunchMode.SingleTop)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
          
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashInfo);
            var videoView = FindViewById<VideoView>(Resource.Id.SplashScreenVideo);
            string videoPath = string.Format("android.resource://{0}/{1}", ApplicationContext.PackageName,Resource.Raw.SplashScreen);
            videoView.SetVideoPath(videoPath);
            Task.Run(() =>
            {
                videoView.Start();
                Thread.Sleep(4000);
                RunOnUiThread(() =>
                {
                    StartActivity(typeof(MainActivity));
                });
            });
        }
    }
}
