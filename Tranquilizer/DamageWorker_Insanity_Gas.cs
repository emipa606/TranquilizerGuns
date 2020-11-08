using System;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.AI;

namespace Wowcheg.Tranquilizer {
    public class DamageWorker_Insanity_Gas : DamageWorker {
        
        private InsanityGasDamageDef Def => this.def as InsanityGasDamageDef;
        
        public override DamageResult Apply(DamageInfo dinfo, Thing victim) {
            DamageResult result = new DamageResult();
            Pawn hitPawn = victim as Pawn;
            if (hitPawn == null || !hitPawn.RaceProps.IsFlesh) return result;
            if (Def.mentalStateDef != null) {
                hitPawn.mindState.mentalStateHandler.TryStartMentalState(Def.mentalStateDef);
            }
            return result;
        }
    }
}