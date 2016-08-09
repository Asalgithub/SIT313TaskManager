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
    class AppTask
    {
        private String _Description;
        private Boolean _Done;

        public AppTask()
        {
            _Description = "";
            _Done = false;
        }

        public AppTask(String _Description)
        {
            this._Description = _Description;
        }

        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public void Reverse()
        {
            _Done = !_Done;
        }

        public override string ToString()
        {
            String ret_value = _Description;
            if(_Done==false)
            {
                ret_value += "<Not Done>";
            }
            else
            {
                ret_value += "<Done>";
            }
            return ret_value;
        }
    }
}