using HugsLib;
using Verse;

namespace Wowcheg.Tranquilizer
{
    public class TranquilizerGunsSettings : ModBase
    {
        public override string ModIdentifier => "TranquilizerGunsSetting";

        public override void DefsLoaded()
        {
            var shotMechanics = Settings.GetHandle("ProjectileMechanics",
                "Projectile_mechanics_settings_description".Translate(), "", HitMechanicsEnum.WeightScaleMechanics,
                null, "settings_");

            shotMechanics.ValueChanged += _ =>
                ProjectileTranquillizerBullet.OneHitMechanics = shotMechanics == HitMechanicsEnum.OneHitMechanics;

            //shotMechanics.OnValueChanged = newValue =>
            //{
            //    ProjectileTranquillizerBullet.OneHitMechanics = newValue == HitMechanicsEnum.OneHitMechanics;
            //};

            ProjectileTranquillizerBullet.OneHitMechanics = shotMechanics == HitMechanicsEnum.OneHitMechanics;

            var gasMechanics = Settings.GetHandle("GasMechanic", "Gas_mechanics_settings_description".Translate(), "",
                HitMechanicsEnum.WeightScaleMechanics, null, "settings_");

            gasMechanics.ValueChanged += _ =>
                DamageWorker_Tranquilizer_Gas.OneHitMechanics = gasMechanics.Value == HitMechanicsEnum.OneHitMechanics;

            //gasMechanics.OnValueChanged = newValue =>
            //{
            //    DamageWorker_Tranquilizer_Gas.OneHitMechanics = newValue == HitMechanicsEnum.OneHitMechanics;
            //};

            DamageWorker_Tranquilizer_Gas.OneHitMechanics = gasMechanics == HitMechanicsEnum.OneHitMechanics;
        }
    }
}