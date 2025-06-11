#nullable enable
using System;
using System.Collections.Generic;
using Game.Scripts.Blocks.Links;
using Game.Scripts.Items;

namespace Game.Scripts.Recipe
{
    public class RecipeWithPower : AbstractRecipe<int?>
    {
        private int maxPower = 1;
        private readonly List<Stage> stages = new();
        private readonly List<ResultStage> resultStages = new();

        public RecipeWithPower MaxPower(int power)
        {
            maxPower = power;
            return this;
        }

        public RecipeWithPower AddStage(in ILinkItem item, float freeze, float waitTime=0.5f)
        {
            stages.Add(new Stage(item, freeze, waitTime));
            return this;
        }

        public RecipeWithPower AddResultStage(in ILinkItem item, float freeze, float timeToResetInput=-1)
        {
            resultStages.Add(new ResultStage(item, freeze, timeToResetInput));
            return this;
        }
        
        public override bool CanPass(Link itemLink, int stage, ref int? power)
        {
            var item = itemLink.GetItem();
            if (item == null) return false;
            
            var stageItem = GetStage(stage).item;
            power ??= Math.Min(item.GetCount() / stageItem.GetCount(), maxPower);

            if (power <= 0) return false;
            
            int cost = stageItem.GetCount() * power.Value;
            itemLink.SetItem(item.WithCount(item.GetCount() - cost));
            return true;
        }

        public Stage GetStage(int stage)
        {
            return stages[stage];
        }
        public int TotalStages => stages.Count;
        public int ResultTotalStages => resultStages.Count;

        public ResultStage GetResultStage(int stage)
        {
            return resultStages[stage];
        }
    }

    public record ResultStage(in ILinkItem item, in float freeze, float timeToResetInput);

    public record Stage(in ILinkItem item, in float freeze, in float waitTime);
}