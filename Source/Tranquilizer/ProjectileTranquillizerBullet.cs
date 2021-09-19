using RimWorld;
using Verse;

namespace Wowcheg.Tranquilizer
{
    public class ProjectileTranquillizerBullet : Bullet
    {
        public static bool OneHitMechanics;
        public HediffDef HediffToAdd = HediffDefTranquilizer.Tranquilizer;

        public ThingDefTranquillizerBullet Def => def as ThingDefTranquillizerBullet;

        protected override void Impact(Thing hitThing)
        {
            base.Impact(hitThing);
            if (Def == null || hitThing == null || hitThing is not Pawn hitPawn)
            {
                return;
            }

            var pawnAnethesized = hitPawn.health?.hediffSet?.GetFirstHediffOfDef(HediffToAdd);
            var addedSeverity = OneHitMechanics ? 1f : Rand.Range(0.20f, 0.50f) / hitPawn.BodySize;
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
}