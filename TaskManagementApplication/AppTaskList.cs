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
    class AppTaskList
    {
        private List<AppTask> _AppTasks = null;
        private static AppTaskList _AppTaskList = null;

        public static AppTaskList GetAppTaskList()
        {
            if (_AppTaskList == null)
                _AppTaskList = new AppTaskList();
            return _AppTaskList;
        }

        public AppTaskList()
        {
            _AppTasks = new List<AppTask>();
        }
       
        public int Count
        {
            get { return _AppTasks.Count; }
        }

        public void NewTask(AppTask atp)
        {
            _AppTasks.Add(atp);
        }

        public AppTask GetAppTask(int index)
        {
            if (_AppTasks.Count > index)
                return _AppTasks[index];

            return null;
        }

        public override string ToString()
        {
            String ret_value = "";
            foreach(AppTask ap in _AppTasks)
            {
                ret_value += ap.ToString() + "\n";
            }
            return ret_value;
        }
    }
}