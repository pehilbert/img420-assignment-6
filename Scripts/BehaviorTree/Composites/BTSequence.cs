using Godot;

namespace EnemyAI.BehaviorTree
{
    public partial class BTSequence : BTNode
    {
        public override void _Ready()
        {
            // TODO: Initialize child nodes if needed
        }

        public override BTState Tick(double delta)
        {
            // TODO: Sequence behavior (all children must succeed in order)
            throw new System.NotImplementedException();
        }
    }
}
