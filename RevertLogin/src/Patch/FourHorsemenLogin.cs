using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace RevertLogin.Patch;

[HarmonyPatch(typeof(SceneManager), nameof(SceneManager.LoadScene), new Type[] { typeof(string), typeof(LoadSceneMode) })]
public class LoginScene_Patch
{
    [HarmonyPostfix]
    private static void OnSceneLoad_Postfix(string sceneName, LoadSceneMode mode)
    {
        if (sceneName != "LoginScene")
        {
            return;
        }

        Mod.Logger.LogInfo("LoginScene loaded, modifying UI...");

        var s4LoginAssets = GameObject.Find("LoginScene/Canvas/S4LoginAssets");
        if (s4LoginAssets != null)
        {
            Mod.Logger.LogInfo("Disabling S4LoginAssets...");
            s4LoginAssets.SetActive(false);
        }
        else
        {
            Mod.Logger.LogWarning("S4LoginAssets not found!");
        }

        var loginAssets = GameObject.Find("LoginAssets");
        if (loginAssets != null)
        {
            Mod.Logger.LogInfo("Enabling LoginAssets...");
            loginAssets.SetActive(true);
        }
        else
        {
            Mod.Logger.LogWarning("LoginAssets not found!");
        }
    }
}
