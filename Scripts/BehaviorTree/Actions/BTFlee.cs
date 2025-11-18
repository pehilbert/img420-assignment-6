using Godot;

namespace EnemyAI.BehaviorTree.Actions
{
    public partial class BTFlee : BTNode
    {
        [Export]
        public float FleeSpeed { get; set; } = 150f;

        [Export]
        public float FleeDistance { get; set; } = 300f;

        public override BTState Tick(double delta)
        {
            // TODO: Move away from player using navigation
            throw new System.NotImplementedException();
        }
    }
}
