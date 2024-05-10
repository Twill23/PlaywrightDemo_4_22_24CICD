using Microsoft.Playwright;
namespace PlaywrightDemo_4_22_24;
using PlaywrightDemo_4_22_24;


public class EventDrivenEAAPP
{
    private IPage _page;
     public EventDrivenEAAPP(IPage page) => _page = page; //constructor single line expression


    // private readonly ILocator _lnkLogin;
    // private readonly ILocator _txtUserName;
    // private readonly ILocator _txtPassword;
    // private readonly ILocator _btnLogin;
    // private readonly ILocator _lnkEmployeeList; // Declare this locator
   
//put all elements in single body member
    private ILocator _lnkLogin => _page.Locator("text=Login");
    private ILocator _txtUserName => _page.Locator("xpath=//input[@id='UserName']");
    private ILocator _txtPassword => _page.Locator("xpath=//input[@id='Password']");
    private ILocator _btnLogin => _page.Locator("xpath=//input[@type='submit']");
    private ILocator _lnkEmployeeList => _page.Locator("text=Employee List"); // Initialize this locator
    private ILocator _lnkLogout => _page.Locator("role=link[name='Log off']"); // Declare this locator



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
    
   

   public async Task ClickEventEAAPP()
{
    Console.WriteLine("About to click the login link...");
    await _lnkLogin.ClickAsync();
    Console.WriteLine("Clicked the login link, now waiting for navigation...");
    await _page.WaitForURLAsync("**/Login", new PageWaitForURLOptions { Timeout = 60000 });
    Console.WriteLine("Navigation complete.");

}

    public async Task ClickEmployeeList() => await _lnkEmployeeList.ClickAsync();


    
   
    public async Task LoginEventDrivenEAAPP(string userName, string password)
    {
        await _txtUserName.FillAsync(userName);
        await _txtPassword.FillAsync(password);
        await _btnLogin.ClickAsync();
    }

    public async Task<bool> IsEmployeeListExist() => await _lnkEmployeeList.IsVisibleAsync();

    public async Task ClickLogOff() => await _lnkLogout.ClickAsync();
}
