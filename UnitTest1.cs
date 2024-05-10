using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
namespace PlaywrightDemo_4_22_24;

using System.Web;
using PlaywrightDemo_4_22_24;

public class Tests
{
    // This method is executed before each test case
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task SigninServiceNow()
    {
        using var playwright = await Playwright.CreateAsync();  // Create a new instance of Playwright

        await using var browser = await playwright.Chromium.LaunchAsync( new BrowserTypeLaunchOptions{
            Headless = true,
        });  // Launch a new Chromium browser instance

        var page = await browser.NewPageAsync();  // Create a new page in the browser

        await page.GotoAsync("https://developer.servicenow.com/dev.do");  // Navigate to the specified URL

        await page.ClickAsync("text=Sign in");  // Click on the element with the text "Sign in"
        // Assuming `page` is an instance of `IPage` that has been initialized appropriately
        await page.Locator("#email").FillAsync("williamstravis228@yahoo.com");
        //await Task.Delay(120000); // Waits for 10,000 milliseconds (10 seconds)


        // For buttons, you can use the role selector if using a Playwright version that supports it or use XPath/CSS selectors
        await page.ClickAsync("text=Next");
      // This assumes your Playwright version supports role selectors
        
        await page.Locator("#password").FillAsync("Nike loves Adidas1!!");
        //await Task.Delay(190000);

        await page.ClickAsync("xpath=//button[@id='password_submit_button' and @tabindex='0' and normalize-space(.)='Sign In']");
        //I AM COMMENTING THIS OUT BUT THIS TAKES SCREEMSHOT FTER A STEP
//await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });


  // Again, assuming role selector support


        Assert.Pass();  // Indicate that the test has passed
    }


    
    [Test, Category("SigninServiceNow2WithPOM")]
    public async Task SigninServiceNow2WithPOM()
    {
        using var playwright = await Playwright.CreateAsync();  // Create a new instance of Playwright

        await using var browser = await playwright.Chromium.LaunchAsync( new BrowserTypeLaunchOptions{
            Headless = true,
        });  // Launch a new Chromium browser instance

        var page = await browser.NewPageAsync();  // Create a new page in the browser

        await page.GotoAsync("https://developer.servicenow.com/dev.do");  // Navigate to the specified URL

        LoginServiceNow loginServiceNow = new LoginServiceNow(page);  // Create an instance of your page object model


        await loginServiceNow.ClickLoginServiceNow();
        await loginServiceNow.LoginServiceNowPOM("williamstravis228@yahoo.com", "Nike loves Adidas1!!");
        

       
        //I AM COMMENTING THIS OUT BUT THIS TAKES SCREEMSHOT FTER A STEP
//await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });


  // Again, assuming role selector support


        Assert.Pass();  // Indicate that the test has passed
    }


    [Test, Category("BlazedemoTest")]
    public async Task BlazedemoTest()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true,
        });

        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://blazedemo.com/");
        

        // Test code goes here
        // Select the 'Boston' option
        await page.SelectOptionAsync("//select[@name='fromPort']", "Boston");
        //await Task.Delay(10000);

        // Correct usage to select 'London' by value using XPath
await page.SelectOptionAsync("select[name='toPort']", new SelectOptionValue { Value = "London" });
// Using XPath to select the dropdown and then choosing the option by value
//await page.SelectOptionAsync("//select[@name='toPort']", new SelectOptionValue { Value = "London" });
// Using XPath to directly click the 'London' option
//await page.ClickAsync("//select[@name='toPort']/option[@value='London']");

//find flights
await page.ClickAsync("//input[contains(@class, 'btn-primary') and @type='submit']");

await page.ClickAsync("xpath=(//input[@type='submit' and @value='Choose This Flight'])[2]");
await page.Locator("xpath=//input[@id='inputName' and @placeholder='First Last']").FillAsync("Travis Williams");
await page.Locator("xpath=//input[@id='address' and @placeholder='123 Main St.']").FillAsync("989 Boss st");
await page.Locator("xpath=//input[@name='city' and @placeholder='Anytown']").FillAsync("Detroit");
await page.Locator("xpath=//input[@id='state' and @placeholder='State']").FillAsync("Michigan");
await page.Locator("xpath=//input[@type='text' and @placeholder='12345']").FillAsync("98765");
await page.Locator("xpath=//input[@id='creditCardNumber' and @placeholder='Credit Card Number']").FillAsync("098765432");
await page.Locator("xpath=//input[@id='creditCardMonth' and @placeholder='Month']").FillAsync("May");
await page.Locator("xpath=//input[@id='creditCardYear' and @value='2017']").FillAsync("2024");
await page.Locator("xpath=//input[@id='nameOnCard' and @placeholder='John Smith']").FillAsync("Travis Williams");
await page.ClickAsync("xpath=//input[@type='submit' and @value='Purchase Flight']");
//await page.PauseAsync();
//I AM COMMENTING THIS OUT BUT THIS TAKES SCREEMSHOT FTER A STEP
//await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });

 // Asserting the presence of the confirmation text
    //await Expect(page.Locator("h1")).ToHaveTextAsync("Thank you for your purchase today!");
    //await page.Locator("xpath=//*[contains(text(), 'Thank you for your purchase today!')]");
    var  useText  = await page.Locator("text='Thank you for your purchase today!'").IsVisibleAsync();
    var isExist = await page.Locator("xpath=//*[contains(text(), 'Thank you for your purchase today!')]").IsVisibleAsync();
    await page.Locator("xpath=//*[contains(text(), 'Thank you for your purchase today!')]").ClickAsync();





        

       // await Task.Delay(190000);
        Assert.IsTrue(useText);
        Assert.IsTrue(isExist);
        Assert.Pass();
}

[Test, Category("BlazedemoTestWithPOM")]
    public async Task BlazedemoTestWithPOM()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true,
        });

        var page = await browser.NewPageAsync();

        await page.GotoAsync("https://blazedemo.com/");
        
        // Make sure to include the using directive for your page object's namespace
         BlazeMeterDemo blazeMeterDemo = new BlazeMeterDemo(page);
         await blazeMeterDemo.SelectDepartureCityAsync("Boston");
         await blazeMeterDemo.SelectDestinationCityAsync("London");
         await blazeMeterDemo.FindFlightsAsync();
         await blazeMeterDemo.ChooseSecondFlightAsync();
         await blazeMeterDemo.FillPassengerDetailsAsync(
            "Travis Williams", "989 Boss st", "Detroit", "Michigan", "98765", "098765432", "May", "2024", "Travis Williams");

        // Test code goes here
        // Select the 'Boston' option
        //await page.SelectOptionAsync("//select[@name='fromPort']", "Boston");
        //await Task.Delay(10000);

        // Correct usage to select 'London' by value using XPath
        //await page.SelectOptionAsync("select[name='toPort']", new SelectOptionValue { Value = "London" });
        // Using XPath to select the dropdown and then choosing the option by value
        //await page.SelectOptionAsync("//select[@name='toPort']", new SelectOptionValue { Value = "London" });
        // Using XPath to directly click the 'London' option
        //await page.ClickAsync("//select[@name='toPort']/option[@value='London']");

        //find flights
        //await page.ClickAsync("//input[contains(@class, 'btn-primary') and @type='submit']");

        //await page.ClickAsync("xpath=(//input[@type='submit' and @value='Choose This Flight'])[2]");
        //await page.Locator("xpath=//input[@id='inputName' and @placeholder='First Last']").FillAsync("Travis Williams");
        //await page.Locator("xpath=//input[@id='address' and @placeholder='123 Main St.']").FillAsync("989 Boss st");
        //await page.Locator("xpath=//input[@name='city' and @placeholder='Anytown']").FillAsync("Detroit");
        //await page.Locator("xpath=//input[@id='state' and @placeholder='State']").FillAsync("Michigan");
        //await page.Locator("xpath=//input[@type='text' and @placeholder='12345']").FillAsync("98765");
        //await page.Locator("xpath=//input[@id='creditCardNumber' and @placeholder='Credit Card Number']").FillAsync("098765432");
        //await page.Locator("xpath=//input[@id='creditCardMonth' and @placeholder='Month']").FillAsync("May");
        //await page.Locator("xpath=//input[@id='creditCardYear' and @value='2017']").FillAsync("2024");
        //await page.Locator("xpath=//input[@id='nameOnCard' and @placeholder='John Smith']").FillAsync("Travis Williams");
        await blazeMeterDemo.PurchaseFlightAsync();
        //await page.ClickAsync("xpath=//input[@type='submit' and @value='Purchase Flight']");

        //I AM COMMENTING THIS OUT BUT THIS TAKES SCREEMSHOT FTER A STEP
        //await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });

        // Asserting the presence of the confirmation text
            //await Expect(page.Locator("h1")).ToHaveTextAsync("Thank you for your purchase today!");
            //await page.Locator("xpath=//*[contains(text(), 'Thank you for your purchase today!')]");
        // var  useText  = await page.Locator("text='Thank you for your purchase today!'").IsVisibleAsync();
        // var isExist = await page.Locator("xpath=//*[contains(text(), 'Thank you for your purchase today!')]").IsVisibleAsync();
        // await page.Locator("xpath=//*[contains(text(), 'Thank you for your purchase today!')]").ClickAsync();

        await blazeMeterDemo.IsThankYouMessageVisibleAsync();

        //await page.PauseAsync();





        

       // await Task.Delay(190000);
       // Assert.IsTrue(useText);
        //Assert.IsTrue(isExist);
       // Assert.Pass();

    }
    [Test, Category("EAPPTestDemo2")]

    public async Task EAPPTestDemo()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true,
        });

        var page = await browser.NewPageAsync();

      

        await page.GotoAsync("http://www.eaapp.somee.com/");
        await page.ClickAsync("text=Login");
        await page.Locator("xpath=//input[@id='UserName']").FillAsync("adminT2");
        await page.Locator("xpath=//input[@id='Password']").FillAsync("adminT1234567!");
        
       // await page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
        await page.ClickAsync("xpath=//input[@type='submit']");
        var isExist = await page.Locator("text='Employee List'").IsVisibleAsync();
        Assert.IsTrue(isExist);
        //await page.PauseAsync();
        await page.GetByRole(AriaRole.Link, new() { Name = "Log off" }).ClickAsync();
        //I AM COMMENTING THIS OUT BUT THIS TAKES SCREEMSHOT FTER A STEP
//await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });

        // // Pause here to interact with the browser
        // Console.WriteLine("Press Enter to continue...");
        // Console.ReadLine();
    

        // Test code goes here

        Assert.Pass();
    }





[Test, Category("EAPPTestDemo2WithPOM")]
public async Task EAPPTestDemoWithPOM()
{
    using var playwright = await Playwright.CreateAsync();
    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    {
        Headless = true,
    });

    var page = await browser.NewPageAsync();

    await page.GotoAsync("http://www.eaapp.somee.com/");

    // Make sure to include the using directive for your page object's namespace
    LoginPageEAAPP loginPageEAAPP = new LoginPageEAAPP(page);
    await loginPageEAAPP.ClickLoginEAAPP();
    await loginPageEAAPP.LoginEAAPP("adminT2", "adminT1234567!");
    
    // Using the page object's method to check for visibility of the Employee List
    var isExist = await loginPageEAAPP.IsEmployeeListExist();
    Assert.IsTrue(isExist);
    
    // Correct way to click on "Log off" using role and name
    //await page.Locator("role=link[name='Log off']").ClickAsync();
    await loginPageEAAPP.ClickLogOff();

    // If you want to uncomment this for a screenshot, it should work fine
    // await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });

    // Console interaction (if needed)
    // Console.WriteLine("Press Enter to continue...");
    // Console.ReadLine();
    
    Assert.Pass();
}



[Test, Category("EAPPTestDemo2WithPOMEventDriven")]
public async Task EAPPTestDemo2WithPOMEventDriven()
{
    using var playwright = await Playwright.CreateAsync();
    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    {
        Headless = true,
    });

    var page = await browser.NewPageAsync();

    await page.GotoAsync("http://www.eaapp.somee.com/");

    // Make sure to include the using directive for your page object's namespace
    EventDrivenEAAPP eventDrivenEAAPP = new EventDrivenEAAPP(page);
    await eventDrivenEAAPP.ClickEventEAAPP();
    await eventDrivenEAAPP.LoginEventDrivenEAAPP("adminT2", "adminT1234567!");
    
    
    // Using the page object's method to check for visibility of the Employee List
    var isExist = await eventDrivenEAAPP.IsEmployeeListExist();
    Assert.IsTrue(isExist);
    
    // Correct way to click on "Log off" using role and name
    //await page.Locator("role=link[name='Log off']").ClickAsync();
    await eventDrivenEAAPP.ClickLogOff();
    
    // If you want to uncomment this for a screenshot, it should work fine
    // await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });

    // Console interaction (if needed)
    // Console.WriteLine("Press Enter to continue...");
    // Console.ReadLine();
    
    Assert.Pass();
}




[Test, Category("TestNetworkAPIPOMEventDriven")]
public async Task TestNetworkAPIPOMEventDriven()
{
    using var playwright = await Playwright.CreateAsync();
    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    {
        Headless = true  // Consider toggling this based on environment or debug needs
    });

    var page = await browser.NewPageAsync();
    await page.GotoAsync("http://www.eaapp.somee.com/");

    EventDrivenEAAPP eventDrivenEAAPP = new EventDrivenEAAPP(page);
    await eventDrivenEAAPP.ClickEventEAAPP();  // Login

    // Wait for the response of the Employee data after clicking the Employee list
    var waitResponse = page.WaitForResponseAsync("**/Employee");

    // Click on the Employee List to trigger the request
    await eventDrivenEAAPP.ClickEmployeeList();

    // Get the response from the awaited task
    var response = await waitResponse;

    // Print response details to console
    Console.WriteLine($"Response URL: {response.Url}");
    Console.WriteLine($"Response Status: {response.Status}");
    Console.WriteLine($"Response Status Text: {response.StatusText}");

    // Optionally, if you want to read and print the response body
    var responseBody = await response.BodyAsync();
    Console.WriteLine($"Response Body: {System.Text.Encoding.UTF8.GetString(responseBody)}");

    // Using the page object's method to check for visibility of the Employee List
    var isExist = await eventDrivenEAAPP.IsEmployeeListExist();
    Assert.IsTrue(isExist, "The employee list should be visible but was not.");

    // Further actions if required
    // await eventDrivenEAAPP.ClickLogOff();

    Assert.Pass("Test passed successfully.");
}


// [Test, Category("flipKartAPI")]
// public async Task Flipkart()
// {
//     using var playwright = await Playwright.CreateAsync();
//     await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
//     {
//         Headless = false  // Consider toggling this based on environment or debug needs
//     });

//     var contex = await browser.NewContextAsync();

//     var page = await browser.NewPageAsync();

//     await page.GotoAsync("https://www.flipkart.com/", new PageGotoOptions
//     {
//         WaitUntil = WaitUntilState.NetworkIdle,
//     });

//     //await page.Locator("a", new PageLocatorOptions{HasTextString = "Login"}).ClickAsync();

//     //await page.Locator("xpath=//span[contains(text(), 'Login')]").ClickAsync();
//     //await page.GetByRole(AriaRole.Link, new() { Name = "Image Image Galaxy F15 5G" }).ClickAsync();

        

//     var response = await page.RunAndWaitForRequestAsync(async () =>
// {
//     await page.GetByRole(AriaRole.Link, new() { Name = "Image Image Galaxy F15 5G" }).ClickAsync();
// }, request =>
// {
//     // Logging the URL and the HTTP method
//     Console.WriteLine($"Request URL: {request.Url}");
//     Console.WriteLine($"HTTP Method: {request.Method}");

//     // Check if the URL contains the specific substring and the method is GET
//     bool isUrlMatch = request.Url.Contains("3Dmobiles");
//     bool isMethodGet = request.Method == "GET";

//     // Optionally log the result of the checks
//     Console.WriteLine($"URL contains '3Dmobiles': {isUrlMatch}");
//     Console.WriteLine($"Method is GET: {isMethodGet}");

//     return isUrlMatch && isMethodGet;
// });

   

    
// ///await page.PauseAsync();

   

// Assert.Pass("Test passed successfully.");
// }


}