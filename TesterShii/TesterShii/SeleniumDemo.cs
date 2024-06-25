using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterShii
{
    internal class SeleniumDemo
    {
        public SeleniumDemo()
        {
            var _driver = new ChromeDriver();
            Thread.Sleep(2000);

            _driver.Navigate().GoToUrl("https://accounts.google.com/v3/signin/identifier?continue=https%3A%2F%2Fwww.youtube.com%2Fsignin%3Faction_handle_signin%3Dtrue%26app%3Ddesktop%26hl%3Dvi%26next%3Dhttps%253A%252F%252Fwww.youtube.com%252Fwatch%253Fv%253DANcDGrtdf9M%2526list%253DPLayYhLZuuO9tV9PV2yeNQXolPc7XXw_7o&ec=65620&hl=vi&ifkv=AS5LTAQxXgTrHrxF9lLtLIiN1vjPaqHabk0IRubhMVRSl8u0LnkxKjWGHf669v2tV3gZsw_v2NQzkA&passive=true&service=youtube&uilel=3&flowName=GlifWebSignIn&flowEntry=ServiceLogin&dsh=S386866153%3A1719288913681382&ddm=0");

            _driver.FindElement(By.Name("identifier")).SendKeys("daoxuanlong492004@gmail.com");
            
        }
        
    }
}
