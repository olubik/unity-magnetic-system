# Magnetic System — Unity

A polarity-based magnetic interaction system developed in Unity using C# and Shader Graph.

The player controls a magnet that can switch between positive and negative polarity, attracting and repelling multiple magnetic objects simultaneously.

## Gameplay Preview

![Magnetic interactions](gifs/magnetic-interactions.gif)

*Attracting and repelling multiple objects.*

![Polarity switching](gifs/polarity-switching.gif)

*Optionally, a magnetic object can periodically switch between polarities.*

## Editor Workflow

Magnetic objects can have their polarity configured directly in the Unity inspector. Changing an object's polarity automatically updates its material, making magnetic objetcs easy to configure an reuse.

![Editor workflow](gifs/editor-workflow.gif)

*Changing an object's polarity in the inspector automatically updates its apprearance*

## Features

- **Polarity-based interactions:** Attract or repel magnetic objects depending on the player's active polarity.
- **Multiple-object detection:** Detect and interact with multiple magnetic objects simultaneously.
- **Distance-based force:** Magnetic force varies with the distance between the player and each target.
- **Automatic polarity switching:** Magnetic objects can automatically switch polarity at configurable intervals.
- **Shader-based visual feedback:** Use color and shader effects to indicate the player's active polarity and highlight affected objects.

## Controls

| Input | Action |
|---|---|
| Left mouse button (hold) | Activate positive polarity |
| Right mouse button (hold) | Activate negative polarity |
| Escape | Unlock cursor |

## Technical Overview

The system separates input handling, player movement, magnetic interactions, and visual feedback into dedicated components.

| Component | Responsibility |
|---|---|
| `PlayerInputReader` | Reads player input. |
| `PlayerMovement` | Handles player movement. |
| `PlayerMagnet` | Manages magnetic interactions, detects magnetic objects and applies forces. |
| `MagneticObject` | Stores an object's polarity and manages its own visual feedback. |
| `PlayerPolarityVisual` | Updates the player's visual based on his active polarity. |
| `MagneticPolaritySwitcher` | Periodically switches an object's polarity. |

## Implementation Details

### Magnetic interactions

The player detects magnetic objects within the aiming area using `Physics.SphereCastAll`. Detected objects are filtered to identify valid magnetic targets.

The force direction depends on the relationship between the player's active polarity and the target object's polarity:

- **Opposite polarities:** Attraction.
- **Matching polarities:** Repulsion.

Magnetic force varies with the distance between the player and each target, providing more control over nearby objects.

### Visual feedback

Shader effects communicate magnetic interactions to the player. Affected objects receive a visual highlight, while the player's color indicates the currently active polarity.

### Automatic polarity switching

Magnetic objects can be configured to automatically alternate between positive and negative polarities at configurable time intervals. This introduces an additional gameplay challenge by changing the interaction between the player and the object over time.

## Built With

- **Engine:** Unity 6 LTS (6000.3.27f1)
- **Language:** C#
- **Visual Effects:** Shader Graph
