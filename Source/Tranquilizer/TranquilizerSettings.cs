using Verse;

namespace Wowcheg.Tranquilizer;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class TranquilizerSettings : ModSettings
{
    public bool GasOneHit;
    public bool ProjectileOneHit;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref ProjectileOneHit, "ProjectileOneHit");
        Scribe_Values.Look(ref GasOneHit, "GasOneHit");
    }
}