using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace implicit_intent
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button call, sms, mail, browser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            call = FindViewById<Button>(Resource.Id.call);
            sms = FindViewById<Button>(Resource.Id.sms);
            mail = FindViewById<Button>(Resource.Id.mail);
            browser = FindViewById<Button>(Resource.Id.forEhud);
            call.Click += Call_Click;
            sms.Click += Sms_Click;
            mail.Click += Mail_Click;
            browser.Click += Browser_Click;
        }

        private void Browser_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://en.wikipedia.org/wiki/Joseph_Stalin"));
            StartActivity(intent);
        }

        private void Mail_Click(object sender, System.EventArgs e)
        {
            string[] emails = { "lavabucket123@gmail.com" };
            Intent i = new Intent(Intent.ActionSend);
            i.SetType("text/plain");
            i.PutExtra(Intent.ExtraEmail, emails);
            i.PutExtra(Intent.ExtraSubject, "more spam");
            i.PutExtra(Intent.ExtraText, "lotsssss of spam");
            StartActivity(i);
        }

        private void Sms_Click(object sender, System.EventArgs e)
        {
            string message = "spam";
            string number = "0506560880";
            Intent i = new Intent(Intent.ActionView, Android.Net.Uri.Parse("sms:" + number));
            Intent.PutExtra("sms_body", message);
            StartActivity(i);
        }

        private void Call_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent();
            i.SetAction(Intent.ActionCall);
            Android.Net.Uri data = Android.Net.Uri.Parse("tel:0506560880");
            i.SetData(data);
            StartActivity(i);
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}