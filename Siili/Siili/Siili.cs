using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Widgets;

namespace Siili;

/// @author jenny
/// @version 28.10.2024
/// <summary>
/// 
/// </summary>
public class Siili : PhysicsGame
{
    public override void Begin()
    {
        //Siili peliin
        Level.Background.Color = Color.Green;
        PhysicsObject olio = new PhysicsObject(100, 50);
        olio.Shape = Shape.Circle;
        olio.Color = Color.Brown;
        Add(olio);






        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
}

