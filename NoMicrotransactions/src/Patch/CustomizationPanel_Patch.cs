using Game.Interface.Customization;
using HarmonyLib;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace NoMicrotransactions.Patch;

[HarmonyPatch(typeof(CustomizationPanel))]
public class CustomizationPanel_Patch
{
    [HarmonyPatch(nameof(CustomizationPanel.Start))]
    [HarmonyPostfix]
    private static void Start_Postfix()
    {
        Mod.Logger.LogInfo("CustomizationPanel.Start called");

        if (!Settings.GetBool(Mod.Settings.Personalize_TomeOfFate))
        {
            GameObject.Find("/Hud/LobbyCustomizationElementsUI(Clone)/CustomizationPanel/TrinketSlot").SetActive(false);
        }
        else if (!Settings.GetBool(Mod.Settings.Personalize_TomeOfFateBoostSkip))
        {
            GameObject.Find("/Hud/LobbyCustomizationElementsUI(Clone)/CustomizationPanel/TrinketSlot/BuyContainer").SetActive(false);
        }
    }
}