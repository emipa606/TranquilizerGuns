using RimWorld;
using Verse;
using Verse.AI;

namespace Wowcheg.Tranquilizer {
    public class ProjectileTranquillizerBullet: Bullet {
        #region Properties
        
        public ThingDefTranquillizerBullet Def => this.def as ThingDefTranquillizerBullet;
        public HediffDef HediffToAdd = HediffDefTranquilizer.Tranquilizer;
        public static bool OneHitMechanics;
        
        #endregion Properties
        
        #region Overrides
        
        protected override void Impact(Thing hitThing) {
            base.Impact(hitThing);
            if (Def != null && hitThing != null && hitThing is Pawn hitPawn) {
                var pawnAnethesized = hitPawn?.health?.hediffSet?.GetFirstHediffOfDef(HediffToAdd);
                var addedSeverity = OneHitMechanics ? 1f : Rand.Range(0.20f, 0.50f)/(hitPawn.BodySize);
                if (pawnAnethesized != null){
                    pawnAnethesized.Severity += addedSeverity;
                } else {
                    Hediff hediff = HediffMaker.MakeHediff(HediffToAdd, hitPawn, null);
                    hediff.Severity = addedSeverity;
                    hitPawn.health.AddHediff(hediff, null, null);
                }
            }
        }
        
        #endregion Overrides
    }
}