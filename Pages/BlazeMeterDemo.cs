using Microsoft.Playwright;
namespace PlaywrightDemo_4_22_24;
using PlaywrightDemo_4_22_24;


public class BlazeMeterDemo
{
    private IPage _page;
     public BlazeMeterDemo(IPage page) => _page = page; //constructor single line expression

    private ILocator _fromPort => _page.Locator("select[name='fromPort']");
    private ILocator _toPort => _page.Locator("select[name='toPort']");
    private ILocator _findFlightsButton => _page.Locator("//input[contains(@class, 'btn-primary') and @type='submit']");
    private ILocator _chooseSecondFlightButton => _page.Locator("xpath=(//input[@type='submit' and @value='Choose This Flight'])[2]");
    private ILocator _firstNameField => _page.Locator("xpath=//input[@id='inputName' and @placeholder='First Last']");
    private ILocator _addressField => _page.Locator("xpath=//input[@id='address' and @placeholder='123 Main St.']");
    private ILocator _cityField => _page.Locator("xpath=//input[@name='city' and @placeholder='Anytown']");
    private ILocator _stateField => _page.Locator("xpath=//input[@id='state' and @placeholder='State']");
    private ILocator _zipCodeField => _page.Locator("xpath=//input[@type='text' and @placeholder='12345']");
    private ILocator _creditCardNumberField => _page.Locator("xpath=//input[@id='creditCardNumber' and @placeholder='Credit Card Number']");
    private ILocator _creditCardMonthField => _page.Locator("xpath=//input[@id='creditCardMonth' and @placeholder='Month']");
    private ILocator _creditCardYearField => _page.Locator("xpath=//input[@id='creditCardYear' and @value='2017']");
    private ILocator _nameOnCardField => _page.Locator("xpath=//input[@id='nameOnCard' and @placeholder='John Smith']");
    private ILocator _purchaseFlightButton => _page.Locator("xpath=//input[@type='submit' and @value='Purchase Flight']");
    private ILocator _thankYouMessage => _page.Locator("text='Thank you for your purchase today!'");

    public async Task SelectDepartureCityAsync(string city) => await _fromPort.SelectOptionAsync(city);
    public async Task SelectDestinationCityAsync(string city) => await _toPort.SelectOptionAsync(new SelectOptionValue { Value = city });
    public async Task FindFlightsAsync() => await _findFlightsButton.ClickAsync();
    public async Task ChooseSecondFlightAsync() => await _chooseSecondFlightButton.ClickAsync();
    public async Task FillPassengerDetailsAsync(string firstName, string address, string city, string state, string zipCode, 
                                                string cardNumber, string month, string year, string nameOnCard)
    {
        await _firstNameField.FillAsync(firstName);
        await _addressField.FillAsync(address);
        await _cityField.FillAsync(city);
        await _stateField.FillAsync(state);
        await _zipCodeField.FillAsync(zipCode);
        await _creditCardNumberField.FillAsync(cardNumber);
        await _creditCardMonthField.FillAsync(month);
        await _creditCardYearField.FillAsync(year);
        await _nameOnCardField.FillAsync(nameOnCard);
    }
    public async Task PurchaseFlightAsync() => await _purchaseFlightButton.ClickAsync();
    public async Task<bool> IsThankYouMessageVisibleAsync() => await _thankYouMessage.IsVisibleAsync();
}
