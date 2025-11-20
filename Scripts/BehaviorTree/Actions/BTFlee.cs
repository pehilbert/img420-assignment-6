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
            if (Enemy.NavigationAgent != null)
            {
                Vector2 fleeDirection = -(Enemy.Player.GlobalPosition - Enemy.GlobalPosition);
                Enemy.NavigationAgent.TargetPosition = fleeDirection * FleeDistance;

                if (!Enemy.NavigationAgent.IsNavigationFinished())
                {
                    Vector2 nextPos = Enemy.NavigationAgent.GetNextPathPosition();
                    Vector2 direction = (nextPos - Enemy.GlobalPosition).Normalized();

                    Enemy.Velocity = direction * FleeSpeed;
                    Enemy.MoveAndSlide();
                }
            }

            Enemy.StateLabel.Text = "Fleeing";
            return BTState.Success;
        }
    }
}
