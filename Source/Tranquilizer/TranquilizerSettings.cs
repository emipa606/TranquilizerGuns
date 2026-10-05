using Verse;

namespace Wowcheg.Tranquilizer;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class TranquilizerSettings : ModSettings
{
    public bool GasOneHit;
    public bool ProjectileOneHit;
    public int TranquilizerDurationTicks = 5000;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref ProjectileOneHit, "ProjectileOneHit");
        Scribe_Values.Look(ref GasOneHit, "GasOneHit");
        Scribe_Values.Look(ref TranquilizerDurationTicks, "TranquilizerDurationTicks", 5000);
    }
}