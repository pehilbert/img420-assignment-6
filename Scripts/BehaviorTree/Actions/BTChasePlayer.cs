using Godot;

namespace EnemyAI.BehaviorTree.Actions
{
    public partial class BTChasePlayer : BTNode
    {
        [Export]
        public float MoveSpeed { get; set; } = 100f;

        public override BTState Tick(double delta)
        {
            if (Enemy.NavigationAgent != null)
            {
                Enemy.NavigationAgent.TargetPosition = Enemy.Player.GlobalPosition;

                if (!Enemy.NavigationAgent.IsNavigationFinished())
                {
                    Vector2 nextPos = Enemy.NavigationAgent.GetNextPathPosition();
                    Vector2 direction = (nextPos - Enemy.GlobalPosition).Normalized();
                    
                    Enemy.Velocity = direction * MoveSpeed;
                    Enemy.MoveAndSlide();
                }
            }

            Enemy.StateLabel.Text = "Chasing";
            return BTState.Success;
        }
    }
}
