using Xamarin.Forms;

namespace CarouselSwipeControl
{
    public class CustomCarouselPage : CarouselPage
    {
        // Constructor
        public CustomCarouselPage()
        {
            Title = "Swipe Control";

            Children.Add(new ContentPage() {BackgroundColor = Color.Coral});
            Children.Add(new ContentPage() {BackgroundColor = Color.DarkSlateBlue});
            Children.Add(new ContentPage() {BackgroundColor = Color.GreenYellow});

            ToolbarItem toolbarItem = new ToolbarItem("Swipe", null, ToolbarItemClicked);
            ToolbarItems.Add(toolbarItem);
        }

        private async void ToolbarItemClicked()
        {
            var answer = await DisplayActionSheet("Choose a selection", "Cancel", "",
                "Enable",
                "Disable");

            if (answer == "Enable")
                IsSwipping = true;
            if (answer == "Disable")
                IsSwipping = false;
        }

        public static readonly BindableProperty IsSwippingProperty = BindableProperty.Create(nameof(IsSwipping),
            typeof(bool), typeof(CustomCarouselPage), default(bool));

        public bool IsSwipping
        {
            get { return (bool) GetValue(IsSwippingProperty); }
            set { SetValue(IsSwippingProperty, value); }
        }
    }
}