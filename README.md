# Tellurium.StableElements
A set of Selenium extensions that solve  StaleElementReferenceException problem


## How it works

The whole concept behind this library is described in the article [No more StaleElementReferenceException](https://cezarypiatek.github.io/post/no-more-staleelementreferenceexception/)

## How to use it

Instead of using standard methods from `Selenium.WebDriver` package for searching web elements, use their counterparts from [Tellurium.StableElements](https://www.nuget.org/packages/Tellurium.StableElements/) nuget package:

|Original method | Stable counterpart|
|----------------|--------------------|
| `FindElement`| `FindStableElement`|
| `TryFindElement`| `TryFindStableElement`|

Example usage:

```cs
[Test]
public void should_be_able_to_run_selenium_and_reuse_stable_elements()
{
    using var driver = new ChromeDriver();
    driver.Navigate().GoToUrl("https://www.selenium.dev/");
    var pageHeader = driver.FindStableElement(By.Id("header"));
    pageHeader.FindStableElement(By.LinkText("Downloads")).Click();
    Thread.Sleep(4000);
    pageHeader.FindStableElement(By.LinkText("Projects")).Click();
    Thread.Sleep(4000);
}
```



