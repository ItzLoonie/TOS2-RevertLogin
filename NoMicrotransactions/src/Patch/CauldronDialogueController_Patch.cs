using HarmonyLib;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace NoMicrotransactions.Patch;

[HarmonyPatch(typeof(CauldronDialogueController))]
public class CauldronDialogueController_Patch
{
    [HarmonyPatch(nameof(CauldronDialogueController.Validate))]
    [HarmonyPostfix]
    private static void Validate_Postfix(CauldronDialogueController __instance)
    {
        if (!Settings.GetBool(Mod.Settings.Cauldron_PremiumPotions))
        {
            Mod.Logger.LogInfo("Deactivating premium potions in CauldronDialogueController");

            __instance._premiumPotionCharacterButton.gameObject.SetActive(false);
            __instance._premiumPotionHouseButton.gameObject.SetActive(false);
            __instance._premiumPotionPetButton.gameObject.SetActive(false);
            __instance._premiumPotionSkinButton.gameObject.SetActive(false);
            __instance._premiumPotionSpeedButton.gameObject.SetActive(false);
        }

        if (!Settings.GetBool(Mod.Settings.Cauldron_ImproveCauldron))
        {
            GameObject.Find("/HUD/HD/CauldronSceneElementsUI/CauldronFeaturedItemPanel").SetActive(false);

            Mod.Logger.LogInfo("Deactivated CauldronFeaturedItemPanel (CauldronScene)");
        }

        if (!Settings.GetBool(Mod.Settings.Cauldron_CauldronLevel))
        {
            GameObject.Find("/HUD/HD/CauldronSceneElementsUI/CauldronLevelPanel").SetActive(false);

            Mod.Logger.LogInfo("Deactivated CauldronLevelPanel (CauldronScene)");
        }
    }
}