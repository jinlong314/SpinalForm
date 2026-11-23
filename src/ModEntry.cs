using MegaCrit.Sts2.Core.Modding;
using MegaCrit.Sts2.Core.Logging;

namespace SpinalForm;

[ModInitializer("ModLoaded")]
public static class ModEntry
{
    public static void ModLoaded()
    {
        Log.Warn("SpinalForm Mod Loaded Successfully!");
    }
}
