using Godot;

namespace EnemyAI.BehaviorTree.Conditions
{
    public enum PlayerRangeCheckMode
    {
        Detection,
        Attack
    }

    public partial class BTIsPlayerInRange : BTNode
    {
        [Export]
        public PlayerRangeCheckMode Mode { get; set; } = PlayerRangeCheckMode.Detection;

        [Export]
        public float DetectionRange { get; set; } = 200f;

        [Export]
        public float AttackRange { get; set; } = 50f;

        public override BTState Tick(double delta)
        {
            // TODO: Use Mode to choose which radius to compare against distance to player
            if (Enemy.Player != null)
            {
                float distance = Enemy.GlobalPosition.DistanceTo(Enemy.Player.GlobalPosition);

                switch (Mode)
                {
                    case PlayerRangeCheckMode.Detection:
                        return distance <= DetectionRange ? BTState.Success : BTState.Failure;
                    
                    case PlayerRangeCheckMode.Attack:
                        return distance <= AttackRange ? BTState.Success : BTState.Failure;
                }
            }

            return BTState.Failure;
        }
    }
}
