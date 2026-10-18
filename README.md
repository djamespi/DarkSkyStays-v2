# DarkSkyStays

Frontend prototype using **C#, .NET 10, standalone Blazor WebAssembly, and Tailwind CSS v4**. Sample data, search, and demo reservation state live in browser memory and reset on refresh. There is no database, backend API, or authentication.

The frontend migration from [Figma Make](https://www.figma.com/make/pdREgP6TjoAe2iGWUjJpdk/Dark-Sky-Stays-Website) is complete. Home, Stays, Tours, and Sky Almanac have all been reviewed and approved. See [migration notes](docs/figma-migration.md) for fidelity and validation details. Database, backend, and production business logic will be planned separately in a future phase.

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

The background Blazor watcher restarts automatically when an edit cannot be hot reloaded, so it does not wait for a terminal confirmation.

For a single build followed by a local server, use `npm start`. Direct `dotnet build` and `dotnet run --project src/DarkSkyStays` also build Tailwind and restore npm dependencies when necessary.

Home search opens Stays with the selected destination, date and guests. Stays includes six sample listings, Bortle and amenity filters, reset controls, and empty results. Date and guest selections do not check availability. Amenities are illustrative sample attributes. Tours includes three guided experiences and a demo reservation dialog with date, guest count, and price totals; no real booking or payment occurs. Sky Almanac shows the next 30 local dates, approximate moon illumination, nights below 15% illumination, and the nine-class Bortle guide. These calculations follow the source's approximate lunar formula and do not predict weather or visibility. The source design is desktop-only with a minimum width of 1200px; fonts and listing photos load from their original Google Fonts and Unsplash URLs.

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
