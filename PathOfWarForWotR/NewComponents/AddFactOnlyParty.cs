﻿using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInfiniteCrusade.NewComponents
{
    public class AddFactOnlyParty : UnitFactComponentDelegate, IUnitLevelUpHandler
    {
        public override void OnActivate()
        {
            if (!(Game.Instance.Player?.Party?.Any() ?? false))
                return;

            bool isParty = this.Owner.IsPet || this.Owner.IsMainCharacter || this.Owner.IsCustomCompanion() || this.Owner.IsStoryCompanion();
            if (!isParty || this.Owner.HasFact(this.Feature))
                return;

            Main.Context.Logger.Log($"Applying {Feature.NameSafe()} for {this.Owner} is IsPet={Owner.IsPet} IsMainCharacter={Owner.IsMainCharacter} IsCustomCompanion={Owner.IsCustomCompanion()} IsStoryCompanion={Owner.IsStoryCompanion()}");
            this.Owner.AddFact(this.Feature, null, this.Parameter);
        }

        public void HandleUnitBeforeLevelUp(UnitEntityData unit)
        {
            OnActivate();
        }

        public void HandleUnitAfterLevelUp(UnitEntityData unit, LevelUpController controller)
        {
        }

        public BlueprintUnitFactReference Feature;
        public FeatureParam Parameter;
    
    }
}
