# Playmaker Actions Pack

Additional custom actions pack for Playmaker, the visual behaviour scripting tool for Unity Engine.

Check the list of available actions below.

## List of Actions

### Animation
* **Is Animation Playing** - Checks if the specified animation is playing and stores the result in a variable. Checkout the Animation.IsPlaying on the Unity Documentation for further details.

### NGUI

* **Set Anchor Container** - Sets the widget an panel containers (using Game Objects as parameters) of a specified Game Object with a UIAnchor component. If a container Game Object isn't provided, it's value is setted on the UIAnchor as null.

* **Set Anchor Relative Offset** - Sets the relative offset of a specified Game Object with a UIAnchor component, using a Vector2 and X an Y values. The X and Y values, when provided/different from 0 override the Vector2 values.

### Transform
* **Get Signed Angle To Target** - Gets the signed Angle (in degrees, clockwise, -180 to 180) between a Game Object's forward axis and a Target. The Target can be defined as a Game Object or a world Position. If you specify both, then the Position will be used as a local offset from the Object's position.