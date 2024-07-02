using HarmonyLib;
using UnityEngine;

namespace CompanyCruiserFix.Patches
{
    [HarmonyPatch(typeof(VehicleController))]
    public class VehicleControlerPatch
    {
        [HarmonyPatch(nameof(VehicleController.GetVehicleInput))]
        [HarmonyPostfix]
        private static void GetVehicleInput(VehicleController __instance)
        {
            if (Mathf.Abs(__instance.moveInputVector.x) <= 0.1f)
            {
                __instance.steeringInput = Mathf.Lerp(__instance.steeringInput, 0.0f, Time.deltaTime * 8.0f);
            }
        }
    }
}
