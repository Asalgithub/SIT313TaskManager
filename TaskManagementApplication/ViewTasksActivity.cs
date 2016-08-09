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
    [Activity(Label = "Show Tasks")]
    public class ViewTasksActivity : Activity
    {
        private AppTask _CurrentTask = null;
        private AppTaskList _AppTaskList = null;
        private int _CurrentTaskIndex = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            _AppTaskList = AppTaskList.GetAppTaskList();

            base.OnCreate(savedInstanceState);

            // Set our view from the "view tasks" layout resource
            SetContentView(Resource.Layout.ViewTasks);

            TextView TextTotalTasks = FindViewById<TextView>(Resource.Id.viewtasks_text_totaltasks);
            TextView TextTaskName = FindViewById<TextView>(Resource.Id.viewtasks_text_taskname);
            Button ButtonFirstTask = FindViewById<Button>(Resource.Id.viewtasks_button_firsttask);
            Button ButtonLastTask = FindViewById<Button>(Resource.Id.viewtasks_button_lasttask);
            Button ButtonNextTask = FindViewById<Button>(Resource.Id.viewtasks_button_nexttask);
            Button ButtonPreviousTask = FindViewById<Button>(Resource.Id.viewtasks_button_previoustask);
            Button ButtonReverseTaskStatus = FindViewById<Button>(Resource.Id.viewtasks_button_reversetaskstatus);

            TextTotalTasks.Text = _AppTaskList.Count + " tasks total";

            // take the user to first task by default
            int temp1 = 0;
            _CurrentTaskIndex = temp1;
            _CurrentTask = _AppTaskList.GetAppTask(_CurrentTaskIndex);
            TextTaskName.Text = _CurrentTask.ToString();

            ButtonFirstTask.Click += delegate {
                int temp = 0;
                if(temp<_AppTaskList.Count)
                {
                    _CurrentTaskIndex = temp;
                    _CurrentTask = _AppTaskList.GetAppTask(_CurrentTaskIndex);
                    TextTaskName.Text = _CurrentTask.ToString();
                }
            };

            ButtonLastTask.Click += delegate {
                int temp = _AppTaskList.Count-1;
                if (temp < _AppTaskList.Count)
                {
                    _CurrentTaskIndex = temp;
                    _CurrentTask = _AppTaskList.GetAppTask(_CurrentTaskIndex);
                    TextTaskName.Text = _CurrentTask.ToString();
                }
            };

            ButtonNextTask.Click += delegate {
                int temp = _CurrentTaskIndex + 1;
                if (temp < _AppTaskList.Count)
                {
                    _CurrentTaskIndex = temp;
                    _CurrentTask = _AppTaskList.GetAppTask(_CurrentTaskIndex);
                    TextTaskName.Text = _CurrentTask.ToString();
                }
            };

            ButtonPreviousTask.Click += delegate {
                int temp = _CurrentTaskIndex - 1;
                if (temp < _AppTaskList.Count)
                {
                    _CurrentTaskIndex = temp;
                    _CurrentTask = _AppTaskList.GetAppTask(_CurrentTaskIndex);
                    TextTaskName.Text = _CurrentTask.ToString();
                }
            };

            ButtonReverseTaskStatus.Click += delegate {
                int temp = _CurrentTaskIndex;
                if (temp < _AppTaskList.Count)
                {
                    _CurrentTaskIndex = temp;
                    _CurrentTask = _AppTaskList.GetAppTask(_CurrentTaskIndex);
                    _CurrentTask.Reverse();
                    TextTaskName.Text = _CurrentTask.ToString();
                }
            };
        }
    }
}