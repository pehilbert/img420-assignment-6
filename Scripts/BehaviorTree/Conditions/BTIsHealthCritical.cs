using Godot;

namespace EnemyAI.BehaviorTree.Conditions
{
    public partial class BTIsHealthCritical : BTNode
    {
        [Export] public float CriticalThresholdPercent { get; set; } = 20f;

        public override BTState Tick(double delta)
        {
            // TODO: Return Success if health < threshold, else Failure
            return Enemy.CurrentHealth / Enemy.MaxHealth * 100 < CriticalThresholdPercent ? BTState.Success : BTState.Failure;
        }
    }
}
