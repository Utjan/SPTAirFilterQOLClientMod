using EFT;
using EFT.Hideout;
using HarmonyLib;
using SPT.Reflection.Patching;
using System.Reflection;

namespace AirFilterQOLClientMod.Patches
{
    internal class AirfilterUpdatePatch : ModulePatch // all patches must inherit ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(AirFilteringUnitBehaviour), nameof(AirFilteringUnitBehaviour.Update));
        }


        [PatchPrefix]
        static bool Prefix(ref AirFilteringUnitBehaviour __instance, float deltaTime, out float __state)
        {
            __state = __instance.ResourceConsumer.Float_0;            
            __instance.ResourceConsumer.Float_0 = 0;

            return true; // return true to run the original code
        }

        [PatchPostfix]
        static void Postfix(ref AirFilteringUnitBehaviour __instance, float __state)
        {
            __instance.ResourceConsumer.Float_0 = __state;
        }
    }
}
