# SubrsiveTest
 Programmer Test for Hogarth Worldwide/Subvrsive

## Unity Questions
>How would your code change if weapons had special effects, like the ability to make targets catch fire?

**Answer:** This would involve a new interface called `IEffect` or something similar. These could be attached to any `IPawn` and would be handled by a separate MonoBehavior component that uses coroutines to tick away damage over time for a given duration. The data to build these effects could be stored/managed using ScriptableObjects, XML, or Json. This is where we tweak properties like: Effect Type, Damage per tick, Duration, the interval between ticks, as well as how it should be applied (Self-targeting, Single-target, AOE.) We can even point to specific prefabs for visual effects.

>How might this system be incorporated into a larger items and inventory system?

**Answer:** I would try to keep things separate at first-- Items and inventory would use their own interfaces and handlers to keep track of storage, quantity, overflow, consumption etc. Then I would create a variant of `IItem` that could apply an arbitrary number of `IEffect` instances to a given pawn. These would be applied using the same system as before, hopefully with minimal changes. Items would need their own static data structure. It would be here that we would provide a set of `EffectID`s that could be fetched in-game to apply to a target upon use. That data structure should mirror whichever route was taken with IEffects (Scriptable Objects, XML, or Json.)

# Documentation

## Unity Project
This project features a combat simulation with a variable number of combatants (Default 10.) These will spawn randomly across the playfield, and try to shoot eachother until only one remains. The playfield can be reset upon completion via a popup.

### Third-Party Plugins 
 - UniTask
 - TextMeshPro
 - ProceduralUI

### State Machine
Flow through the app is handled using a state machine. This is a super simple version of a state machine that relies on MonoBehaviours to dictate the transitions through the game.

### Pawns
Pawns are the base component that represents a moveable entity on the field. These all use Unity's NavMesh components to navigate the field.

### Combatants
Combatants are a child class of Pawns. They have an attached Weapon and can be loaded with a `CombatantData` Scriptable Object that allows you to set the following parameters:
 - Move Speed
 - Turn Speed
 - Max HP
 - Weapon Data
 - Prefab

These ScriptableObjects can be found here: *Assets/Runtime/Data/Combatants*

### Weapons
Weapons are attached to combatants. They utilize a MonoBehaviour called `ProjectileLauncher` to fire projectiles. `WeaponData` can be edited via a ScriptableObject:
  - Attack Speed
  - Damage
  - Range
  - Bullet Speed

 These ScriptableObjects can be found here: *Assets/Runtime/Data/Weapons*

### Behaviors
Combatant AI is handled using various MonoBehaviours that can be attached to their prefabs. There are only two such behaviors in this project.
 - CombatantMoveTowardTarget: Checks if a combatant is within firing range. If it is not, it will move toward its target.
 - AutoTargetPawns: Checks potential targets in-range and sets them as the user's target.

### Assets
Uses primitive 3D assets and a simple checkerboard shader made in shadergraph.


## Unreal Project
The Unreal project uses the First-Person Shooter template. Upon playing you'll see a keypad in front of you, and a security camera above that. The camera will emit green light when it cannot detect you, a yellow light when you are near detection, and a red light when you are clearly detected. Entering the correct code on the keypad will disable the camera, causing it to permenantly glow green.

*There is no in-game reset once the camera has been disabled. The playfield must be restarted to enable to security camera again.*

### Blueprints
All of the logic in this demo takes place in three custom blueprints:
 - BP_SecurityCamera
 - BP_NumPad
 - BP_NumPadButton

### BP_SecurityCamera
This blueprint handles the camera logic. Exposed parameters allow you to tweak the tolerance for the various stages of detection:
 - Light Colors: The colors the light should use for green, yellow, and red.
 - Detection Angle Tolerance: Determines how sensitive the calculation for full detection (Red light) is.
 - Warning Angle Tolerance: Determins how sensitive the calculation for semi detection (Yellow light) is.
 - Detection Sphere Radius: The size of the overall detection sphere. Anything outside of this will not be detected.

### BP_NumPadButton
This blueprint simply passes events to `BP_NumPad` when clicked. The event is called `NumPasButtonPressed` and it passes a single integer to its recipient. There is one exposed parameter:
 - Button Number: The integer that will be sent via event when the button is pressed (Also determines the number that appears on the button.)

### BP_NumPad
This blueprint has quite a bit of functionality crammed into it. It receives events from it's child BP_NumPadButtons when clicked, and builds a string using the input. If the code is correct, it will fire an event to `BP_SecurityCamera` informing it to disable the security camera. Getting the code correct will also lock the Num Pad from receiving more input.

Exposed parameters:
 - Target Input String: The desired code. When entered the num pad will show green and deactivate the camera.
 - Success Text Color: Green color to set the text when the code is correct.
 - Failed Text Color: Red color to set the text when the code is incorrect.
 - Default Text Color: Black color to set the text when input is being accepted.
