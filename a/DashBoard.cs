
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
using Firebase.Auth;
using static Android.Views.View;

namespace a
{
    [Activity(Label = "DashBoard")]
    public class DashBoard : Activity, IOnClickListener
    {
        TextView txtWelcome;
        TextView logOut;
        FirebaseAuth auth;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DashBoardLayout);

            txtWelcome = FindViewById<TextView>(Resource.Id.txtWelcome);


            logOut = FindViewById<TextView>(Resource.Id.txtLogOut);
            logOut.SetOnClickListener(this);
            auth = FirebaseAuth.GetInstance(MainActivity.app);
            txtWelcome.Text += ", "+ auth.CurrentUser.Email;
        }

        public void OnClick(View v)
        {
            if(v.Id == Resource.Id.txtLogOut){
                auth.SignOut();
                if(auth.CurrentUser == null)
                {
                    StartActivity(new Intent(this, typeof(MainActivity)));
                    Finish();
                }
            }
        }

    }
}
