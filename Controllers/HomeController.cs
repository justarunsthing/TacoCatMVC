using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TacoCatMVC.Models;

namespace TacoCatMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult App()
        {
            var model = new Tacocat();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult App(Tacocat model)
        {
            if (!string.IsNullOrEmpty(model.Input))
            {
                var userInput = model.Input.ToLower().Replace(" ", "");
                var reversedInput = string.Empty;

                for (int i = userInput.Length - 1; i >= 0; i--)
                {
                    reversedInput += userInput[i];
                }

                if (reversedInput == userInput)
                {
                    model.Result = $"Well done, {model.Input} is a palindrome!";
                    model.IsPalindrome = true;
                }
                else
                {
                    model.Result = $"Oops, {model.Input} is not a palindrome.";
                    model.IsPalindrome = false;
                }
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
