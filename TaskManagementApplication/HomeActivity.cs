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

namespace TaskManagementApplication
{
    [Activity(Label = "Add Tasks")]
    public class HomeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "home" layout resource
            SetContentView(Resource.Layout.Home);

            // select a button from the layout
            EditText TextTaskName = FindViewById<EditText>(Resource.Id.home_edittext_taskname);
            Button ButtonAddTask = FindViewById<Button>(Resource.Id.home_button_addtask);
            Button ButtonViewTasks = FindViewById<Button>(Resource.Id.home_button_viewtasks);

            ButtonViewTasks.Click += delegate {
                StartActivity(typeof(ViewTasksActivity));
            };

            ButtonAddTask.Click += delegate {
                if(TextTaskName.Text=="")
                {
                    TextTaskName.Text = "No Description";
                }

                // create a new task and add to the list
                AppTaskList _AppTaskList = AppTaskList.GetAppTaskList();
                _AppTaskList.NewTask(new AppTask(TextTaskName.Text));
                TextTaskName.Text = "";
            };
        }
    }
}