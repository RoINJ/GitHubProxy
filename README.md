# GitHub Proxy with Trademark Symbol Injection

## Overview
This project is a proxy server for GitHub that modifies the content of web pages by adding the "™" symbol to every six-letter word. It acts as an intermediary between the client and GitHub, intercepting responses and applying text modifications before delivering them to the user.

## Features
- Acts as a proxy to GitHub
- Modifies text content by appending "™" to every six-letter word
- Preserves non-text elements such as scripts and styles

## Installation & Setup

### Prerequisites
- .NET 6 or later
- ASP.NET Core

### Steps to Run
1. Clone the repository:
   ```sh
   git clone https://github.com/RoINJ/GitHubProxy
   cd github-proxy
   ```
2. Build and run the application:
   ```sh
   dotnet build
   dotnet run
   ```
3. The application will start and listen for requests. To use it, navigate to:
   ```
   http://localhost:5000/{github-path}
   ```
   Replace `{github-path}` with the desired GitHub URL path.

## Technologies Used
- ASP.NET Core
- MediatR
- HtmlAgilityPack
- Regular Expressions (Regex)

## Example
**Original Content:**
```
Welcome to GitHub!
```
**Modified Output:**
```
Welcome™ to GitHub!
```
