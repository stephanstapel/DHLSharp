# DHLSharp

[![NuGet](https://img.shields.io/nuget/v/DHLSharp.Client?color=yellow)](https://www.nuget.org/packages/DHLSharp.Client/)

**DHLSharp** is a C# library that provides an interface to the DHL API. It allows you to **create** and **track** shipments with DHL from within your .NET applications.

## Sponsoring
Implementing and maintaining this library is a lot of hard work. I'm doing this in my spare time, there is no company behind developing DHLSharp. Support me in this work and help making this library better:

[:heart: Sponsor me on GitHub](https://github.com/sponsors/stephanstapel)


## Features

- 📦 Create shipments programmatically via the DHL API
- 🔍 Track existing shipments using tracking numbers
- 💡 Simple and fluent interface for integration in .NET projects
- 🇩🇪 Currently tested and validated for use in Germany

## License
Subject to the Apache license http://www.apache.org/licenses/LICENSE-2.0.html

## Installation
Just use nuget or Visual Studio Package Manager and download 'DHLSharp.Client'.

You can find more information about the nuget package here:

[![NuGet](https://img.shields.io/nuget/v/DHLSharp.Client?color=yellow)](https://www.nuget.org/packages/DHLSharp.Client/)

https://www.nuget.org/packages/DHLSharp.Client/

You might also clone the repository and reference the project or compile it into your solution manually.

```bash
git clone https://github.com/stephanstapel/DHLSharp.git
```

## Getting Started

### Create a Shipment

```csharp
DHLClient client = new DHLClient(myConfiguration);
Shipment[] shipments = new[]
    {
    new Shipment
    {
        Product = ProductType.NationalPackage,         
        RefNo = "Order No. 1234",
        ShipDate = DateTime.Today,
        Shipper = new Shipper
        {
            Name1 = "My Online Shop GmbH",
            AddressStreet = "Sträßchensweg 10",
            PostalCode = "53113",
            City = "Bonn",
            Country = CountryCode.Germany,
            Email = "max@mustermann.de",
            Phone = "+49 123456789"
        },
        Consignee = new Consignee
        {
            Name = "Maria Musterfrau",
            PostNumber = "12345678",
            RetailID = "502",
            PostalCode = "53113",
            City = "Bonn",
            Country = CountryCode.Germany
        },
        Details = new Details
        {
            Dimensions = new Dimensions
            {
                Uom = "mm",
                Height = 100,
                Length = 200,
                Width = 150
            },
            Weight = new Weight
            {
                Uom = "g",
                Value = 500
            }
        }
    }
};
var result = await client.CreateShipmentAsync("STANDARD_GRUPPENPROFIL", shipments, validate: false);
```

In order to use this function, these configuration parameters need to be filled

* `DHLClientConfig.ApiKey`
* `DHLClientConfig.ApiSecret`
* `DHLClientConfig.Username`
* `DHLClientConfig.Password`

### Track a Shipment

```csharp
var trackingData = await client.TrackShipmentAsync("<parcelid>", "de"); // "de": optional parameter allows to specify output language
```

Please note that the API uses the Unified Shipment Tracking API. In order to call this function, only `DHLClientConfig.TrackingUnifiedApiKey` needs to be filled.

## Credential handling in the demo application
The component comes with a demo application which showcases the functionality of the component.

⚠️ The file `credentials.json` is **not part of the public repository**.  
Copy `credentials.template.json` into `credentials.json` and add the missing information. Alternatively, you can of course fill the DHLClientConfig structure manually.

## Limitations
* Only tested for Germany (DE) so far.
* Not production-ready for other DHL regions or products.
* Requires manual setup (e.g. credentials, integration logic).

## Contributing
Contributions are welcome! If you find issues or want to improve functionality, feel free to open a pull request or create an issue.
License

This project is licensed under the Apache 2.0 License.
