using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Hardware;
using Android.Views;
using LoginForm.Droid;
using LoginForm.Source.Views.CustomRenderersTabs.ContentPageCustomize;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CameraPage), typeof(CameraPageRenderer))]
namespace LoginForm.Droid
{
    [Obsolete]
    public class CameraPageRenderer : PageRenderer, TextureView.ISurfaceTextureListener
    {
        //[Obsolete]
        //global::Android.Hardware.Camera camera;
        //global::Android.Widget.Button takePhotoButton;
        //global::Android.Widget.Button toggleFlashButton;
        //global::Android.Widget.Button switchCameraButton;
        //global::Android.Views.View view;

        //Activity activity;
        //CameraFacing cameraType;
        //TextureView textureView;
        //SurfaceTexture surfaceTexture;

        //bool flashOn;

        //public CameraPageRenderer(Context context) : base(context)
        //{
        //}

        //protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.OldElement != null || e.NewElement != null)
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        SetupUserInterface();
        //        SetupEventHandlers();
        //    }
        //    catch (Exception error)
        //    {
        //        System.Diagnostics.Debug.WriteLine(@"   ERROR: ", error.Message);
        //    }
        //}

        //void SetupUserInterface()
        //{
        //    activity = this.Context as Activity;
        //    view = activity.LayoutInflater.Inflate(Resource.Layout.CameraLayout, this, false);
        //    cameraType = CameraFacing.Back;

        //    textureView = view.FindViewById<TextureView>(Resource.Id.textureView);
        //    textureView.SurfaceTextureListener = this;
        //}

        //void SetupEventHandlers()
        //{
        //    takePhotoButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.takePhotoButton);
        //    takePhotoButton.Click += TakePhotoButtonTapped;

        //    switchCameraButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.switchCameraButton);
        //    switchCameraButton.Click += SwitchCameraButtonTapped;

        //    toggleFlashButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.toggleFlashButton);
        //    toggleFlashButton.Click += ToggleFlashButtonTapped;
        //}

        //protected override void OnLayout(bool changed, int l, int t, int r, int b)
        //{
        //    base.OnLayout(changed, l, t, r, b);

        //    var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
        //    var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

        //    view.Measure(msw, msh);
        //    view.Layout(0, 0, r - l, b - t);
        //}

        //[Obsolete]
        //void PrepareAndStartCamera()
        //{
        //    camera.StopPreview();

        //    var display = activity.WindowManager.DefaultDisplay;

        //    if (display.Rotation == SurfaceOrientation.Rotation0)
        //    {
        //        camera.SetDisplayOrientation(90);
        //    }

        //    if (display.Rotation == SurfaceOrientation.Rotation270)
        //    {
        //        camera.SetDisplayOrientation(180);
        //    }

        //    camera.StartPreview();
        //}

        //void ToggleFlashButtonTapped(object sender, EventArgs e)
        //{

        //}

        //void TakePhotoButtonTapped(object sender, EventArgs e)
        //{

        //}

        //void SwitchCameraButtonTapped(object sender, EventArgs e)
        //{

        //}

        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            throw new System.NotImplementedException();
        }

        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            throw new System.NotImplementedException();
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
            throw new System.NotImplementedException();
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
            throw new System.NotImplementedException();
        }
    }
}