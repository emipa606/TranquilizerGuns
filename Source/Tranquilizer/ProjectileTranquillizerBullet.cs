using RimWorld;
using Verse;

namespace Wowcheg.Tranquilizer;

public class ProjectileTranquillizerBullet : Bullet
{
    public readonly HediffDef HediffToAdd = HediffDefTranquilizer.Tranquilizer;

    public ThingDefTranquillizerBullet Def => def as ThingDefTranquillizerBullet;

    protected override void Impact(Thing hitThing, bool blockedByShield = false)
    {
        base.Impact(hitThing, blockedByShield);
        if (Def == null || hitThing is not Pawn hitPawn || !hitPawn.RaceProps.IsFlesh)
        {
            return;
        }

        var pawnAnethesized = hitPawn.health?.hediffSet?.GetFirstHediffOfDef(HediffToAdd);
        var addedSeverity = TranquilizerMod.instance.Settings.ProjectileOneHit
            ? 1f
            : Rand.Range(0.20f, 0.50f) / hitPawn.BodySize;
        if (pawnAnethesized != null)
        {
            pawnAnethesized.Severity += addedSeverity;
        }
        else
        {
            var hediff = HediffMaker.MakeHediff(HediffToAdd, hitPawn);
            hediff.Severity = addedSeverity;
            hitPawn.health?.AddHediff(hediff);
        }
    }
}