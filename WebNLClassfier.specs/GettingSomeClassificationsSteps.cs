using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using TechTalk.SpecFlow;

namespace WebNLClassfier.specs
{
    [Binding]
    public class GettingSomeClassificationsSteps
    {
        private ChromeDriver _driver;
        private const string TEXT_INPUT_ID = "textInput";

        [BeforeScenario]
        public void FixtureSetUp()
        {
            var chromeDriverDirectory = string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\..\..\packages\WebDriver.ChromeDriver.win32.2.21.0.0\content\");
            _driver = new ChromeDriver(chromeDriverDirectory);
        }

        [AfterScenario]
        public void FixtureTearDown()
        {
            _driver.Dispose();
            _driver = null;
        }

        [Given(@"The user is on the index page")]
        public void GivenTheUserIsOnTheIndexPage()
        {
            _driver.Navigate().GoToUrl("http://localhost:51981/");
        }

        [Given(@"they enter the sentence (.*)")]
        public void GivenTheyEnterTheSentence(string sentence)
        {
            _driver.FindElementById(TEXT_INPUT_ID).SendKeys(sentence);
        }

        [When(@"the button labelled ""(.*)"" is clicked")]
        public void WhenTheButtonLabelledIsClicked(string buttonLabel)
        {
            if (buttonLabel == "classify")
            {
                var buttonId = "classfiyButton";
                 _driver.FindElementById(buttonId).Click();
            }
        }

        [Then(@"some text should be returned")]
        public void ThenSomeTextShouldBeReturned()
        {
            var value = _driver.FindElementById("modelData").Text;

            var timeOut = DateTime.Now.AddSeconds(2);

            while(DateTime.Now < timeOut)
            {
                Thread.SpinWait(1000);
            }

            Assert.IsNotNullOrEmpty(value);
        }


    }
}
