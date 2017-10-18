
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using static Android.Views.View;

namespace a
{
    [Activity(Label = "SignUp")]
    public class SignUp : Activity, IOnClickListener, IOnCompleteListener
    {

        Button btnSignUp;
        EditText input_email, input_password;
        LinearLayout activity_sign_up;

        FirebaseAuth auth;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignUpLayout);

            auth = FirebaseAuth.GetInstance(MainActivity.app);

            btnSignUp = FindViewById<Button>(Resource.Id.signup_btn_register);
            input_email = FindViewById<EditText>(Resource.Id.sign_email);
            input_password = FindViewById<EditText>(Resource.Id.sign_password);
            activity_sign_up = FindViewById<LinearLayout>(Resource.Id.activity_sign_up);

            btnSignUp.SetOnClickListener(this);

        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.signup_btn_register)
            {
                SignUpUser(input_email.Text, input_password.Text);
            }
        }

        private void SignUpUser(string email, string password)
        {
            auth.CreateUserWithEmailAndPassword(email, password)
                .AddOnCompleteListener(this, this);
           
        }

                                 
        public void OnComplete(Task task)
        {
            if (task.IsSuccessful == true){

                Console.Write("Goood!!!");
            }
            else{
                Console.Write("Bad!!!");
            }

        }
    }
}
