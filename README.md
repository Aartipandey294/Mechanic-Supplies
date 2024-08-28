Mechanic Supplies Integration System
Overview
This project integrates with the fictional "Mechanic Supplies" system to send and receive orders using ASP.NET Core, RabbitMQ.

Architecture
Order Service: Handles orders and communicates with Mechanic Supplies.
Integration Service: Manages REST API calls and error handling.
Message Queue: RabbitMQ for asynchronous order handling.
Logging: Serilog for structured logging.
