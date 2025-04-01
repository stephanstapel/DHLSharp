# DHLSharp

[![NuGet](https://img.shields.io/nuget/v/DHLSharp.Client?color=yellow)](https://www.nuget.org/packages/DHLSharp.Client/)

**DHLSharp** is a C# library that provides an interface to the DHL API. It allows you to **create** and **track** shipments with DHL from within your .NET applications.

> ⚠️ This library is in an early stage of development. It has been validated only for the **German (DE)** market so far.

## Features

- 📦 Create shipments programmatically via the DHL API
- 🔍 Track existing shipments using tracking numbers
- 💡 Simple and fluent interface for integration in .NET projects
- 🇩🇪 Currently tested and validated for use in Germany

## Installation

Coming soon to NuGet!

For now, clone the repository and reference the project or compile it into your solution manually.

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

### Track a Shipment

```csharp
var trackingData = await api.TrackShipmentAsync("<parcelid>", "de"); // "de": optional parameter allows to specify output language
```

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
