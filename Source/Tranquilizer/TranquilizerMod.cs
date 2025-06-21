using Mlie;
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
    ///     The private settings
    /// </summary>
    private TranquilizerSettings settings;

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
            settings ??= GetSettings<TranquilizerSettings>();

            return settings;
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
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
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

        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("settings_CurrentModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }
}