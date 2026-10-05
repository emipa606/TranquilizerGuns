# Copilot Instructions for Tranquilizer Guns (Continued)

Welcome to the GitHub Copilot instruction file for the "Tranquilizer Guns (Continued)" RimWorld mod. This guide will help you understand the key features and systems, coding patterns and conventions, XML integration, and Harmony patching used in this project. Additionally, you'll find suggestions on how to make the most out of GitHub Copilot when contributing to this mod.

## Mod Overview and Purpose

The "Tranquilizer Guns (Continued)" mod introduces non-lethal weaponry and mechanics to RimWorld, focusing on tranquilization. The mod provides various tools and effects for subduing targets without causing permanent harm. These include tranquilizer rifles, pistols, sleep gas grenades, and tranquilizer autoturrets. The mod adds a new dimension to gameplay, allowing players to incapacitate rather than kill.

## Key Features and Systems

- **Tranquilizer Mechanics:** 
  - Introduction of stacking 'Tranquilized' effects based on target body size. Smaller enemies (like rabbits) succumb quickly, while larger targets (like humans) require multiple hits.
- **New Weapons and Items:**
  - Tranquilizer rifle, pistol, and gas grenades.
  - Insanity liquid and gas effects, such as insanity gas mortar shells and mines.
  - Sleeproot plant, used in making tranquilizer liquids.
- **Customizable Settings:**
  - HugsLib integration enables toggling between hit-based and weight-scale mechanism for tranquilizers.
  
## Coding Patterns and Conventions

- **C# Files:**
  - Utilize clear and descriptive type and member names such as `ProjectileTranquillizerBullet` and respective methods like `Def`, `Impact`.
  - Follow standard C# conventions for class and method definitions. Organize classes into files that suit their functionality, like `DamageWorker_Insanity_Gas` and `TranquilizerSettings`.

- **XML Files:**
  - Define game-specific data such as weapon and effect specifications using Def files (e.g., `Damages_TranquilizerGas.xml`).
  - Consistency in naming (e.g., `HediffDef` for hediff definitions) aligns with game standards and improves readability.

## XML Integration

- **Def References:**
  - XML files are structured to provide information on new items, mechanics, and research projects. For example, `Effecter_TranquilizerExplosion.xml` defines tranquility explosion effects by using `EffecterDef` and `moteDef`.

- **Balanced Gameplay:**
  - Mod adjustments such as weapon range and damage are configured via XML files to maintain balance. Edits to XML files ensure that changes dynamically reflect within the game.

## Harmony Patching

- **Modify Vanilla Behavior:**
  - Use the Harmony library to safely alter existing game logic. For instance, changes in weapon behavior or adding new mechanics should employ Harmony patches to avoid conflicts with the base game or other mods.

- **Implementation Guidelines:**
  - Create prefix or postfix methods as needed, ensuring they align with Harmony documentation and best practices.

## Suggestions for Copilot

- **Feature Implementation:**
  - Utilize Copilot to assist in writing boilerplate code for new weapons or effects. Suggest function outlines and automatically generate XML structures.

- **Debugging and Enhancement:**
  - Leverage Copilot for suggestions in optimizing C# code or formatting complex XML files. Copilot can identify areas for performance improvement or code simplifications.

- **Consistency and Accuracy:**
  - Use Copilot to maintain consistent naming conventions and adherence to RimWorld modding guidelines, especially when expanding on existing or adding new mod features.

By following these instructions, you will effectively contribute to the ongoing development and maintenance of the Tranquilizer Guns mod. Make sure to reference any relevant documentation or API references to ensure compliance and creativity in your work.

For further assistance or questions, consult the repository's issues, or engage with the community via the provided Discord channel.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

