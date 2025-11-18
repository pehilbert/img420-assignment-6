using Godot;

namespace EnemyAI.BehaviorTree.Conditions
{
    public partial class BTAreAlliesAvailable : BTNode
    {
        [Export]
        public float SearchRadius { get; set; } = 400f;

        public override BTState Tick(double delta)
        {
            // TODO: Check for ally presence / capacity
            throw new System.NotImplementedException();
        }
    }
}
