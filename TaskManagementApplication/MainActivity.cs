using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TaskManagementApplication
{
    [Activity(Label = "Task Manager", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // setup a couple of test tasks
            AppTaskList _AppTaskList = AppTaskList.GetAppTaskList();
            _AppTaskList.NewTask(new AppTask("Weekend grocery shopping"));
            _AppTaskList.NewTask(new AppTask("SIT313 Assignment 1"));
            _AppTaskList.NewTask(new AppTask("SIT202 Assignment 1"));

            // select a button from the layout
            ImageButton button = FindViewById<ImageButton>(Resource.Id.main_image_gohome);

            button.Click += delegate {
                StartActivity(typeof(HomeActivity));
            };
        }
    }
}

