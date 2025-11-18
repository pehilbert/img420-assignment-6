using Godot;

namespace EnemyAI.BehaviorTree.Conditions
{
    public partial class BTCanAttack : BTNode
    {
        [Export]
        public float AttackCooldownSeconds { get; set; } = 1.0f;

        public override BTState Tick(double delta)
        {
            // TODO: Check attack cooldown / resources
            throw new System.NotImplementedException();
        }
    }
}
