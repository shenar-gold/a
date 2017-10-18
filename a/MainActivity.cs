using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Firebase;
using Firebase.Auth;
using System;
using static Android.Views.View;
using Android.Views;
using Android.Gms.Tasks;


namespace a
{
    [Activity(Label = "a", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class MainActivity : Activity, IOnClickListener, IOnCompleteListener
    {
        public Button btnSignUp;
        LinearLayout activity_main;
        public static FirebaseApp app;
        FirebaseAuth auth;

        public Button btnLogIn;
        EditText input_email, input_password;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            InitFirebaseAuth();

            btnSignUp = FindViewById<Button>(Resource.Id.login_btn_sign_up);
            btnSignUp.SetOnClickListener(this);
            activity_main = FindViewById<LinearLayout>(Resource.Id.activity_main);


            input_email = FindViewById<EditText>(Resource.Id.login_email);
            input_password = FindViewById<EditText>(Resource.Id.login_password);
            btnLogIn = FindViewById<Button>(Resource.Id.login_btn_login);
            btnLogIn.SetOnClickListener(this);
        }

        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
                                             .SetApplicationId("1:715252781463:android:3681a575e998e063")
                                             .SetApiKey("AIzaSyAhXehU8TNLv9VhbNHCGDVXSOseeHajTu0")
                                             .Build();
            if (app == null)
                app = FirebaseApp.InitializeApp(this, options);
            auth = FirebaseAuth.GetInstance(app);

        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.login_btn_sign_up)
            {
                StartActivity(new Android.Content.Intent(this,typeof(SignUp)));
                Finish();
            }

            if (v.Id == Resource.Id.login_btn_login)
            {
                LoginUser(input_email.Text, input_password.Text);
            }
        }

        private void LoginUser(string email, string password)
        {
            auth.SignInWithEmailAndPassword(email,password)
                .AddOnCompleteListener(this,this);
        }

        public void OnComplete(Task task)
        {
            if(task.IsSuccessful){
                StartActivity(new Android.Content.Intent(this,typeof(DashBoard)));
                Finish();
            }else{
                Console.Write("Login Failed");
            }
        }
    }
}

