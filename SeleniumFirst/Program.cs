using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit.Compatibility;
using OpenQA.Selenium.Support.UI;
using System.IO;


namespace SeleniumFirst
{
    class Program
    {
        
        static void Main(string[] args)
        {  
                        
           
         }
        [SetUp]
        public void AppDomainInitializer()
        {
            PropertiesCollection.driver = new ChromeDriver();
            
            PropertiesCollection.driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");

           
        }

        
        [Test]
        public void FillForm()
        {

            
            loginPageObject PageLogin = new loginPageObject();
            EAPageObject pageEA = PageLogin.Login("execute", "automation");
            pageEA.fillUserForm("abc", "Lolo", "M.", Gender.Female, Userlanguage.Hindi);
            pageEA.OpenHTMLPopup();

          }

        [Test]
        public void FillFromFile()
        {
            loginPageObject PageLogin = new loginPageObject();
            EAPageObject pageEA = PageLogin.Login("execute", "automation");
            // Read Input from file
            
            String String1 = System.IO.File.ReadAllText(@"C:\Users\amismar\Initial.txt");
            String[] InitialInput = String1.Split(',');

            String String2 = System.IO.File.ReadAllText(@"C:\Users\amismar\FirstName.txt");
            String[] FirstName = String1.Split(',');

            String String3 = System.IO.File.ReadAllText(@"C:\Users\amismar\LastName.txt");
            String[] MiddleName = String1.Split(',');

            for (int i = 0; i < 3; i++)
            {
                pageEA.fillUserForm(InitialInput[i], FirstName[i], MiddleName[i], Gender.Male, Userlanguage.English);
                pageEA.btnSave.Click();
            }
                       
        }

        [Test]
        public void FindElements()

        {
            loginPageObject PageLogin = new loginPageObject();
            EAPageObject pageEA = PageLogin.Login("execute", "automation");
            pageEA.ClickDragandDrop();

            string FilePath = @"C:\Users\amismar\ItemIds.txt";


            /*            String String1 = System.IO.File.ReadAllText(@"C:\Users\amismar\ItemIds.txt");
                     String[] ItemsIds = String1.Split(',');

                     Boolean found;
                       int i = 0;
                       for (i = 0; i < 5; i++)

                       {
                           found = PropertiesCollection.driver.FindElement(By.Id(ItemsIds[i])).Displayed;
                           Assert.IsTrue(found);

                         if (found == true)
                             Console.WriteLine(ItemsIds[i] + " is found. ");

                       }
                       */

            pageEA.FindItems(FilePath, 5);






        }




        [TearDown]
        public void Cleanup()
        {
            // driver.Close();
            Console.WriteLine("Closed");
        }
    }
}
