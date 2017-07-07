using System;
using Android.Views;
using CarouselSwipeControl;
using CarouselSwipeControl.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomCarouselPage), typeof(CustomCarouselPageRenderer))]

namespace CarouselSwipeControl.Droid.Renderers
{
    public class CustomCarouselPageRenderer : CarouselPageRenderer
    {
        private float x1 { get; set; }
        private float x2 { get; set; }

        private float y1 { get; set; }
        private float y2 { get; set; }

        private CustomCarouselPage _page = null;

        protected override void OnElementChanged(ElementChangedEventArgs<CarouselPage> e)
        {
            _page = e.NewElement as CustomCarouselPage;
            base.OnElementChanged(e);
        }

        public override bool DispatchTouchEvent(MotionEvent e)
        {
            // Left or right swipe control
            if (!_page.IsSwipping)
            {
                if (e.ActionMasked == MotionEventActions.Down)
                {
                    x1 = e.GetX();
                    y1 = e.GetY();

                    return base.DispatchTouchEvent(e);
                }

                x2 = e.GetX();
                y2 = e.GetY();

                float xSize = Math.Abs(x1 - x2);
                float ySize = Math.Abs(y1 - y2);

                // Left or right swipe
                if (xSize > ySize)
                {
                    return false;
                }
                // Up or down swipe
                else
                {
                    return base.DispatchTouchEvent(e);
                }
            }

            return base.DispatchTouchEvent(e);
        }
    }
}