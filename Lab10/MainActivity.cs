using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab10
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private int Counter = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Validate);

            /*var contentHeader = FindViewById<TextView>(Resource.Id.ContentHeader);
            contentHeader.Text = GetText(Resource.String.ContentHeader);

            var ClickMe = FindViewById<Button>(Resource.Id.ClickMe);
            var ClickCounter = FindViewById<TextView>(Resource.Id.ClickCounter);
            ClickMe.Click += (s, e) =>
            {
                Counter++;
                ClickCounter.Text = Resources.GetQuantityString(Resource.Plurals.numberOfClicks, Counter, Counter);

                var Player = Android.Media.MediaPlayer.Create(this, Resource.Raw.sound);

                Player.Start();
            };

            Android.Content.Res.AssetManager Manager = this.Assets;

            using (var Reader = new System.IO.StreamReader(Manager.Open("Contenido.txt")))
            {
                contentHeader.Text += $"\n\n{Reader.ReadToEnd()}";
            }*/



            var ExecValidateButton = FindViewById<Button>(Resource.Id.ExecValidateButton);

            ExecValidateButton.Click += (sender, e) =>
            {
                Validate();
            };

        }
        private async void Validate()
        {
            var ServiceClient = new SALLab10.ServiceClient();
            var Comprobar = FindViewById<TextView>(Resource.Id.textView2);
            var UsernameText = FindViewById<EditText>(Resource.Id.UsernameText);
            var PasswordText = FindViewById<EditText>(Resource.Id.PasswordText);


            string StudentEmail = UsernameText.Text;
            string Password = PasswordText.Text;

            string MyDevice = Android.Provider.Settings.Secure.GetString(
                ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var Result = await ServiceClient.ValidateAsync(StudentEmail, Password, MyDevice);

            Comprobar.Text = $"{Result.Status}\n{Result.Fullname}\n{Result.Token}";

        }


    }
}

