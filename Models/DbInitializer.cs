namespace basic_html_css.Models
{
    public class DbInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();
        }
    }
}