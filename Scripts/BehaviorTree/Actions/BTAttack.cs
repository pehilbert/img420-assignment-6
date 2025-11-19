using Godot;

namespace EnemyAI.BehaviorTree.Actions
{
    public partial class BTAttack : BTNode
    {
        [Export]
        public int DamageAmount { get; set; } = 10;

        public override BTState Tick(double delta)
        {
            Enemy.Attack();
            return BTState.Success;
        }
    }
}
