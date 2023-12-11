using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Com.Example.Amitywrap;
using Android.Widget;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace XamityTest
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        AmityWrap test = new AmityWrap();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            test.SetupAmity("APIKEY");
            //test.LoginAmity("username", "displayname", "AUTHTOKEN");
            var status = test.PrintAmityStatus();
            System.Console.WriteLine("STATUS :: " + status);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            Button showhomebutton = FindViewById<Button>(Resource.Id.showhomebutton);
            showhomebutton.Click += (sender, e) =>
            {
                var fragmentManager = SupportFragmentManager.BeginTransaction();
                var homefrag = test.ShowHomeNewsFeed();
                fragmentManager.Replace(Resource.Id.content, homefrag);
                fragmentManager.Commit();
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            test.LoginAmity("username", "displayname", "AUTHTOKEN");
            var status = test.PrintAmityStatus();
            System.Console.WriteLine("STATUS :: " + status);
            System.Console.WriteLine("STATUS :: " + status);
            //Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
            //    .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

