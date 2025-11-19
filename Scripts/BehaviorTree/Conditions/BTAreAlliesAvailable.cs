using Godot;

namespace EnemyAI.BehaviorTree.Conditions
{
    public partial class BTAreAlliesAvailable : BTNode
    {
        [Export]
        public float SearchRadius { get; set; } = 400f;

        // Exported capacity so the behavior tree can decide whether there's room to summon more allies.
        [Export]
        public int MaxAllies { get; set; } = 3;

        public override BTState Tick(double delta)
        {
            if (Enemy == null)
                return BTState.Failure;

            // If there's no ally scene to instantiate, we can't summon allies.
            if (Enemy.AllyScene == null)
                return BTState.Failure;

            var currentScene = GetTree().CurrentScene;
            if (currentScene == null)
                return BTState.Failure;

            int nearbyAllies = CountAlliesInRadius(currentScene);

            // Success when there's capacity to add another ally.
            return nearbyAllies < MaxAllies ? BTState.Success : BTState.Failure;
        }

        private int CountAlliesInRadius(Node node)
        {
            int count = 0;

            foreach (var childObj in node.GetChildren())
            {
                if (childObj is Node child)
                {
                    // If this child is an Ally, check its distance to the Enemy.
                    if (child is global::Ally ally)
                    {
                        // Use Node2D.GlobalPosition for distance calculation.
                        var allyPos = ally.GlobalPosition;
                        var enemyPos = Enemy.GlobalPosition;
                        if (allyPos.DistanceTo(enemyPos) <= SearchRadius)
                            count++;
                    }

                    // Recurse into children to find nested allies.
                    count += CountAlliesInRadius(child);
                }
            }

            return count;
        }
    }
}
