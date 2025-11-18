using Godot;

namespace EnemyAI.BehaviorTree.Actions
{
    public partial class BTSummonAlly : BTNode
    {
        [Export]
        public float SummonCooldownSeconds { get; set; } = 5f;

        public override BTState Tick(double delta)
        {
            // TODO: Summon ally PackedScene near enemy
            throw new System.NotImplementedException();
        }
    }
}
