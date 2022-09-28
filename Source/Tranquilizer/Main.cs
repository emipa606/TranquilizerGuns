using System.IO;
using System.Xml.Linq;
using Verse;

namespace Wowcheg.Tranquilizer;

[StaticConstructorOnStartup]
internal static class Main
{
    static Main()
    {
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

        foreach (var modSetting in modSettings.Elements())
        {
            if (modSetting.Name == "ProjectileMechanics")
            {
                TranquilizerMod.instance.Settings.ProjectileOneHit = true;
            }

            if (modSetting.Name == "GasMechanic")
            {
                TranquilizerMod.instance.Settings.GasOneHit = true;
            }
        }

        xml.Root.Element("TranquilizerGunsSetting")?.Remove();
        xml.Save(hugsLibConfig);

        Log.Message("[TranquilizerGunsSetting]: Imported old HugLib-settings");
    }
}