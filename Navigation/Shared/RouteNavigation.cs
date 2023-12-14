namespace Navigation.Shared
{
    public static class RouteNavigation
    {
        public static string GetRoute( BindableObject target ) => (string)target.GetValue( RouteProperty );
        public static void SetRoute( BindableObject target, string value ) => target.SetValue( RouteProperty, value );

        public static readonly BindableProperty RouteProperty = BindableProperty.Create( "Route", typeof( string ), typeof( RouteNavigation ), null, propertyChanged: OnRoutePropertyChanged );

        private static void OnRoutePropertyChanged( BindableObject bindable, object oldValue, object newValue )
        {
            if ( bindable is Button button )
            {
                if ( oldValue is not null && newValue is null )
                {
                    button.Clicked -= Item_Clicked;
                }
                if ( newValue is not null && oldValue is null )
                {
                    button.Clicked += Item_Clicked;
                }
            }
            if ( bindable is MenuItem menuitem )
            {
                if ( oldValue is not null && newValue is null )
                {
                    menuitem.Clicked -= Item_Clicked;
                }
                if ( newValue is not null && oldValue is null )
                {
                    menuitem.Clicked += Item_Clicked;
                }
            }
        }

        private static async void Item_Clicked( object sender, EventArgs e )
        {
            await Shell.Current.GoToAsync( GetRoute( (BindableObject)sender! ) );
        }
    }

}
