using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SeleniumFirst
{
    enum PropertyType
    {
        Id,
        Name,
        Type,
        linkText,
        CssName,
        ClassName,
        XPath
        
    }

    enum Gender
    {
        Female,
        Male
    }

    enum Userlanguage
    {
        English,
        Hindi
    }
    class PropertiesCollection
    {
        public static IWebDriver driver { get; set; }
    }
}
