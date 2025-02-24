# LiveTrains

LiveTrains is a Blazor Server application that provides real-time train information using APIs from the RailData marketplace. Built with Blazor Bootstrap, it offers a modern and responsive user interface for tracking live train movements across the UK.

## Features

- Real-time train tracking using RailData marketplace APIs
- Modern UI built with Blazor Bootstrap
- Server-side rendering for efficient performance
- User-friendly interface for easy navigation

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- .NET SDK (latest version recommended)
- Visual Studio or VS Code with Blazor support
- API keys from the RailData marketplace for the following subscriptions:
  - [Live Departure Board](https://raildata.org.uk/dataProduct/P-d81d6eaf-8060-4467-a339-1c833e50cbbe/overview)
  - [Reference Data](https://raildata.org.uk/dashboard/dataProduct/P-c73f0d2a-c233-497d-846b-8354e2cac326/overview)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/LiveTrains.git
   cd LiveTrains
   ```

2. Configure API access:
   - Obtain API keys from the RailData marketplace.
   - Add them to your user secrets file for the LiveTrains project:
     ```json
     {
       "RailData": {
         "LADB": {
           "ApiKey": "YOUR_API_KEY"
         },
         "ReferenceData": {
           "ApiKey": "YOUR_API_KEY"
         }
       }
     }
     ```

5. Open your browser and navigate to `https://localhost:5001` (or the specified port).

## Technologies Used

- Blazor Server
- Blazor Bootstrap
- RailData marketplace APIs
- .NET 9 (or latest version)

## Contributing

Contributions are welcome! If you'd like to contribute, please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](../LICENSE) file for details.

## Contact

For questions or feedback, feel free to open an issue on GitHub.

---

Happy coding!

