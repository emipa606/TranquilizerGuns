using Verse;

namespace Wowcheg.Tranquilizer
{
    public class DamageWorker_Insanity_Gas : DamageWorker
    {
        private InsanityGasDamageDef Def => def as InsanityGasDamageDef;

        public override DamageResult Apply(DamageInfo dinfo, Thing victim)
        {
            var result = new DamageResult();
            if (victim is not Pawn hitPawn || !hitPawn.RaceProps.IsFlesh)
            {
                return result;
            }

            if (Def.mentalStateDef != null)
            {
                hitPawn.mindState.mentalStateHandler.TryStartMentalState(Def.mentalStateDef);
            }

            return result;
        }
    }
}