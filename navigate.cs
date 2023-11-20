using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CCUS
{
    class navigate
    {
        public IWebDriver Driver;

        public void BeforeTest(string url, string folder, string email, string password, bool type, string stateValue)
        {
            Form2 formularioCargando = new Form2();
            formularioCargando.MostrarCargando();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless"); // Habilitar el modo headless
            options.AddArgument("--no-sandbox"); // Puede ser necesario en algunos entornos
            options.AddArgument("disable-gpu");
            options.AddArgument("hide-command-prompt-window");
            MethodCreate create = new MethodCreate();

            Driver = new ChromeDriver(options);
            Driver.Navigate().GoToUrl(url);

            //Login
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement inputEmail = Driver.FindElement(By.Id("i0116"));
            inputEmail.SendKeys(email);

            Driver.FindElement(By.Id("idSIButton9")).Click();

            Thread.Sleep(2000);
            IWebElement inputPassword = Driver.FindElement(By.Id("i0118"));
            inputPassword.SendKeys(password);

            Thread.Sleep(3000);
            Driver.FindElement(By.Id("idSIButton9")).Click();
            Driver.FindElement(By.Id("idBtn_Back")).Click();

            //Sprint
            IWebElement sprint = Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[2]/div[2]/div/div[2]/div/div[2]/div/div[1]/div/div/input"));
            string sprintValue = sprint.GetAttribute("value");

            //Filtro
            Driver.FindElement(By.Id("__bolt-filter")).Click();
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[2]/div[2]/div/div[3]/div/div/div/div[1]/div/div/div/div[4]/div/button")).Click();
            Thread.Sleep(2000);
            Driver.FindElement(By.XPath($"//span[@class='text-ellipsis body-m'][contains(.,'{stateValue}')]")).Click();
            Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[2]/div[2]/div/div[3]/div/div/div/div[1]/div/div/div/div[4]/div/button")).Click();

            //Historias de usuario
            IWebElement tbodyElement = Driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/div[2]/div[2]/div/div[3]/div/div/div/div[2]/div/div/div/div/table/tbody"));
            IList<IWebElement> rows = tbodyElement.FindElements(By.XPath("./tr"));
            List<string> linkTexts = new List<string>();

            foreach (IWebElement row in rows)
            {
                IList<IWebElement> cells = row.FindElements(By.XPath("./td"));

                if (cells.Count >= 3)
                {
                    IWebElement thirdCell = cells[3]; 

                    IList<IWebElement> divs = thirdCell.FindElements(By.XPath(".//div"));

                    foreach (IWebElement div in divs)
                    {
                        IList<IWebElement> links = div.FindElements(By.XPath(".//a"));
                        
                        foreach (IWebElement link in links)
                        {
                            string linkText = link.Text; 
                            linkTexts.Add(linkText);
                        }
                        
                    }
                }
            }
            string[] linkTextsArray = linkTexts.ToArray();

            //Driver.Quit();
            formularioCargando.OcultarCargando();
            create.SelectMethod(linkTextsArray, sprintValue, folder, type);
        }

    }
}
