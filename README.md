# DarkSkyStays

Frontend prototype using **C#, .NET 10, standalone Blazor WebAssembly, and Tailwind CSS v4**. Sample data and saved-stay state live in browser memory and reset on refresh. There is no database, backend API, or authentication.

The initial screen is temporary. The Figma Make design and interactions will be migrated after the project URL is provided.

## Requirements

- .NET SDK 10.0 (constrained by global.json)
- Node.js 22+ (24 recommended), npm 10+, and Git

## Run locally

From the repository root:

```sh
npm ci
npm run dev
```

Open **http://localhost:5195**. Tailwind and Blazor watch for changes. Stop both processes with Ctrl+C.

For a single build followed by a local server, use `npm start`. Direct `dotnet build` and `dotnet run --project src/DarkSkyStays` also build Tailwind and restore npm dependencies when necessary.

The sample screen supports live search, saving/unsaving stays, filtering saved stays, and resetting filters.

## Build and publish

```sh
npm run build
npm run publish
```

Deployable static files are in `artifacts/publish/wwwroot`. Hosting must serve WebAssembly assets and fall back to index.html for client routes. Subpath hosting also requires changing the base URL. No deployment is configured. GitHub Actions builds and uploads the static files as an artifact for pushes to main and pull requests.

## Structure

- `src/DarkSkyStays/Pages`: routed Razor screens
- `Components`: reusable UI
- `Layout`: application shell
- `Models`: sample data records
- `Services`: browser-side sample data and state
- `Styles/app.css`: Tailwind entry point and global styles
- `wwwroot`: static assets; compiled CSS is generated

Use complete Tailwind class names, since dynamically concatenated names are not scanned reliably. Tailwind uses local CLI output without a CDN dependency.

## Conventional Commits

Use `type(optional-scope): description`, for example:

```text
chore: initialize Blazor and Tailwind prototype
feat(stays): add sample stay filters
fix(ui): correct mobile navigation spacing
docs: document prototype setup
```

Husky installs a commit-msg hook during `npm ci`. Commitlint checks formatting before each local commit. Use ! or a BREAKING CHANGE footer for breaking changes.

## GitHub repository

The repository is [djamespi/DarkSkyStays-v2](https://github.com/djamespi/DarkSkyStays-v2). The local branch is main, with origin configured to that repository:

```sh
git push -u origin main
```

If the target already contains commits, fetch and inspect its history before integrating; do not force-push.
