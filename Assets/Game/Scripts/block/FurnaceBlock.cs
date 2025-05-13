using Game.Scripts.block.link;
using Game.Scripts.items;
using Game.Scripts.recipe;
using Game.Scripts.tile;
using Game.Scripts.World.Schedules;
using UnityEngine;

namespace Game.Scripts.block
{
    public class FurnaceBlock : CraftStationBlock
    {
        public static readonly RecipeWithPower RECIPE = new RecipeWithPower().MaxPower(10).AddStage(new Energy(5), 0.5f).AddStage(new Energy(7), 0.5f, 0.1f);
            
        private readonly LinkPoint In;
        private readonly LinkPoint Out;

        private int? power;
        public FurnaceBlock() : base()
        {
            In = AddLinkPoint(new LinkPoint(this, new Vector2(2, 2), LinkGroup.ENERGY, true));
            Out = AddLinkPoint(new LinkPoint(this, new Vector2(2, 2), LinkGroup.ITEM, false, true));
            
        }

        public override void Init(ScheduleContainer container)
        {
            base.Init(container);
            Reset(container);
        }

        protected void Reset(ScheduleContainer container)
        {
            stage = 0;
            if (In.Link != null) Transfer(In.Link);
        }

        protected override bool Input(Link from)
        {
            CloseListener();
            if (!RECIPE.CanPass(from, stage, ref power)) return false;
            
            GetWorldMap().Schedules.Activate(new DelaySchedule(this, RECIPE.GetStage(stage).freeze, AfterItemProcessing));
            return true;
        }

        private void AfterItemProcessing(ScheduleContainer container)
        {
            if (stage == RECIPE.TotalStages)
            {
                ResultProcessing(stage, container);
            }
            else
            {
                OpenListener(RECIPE.GetStage(stage).waitTime);
            }
        }

        private void ResultProcessing(int pStage, ScheduleContainer container)
        {
            var resultStage = RECIPE.GetResultStage(pStage);
            Out.SetItem(resultStage.item);

            if (resultStage.timeToResetInput >= 0)
            {
                container.Activate(new DelaySchedule(this, resultStage.timeToResetInput, Reset));
                if (resultStage.timeToResetInput == 0) Reset(container);
            }
            
            if (pStage < RECIPE.TotalStages + RECIPE.ResultTotalStages)
            {
                container.Activate(new DelaySchedule(this, resultStage.freeze, _ => ResultProcessing(pStage + 1, container)));
            }
        }

        protected override void OnListenerExpire(ScheduleContainer container) => Reset(container);
    }
}