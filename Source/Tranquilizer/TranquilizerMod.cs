using UnityEngine;
using Verse;

namespace Wowcheg.Tranquilizer;

[StaticConstructorOnStartup]
internal class TranquilizerMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static TranquilizerMod instance;

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
        instance = this;
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal TranquilizerSettings Settings
    {
        get
        {
            if (settings == null)
            {
                settings = GetSettings<TranquilizerSettings>();
            }

            return settings;
        }
        set => settings = value;
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
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        listing_Standard.Label("Projectile_mechanics_settings_description".Translate());
        if (listing_Standard.RadioButton("settings_OneHitMechanics".Translate(), Settings.ProjectileOneHit))
        {
            Settings.ProjectileOneHit = true;
        }

        if (listing_Standard.RadioButton("settings_WeightScaleMechanics".Translate(), !Settings.ProjectileOneHit))
        {
            Settings.ProjectileOneHit = false;
        }

        listing_Standard.Gap();
        listing_Standard.Label("Gas_mechanics_settings_description".Translate());
        if (listing_Standard.RadioButton("settings_OneHitMechanics".Translate(), Settings.GasOneHit))
        {
            Settings.GasOneHit = true;
        }

        if (listing_Standard.RadioButton("settings_WeightScaleMechanics".Translate(), !Settings.GasOneHit))
        {
            Settings.GasOneHit = false;
        }

        listing_Standard.End();
    }
}