# Support Operations SaaS (Blazor + ASP.NET Core)

A modern full-stack support ticket management platform built with ASP.NET Core and Blazor.

This project is being developed incrementally as a production-style portfolio application focused on clean architecture, API design, CRUD workflows, and cloud deployment.

## Live Demo

https://blazor-interview-app-2.onrender.com

---

## Current Features (MVP v1)

- Blazor Server UI
- ASP.NET Core backend endpoints
- Ticket listing
- Reusable UI components
- HTTP API consumption with HttpClient
- Loading / error handling states
- Dockerized deployment
- Cloud hosted on Render

---

## Planned Roadmap

### v1.1 Core CRUD
- Create ticket
- Edit ticket
- Delete ticket
- Ticket detail page

### v1.2 Business Workflows
- Status management (Open / In Progress / Closed)
- Priority levels
- Search / filtering

### v1.3 Authentication
- User login
- Roles: Admin / Agent / Customer

### v2 Analytics
- Dashboard metrics
- SLA indicators
- Ticket trends

### v3 Architecture Enhancements
- Service layer
- Repository pattern (where appropriate)
- Logging / monitoring
- Production configuration

---

## Tech Stack

- ASP.NET Core
- Blazor Server
- C#
- Razor Components
- REST-style endpoints
- Docker
- Render Cloud Hosting
- GitHub Actions (planned)

---

## Engineering Goals

This project is intentionally designed to demonstrate:

- Full-stack application delivery
- Clean separation of concerns
- Real-world CRUD workflows
- API design
- Component-based UI architecture
- Deployment & DevOps fundamentals
- Scalable system thinking

---

## Local Development

```bash
dotnet restore
dotnet run