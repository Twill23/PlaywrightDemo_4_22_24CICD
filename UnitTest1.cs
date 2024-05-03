using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
namespace PlaywrightDemo_4_22_24;

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

    [Test, Category("EAPPTestDemo")]

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
        await page.Locator("xpath=//input[@id='UserName']").FillAsync("adminT");
        await page.Locator("xpath=//input[@id='Password']").FillAsync("adminT1234567!");
        //I AM COMMENTING THIS OUT BUT THIS TAKES SCREEMSHOT FTER A STEP
//await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });

        // // Pause here to interact with the browser
        // Console.WriteLine("Press Enter to continue...");
        // Console.ReadLine();
    

        // Test code goes here

        Assert.Pass();
    }
}