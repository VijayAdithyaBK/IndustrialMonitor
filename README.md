# Industrial Equipment Monitoring Dashboard

> **"Building reliable software for critical industries isn't just a job—it's a craft."**

This project is a modern **WPF (Windows Presentation Foundation)** application designed to demonstrate the skills and mindset ready to tackle challenges in the Industrial & Manufacturing sector.

## 🎯 Purpose: Why I Built This
**I built this project specifically for this role.** 

Recognizing that your team requires strong expertise in **.NET** and deep proficiency in **WPF**, I proactively took the initiative to research, design, and build this application from scratch. It serves as a tangible demonstration of my:
1.  **Willingness to Learn & Execute**: I researched modern best practices (MVVM Toolkit, Dependency Injection in WPF) and implemented them effectively.
2.  **Commitment to Quality**: I didn't just write code; I built an architecture that is testable, scalable, and maintainable.
3.  **Readiness for the Role**: This dashboard mimics real-world industrial constraints (live telemetry, status monitoring), showing I understand the domain.

## 💡 Passion for Technology & Growth
While this project focuses on the required **WPF** and **.NET 8** stack, my passion lies in solving complex problems.
- **Continuous Learner**: I am constantly exploring new technologies. Whether it's integrating **Azure IoT Hub** for cloud connectivity, migrating to **MAUI** for cross-platform reach, or diving into **Blazor**, I embrace the learning curve.
- **Adaptable**: The industrial sector evolves rapidly—from legacy systems to Industry 4.0. I am eager to bridge that gap, learning proprietary protocols or modern frameworks as the role demands.

---

## 🚀 Key Features
- **Real-Time Simulation**: Mock services generate live temperature and vibration data.
- **MVVM Architecture**: Clean separation of concerns using `CommunityToolkit.Mvvm`.
- **Dependency Injection**: Fully configured `Microsoft.Extensions.DependencyInjection` container.
- **Modern UI**: Custom styles, DataTemplates, and ValueConverters for a professional look.
- **Unit Testing**: Testable ViewModels with `xUnit` and `Moq`.

## 🛠 Technology Stack
- **Framework**: .NET 8 (WPF)
- **Language**: C# 12
- **Libraries**: `CommunityToolkit.Mvvm`, `Microsoft.Extensions.DependencyInjection`
- **Testing**: `xUnit`, `Moq`

## 🏃‍♂️ How to Run
1. **Build**: `dotnet build`
2. **Run**: `dotnet run --project IndustrialMonitor.App`
# Industrial Equipment Monitoring Dashboard

> **"Building reliable software for critical industries isn't just a job—it's a craft."**

This project is a modern **WPF (Windows Presentation Foundation)** application designed to demonstrate the skills and mindset ready to tackle challenges in the Industrial & Manufacturing sector.

## 🎯 Purpose: Why I Built This
**I built this project specifically for this role.** 

Recognizing that your team requires strong expertise in **.NET** and deep proficiency in **WPF**, I proactively took the initiative to research, design, and build this application from scratch. It serves as a tangible demonstration of my:
1.  **Willingness to Learn & Execute**: I researched modern best practices (MVVM Toolkit, Dependency Injection in WPF) and implemented them effectively.
2.  **Commitment to Quality**: I didn't just write code; I built an architecture that is testable, scalable, and maintainable.
3.  **Readiness for the Role**: This dashboard mimics real-world industrial constraints (live telemetry, status monitoring), showing I understand the domain.

## 💡 Passion for Technology & Growth
While this project focuses on the required **WPF** and **.NET 8** stack, my passion lies in solving complex problems.
- **Continuous Learner**: I am constantly exploring new technologies. Whether it's integrating **Azure IoT Hub** for cloud connectivity, migrating to **MAUI** for cross-platform reach, or diving into **Blazor**, I embrace the learning curve.
- **Adaptable**: The industrial sector evolves rapidly—from legacy systems to Industry 4.0. I am eager to bridge that gap, learning proprietary protocols or modern frameworks as the role demands.

---

## 🚀 Key Features
- **Real-Time Simulation**: Mock services generate live temperature and vibration data.
- **MVVM Architecture**: Clean separation of concerns using `CommunityToolkit.Mvvm`.
- **Dependency Injection**: Fully configured `Microsoft.Extensions.DependencyInjection` container.
- **Modern UI**: Custom styles, DataTemplates, and ValueConverters for a professional look.
- **Unit Testing**: Testable ViewModels with `xUnit` and `Moq`.

## 🛠 Technology Stack
- **Framework**: .NET 8 (WPF)
- **Language**: C# 12
- **Libraries**: `CommunityToolkit.Mvvm`, `Microsoft.Extensions.DependencyInjection`
- **Testing**: `xUnit`, `Moq`

## 🏃‍♂️ How to Run
1. **Build**: `dotnet build`
2. **Run**: `dotnet run --project IndustrialMonitor.App`
3. **Test**: `dotnet test`

## 👨‍💻 Architecture & Decisions
- **Core Separation**: Business logic lives in `IndustrialMonitor.Core`, completely decoupled from the UI.
- **Test-Driven Design**: The `MainViewModel` is designed with abstraction in mind, allowing unit tests to run without the WPF Dispatcher getting in the way.


---

⚡ Crafted by Vijay Adithya B K
