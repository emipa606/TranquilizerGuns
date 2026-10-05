using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace Wowcheg.Tranquilizer;

[StaticConstructorOnStartup]
internal class TranquilizerMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static TranquilizerMod Instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public TranquilizerMod(ModContentPack content) : base(content)
    {
        Instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal TranquilizerSettings Settings
    {
        get
        {
            field ??= GetSettings<TranquilizerSettings>();

            return field;
        }
    }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Tranquilizer";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="inRect"></param>
    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        listingStandard.Gap();
        listingStandard.Label("Projectile_mechanics_settings_description".Translate());
        if (listingStandard.RadioButton("settings_OneHitMechanics".Translate(), Settings.ProjectileOneHit))
        {
            Settings.ProjectileOneHit = true;
        }

        if (listingStandard.RadioButton("settings_WeightScaleMechanics".Translate(), !Settings.ProjectileOneHit))
        {
            Settings.ProjectileOneHit = false;
        }

        listingStandard.Gap();
        listingStandard.Label("Gas_mechanics_settings_description".Translate());
        if (listingStandard.RadioButton("settings_OneHitMechanics".Translate(), Settings.GasOneHit))
        {
            Settings.GasOneHit = true;
        }

        if (listingStandard.RadioButton("settings_WeightScaleMechanics".Translate(), !Settings.GasOneHit))
        {
            Settings.GasOneHit = false;
        }

        Settings.TranquilizerDurationTicks = (int)listingStandard.SliderLabeled(
            "settings_TranquilizerDuration".Translate(Settings.TranquilizerDurationTicks.ToStringTicksToPeriod()),
            Settings.TranquilizerDurationTicks,
            1, 20000);

        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("settings_CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        Main.UpdateTranquilizerDuration();
    }
}