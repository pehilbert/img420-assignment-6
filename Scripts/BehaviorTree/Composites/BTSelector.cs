using Godot;

namespace EnemyAI.BehaviorTree
{
    public partial class BTSelector : BTNode
    {
        public override void _Ready()
        {
            // TODO: Initialize child nodes if needed
        }

        public override BTState Tick(double delta)
        {
            // TODO: Selector behavior (try children until one succeeds or runs)
            throw new System.NotImplementedException();
        }
    }
}
