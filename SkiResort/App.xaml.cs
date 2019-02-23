namespace SkiResort
{
    using SkiResort.View;
    using System.Windows;
    using System.Windows.Navigation;

    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static NavigationService Navigation;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SkiPage skiPage = new SkiPage();
            skiPage.Show();

        }
    }
}
