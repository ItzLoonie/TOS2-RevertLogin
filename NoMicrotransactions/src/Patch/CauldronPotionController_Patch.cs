using HarmonyLib;

// ReSharper disable InconsistentNaming

namespace NoMicrotransactions.Patch;

[HarmonyPatch(typeof(CauldronPotionController))]
public class CauldronPotionController_Patch
{
    [HarmonyPatch(nameof(CauldronPotionController.SetPotionState))]
    [HarmonyPrefix]
    private static void SetPotionState_Prefix(CauldronPotionController __instance, ref PotionState toSet)
    {
        Mod.Logger.LogInfo("CauldronPotionController.SetPotionState called");

        if (!Settings.GetBool(Mod.Settings.Cauldron_PremiumPotions) && !__instance.IsFree)
        {
            Mod.Logger.LogInfo($"Potion {__instance.PotionName} isn't free, setting PotionState to Disabled");

            toSet = PotionState.Disabled;
        }
    }
}