﻿using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using TheInfiniteCrusade.Backend.NewComponents.ManeuverBookSystem;
using TheInfiniteCrusade.Backend.NewUnitParts;

namespace TheInfiniteCrusade.ModifiedComponents
{
    class PatchRuleCalculateAbilityParams
    {
        [HarmonyPatch(typeof(RuleCalculateAbilityParams), nameof(RuleCalculateAbilityParams.OnTrigger))]
        static class Spellbook_QueryPostload
        {
            static void Postfix(RuleCalculateAbilityParams __instance, RulebookEventContext context)
            {
                if (__instance.AbilityData.Blueprint?.GetComponent<ManeuverInformation>() != null)
                {
                    var ability = __instance.AbilityData.Blueprint;
                    var comp = __instance.AbilityData.Blueprint.GetComponent<ManeuverInformation>();

                    var disciple = __instance.Initiator.Ensure<UnitPartMartialDisciple>();
                    if (comp != null)
                    {
                       //TODO figure out what this was?
                    }

                }
            }
        }
    }
}
