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
            if (__instance.moveInputVector.magnitude <= 0.1f)
            {
                __instance.steeringInput = Mathf.Lerp(__instance.steeringInput, 0.0f, Time.deltaTime * 16.0f);
                __instance.steeringAnimValue = __instance.steeringInput / 3.0f;
            }
        }
    }
}
