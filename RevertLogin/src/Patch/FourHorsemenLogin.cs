using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Reflection;

namespace RevertLogin.Patch
{
    [HarmonyPatch]
    public class LoginScene_Patch
    {
        static MethodBase TargetMethod()
        {
            // Ensure correct overload is targeted
            return AccessTools.Method(typeof(SceneManager), "LoadScene", new Type[] { typeof(string), typeof(LoadSceneMode) });
        }

        [HarmonyPostfix]
        private static void OnSceneLoad_Postfix(string sceneName, LoadSceneMode mode)
        {
            // Only modify if LoginScene is loaded
            if (sceneName != "LoginScene")
            {
                return;
            }

            Mod.Logger.LogInfo("LoginScene loaded, modifying UI...");

            var s4LoginAssets = GameObject.Find("/Canvas/S4LoginAssets");
            if (s4LoginAssets != null)
            {
                Mod.Logger.LogInfo("Disabling S4LoginAssets...");
                s4LoginAssets.SetActive(false);
            }
            else
            {
                Mod.Logger.LogWarning("S4LoginAssets not found!");
            }

            var loginAssets = GameObject.Find("/LoginAssets");
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
}
