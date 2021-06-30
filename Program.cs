using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace RestVaccineBooker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Rest Vaccine Booker");
            string navn = args[0];
            string bday = args[1];
            string email = args[2];
            string telefon = args[3];

            var steder = new List<string> { "Vaccination Aarhus NORD", "Vaccination Aarhus SYD", "Vaccination Aarhus Ø" };

            foreach (var sted in steder)
            {

                using (var driver = new ChromeDriver(AppContext.BaseDirectory))
                {
                    var waiter = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
                    driver.Navigate().GoToUrl("https://www.auh.dk/om-auh/tilbud-om-covid-vaccination-ved-brug-af-restvacciner/");
                    Thread.Sleep(2000);

                    waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("CybotCookiebotDialogBodyButtonDecline"))).Click();
                    waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("06ea46a4-9fe2-49c0-b3fa-9217ab3e3c0e"))).SendKeys(navn);
                    waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("56930c3b-65ef-4e63-bb15-27a36a4256b8"))).SendKeys(bday);
                    waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("db67108b-6627-43d7-982e-2b11c6b5b26e"))).SendKeys(email);
                    waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("41df7f89-d7b9-4203-b18a-8f4c86023f89"))).SendKeys(telefon);

                    waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("__field_913923")));

                    driver.FindElements(By.Name("__field_913923")).First(s => s.GetAttribute("value") == sted).Click();

                    waiter.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("58efbdd7-1555-4202-aec4-30c5745c4797"))).Click();

                    Thread.Sleep(5000);
                }
            }
        }
    }
}
