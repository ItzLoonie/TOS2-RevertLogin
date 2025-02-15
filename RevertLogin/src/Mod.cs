using BepInEx.Logging;
using HarmonyLib;

namespace RevertLogin
{
    [SML.Mod.SalemMod]
    public class Mod
    {
        internal static ManualLogSource Logger;
        public static Harmony harmony;

        public static void Start()
        {
            Logger = BepInEx.Logging.Logger.CreateLogSource("RevertLogin");

            Logger.LogInfo("waga baba bobo");

            // Initialize Harmony
            harmony = new Harmony("loonie.tos.revertlogin");
            harmony.PatchAll();  // Apply all patches

            Logger.LogInfo("Harmony patches applied.");
        }
    }
}
