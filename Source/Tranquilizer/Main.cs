using System.IO;
using System.Linq;
using System.Xml.Linq;
using Verse;

namespace Wowcheg.Tranquilizer;

[StaticConstructorOnStartup]
internal static class Main
{
    static Main()
    {
        UpdateTranquilizerDuration();
        var hugsLibConfig = Path.Combine(GenFilePaths.SaveDataFolderPath, Path.Combine("HugsLib", "ModSettings.xml"));
        if (!new FileInfo(hugsLibConfig).Exists)
        {
            return;
        }

        var xml = XDocument.Load(hugsLibConfig);

        var modSettings = xml.Root?.Element("TranquilizerGunsSetting");
        if (modSettings == null)
        {
            return;
        }

        foreach (var modSetting in modSettings.Elements().Select(setting => setting.Name))
        {
            if (modSetting == "ProjectileMechanics")
            {
                TranquilizerMod.Instance.Settings.ProjectileOneHit = true;
            }

            if (modSetting == "GasMechanic")
            {
                TranquilizerMod.Instance.Settings.GasOneHit = true;
            }
        }

        xml.Root?.Element("TranquilizerGunsSetting")?.Remove();
        xml.Save(hugsLibConfig);

        Log.Message("[TranquilizerGunsSetting]: Imported old HugLib-settings");
    }

    public static void UpdateTranquilizerDuration()
    {
        HediffDefTranquilizer.Tranquilizer.CompProps<HediffCompProperties_Disappears>().disappearsAfterTicks =
            new IntRange(TranquilizerMod.Instance.Settings.TranquilizerDurationTicks);
    }
}