using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class StaticGameData
{
    // Scene load related
    public static string scenesName_Title = "TitleScreen";
    public static string scenesName_Game = "GameStage";
    // Game Setup related
    public static int selection = 0;
    public static int stage = 0;
    public static AudioClip[] stageBgmList;
    public static AudioClip[] bossBgmList;
    public static bool isBgmSetted = false;
    // Game UI related
    public static GameObject winMenu;
    public static UI_GamePasue pasueSetter;
    public static string[] skillText = {
        "Solar Shield Ready!!!",
        "Vortex Blast Ready!!!",
        "Nebula Snipe Ready!!!",
        "Star Overload Ready!!"
        };
}
