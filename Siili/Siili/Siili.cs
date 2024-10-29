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
/// https://tim.jyu.fi/view/kurssit/jypeli/kentat/ruutukentta#NTxBwYrXAJeI
//  Luodaan pelihahmo ja määritellään perusliikkeet (kävely, hyppy).
public class Siili : PhysicsGame
{
    private const double NOPEUS = 200;
    private const double HYPPYNOPEUS = 750;
    private const int RUUDUN_KOKO = 40;
    private PlatformCharacter siili;
    public override void Begin()
    {
        Gravity = new Vector(0, -1000);

        LuoKentta();
        //LisaaNappaimet();

        Camera.ZoomToLevel();   
        Camera.Follow(siili);
        Camera.ZoomFactor = 1.2;
        Camera.StayInLevel = true;
        
        //MasterVolume = 0.5;

    }

    //Liikkuminen -> näppäimet
    //   PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
    //   Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");


    void LuoKentta()
    {
        TileMap kentta = TileMap.FromLevelAsset("pelikentta");

        kentta.SetTileMethod('S', LuoSiili);
        kentta.SetTileMethod('M', LuoMarja);
        kentta.SetTileMethod('#', LuoPuu);

        kentta.Execute(RUUDUN_KOKO, RUUDUN_KOKO);

        Level.Background.CreateGradient(Color.Green, Color.Blue);
        //Surface alareuna = Surface.CreateBottom(Level, 50, 300, 50, 30);
        //alareuna.Color = Color.Brown;
        //Add(alareuna);
        Level.CreateBorders(false);

        //Camera.ZoomToLevel();

        /*PlatformCharacter siili = new PlatformCharacter(100, 50);
        siili.Shape = Shape.Circle;
        siili.Color = Color.Brown;
        siili.Position = new Vector(-450, -350);
        this.Add(siili);
        
       /* GameObject marja = new GameObject(40, 20);
        marja.X = -200.0;
        marja.Y = 0.0;
        marja.Shape = Shape.Circle;
        marja.Color = Color.Red;
        this.Add(marja);

        GameObject puu = new GameObject(50, 30);
        puu.X = -190.0;
        puu.Y = -20.0;
        puu.Shape = Shape.Rectangle;
        puu.Color = Color.Brown;
        this.Add(puu);
        */


    }

    private void LuoPuu(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject puu = PhysicsObject.CreateStaticObject(leveys, korkeus);
        puu.Position = paikka;
        puu.Color = Color.Green;
        this.Add(puu);
    }

      private void LuoMarja(Vector paikka, double leveys, double korkeus)
    {
        PhysicsObject marja = PhysicsObject.CreateStaticObject(leveys, korkeus);
        marja.IgnoresCollisionResponse = true;
        marja.Position = paikka;
        marja.Shape = Shape.Circle;
        marja.Color = Color.Red;
        //tahti.Image = tahtiKuva;
        //tahti.Tag = "tahti";
        this.Add(marja);
    }

     private void LuoSiili(Vector paikka, double leveys, double korkeus)
    {
        siili = new PlatformCharacter(leveys, korkeus);
        siili.Position = paikka;
        siili.Mass = 4.0;
        siili.Shape = Shape.Circle;
        siili.Color = Color.Brown;
        //pelaaja1.Image = pelaajanKuva;
        //AddCollisionHandler(pelaaja1, "tahti", TormaaTahteen);
        this.Add(siili);
    }




}
