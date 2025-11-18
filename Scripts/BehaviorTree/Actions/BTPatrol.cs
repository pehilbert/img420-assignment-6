using Godot;

namespace EnemyAI.BehaviorTree.Actions
{
    public partial class BTPatrol : BTNode
    {
        [Export]
        public NodePath PatrolPointsParentPath { get; set; }

        [Export]
        public float PatrolSpeed { get; set; } = 80f;

        public override void _Ready()
        {
            // TODO: Cache patrol points from PatrolPointsParentPath
        }

        public override BTState Tick(double delta)
        {
            // TODO: Move between patrol waypoints in a loop
            throw new System.NotImplementedException();
        }
    }
}
