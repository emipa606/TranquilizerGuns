using RimWorld;
using Verse;

namespace Wowcheg.Tranquilizer;

public class ThingDefTranquillizerBullet : ThingDef
{
    public HediffDef HediffToAdd;

    public override void ResolveReferences()
    {
        base.ResolveReferences();
        HediffToAdd = HediffDefOf.Anesthetic;
    }
}