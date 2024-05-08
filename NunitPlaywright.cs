using NUnit.Framework;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightDemo_4_22_24;
//this is the correct WAY TI RUN PLAYWRIGHT TEST WITHOUT NUNIT INHERITANCE 
public class NunitPlaywright : PageTest
{
    // This method is executed before each test case
    [SetUp]
    public void Setup() 
    {
        
        
    }

    [Test, Category("Integration")]
    public async Task SigninServiceNow()
    {
        Page.SetDefaultTimeout(40000);
      


        await Page.GotoAsync("https://developer.servicenow.com/dev.do", new PageGotoOptions{
            WaitUntil = WaitUntilState.Load
        });  // Navigate to the specified URL
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Build apps that solve" })).ToBeVisibleAsync();

        await Page.ClickAsync("text=Sign in");  // Click on the element with the text "Sign in"
        // Assuming `Page` is an instance of `IPage` that has been initialized appropriately
        await Page.Locator("#email").FillAsync("williamstravis228@yahoo.com");
        //await Task.Delay(120000); // Waits for 10,000 milliseconds (10 seconds)


        // For buttons, you can use the role selector if using a Playwright version that supports it or use XPath/CSS selectors
        await Page.ClickAsync("text=Next");
      // This assumes your Playwright version supports role selectors
        
        await Page.Locator("#password").FillAsync("Nike loves Adidas1!!");
        //await Task.Delay(190000);

        await Page.ClickAsync("xpath=//button[@id='password_submit_button' and @tabindex='0' and normalize-space(.)='Sign In']");
        //I AM COMMENTING THIS OUT BUT THIS TAKES SCREEMSHOT FTER A STEP
//await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });


  // Again, assuming role selector support


        Assert.Pass();  // Indicate that the test has passed
    }

    [Test, Category("BlazedemoTest2")]
    public async Task BlazedemoTest()
    {
        
        await Page.GotoAsync("https://blazedemo.com/");


        // Test code goes here
        // Select the 'Boston' option
        await Page.SelectOptionAsync("//select[@name='fromPort']", "Boston");
        //await Task.Delay(10000);

        // Correct usage to select 'London' by value using XPath
await Page.SelectOptionAsync("select[name='toPort']", new SelectOptionValue { Value = "London" });
// Using XPath to select the dropdown and then choosing the option by value
//await Page.SelectOptionAsync("//select[@name='toPort']", new SelectOptionValue { Value = "London" });
// Using XPath to directly click the 'London' option
//await Page.ClickAsync("//select[@name='toPort']/option[@value='London']");

//find flights
await Page.ClickAsync("//input[contains(@class, 'btn-primary') and @type='submit']");

await Page.ClickAsync("xpath=(//input[@type='submit' and @value='Choose This Flight'])[2]");
await Page.Locator("xpath=//input[@id='inputName' and @placeholder='First Last']").FillAsync("Travis Williams");
await Page.Locator("xpath=//input[@id='address' and @placeholder='123 Main St.']").FillAsync("989 Boss st");
await Page.Locator("xpath=//input[@name='city' and @placeholder='Anytown']").FillAsync("Detroit");
await Page.Locator("xpath=//input[@id='state' and @placeholder='State']").FillAsync("Michigan");
await Page.Locator("xpath=//input[@type='text' and @placeholder='12345']").FillAsync("98765");
await Page.Locator("xpath=//input[@id='creditCardNumber' and @placeholder='Credit Card Number']").FillAsync("098765432");
await Page.Locator("xpath=//input[@id='creditCardMonth' and @placeholder='Month']").FillAsync("May");
await Page.Locator("xpath=//input[@id='creditCardYear' and @value='2017']").FillAsync("2024");
await Page.Locator("xpath=//input[@id='nameOnCard' and @placeholder='John Smith']").FillAsync("Travis Williams");
await Page.ClickAsync("xpath=//input[@type='submit' and @value='Purchase Flight']");
//await Page.PauseAsync();
//I AM COMMENTING THIS OUT BUT THIS TAKES SCREEMSHOT FTER A STEP
//await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });

 // Asserting the presence of the confirmation text with playwright built in assertion
    await Expect(Page.Locator("h1")).ToHaveTextAsync("Thank you for your purchase today!");
     await Expect(Page.Locator("xpath=//*[contains(text(), 'Thank you for your purchase today!')]")).ToHaveTextAsync("Thank you for your purchase today!");

     //this assertion is Nuit
    var  useText  = await Page.Locator("text='Thank you for your purchase today!'").IsVisibleAsync();
    var isExist = await Page.Locator("xpath=//*[contains(text(), 'Thank you for your purchase today!')]").IsVisibleAsync();
    await Page.Locator("xpath=//*[contains(text(), 'Thank you for your purchase today!')]").ClickAsync();





        

       // await Task.Delay(190000);
        Assert.IsTrue(useText);
        Assert.IsTrue(isExist);
        Assert.Pass();
}

    [Test, Category("EAPPTestDemo")]

    public async Task EAPPTestDemo()
    {
       
    await Page.GotoAsync("http://www.eaapp.somee.com/", new PageGotoOptions
    {WaitUntil = WaitUntilState.DOMContentLoaded});
   // await Page.ClickAsync("text=Login");
    var lnklgin = Page.Locator("text=Login");
    await lnklgin.ClickAsync();
    await Page.Locator("xpath=//input[@id='UserName']").FillAsync("adminT");
    await Page.Locator("xpath=//input[@id='Password']").FillAsync("adminT1234567!");
    //I AM COMMENTING THIS OUT BUT THIS TAKES SCREEMSHOT FTER A STEP
    //await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });

    // // Pause here to interact with the browser
    // Console.WriteLine("Press Enter to continue...");
    // Console.ReadLine();


    // Test code goes here

    Assert.Pass();

    }

    [Test, Category("Tiffany_Jewlery")]

    public async Task Tiffany_Jewlery()
    {
       
    await Page.GotoAsync("https://www.tiffany.com/");
    // ///await Page.GetByLabel("My Account").GetByLabel("animation").ClickAsync();
    // await Page.GetByRole(AriaRole.Link, new() { Name = "Register" }).ClickAsync();
    // await Page.GetByRole(AriaRole.Link, new() { Name = "Jewelry", Exact = true }).ClickAsync();
    // //await Page.FrameLocator("iframe[title=\"Sign Up via Text for Offers\"]").GetByTestId("closeIcon").ClickAsync();
    // await Page.GetByRole(AriaRole.Link, new() { Name = "Necklaces & Pendants" }).ClickAsync();
    // await Page.GetByRole(AriaRole.Link, new() { Name = "Gifts", Exact = true }).ClickAsync();
    // await Page.GetByRole(AriaRole.Link, new() { Name = "Love & Engagement" }).ClickAsync();
    // await Page.GetByRole(AriaRole.Link, new() { Name = "Fine Watches" }).ClickAsync();
    // await Page.GetByRole(AriaRole.Link, new() { Name = "Home & Accessories" }).ClickAsync();
    // await Page.GetByRole(AriaRole.Link, new() { Name = "Fragrance", Exact = true }).ClickAsync();
    // await Page.GetByRole(AriaRole.Link, new() { Name = "Men’s" }).ClickAsync();
    // await Page.GetByRole(AriaRole.Link, new() { Name = "Men’s", Exact = true }).ClickAsync();
    // await Page.GetByRole(AriaRole.Navigation).GetByText("Stories", new() { Exact = true }).ClickAsync();
    //I AM COMMENTING THIS OUT BUT THIS TAKES SCREEMSHOT FTER A STEP
    //await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });

    // // Pause here to interact with the browser
    // Console.WriteLine("Press Enter to continue...");
    // Console.ReadLine();


    // Test code goes here
    //await Page.PauseAsync();

    Assert.Pass();

    }
}