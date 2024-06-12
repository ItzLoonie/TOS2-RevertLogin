using BepInEx.Logging;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global

namespace NoMicrotransactions;

[SML.Mod.SalemMod]
public class Mod
{
    internal static ManualLogSource Logger;
    internal static Settings Settings;

    public static void Start()
    {
        Logger = BepInEx.Logging.Logger.CreateLogSource("NoMicrotransactions");
        Settings = new Settings();

        Logger.LogInfo("Balls retain pee");
    }
}