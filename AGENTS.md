# Project conventions

- Use C#, .NET 10, standalone Blazor WebAssembly, and Tailwind CSS v4.
- Keep sample data and interaction state in the browser. Do not add databases, backend APIs, or authentication servers unless requested.
- Keep Razor pages in Pages, reusable UI in Components, records in Models, and browser-side data/state in Services.
- Use complete Tailwind class names. Edit Styles/app.css, not generated wwwroot/css/app.css.
- Use Conventional Commits: type(optional-scope): description. Examples: feat(stays): add sample search; fix(ui): correct mobile spacing; chore: update dependencies.
- Run npm run build for compilation changes and npm run publish for static asset or release packaging changes.
- The starter screen is temporary. Inspect the Figma Make URL using Figma MCP when provided, then migrate its design and interactions into this stack.
