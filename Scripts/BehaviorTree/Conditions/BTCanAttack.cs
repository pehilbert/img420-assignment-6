using Godot;

namespace EnemyAI.BehaviorTree.Conditions
{
    public partial class BTCanAttack : BTNode
    {
        public override BTState Tick(double delta)
        {
            return Enemy.CanAttack ? BTState.Success: BTState.Failure;
        }
    }
}
