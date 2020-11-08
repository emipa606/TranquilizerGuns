using RimWorld;
using UnityEngine;
using Verse;

namespace Wowcheg.Tranquilizer {
    public class DamageWorker_Tranquilizer_Gas : DamageWorker {
        private const float TranquilizerAmount = 0.01f;
        public static bool OneHitMechanics;
        
        public override DamageResult Apply(DamageInfo dinfo, Thing victim)
        {
            DamageResult result = new DamageResult();

            Pawn hitPawn = victim as Pawn;
            if (hitPawn == null) return result;
            
            var pawnAnethesized = hitPawn?.health?.hediffSet?.GetFirstHediffOfDef(HediffDefTranquilizer.Tranquilizer);
            var addedSeverity = OneHitMechanics ? 1f : Rand.Range(0.9f, 1.5f)/(hitPawn.BodySize);
            if (pawnAnethesized != null){
                pawnAnethesized.Severity += addedSeverity;
            } else {
                Hediff hediff = HediffMaker.MakeHediff(HediffDefTranquilizer.Tranquilizer, hitPawn, null);
                hediff.Severity = addedSeverity;
                hitPawn.health.AddHediff(hediff, null, null);
            }
            return result;
        }
    }
}