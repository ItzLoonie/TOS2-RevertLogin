using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RevertLogin.Patch
{
    [HarmonyPatch(typeof(SceneManager))]
    public class LoginScene_Patch
    {
        // This will explicitly target the LoadScene method with the signature (string, LoadSceneMode)
        [HarmonyPatch("LoadScene", new[] { typeof(string), typeof(LoadSceneMode) })]
        [HarmonyPostfix]
        private static void OnSceneLoad_Postfix(string sceneName, LoadSceneMode mode)
        {
            Mod.Logger.LogInfo($"Scene loaded: {sceneName}");

            if (sceneName != "LoginScene")
            {
                return;
            }

            Mod.Logger.LogInfo("LoginScene loaded, modifying UI...");

            // Find the S4LoginAssets object inside Canvas and disable it
            var s4LoginAssets = GameObject.Find("/LoginScene/Canvas/S4LoginAssets");
            if (s4LoginAssets != null)
            {
                Mod.Logger.LogInfo("Disabling S4LoginAssets...");
                s4LoginAssets.SetActive(false);
            }
            else
            {
                Mod.Logger.LogWarning("S4LoginAssets not found!");
            }

            // Find the LoginAssets object and enable it
            var loginAssets = GameObject.Find("/LoginScene/LoginAssets");
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
