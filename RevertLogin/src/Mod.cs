using BepInEx.Logging;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global

namespace RevertLogin;

[SML.Mod.SalemMod]
public class Mod
{
    internal static ManualLogSource Logger;
    internal static Settings Settings;

    public static void Start()
    {
        Logger = BepInEx.Logging.Logger.CreateLogSource("RevertLogin");
        Settings = new Settings();

        Logger.LogInfo("waga baba bobo");
    }
}