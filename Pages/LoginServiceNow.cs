using Microsoft.Playwright;
namespace PlaywrightDemo_4_22_24;
using PlaywrightDemo_4_22_24;


public class LoginServiceNow
{
    private IPage _page;
     public LoginServiceNow(IPage page) => _page = page; //constructor single line expression


    // private readonly ILocator _lnkLogin;
    // private readonly ILocator _txtUserName;
    // private readonly ILocator _txtPassword;
    // private readonly ILocator _btnLogin;
    // private readonly ILocator _lnkEmployeeList; // Declare this locator
   
//put all elements in single body member
    private ILocator _lnkSignIn => _page.Locator("text=Sign in");
    private ILocator _txtEmail => _page.Locator("#email");
    private ILocator _btnNext => _page.Locator("text=Next");
    private ILocator _txtPassword => _page.Locator("#password");
    private ILocator _btnLogin => _page.Locator("xpath=//input[@type='submit']");
    private ILocator _btnSignIn => _page.Locator("xpath=//button[@id='password_submit_button' and @tabindex='0' and normalize-space(.)='Sign In']"); // Initialize this locator

   private ILocator _subtitleLocator => _page.Locator("dps-page-header:has-text('Welcome to ServiceNow!')");




//await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Blazedemo.png" });



    // public LoginPageEAAPP(IPage page)//regular constructor
    // {
    //     _page = page;
    //     _lnkLogin = _page.Locator("text=Login");
    //     _txtUserName = _page.Locator("xpath=//input[@id='UserName']");
    //     _txtPassword = _page.Locator("xpath=//input[@id='Password']");
    //     _btnLogin = _page.Locator("xpath=//input[@type='submit']");
    //     _lnkEmployeeList = _page.Locator("text=Employee List");
    //     _lnkLogout = _page.Locator("text=Logout"); 
    // }
    
    public async Task ClickLoginServiceNow() => await _lnkSignIn.ClickAsync();
    public async Task LoginServiceNowPOM(string email, string password)
    {
        await _txtEmail.FillAsync(email);
        await _btnNext.ClickAsync();
        await _txtPassword.FillAsync(password);
       // await _btnLogin.ClickAsync();
        await _btnSignIn.ClickAsync();
        
    }

     public async Task<bool> IsSubtitleDisplayedAsync() => await _subtitleLocator.IsVisibleAsync();

   // public async Task ClickLogOff() => await _lnkLogout.ClickAsync();
}





