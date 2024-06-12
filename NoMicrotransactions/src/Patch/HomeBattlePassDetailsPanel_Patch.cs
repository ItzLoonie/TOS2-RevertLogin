using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable InconsistentNaming

namespace NoMicrotransactions.Patch;

[HarmonyPatch(typeof(HomeBattlePassDetailsPanel))]
public class HomeBattlePassDetailsPanel_Patch
{
    [HarmonyPatch(nameof(HomeBattlePassDetailsPanel.ValidateTiers))]
    [HarmonyPostfix]
    private static void ValidateTiers_Postfix()
    {
        Mod.Logger.LogInfo("HomeBattlePassDetailsPanel.ValidateTiers called");

        if (SceneManager.GetActiveScene().name != "HomeScene")
        {
            return;
        }

        var obj = GameObject.Find("/HomeUI(Clone)/HomeScreenMainCanvas/SafeArea/HomeBattlePassView/BattlePassPrizeTrackDetails/DetailsPopup/Frame");

        if (!Settings.GetBool(Mod.Settings.Battlepass_PremiumTrack))
        {
            Mod.Logger.LogInfo("Setting Battlepass_PremiumTrack is false, deactivating premium stuff");

            obj.transform.Find("SelectedBattlePassDetails/PaidText").gameObject.SetActive(false);
            obj.transform.Find("SelectedBattlePassDetails/Divider").gameObject.SetActive(false);
            obj.transform.Find("SelectedItemBuyButton").gameObject.SetActive(false);

            var scrollView = obj.transform.Find("SelectedBattlePassDetails/Scroll View/Viewport/Content");

            foreach (Transform transform in scrollView)
            {
                if (transform.name != "PrizeTrackTierDetailsTemplate(Clone)")
                {
                    continue;
                }

                transform.Find("Rewards/PrizeTrackTierRewardTemplate (1)").gameObject.SetActive(false);
                transform.Find("Rewards/PrizeTrackTierRewardTemplate (2)").gameObject.SetActive(false);
            }
        }
    }
}