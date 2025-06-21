using RimWorld;
using Verse;

namespace Wowcheg.Tranquilizer;

public class ProjectileTranquillizerBullet : Bullet
{
    private readonly HediffDef hediffToAdd = HediffDefTranquilizer.Tranquilizer;

    private ThingDefTranquillizerBullet Def => def as ThingDefTranquillizerBullet;

    protected override void Impact(Thing hitThing, bool blockedByShield = false)
    {
        base.Impact(hitThing, blockedByShield);
        if (Def == null || hitThing is not Pawn hitPawn || !hitPawn.RaceProps.IsFlesh)
        {
            return;
        }

        var pawnAnethesized = hitPawn.health?.hediffSet?.GetFirstHediffOfDef(hediffToAdd);
        var addedSeverity = TranquilizerMod.Instance.Settings.ProjectileOneHit
            ? 1f
            : Rand.Range(0.20f, 0.50f) / hitPawn.BodySize;
        if (pawnAnethesized != null)
        {
            pawnAnethesized.Severity += addedSeverity;
        }
        else
        {
            var hediff = HediffMaker.MakeHediff(hediffToAdd, hitPawn);
            hediff.Severity = addedSeverity;
            hitPawn.health?.AddHediff(hediff);
        }
    }
}