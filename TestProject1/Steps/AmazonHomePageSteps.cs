using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProject1.Steps
{
    [Binding]
    public class AmazonHomePageSteps 
    {
        private IWebDriver driver = null ;
        private string homeTitle = null;
        private string amazonLogo = "nav-logo-sprites";

        [Given(@"I open the web application")]
        public void GivenIOpenTheWebApplication()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.amazon.co.uk");
            driver.FindElement(By.Id("sp-cc-accept")).Click();


        }

        [When(@"I Get the page title")]
        public void WhenIGEtThePageTitle()
        {
            this.homeTitle = driver.Title;
        }
        
        [Then(@"It should contain ""(.*)""")]
        public void ThenItShouldContain(string title)
        {
            Assert.AreEqual(homeTitle, title);
        }

        [Given(@"I am on amazon homepage")]
        public void GivenIAmOnAmazonHomepage()
        {
            GivenIOpenTheWebApplication();
        }

        [When(@"I check for amazon logo")]
        public void WhenICheckForAmazonLogo()
        {
            

            Assert.AreEqual(true, driver.FindElement(By.Id("nav-logo-sprites")).Displayed);

        }

        [Then(@"I should see the correct amazon logo with the right page layout")]
        public void ThenIShouldSeeTheCorrectAmazonLogoWithTheRightPageLayout()
        {
            WhenICheckForAmazonLogo();
            Assert.AreEqual(true, driver.FindElement(By.Id("a-page")).Displayed);

            
        }

        [When(@"I search for Harry Potter and the Cursed Child in section books")]
        public void WhenISearchFor()
        {
            GivenIAmOnAmazonHomepage();
            driver.FindElement(By.Id("searchDropdownBox")).Click();
            driver.FindElement(By.Id("searchDropdownBox")).SendKeys("Books" + Keys.Enter);
            driver.FindElement(By.Id("twotabsearchtextbox")).Click();
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("Harry Potter and the Cursed Child");
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
        }

        [Then(@"I should see the result for Harry Potter and the Cursed Child")]
        public void ThenIShouldSeeTheResult()
        {
            
            Assert.AreEqual(true, driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div[1]/div/span[3]/div[2]/div[2]/div/span/div/div/div[2]/div[2]/div/div/div[1]/h2/a/span")).Displayed);
           
        
        }
        [Then(@"It has a badge “Best Seller”")]
        public void ThenItHasABadgeBestSeller()
        {
            ThenIShouldSeeTheResult();
        }

        [Then(@"Selected type is Paperback")]
        public void ThenSelectedTypeIsPaperback()
        {
            Assert.AreEqual(true, driver.FindElement(By.LinkText("Paperback")).Displayed);

        }

        [Then(@"the price is £(.*)")]
        public void ThenThePriceIs(Decimal p0)
        {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("#a-autoid-11-announce > span.a-color-base > span")).Displayed);


        }
        [Given(@"I should see the result for Harry Potter and the Cursed Child")]
        public void GivenIShouldSeeTheResultForHarryPotterAndTheCursedChild()
        {
            ThenIShouldSeeTheResult();
        }

        [When(@"I select the first result")]
        public void WhenISelectTheFirstResult()
        {
            driver.FindElement(By.CssSelector("#search > div.s-desktop-width-max.s-desktop-content.s-opposite-dir.sg-row > div.s-matching-dir.sg-col-16-of-20.sg-col.sg-col-8-of-12.sg-col-12-of-16 > div > span:nth-child(4) > div.s-main-slot.s-result-list.s-search-results.sg-row > div:nth-child(2) > div > span > div > div > div:nth-child(2) > div.sg-col.sg-col-4-of-12.sg-col-8-of-16.sg-col-12-of-20 > div > div > div.a-section.a-spacing-none.s-title-instructions-style > h2 > a > span")).Click();
        }

        [Then(@"I should be taken to the book details")]
        public void ThenIShouldBeTakenToTheBookDetails()
        {
            
            Assert.AreEqual(true, driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[5]/div[1]/div[5]/div[1]/div[1]")).Displayed);
        }

        [Then(@"I should see the correct title")]
        public void ThenIShouldSeeTheCorrectTitle()
        {
            Assert.AreEqual(true, driver.FindElement(By.Id("productTitle")).Displayed);
        }

        [Then(@"I should see the correct badge")]
        public void ThenIShouldSeeTheCorrectBadge()
        {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("#zeitgeistBadge_feature_div > div > a > i")).Displayed);
        }

        [Then(@"I should see the correct price")]
        public void ThenIShouldSeeTheCorrectPrice()
        {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("#a-autoid-11-announce > span.a-color-base > span")).Displayed);
        }

        [Then(@"I should see that type is Paperback")]
        public void ThenIShouldSeeThatTypeIsPaperback()
        {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("#a-autoid-11-announce > span:nth-child(1)")).Displayed);
        }

        [Given(@"I am already on the book details page")]
        public void GivenIAmAlreadyOnTheBookDetailsPage()
        {
            ThenIShouldBeTakenToTheBookDetails();
        }

        [When(@"I add the book to the basket")]
        public void WhenIAddTheBookToTheBasket()
        {
            GivenIAmAlreadyOnTheBookDetailsPage();
            driver.FindElement(By.Id("add-to-cart-button")).Click();
        }

        [Then(@"I should see a notification that the book has been added to the basket")]
        public void ThenIShouldSeeANotificationThatTheBookHasBeenAddedToTheBasket()
        {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("#nav-cart-count")).Displayed);
        }

        [Then(@"I should see the title Added to basket")]
        public void ThenIShouldSeeTheTitleAddedToBasket()
        {
            
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("#sw-atc-details-single-container > div.a-section.a-padding-medium.sw-atc-message-section > div > span")).Displayed);

        }

        [Then(@"I should also see that there is one item in the basket")]
        public void ThenIShouldAlsoSeeThatThereIsOneItemInTheBasket()
        {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("#sc-subtotal-label-activecart")).Displayed);
        }

        [Given(@"I have selected the basket")]
        public void GivenIHaveSelectedTheBasket()
        {
            driver.FindElement(By.Id("nav-cart-text-container")).Click();
        }

        [When(@"I am on edit basket page")]
        public void WhenIAmOnEditBasketPage()
        {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("#sc-active-cart > div")).Displayed);

        }

        [Then(@"I should see the book on the list")]
        public void ThenIShouldSeeTheBookOnTheList()
        {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("# sc-item-C2f5dd545-5ddc-4ce2-aba0-bc2cde17ca6b > div.sc-list-item-content > div > div.a-column.a-span10 > div > div > div.a-fixed-left-grid-col.a-col-right > ul > li:nth-child(1) > span > a > span.a-size-medium.a-color-base.sc-product-title > span > span.a-truncate-cut")).Displayed);

        }

        [Then(@"I should see the title,")]
        public void ThenIShouldSeeTheTitle()
        {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("# sc-item-C2f5dd545-5ddc-4ce2-aba0-bc2cde17ca6b > div.sc-list-item-content > div > div.a-column.a-span10 > div > div > div.a-fixed-left-grid-col.a-col-right > ul > li:nth-child(1) > span > a > span.a-size-medium.a-color-base.sc-product-title > span > span.a-truncate-cut")).Displayed);
        }

        [Then(@"I should see the type of print is Paperback")]
        public void ThenIShouldSeeTheTypeOfPrintIsPaperback()
        {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("# sc-item-C2f5dd545-5ddc-4ce2-aba0-bc2cde17ca6b > div.sc-list-item-content > div > div.a-column.a-span10 > div > div > div.a-fixed-left-grid-col.a-col-right > ul > li:nth-child(3) > span > span")).Displayed);
        }

        [Then(@"I should see price is £(.*),")]
        public void ThenIShouldSeePriceIs(Decimal p0)
        {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("#sc-item-C2f5dd545-5ddc-4ce2-aba0-bc2cde17ca6b > div.sc-list-item-content > div > div.a-column.a-span2.a-text-right.sc-item-right-col.a-span-last > p > span")).Displayed);
        }

        [Then(@"I should see that the quantity is (.*),")]
        public void ThenIShouldSeeThatTheQuantityIs(int p0)
        {

            Assert.AreEqual(true, driver.FindElement(By.CssSelector("# sc-item-C2f5dd545-5ddc-4ce2-aba0-bc2cde17ca6b > div.sc-list-item-content > div > div.a-column.a-span10 > div > div > div.a-fixed-left-grid-col.a-col-right > div.a-row.sc-action-links > span.sc-action-quantity > span")).Displayed);

        }

        [Then(@"I should also see that the total price is £(.*)")]
        public void ThenIShouldAlsoThatTheTotalPriceIs(Decimal p0)
        {
            Assert.AreEqual(true, driver.FindElement(By.CssSelector("#sc-subtotal-amount-buybox")).Displayed);

            driver.Quit();
        }


    }
}
