using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFirst
{
    class SeleniumMethods
    {


       public static void EnterText( String element, String value, PropertyType ElementType )
        {
            if (ElementType == PropertyType.Id)
                PropertiesCollection.driver.FindElement(By.Id(element)).SendKeys(value);

            if (ElementType == PropertyType.Name)
                PropertiesCollection.driver.FindElement(By.Name(element)).SendKeys(value);
        }

        public static void ClickElement ( String element, PropertyType ElementType)
        {
            if (ElementType == PropertyType.Id)
                PropertiesCollection.driver.FindElement(By.Id(element)).Click();

            if (ElementType == PropertyType.Name)
                PropertiesCollection.driver.FindElement(By.Name(element)).Click();
        }

        public static void SelectDropDown( String element, String value, PropertyType ElementType)
        {
            if (ElementType == PropertyType.Id)
                new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).SelectByText(value);
            if (ElementType == PropertyType.Name)
                new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).SelectByText(value);
        }

        public static String GetValueofTextbox ( String element, PropertyType ElementType)
        {
            String Text1;

            if (ElementType == PropertyType.Id)
             Text1 = PropertiesCollection.driver.FindElement(By.Id(element)).GetAttribute("value").ToString();

            if (ElementType == PropertyType.Name)

                Text1 = PropertiesCollection.driver.FindElement(By.Name(element)).GetAttribute("value").ToString();
            else Text1 = "not Found";

            return Text1;

         }
        public static String GetSelectedValueFromDropDown( String element, PropertyType ElementType)
        {
            if (ElementType == PropertyType.Id)
                return new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;

            if (ElementType == PropertyType.Name)
                return new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
            else return String.Empty;
        } 

        }
    }

