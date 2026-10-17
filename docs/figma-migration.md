# Figma Make migration

Source: [Dark Sky Stays Website](https://www.figma.com/make/pdREgP6TjoAe2iGWUjJpdk/Dark-Sky-Stays-Website)

Inspected through Figma MCP: src/App.tsx, src/index.css, DESIGN.md.

## Review sequence

1. **Home:** reviewed, approved, and committed as 19e6653. Shared navigation, footer, fonts, star field, original hero, search fields, moon calculation, statistics, and three featured stay cards.
2. **Stays:** reviewed and approved by the user. Includes the original six source listings, sticky filter sidebar, Bortle slider, working amenity filters, reset and empty states, and Home search integration.
3. **Tours:** pending separate approval.
4. **Sky Almanac:** pending separate approval.

Do not commit, push, or begin the next page before the user reviews and approves the current page.

## Handoff

The user requested committing and pushing Stays, then stopping. Do not begin Tours or any other feature until the user explicitly asks to resume. Home and Stays have both passed user review. The preview server is stopped for this handoff; start it next time with npm run dev.

Stays validation completed before approval: Release build and publish passed; all 11 focused filter checks passed; the Stays deep link, styles, application assembly, and runtime-script integrity checks passed.

## Fidelity and prototype behavior

- Preserve the source's desktop-only layout: minimum viewport width 1200px, content width 1280px, 40px side padding.
- Fonts: Fraunces and Space Grotesk from the original Google Fonts import.
- The hero and first three listing image URLs are the exact Unsplash URLs from the Make source. These are data-supplied URLs, not temporary Figma asset links. All four returned HTTP 200 when checked.
- The original source supplies the moon geometry and approximate lunar phase formula; both are translated to C#.
- Source search fields were static labels. They are editable; Find darkness now opens Stays with destination, arrival and guest preferences in the URL. Destination filters all six sample records. Date/guest selections are shown in the search summary and do not assert availability.
- Home continues to show the original first three listings. Stays adds the other three exact listing image URLs from the source; all three additional URLs returned HTTP 200.
- The Stays slider supports Bortle classes 1–3. Selected amenity checkboxes are combined with AND, alongside the destination and Bortle limits.
- The Make source does not assign amenities to individual stays. Illustrative amenity flags were added to the sample records so every checkbox has working behavior; these are not verified property facts.
- Home and Stays use native Blazor routes with active navigation states. Tours and Sky Almanac still open dismissible coming-soon dialogs.
- The stats (120 stays, 18 provinces, 21.9 average SQM) are source sample copy, not counts calculated from the six available records.
- Figma MCP returned Make source but no screenshot. Its screenshot tool explicitly does not support Make files. No browser surface was connected for visual or interaction automation.

## Development startup

A separate Debug rebuild while the Blazor development server was running left its runtime asset map stale: index.html referenced a fingerprinted dotnet script that returned 404. The project dev server was restarted to reload its asset mappings. Use Release builds for independent validation while npm run dev is active; after a required Debug rebuild, restart the dev server and check the runtime URLs as well as the HTML/CSS endpoints.

The dev command uses dotnet watch --non-interactive so adding components or applying other edits that require a restart will not leave the background server waiting for a terminal response.
