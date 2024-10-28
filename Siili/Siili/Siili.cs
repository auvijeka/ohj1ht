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
/// Siili Hippu lähtee tutkimaan kotimetsäänsä kerätäkseen talvivarastoon marjoja ja hedelmiä ennen talven tuloa. Matkallaan hän kohtaa esteitä, 
/// kuten kiviä ja oksia, joita täytyy ylittää hyppäämällä.
//  Pelaaja ohjaa Siili Hippua keräämään ruokaa talvivarastoon ennen talven saapumista. Tavoitteena on kerätä riittävä määrä marjoja ja hedelmiä.
/// </summary>

/// TODO: - Suunnitellaan pelin rakenne -> luodaan pelin taso -> lisätään esteet ja keräilyesineet.
//  Luodaan pelihahmo ja määritellään perusliikkeet (kävely, hyppy).
public class Siili : PhysicsGame
{
    public override void Begin()
    {
       // TileMap ruudut = TileMap.FromLevelAsset("pelikentta");

        //ruudut.SetTileMethod("S", LuoSiili);
        //ruudut.SetTileMethod("M", LuoMarja);
        //ruudut.SetTileMethod("#", LuoPuu);
        //ruudut.SetTileMethod("/", LuoSeina);


        //Siili peliin 
        Level.Background.CreateGradient(Color.Green, Color.Blue);
        PhysicsObject siili = new PhysicsObject(100, 50);
        siili.Shape = Shape.Circle;
        siili.Color = Color.Brown;
        siili.Position = new Vector(-450, -350); 
        this.Add(siili);






        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }
}

