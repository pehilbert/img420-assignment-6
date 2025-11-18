using Godot;

namespace EnemyAI.BehaviorTree.Actions
{
    public partial class BTChasePlayer : BTNode
    {
        [Export]
        public float MoveSpeed { get; set; } = 100f;

        public override BTState Tick(double delta)
        {
            // TODO: Move towards player using NavigationAgent2D or similar
            throw new System.NotImplementedException();
        }
    }
}
