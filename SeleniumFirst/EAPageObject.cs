using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.IO;
using NUnit.Framework;

namespace SeleniumFirst
{
    class EAPageObject
    {
        
        public EAPageObject()
        {
            // Initial Elements are in PropertiesCollection class
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        // POM Page Object Model used to represnt Web pages as classes and elemenst as variables. 
        // This helps to update the code 

        [FindsBy(How = How.Id, Using = "TitleId")]
        public IWebElement ddlTitleId { get; set; }

        [FindsBy(How = How.Name, Using = "Initial")]
        public IWebElement txtInitial { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.Name, Using = "MiddleName")]
        public IWebElement txtMiddleName { get; set; }

        [FindsBy(How = How.Name, Using = "Male")]
        public IWebElement rdbtnMale { get; set; }

        [FindsBy(How = How.Name, Using = "Female")]
        public IWebElement rdbtnFemale { get; set; }

        [FindsBy(How = How.Name, Using = "english")]
        public IWebElement checkEnglish { get; set; }

        [FindsBy(How = How.Name, Using = "Hindi")]
        public IWebElement checkHindi { get; set; }

        [FindsBy(How = How.Name, Using = "Save")]
        public IWebElement btnSave { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cssmenu']/ul/li[1]/a/span")]
        public IWebElement btnLogOut { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='details']/div[1]/p/a")]
        public IWebElement linkOpenpopup { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='cssmenu']/ul/li[4]/a/span")]
        public IWebElement listdragDrop { get; set; }

        public void fillUserForm(String Initial, String FirstName, String MiddleName, Gender G, Userlanguage UL )
        {
            txtInitial.SendKeys(Initial);
            txtFirstName.SendKeys(FirstName);
            txtMiddleName.SendKeys(MiddleName);

            if (G == Gender.Female)
            rdbtnFemale.Click();

            if (G == Gender.Male)
                rdbtnMale.Click();

            if (UL == Userlanguage.English)
                checkEnglish.Click();

            if (UL == Userlanguage.Hindi)
                checkHindi.Click();

           // btnSave.Submit();   
        }

        public void Logout()
        {
            btnLogOut.Click();
        }

        public void OpenHTMLPopup()
        {
            linkOpenpopup.Click();
            
        }

        public void ClickDragandDrop()
        {
            listdragDrop.Click();
        }

        public void FindItems(String FilePath, int number)
        {
            /*  loginPageObject PageLogin = new loginPageObject();
              EAPageObject pageEA = PageLogin.Login("execute", "automation");
              pageEA.ClickDragandDrop();
              */

            String String1 = System.IO.File.ReadAllText(FilePath);
            String[] ItemsIds = String1.Split(',');

            Boolean found;
            int i = 0;
            for (i = 0; i < number; i++)

            {
                found = PropertiesCollection.driver.FindElement(By.Id(ItemsIds[i])).Displayed;
                Assert.IsTrue(found);

                if (found == true)
                    Console.WriteLine(ItemsIds[i] + " is found. ");
            }
        }

    }
}
