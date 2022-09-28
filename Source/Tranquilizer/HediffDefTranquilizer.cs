using RimWorld;
using Verse;

namespace Wowcheg.Tranquilizer;

[DefOf]
public static class HediffDefTranquilizer
{
    public static HediffDef Tranquilizer;

    static HediffDefTranquilizer()
    {
        DefOfHelper.EnsureInitializedInCtor(typeof(HediffDefOf));
    }
}