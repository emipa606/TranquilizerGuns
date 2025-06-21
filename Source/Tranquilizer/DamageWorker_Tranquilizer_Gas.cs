using Verse;

namespace Wowcheg.Tranquilizer;

public class DamageWorker_Tranquilizer_Gas : DamageWorker
{
    private const float TranquilizerAmount = 0.01f;

    public override DamageResult Apply(DamageInfo dinfo, Thing victim)
    {
        var result = new DamageResult();

        if (victim is not Pawn hitPawn || !hitPawn.RaceProps.IsFlesh)
        {
            return result;
        }

        var pawnAnethesized = hitPawn.health?.hediffSet?.GetFirstHediffOfDef(HediffDefTranquilizer.Tranquilizer);
        var addedSeverity = TranquilizerMod.Instance.Settings.GasOneHit
            ? 1f
            : Rand.Range(0.9f, 1.5f) / hitPawn.BodySize;
        if (pawnAnethesized != null)
        {
            pawnAnethesized.Severity += addedSeverity;
        }
        else
        {
            var hediff = HediffMaker.MakeHediff(HediffDefTranquilizer.Tranquilizer, hitPawn);
            hediff.Severity = addedSeverity;
            hitPawn.health?.AddHediff(hediff);
        }

        return result;
    }
}