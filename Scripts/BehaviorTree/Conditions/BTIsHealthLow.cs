using Godot;

namespace EnemyAI.BehaviorTree.Conditions
{
    public partial class BTIsHealthLow : BTNode
    {
        [Export] public float LowThresholdPercent { get; set; } = 50f;

        public override BTState Tick(double delta)
        {
            return ((float)Enemy.CurrentHealth / (float)Enemy.MaxHealth) * 100 < LowThresholdPercent ? BTState.Success : BTState.Failure;
        }
    }
}
