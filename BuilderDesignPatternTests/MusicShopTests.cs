using System.Diagnostics;
using BuilderDesignPatternTests.Data.Builders;
using BuilderDesignPatternTests.Data.Factories;
using OpenQA.Selenium.Chrome;
using RepositoryDesignPatternTests.Data.Factories;
using RepositoryDesignPatternTests.Data.Repositories;
using RepositoryDesignPatternTests.Models;
using WebDriverManager.DriverConfigs.Impl;

namespace RepositoryDesignPatternTests;

[TestFixture]
public class MusicShopTests
{
    private IWebDriver _driver;
    private CustomerRepository _customerRepository;

    [SetUp]
    public void TestInit()
    {
        var artistRepository = new ArtistRepository(Urls.BASE_API_URL);
        var albumRepository = new AlbumRepository(Urls.BASE_API_URL);
        var trackRepository = new TrackRepository(Urls.BASE_API_URL);
        var customerRepository = new CustomerRepository(Urls.BASE_API_URL);
        var invoiceRepository = new InvoiceRepository(Urls.BASE_API_URL);
        var invoiceItemRepository = new InvoiceItemRepository(Urls.BASE_API_URL);

        // Manually create an artist
        var artist = ArtistFactory.GenerateArtist();
        artist.Name = "Artist Name";
        artist = artistRepository.Create(artist);

        for (int i = 0; i < 2; i++) // Assuming 2 albums
        {
            // Manually create an album
            var album = AlbumFactory.GenerateAlbum();
            album.Title = $"Album {i + 1}";
            album.ArtistId = artist.ArtistId;
            album = albumRepository.Create(album);

            for (int j = 0; j < 5; j++) // Assuming 5 tracks per album
            {
                // Manually create a track
                var track = TrackFactory.GenerateTrack();
                track.Name = $"Track {j + 1}";
                track.AlbumId = album.AlbumId;
                track = trackRepository.Create(track);

                for (int k = 0; k < 10; k++) // Assuming 10 customers per track
                {
                    // Manually create a customer
                    var customer = CustomerFactory.GenerateCustomer();
                    customer.FirstName = $"Customer {k + 1}";
                    customer.LastName = "Lastname";
                    customer.Email = $"customer{k + 1}@example.com";
                    customer.Phone = "555-0100+i";
                    customer = customerRepository.Create(customer);

                    // Manually create an invoice for the customer
                    var invoice = InvoiceFactory.GenerateInvoice();
                    invoice.CustomerId = customer.CustomerId;
                    invoice.InvoiceDate = DateTime.Now.ToShortDateString();
                    invoice = invoiceRepository.Create(invoice);

                    // Manually create an invoice item for the invoice and track
                    var invoiceItem = InvoiceItemFactory.GenerateInvoiceItem();
                    invoiceItem.InvoiceId = invoice.InvoiceId;
                    invoiceItem.TrackId = track.TrackId;
                    invoiceItem.Quantity = 1;
                    invoiceItem.UnitPrice = "9.99"; // Example unit price
                    invoiceItem = invoiceItemRepository.Create(invoiceItem);
                }
            }
        }

        _customerRepository = new CustomerRepository(Urls.BASE_API_URL);

        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();

        _driver.Navigate().GoToUrl(Urls.BASE_URL);
        _driver.Manage().Cookies.DeleteAllCookies();
    }

    [TearDown]
    public void TestCleanup()
    {
        _driver.Quit();
    }

    [Test]
    public void RightCustomersDisplayed_When_SearchViaUI()
    {
        //TestDataDirector director = new TestDataDirector(BuilderMode.Persistent);

        //// Now, use the director to create data with the complexity and relationships needed
        //Artist artist = director.CreateArtistWithDiscographyAndSales("New Artist", 3, 10, 100);

        // Arrange
        var customer1 = _customerRepository.Create(CustomerFactory.GenerateCustomer(lastName: "Doe", email: "john.doe@example.com"));
        var customer2 = _customerRepository.Create(CustomerFactory.GenerateCustomer(lastName: "Doe", email: "jane.doe@example.net"));

        var customersTab = _driver.FindElement(By.XPath("//a[text()='Customers']"));
        customersTab.Click();

        var customersSearchInput = _driver.FindElement(By.Id("searchCustomerQuery"));
        customersSearchInput.Clear();
        customersSearchInput.SendKeys("LastName:Doe;AND;Email:.com");


        var searchButton = _driver.FindElement(By.XPath("//button[text()='Search']"));
        searchButton.Click();

        var allHeaders = _driver.FindElements(By.XPath("//tbody[@id='customerList']/preceding-sibling::thead/tr/th")).Select(x => x.Text).ToList();
        int indexOfFirstName = allHeaders.FindIndex(0, allHeaders.Count, s => s.Equals("First Name")) + 1;
        int indexOfLastName = allHeaders.FindIndex(0, allHeaders.Count, s => s.Equals("Last Name")) + 1;
        int indexOfEmail= allHeaders.FindIndex(0, allHeaders.Count, s => s.Equals("Email")) + 1;

        var allLastNames = _driver.FindElements(By.XPath($"//tbody[@id='customerList']/tr/td[{indexOfLastName}]"));
        allLastNames.ToList().ForEach(s => Debug.WriteLine(s.Text));
        var allEmails = _driver.FindElements(By.XPath($"//tbody[@id='customerList']/tr/td[{indexOfEmail}]"));

        Assert.IsTrue(allLastNames.Any(c => c.Text.Contains("Doe")));
        Assert.IsTrue(allEmails.Any(c => c.Text.Contains(".com")));

        // Cleanup
        _customerRepository.Delete(customer1.CustomerId);
        _customerRepository.Delete(customer2.CustomerId);
    }
}
