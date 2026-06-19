🚀 OpenChromeService


OpenChromeService is a lightweight hybrid .NET Worker + Web API service designed for running background automation tasks while exposing real-time HTTP control endpoints — all in a single unified host.

It’s built for scenarios where you need automation + API control + long-running processes without splitting services.

⚡ Key Features
🧠 Hybrid architecture (Worker Service + Web API in one process)
🔄 Continuous background processing
🌐 Embedded HTTP API (Kestrel-based)
🧩 Clean separation of concerns (Worker vs API Host)
⚙️ Built on .NET Generic Host
🚀 Lightweight, fast startup, minimal dependencies
🏗️ Architecture

This project merges background execution and API control layer into a single runtime:

┌──────────────────────────────────────┐
│        .NET Generic Host            │
│                                      │
│   ┌──────────────────────────────┐   │
│   │   Background Worker          │   │
│   │   (Automation / Jobs)        │   │
│   └──────────────────────────────┘   │
│                                      │
│   ┌──────────────────────────────┐   │
│   │   Web API Host              │   │
│   │   (Control / Monitoring)    │   │
│   └──────────────────────────────┘   │
│                                      │
└──────────────────────────────────────┘
📦 Project Structure
OpenChromeService
│
├── Program.cs              # Application bootstrap
├── Worker.cs               # Background job processor
├── WebApiHostService.cs    # Embedded Web API host
🧠 How It Works
🔹 Worker Service

Runs continuously in the background and handles long-running tasks such as:

Automation workflows
Scheduled jobs
System monitoring
Chrome / browser automation scenarios
🔹 Web API Host

Provides HTTP endpoints to:

Control worker execution
Trigger tasks manually
Monitor system state
Integrate with external systems
🔹 Program.cs

The entry point that:

Builds the Generic Host
Registers Worker + API services
Starts everything in a unified runtime
🎯 Why This Project?

Most systems separate API and background workers into different services.

This project explores a different approach:

⚡ Run everything in a single, lightweight, self-contained service.

Benefits:
⚡ Faster development & debugging
🔗 Shared state between API and worker
📦 Single deployment unit
🧪 Easier local testing
🧠 Simplified architecture for automation tools
🔥 Ideal Use Cases
Chrome / browser automation services
Internal automation agents
Job processing systems
Lightweight microservices
Dev tools with API + background logic
▶️ Getting Started
1. Clone the repo
git clone https://github.com/pouriaghadiri/OpenChromeService
cd OpenChromeService
2. Run the service
dotnet run
📡 Example API Concept

The embedded API can expose endpoints like:

POST /start
POST /stop
GET  /status
POST /execute

Used to interact directly with the background worker.

🧩 Design Pattern

This project is built using:

.NET Generic Host
Hosted Services (BackgroundService, IHostedService)
Embedded Web Host (Kestrel)
Modular service composition

⭐ If you like this project

Give it a star ⭐ and feel free to contribute ideas or improvements.

