using Android.OS;
using Android.App;
using Android.Views;
using Android.Runtime;
using Android.Content;
using Android.Content.Res;

using Unity3d.Player;
using ARNative.Droid.Views.Main;
using System.Threading.Tasks;
using System;

namespace ARNative.Droid
{
    [Activity(Name = "com.jdiaz.arnative.UnityActivity")]
    public class UnityActivity : Activity
    {
        protected UnityPlayer mUnityPlayer; // don't change the name of this variable; referenced from native code

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {            
                RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
                base.OnCreate(savedInstanceState);
                mUnityPlayer = new UnityPlayer(this);
                SetContentView(mUnityPlayer);
                mUnityPlayer.RequestFocus();
                Timer();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async void Timer()
        {

        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }

        protected override void OnDestroy()
        {
            mUnityPlayer.Destroy();
            base.OnDestroy();
        }

        protected override void OnPause()
        {
            base.OnPause();
            mUnityPlayer.Pause();
        }

        protected override void OnResume()
        {
            base.OnResume();
            mUnityPlayer.Resume();
        }

        protected override void OnStart()
        {
            base.OnStart();
            mUnityPlayer.Start();
        }

        protected override void OnStop()
        {
            base.OnStop();
            mUnityPlayer.Stop();
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();
            mUnityPlayer.LowMemory();
        }

        public override void OnTrimMemory([GeneratedEnum] TrimMemory level)
        {
            base.OnTrimMemory(level);
            if (level == TrimMemory.RunningCritical)
                mUnityPlayer.LowMemory();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            mUnityPlayer.ConfigurationChanged(newConfig);
        }

        public override void OnWindowFocusChanged(bool hasFocus)
        {
            base.OnWindowFocusChanged(hasFocus);
            mUnityPlayer.WindowFocusChanged(hasFocus);
        }

        public override bool DispatchKeyEvent(KeyEvent e)
        {
            if (e.Action == KeyEventActions.Multiple)
                return mUnityPlayer.InjectEvent(e);
            return base.DispatchKeyEvent(e);
        }

        public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            return mUnityPlayer.InjectEvent(e);
        }

        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            return mUnityPlayer.InjectEvent(e);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            return mUnityPlayer.InjectEvent(e);
        }

        public override bool OnGenericMotionEvent(MotionEvent e)
        {
            return mUnityPlayer.InjectEvent(e);
        }
    }
}