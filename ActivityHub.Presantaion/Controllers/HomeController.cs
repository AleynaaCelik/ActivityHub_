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
            // Burada sorular�n cevaplar�n� i�leyebilirsiniz. �rne�in, veritaban�na kaydedebilirsiniz.

            // �rnek: Yan�tlar� konsola yazd�rma
            Console.WriteLine($"Outdoor or Indoor: {OutdoorOrIndoor}");
            Console.WriteLine($"Activity Type: {ActivityType}");
            Console.WriteLine($"Interests: {string.Join(", ", Interests)}");
            Console.WriteLine($"Time Preference: {TimePreference}");
            Console.WriteLine($"Group Size: {GroupSize}");
            Console.WriteLine($"Mood: {string.Join(", ", Mood)}");

            // ��lem tamamland���nda bir ba�ka sayfaya y�nlendirebilirsiniz.
            // �rne�in, te�ekk�r sayfas�na y�nlendirme
            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
