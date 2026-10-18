# Figma Make migration

Source: [Dark Sky Stays Website](https://www.figma.com/make/pdREgP6TjoAe2iGWUjJpdk/Dark-Sky-Stays-Website)

Inspected through Figma MCP: src/App.tsx, src/index.css, DESIGN.md.

## Review sequence

1. **Home:** reviewed, approved, and committed as 19e6653. Shared navigation, footer, fonts, star field, original hero, search fields, moon calculation, statistics, and three featured stay cards.
2. **Stays:** reviewed, approved, and committed as c0b0683. Includes the original six source listings, sticky filter sidebar, Bortle slider, working amenity filters, reset and empty states, and Home search integration.
3. **Tours:** reviewed and approved. Includes the three alternating source cards, a native Blazor route, and a working demo reservation dialog.
4. **Sky Almanac:** authorized as the next page; pending implementation and review.

Do not commit, push, or begin the next page before the user reviews and approves the current page.

## Handoff

The user approved Tours and authorized committing and pushing it, then continuing with Sky Almanac. Pause again for review after Sky Almanac is implemented and validated. Start the project from the repository root with npm run dev.

Stays validation completed before approval: Release build and publish passed; all 11 focused filter checks passed; the Stays deep link, styles, application assembly, and runtime-script integrity checks passed.

Tours validation: Release build and publish passed with no compilation warnings; all 14 focused booking, pricing, state, and form-validation checks passed. JavaScript syntax and dialog closing checks passed. The running Tours route, dialog styles and helper, application assembly, startup-script integrity, and published helper were verified. The user reviewed and approved Tours; no browser was connected for automation.

## Fidelity and prototype behavior

- Preserve the source's desktop-only layout: minimum viewport width 1200px, content width 1280px, 40px side padding.
- Fonts: Fraunces and Space Grotesk from the original Google Fonts import.
- The hero and first three listing image URLs are the exact Unsplash URLs from the Make source. These are data-supplied URLs, not temporary Figma asset links. All four returned HTTP 200 when checked.
- The original source supplies the moon geometry and approximate lunar phase formula; both are translated to C#.
- Source search fields were static labels. They are editable; Find darkness now opens Stays with destination, arrival and guest preferences in the URL. Destination filters all six sample records. Date/guest selections are shown in the search summary and do not assert availability.
- Home continues to show the original first three listings. Stays adds the other three exact listing image URLs from the source; all three additional URLs returned HTTP 200.
- The Stays slider supports Bortle classes 1–3. Selected amenity checkboxes are combined with AND, alongside the destination and Bortle limits.
- The Make source does not assign amenities to individual stays. Illustrative amenity flags were added to the sample records so every checkbox has working behavior; these are not verified property facts.
- Home, Stays, and Tours use native Blazor routes with active navigation states. Sky Almanac still opens a dismissible coming-soon dialog.
- Tours preserves the source names, locations, schedules, guides, three original photo URLs, peso prices, 320px card height, and alternating image positions. The additional telescope photo URL returned HTTP 200.
- The original tour buttons were inert. Each now opens a demo dialog with date and guest selection, a per-person price total, cancellation, and confirmation. Demo reservations are held only in the browser's scoped sample service and reset on refresh; no payment, availability lookup, real booking, or external submission occurs.
- The stats (120 stays, 18 provinces, 21.9 average SQM) are source sample copy, not counts calculated from the six available records.
- Figma MCP returned Make source but no screenshot. Its screenshot tool explicitly does not support Make files. No browser surface was connected for visual or interaction automation.

## Development startup

A separate Debug rebuild while the Blazor development server was running left its runtime asset map stale: index.html referenced a fingerprinted dotnet script that returned 404. The project dev server was restarted to reload its asset mappings. Use Release builds for independent validation while npm run dev is active; after a required Debug rebuild, restart the dev server and check the runtime URLs as well as the HTML/CSS endpoints.

The dev command uses dotnet watch --non-interactive so adding components or applying other edits that require a restart will not leave the background server waiting for a terminal response.
