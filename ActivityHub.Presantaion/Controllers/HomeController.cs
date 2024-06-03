using Microsoft.AspNetCore.Mvc;

namespace ActivityHub.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Questions()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitQuestions(string OutdoorOrIndoor, string ActivityType, string[] Interests, string TimePreference, string GroupSize, string[] Mood)
        {
            // Burada sorularýn cevaplarýný iþleyebilirsiniz. Örneðin, veritabanýna kaydedebilirsiniz.

            // Örnek: Yanýtlarý konsola yazdýrma
            Console.WriteLine($"Outdoor or Indoor: {OutdoorOrIndoor}");
            Console.WriteLine($"Activity Type: {ActivityType}");
            Console.WriteLine($"Interests: {string.Join(", ", Interests)}");
            Console.WriteLine($"Time Preference: {TimePreference}");
            Console.WriteLine($"Group Size: {GroupSize}");
            Console.WriteLine($"Mood: {string.Join(", ", Mood)}");

            // Ýþlem tamamlandýðýnda bir baþka sayfaya yönlendirebilirsiniz.
            // Örneðin, teþekkür sayfasýna yönlendirme
            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
