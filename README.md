# Event Management System

Welcome to the Event Management System! This system allows users to manage events effectively, with features for creating, updating, deleting, and retrieving event information.

## CRUD Operations

- **Create**: Create new events with detailed information such as title, description, date, time, and location.
- **Read**: Retrieve event details, including title, description, date, time, and location.
- **Update**: Update existing events with new information, such as changing the title, date, or location.
- **Delete**: Delete events that are no longer needed, removing them from the system.

## Testing

The Event Management System includes comprehensive unit tests to ensure reliability and functionality. These tests cover various scenarios for creating, reading, updating, and deleting events, as well as handling edge cases and error conditions.

## Technologies Used

- **Backend**: Built with ASP.NET Core for a fast and reliable backend service.
- **Database**: Utilizes Entity Framework Core for data access and management, with support for various database providers.
- **Testing**: Utilizes XUnit and Moq for unit testing, ensuring code quality and reliability.
- **Documentation**: Includes comprehensive documentation for developers, making it easy to understand and extend the system.
- 
| Method   | Endpoint            | Description                                   | Request Body/Parameters | Returns                |
|----------|---------------------|-----------------------------------------------|-------------------------|------------------------|
| POST     | `/events`           | Creates a new event                          | Event object            | Created event object   |
| PUT      | `/events/{eventId}` | Updates an existing event                    | Event object            | Updated event object   |
| GET      | `/events/{eventId}` | Retrieves an event by its ID                 | Event ID                | Event object           |
| GET      | `/events/{title}`   | Retrieves an event by its title              | Event title             | Event object           |
| DELETE   | `/events/{eventId}` | Deletes an event by its ID                   | Event ID                | Deleted event object   |
| DELETE   | `/events/{title}`   | Deletes an event by its title                | Event title             | Deleted event object   |


  ![image](https://github.com/beatrizgomees/EventRegistrationSystem/assets/150337944/ce416f30-99c8-4e9f-94dd-57a642f6de52)


## Getting Started

To get started with the Event Management System, follow these steps:

1. **Clone the Repository**: Clone this repository to your local machine using `git clone https://github.com/yourusername/event-management-system.git`
2. **Install Dependencies**: Navigate to the project directory and install dependencies using `npm install` or `yarn install`.
3. **Database Setup**: Set up your database and configure connection strings in the `appsettings.json` file.
4. **Run the Application**: Start the backend server by running `dotnet run` and launch the frontend application.
5. **Explore the API**: Access the API documentation at `/api/docs` to explore available endpoints and interact with the system.

## Contributing

We welcome contributions from the community to improve and extend the Event Management System. To contribute, please follow these guidelines:

1. **Fork the Repository**: Fork this repository to your GitHub account.
2. **Create a Branch**: Create a new branch for your feature or bug fix.
3. **Commit Changes**: Make your changes, commit them, and push to your fork.
4. **Submit a Pull Request**: Submit a pull request from your branch to the `main` branch of this repository.

## License

The Event Management System is open-source software licensed under the [MIT License](LICENSE). Feel free to use, modify, and distribute the code for your own purposes. Contributions are welcome!

## Contact

For any inquiries or support, please contact us at [contact@example.com](beatrizgomesxx@gmail.com). We'd love to hear from you!
