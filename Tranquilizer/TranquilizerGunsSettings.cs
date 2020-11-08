using HugsLib;
using HugsLib.Settings;
using Verse;

namespace Wowcheg.Tranquilizer {
    public class TranquilizerGunsSettings: ModBase {
        public override string ModIdentifier => "TranquilizerGunsSetting";

        public override void DefsLoaded() {
            SettingHandle<HitMechanicsEnum> shotMechanics = Settings.GetHandle<HitMechanicsEnum>("ProjectileMechanics", "Projectile_mechanics_settings_description".Translate(), "", HitMechanicsEnum.WeightScaleMechanics, null, "settings_");
            shotMechanics.OnValueChanged = newValue => { ProjectileTranquillizerBullet.OneHitMechanics = newValue == HitMechanicsEnum.OneHitMechanics; };
            ProjectileTranquillizerBullet.OneHitMechanics = shotMechanics == HitMechanicsEnum.OneHitMechanics;
                
            SettingHandle<HitMechanicsEnum> gasMechanics = Settings.GetHandle<HitMechanicsEnum>("GasMechanic", "Gas_mechanics_settings_description".Translate(), "", HitMechanicsEnum.WeightScaleMechanics, null, "settings_");
            gasMechanics.OnValueChanged = newValue => { DamageWorker_Tranquilizer_Gas.OneHitMechanics = newValue == HitMechanicsEnum.OneHitMechanics; };
            DamageWorker_Tranquilizer_Gas.OneHitMechanics = gasMechanics == HitMechanicsEnum.OneHitMechanics;
        }
    }
}