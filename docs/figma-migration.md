# Figma Make migration

Source: [Dark Sky Stays Website](https://www.figma.com/make/pdREgP6TjoAe2iGWUjJpdk/Dark-Sky-Stays-Website)

Inspected through Figma MCP: src/App.tsx, src/index.css, DESIGN.md.

## Review sequence

1. **Home:** reviewed and approved by the user. Shared navigation, footer, fonts, star field, original hero, search fields, moon calculation, statistics, and three featured stay cards.
2. **Stays:** next page to migrate.
3. **Tours:** pending separate approval.
4. **Sky Almanac:** pending separate approval.

Do not commit, push, or begin the next page before the user reviews and approves the current page.

## Fidelity and prototype behavior

- Preserve the source's desktop-only layout: minimum viewport width 1200px, content width 1280px, 40px side padding.
- Fonts: Fraunces and Space Grotesk from the original Google Fonts import.
- The hero and first three listing image URLs are the exact Unsplash URLs from the Make source. These are data-supplied URLs, not temporary Figma asset links. All four returned HTTP 200 when checked.
- The original source supplies the moon geometry and approximate lunar phase formula; both are translated to C#.
- Source search fields were static labels. They are now editable; Find darkness filters the three featured stays locally and scrolls to the result. Date/guest selections are shown in the search summary and do not assert availability.
- Other-page links open a dismissible coming-soon dialog while those pages await their separate migration.
- The stats (120 stays, 18 provinces, 21.9 average SQM) are source sample copy, not counts calculated from the three available records.
- Figma MCP returned Make source but no screenshot. Its screenshot tool explicitly does not support Make files. No browser surface was connected for visual or interaction automation.

## Development startup

A separate Debug rebuild while the Blazor development server was running left its runtime asset map stale: index.html referenced a fingerprinted dotnet script that returned 404. The project dev server was restarted to reload its asset mappings. Use Release builds for independent validation while npm run dev is active; after a required Debug rebuild, restart the dev server and check the runtime URLs as well as the HTML/CSS endpoints.
