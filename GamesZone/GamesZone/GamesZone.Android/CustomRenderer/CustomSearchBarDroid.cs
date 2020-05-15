using Android.Content;
using Android.Support.V4.Content.Res;
using GamesZone.CustomRenderer;
using GamesZone.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarDroid))]
namespace GamesZone.Droid.CustomRenderer
{
    public class CustomSearchBarDroid : SearchBarRenderer
    {
        public CustomSearchBarDroid(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e); 
            if (Control != null)
            {
                Control.SetBackground(ResourcesCompat.GetDrawable(Resources, Resource.Drawable.SearchBarStyle, null));
            }
        }
    }
}