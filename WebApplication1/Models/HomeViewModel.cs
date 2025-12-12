namespace WebApplication1.Models
{
    public class HomeViewModel
    {

        public List<BannerItem> BannerItems { get; set; } = new List<BannerItem>();


        public ContactFormModel ContactForm { get; set; } = new ContactFormModel();

    }
}