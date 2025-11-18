using Godot;

namespace EnemyAI.BehaviorTree.Conditions
{
    public partial class BTIsHealthLow : BTNode
    {
        [Export] public float LowThresholdPercent { get; set; } = 50f;

        public override BTState Tick(double delta)
        {
            // TODO: Return Success if health < threshold, else Failure
            throw new System.NotImplementedException();
        }
    }
}
