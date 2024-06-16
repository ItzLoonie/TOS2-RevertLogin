using Game.Interface;
using HarmonyLib;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace NoMicrotransactions.Patch;

[HarmonyPatch(typeof(DecorationsPanel))]
public class DecorationsPanel_Patch
{
    [HarmonyPatch(nameof(DecorationsPanel.Start))]
    [HarmonyPostfix]
    private static void Start_Postfix()
    {
        Mod.Logger.LogInfo("DecorationsPanel.Start called");

        if (!Settings.GetBool(Mod.Settings.Personalize_TomeOfFate))
        {
            GameObject.Find("/TosCustomizationUI/Canvas/SafeArea/CustomizationElementsUI/MainPanel" +
                            "/PersonalizationSelectionPanel/MidPanel/ScrollOptions/TrinketSlot").SetActive(false);
        }
        else if (!Settings.GetBool(Mod.Settings.Personalize_TomeOfFateBoostSkip))
        {
            GameObject.Find("/TosCustomizationUI/Canvas/SafeArea/CustomizationElementsUI/MainPanel" +
                            "/PersonalizationSelectionPanel/MidPanel/ScrollOptions/TrinketSlot/BuyContainer").SetActive(false);
        }
    }
}