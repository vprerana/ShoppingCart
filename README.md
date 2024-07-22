# Shopping Cart Service - Backend API Implementation

## Objective : 
Implement a simple backend for a shopping cart service. The consumer of your service should
be able to make an API call to add items to the cart as well as view items in the cart. Adding to
the shopping cart should require an object with the attributes Name, Price, and Quantity (you
can set the values to whatever you like).
Please use C#, Java, or Python for your solution.

## Table of Contents

- [Getting Started](#getting-started)
- [Running the Tests](#running-the-tests)

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio Code](https://code.visualstudio.com/)

### Installing

1. Clone the repository:

    ```bash
    git clone https://github.com/vprerana/ShoppingCartBeService.git
    cd ShoppingCartBeService
    ```

2. Restore the dependencies:

    ```bash
    dotnet restore
    ```

3. Build the project:

    ```bash
    dotnet build
    ```

4. Run the project:

    ```bash
    dotnet run
    ```

The service will be available at `https://localhost:5001` or `http://localhost:5000`.

## Running the Tests

To run the tests, use the following command:

```bash
dotnet test
