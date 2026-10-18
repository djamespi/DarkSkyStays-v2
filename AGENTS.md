# Project conventions

- Use C#, .NET 10, standalone Blazor WebAssembly, and Tailwind CSS v4.
- Keep sample data and interaction state in the browser. Do not add databases, backend APIs, or authentication servers unless requested.
- Keep Razor pages in Pages, reusable UI in Components, records in Models, and browser-side data/state in Services.
- Use complete Tailwind class names. Edit Styles/app.css, not generated wwwroot/css/app.css.
- Use Conventional Commits: type(optional-scope): description. Examples: feat(stays): add sample search; fix(ui): correct mobile spacing; chore: update dependencies.
- Run npm run build for compilation changes and npm run publish for static asset or release packaging changes.
- The starter screen is temporary. Inspect the Figma Make URL using Figma MCP when provided, then migrate its design and interactions into this stack.

## Page migration and review

- Migrate one page at a time: Home, Stays, Tours, then Sky Almanac.
- After completing and validating a page, pause for the user's review.
- Do not commit, push, or implement the next page until the user approves the current page.
- Track source fidelity and pending pages in docs/figma-migration.md.
- When npm run dev is active, use Release builds for independent validation. Do not run a separate Debug build against the running server: regenerated runtime fingerprints can leave its in-memory asset map stale. After an unavoidable Debug rebuild, restart the project dev server and verify the runtime script referenced by index.html returns non-empty JavaScript before handing over the preview.

## Current handoff

- Home, Stays, Tours, and Sky Almanac have been reviewed and approved. The frontend migration is complete.
- The user authorized committing and pushing the final Sky Almanac changes.
- Database, backend, and production business logic are a future phase. Await the user's requirements before implementing them.
