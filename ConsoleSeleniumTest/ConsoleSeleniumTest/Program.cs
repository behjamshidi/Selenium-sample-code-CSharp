using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

// Requires reference to WebDriver.Support.dll
using OpenQA.Selenium.Support.UI;


namespace ConsoleSeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {


            using (IWebDriver driver = new ChromeDriver())
            {

                //Set the wait method to imlicit
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                //Open the log-in link
                driver.Navigate().GoToUrl("https://master.talon.farm/");

                // Log in to the system
                driver.FindElement(By.Name("email")).SendKeys("demo@talon.one");
                driver.FindElement(By.Name("password")).SendKeys("demo1234");
                driver.FindElement(By.TagName("button")).Click();

                //Select Create Application Button
                driver.FindElement(By.ClassName("Button-button-2EGTp")).Click();

                //Fill out New Application form 
                driver.FindElement(By.Name("name")).SendKeys("TestApp1");
                driver.FindElement(By.Name("currency")).SendKeys("Euro - EUR");
                driver.FindElement(By.Name("type")).SendKeys("Magento 1.9");
                driver.FindElement(By.Name("description")).SendKeys("description");
                driver.FindElement(By.Name("timezone")).SendKeys("Europe/Berlin");

                //Submit the from by clicking the Creat Application               
                driver.FindElement(By.Name("name")).Submit();

                //Search for a created application with its link. 
		//If there is a link with the name of created application so application has been created and test is passed.
                var count = driver.FindElements(By.LinkText("TestApp1")).Count();

                if ( count== 1) 
                    Console.WriteLine("Test Pass");
                else 
                    Console.WriteLine("Fail");
                }            
        }
        }
    }
}
