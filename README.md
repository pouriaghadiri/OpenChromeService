# OpenChromeService

A lightweight **.NET Worker + Web API hybrid service** for running background automation tasks with an embedded HTTP control layer.

This project demonstrates how to combine a **Background Worker** and a **Web API host** inside a single .NET Generic Host process.

---

## 🚀 Overview

OpenChromeService runs both:

- A **Background Worker** for continuous processing / automation
- An **Embedded Web API** for runtime control and monitoring

This makes it ideal for automation systems where you need:
- long-running background processes
- HTTP-based control and integration

---

## 🧠 Architecture

```
                .NET Generic Host
┌─────────────────────────────────────────┐
│                                         │
│   ┌──────────────────────────────┐      │
│   │   Worker Service             │      │
│   │   (Background Processing)    │      │
│   └──────────────────────────────┘      │
│                                         │
│   ┌──────────────────────────────┐      │
│   │   Web API Host               │      │
│   │   (HTTP Control Layer)       │      │
│   └──────────────────────────────┘      │
│                                         │
└─────────────────────────────────────────┘
```

---

## 📁 Project Structure

```
OpenChromeService
│
├── Program.cs              # Application entry point
├── Worker.cs               # Background worker logic
├── WebApiHostService.cs    # Embedded Web API host
```

---

## ⚙️ How It Works

### Worker.cs
Runs continuous background tasks such as:
- automation workflows
- long-running processing
- scheduled or loop-based jobs

---

### WebApiHostService.cs
Provides an internal HTTP API used to:
- control worker execution
- trigger actions manually
- check service status
- integrate with external systems

---

### Program.cs
Bootstraps the entire application:
- builds .NET Generic Host
- registers Worker + Web API services
- starts everything in a single runtime

---

## 📡 Example API Endpoints (Conceptual)

```
GET  /status
POST /start
POST /stop
POST /execute
```

These endpoints allow external systems to interact with the running worker.

---

## 🎯 Use Cases

- Browser automation (e.g., Chrome automation services)
- Background job processing systems
- Internal automation tools
- Lightweight microservices
- Agent-based systems with API control

---

## ⚡ Why This Architecture?

Instead of splitting into multiple services:

- API service
- Worker service

This project merges both into one runtime.

### Benefits:
- Single deployment unit
- Easier debugging
- Shared state between API and worker
- Faster development
- Reduced infrastructure complexity

---

## 🛠️ Tech Stack

- .NET Generic Host
- ASP.NET Core Web API
- BackgroundService / IHostedService
- Kestrel Web Server
- Dependency Injection

---

## ▶️ Getting Started

### Clone the repository
```bash
git clone https://github.com/pouriaghadiri/OpenChromeService
cd OpenChromeService
```

### Run the project
```bash
dotnet run
```

---

## 📌 Roadmap

- [ ] Authentication for API endpoints
- [ ] Job queue system
- [ ] Structured logging improvements
- [ ] Docker support
- [ ] Metrics & monitoring (OpenTelemetry)
- [ ] Worker orchestration improvements

---

## 📄 License

MIT License
