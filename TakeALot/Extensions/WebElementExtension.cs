
using TakeALot.CoreUI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TakeALot.Extensions
{
    public static class WebElementExtension
    {
        public static bool WaitUntilDisplayed(this IWebElement e, int timeout = 240)
        {
            return WaitHandler(e, timeout, ElementOptions.Displayed);
        }

        private enum ElementOptions
        {
            Displayed,
            NotDisplayed,
            Enabled,
            SelectOptionDisplayed
        }

        public static bool WaitUntilNotDisplayed(this IWebElement e, int timeout = 10)
        {
            return e == null || WaitHandler(e, timeout, ElementOptions.NotDisplayed);
        }

        public static bool WaitUntilEnabled(this IWebElement e, int timeout = 60)
        {
            return WaitHandler(e, timeout, ElementOptions.Enabled);
        }

        private static bool WaitHandler(IWebElement e, int timeout, ElementOptions option, string text = "")
        {
            var watch = new Stopwatch();
            var driver = WebDriverSupport.SupportDriver();
            var result = false;
            watch.Start();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (watch.Elapsed.TotalMilliseconds <= timeout.ToMilliseconds() && !result)
            {
                try
                {
                    switch (option)
                    {
                        case ElementOptions.Displayed:
                            if (e.Displayed)
                            {
                                result = true;
                            }

                            break;
                        case ElementOptions.NotDisplayed:
                            if (e == null || !e.Displayed)
                            {
                                result = true;
                            }

                            break;
                        case ElementOptions.Enabled:
                            if (e.Enabled)
                            {
                                result = true;
                            }

                            break;
                        case ElementOptions.SelectOptionDisplayed:
                            if (e.FindElements(By.TagName("option")).Count(x => x.Text.Contains(text)) > 0)
                            {
                                result = true;
                            }

                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(option), option, null);
                    }

                }
                catch (NoSuchElementException)
                {
                    if (option == ElementOptions.NotDisplayed) result = true;
                }
                catch (StaleElementReferenceException)
                {
                    if (option == ElementOptions.NotDisplayed) result = true;
                }
                catch
                {
                    //Ignored
                }
            }

            // if (watch.Elapsed.Seconds > 1) Log.Info($"Waited for {watch.Elapsed.Seconds} seconds for the element state {option}");

            return result;
        }

        public static void ClickElement(this IWebElement e)
        {
            try
            {
                WaitUntilDisplayed(e);
                e.Click();
            }
            catch (TargetInvocationException)
            {
                //TODO make this more realistic for chrome.
                IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriverSupport.SupportDriver();
                executor.ExecuteScript("arguments[0].click();", e);
            }
            catch (ElementClickInterceptedException)
            {
                //TODO make this more realistic for chrome.
                IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriverSupport.SupportDriver();
                executor.ExecuteScript("arguments[0].click();", e);
            }
            catch (ElementNotInteractableException)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriverSupport.SupportDriver();
                executor.ExecuteScript("arguments[0].click();", e);
            }
        }
        public static void EnterTextIntoField(IWebElement element, string text, bool clearBeforeTyping = true)
        {
            WaitUntilDisplayed(element);
            if (clearBeforeTyping) element.Clear();
            element.SendKeys(text);
        }


    }
}
