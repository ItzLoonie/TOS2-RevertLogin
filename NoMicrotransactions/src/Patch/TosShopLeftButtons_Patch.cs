using HarmonyLib;
using Home.Shop;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace NoMicrotransactions.Patch;

[HarmonyPatch(typeof(TosShopLeftButtons))]
public class TosShopLeftButtons_Patch
{
    [HarmonyPatch(nameof(TosShopLeftButtons.Init))]
    [HarmonyPostfix]
    private static void Init_Postfix(TosShopLeftButtons __instance, TosShopState tosShopState)
    {
        var obj = GameObject.Find("/TosShopUI/Canvas/SafeArea/TosShopElementsUI/LeftSidePanel/ScalePanel/Tabs/LeftButtonPanel");

        Mod.Logger.LogInfo($"defaultButton: {__instance.defaultButton.name}");

        if (!Settings.GetBool(Mod.Settings.Shop_BundlesSection))
        {
            obj.transform.Find("BundlesButton").gameObject.SetActive(false);

            Mod.Logger.LogInfo("Deactivated BundlesButton (TosShopUI)");
        }

        if (!Settings.GetBool(Mod.Settings.Shop_AccountItemsSection))
        {
            obj.transform.Find("AccountItemsButton").gameObject.SetActive(false);

            Mod.Logger.LogInfo("Deactivated AccountItemsButton (TosShopUI)");
        }

        if (!Settings.GetBool(Mod.Settings.Shop_TownPointsSection))
        {
            obj.transform.Find("TownPointsButton").gameObject.SetActive(false);

            Mod.Logger.LogInfo("Deactivated TownPointsButton (TosShopUI)");
        }

        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach (var button in __instance.buttonGroup.buttonGroup)
        {
            if (button.gameObject.activeSelf)
            {
                Mod.Logger.LogInfo($"Setting shop view mode to first active section ({button.gameObject.name})");

                tosShopState.shopViewMode.Set(button.GetComponent<TosShopLeftButton>().viewMode);

                break;
            }
        }
    }
}