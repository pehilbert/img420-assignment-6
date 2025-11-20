using Godot;
using System;

namespace EnemyAI.BehaviorTree
{
    public enum BTState
    {
        Success,
        Failure,
        Running
    }

    public abstract partial class BTNode : Node
    {
        [Export]
        public Enemy Enemy { get; set; }

        public virtual void Initialize(Enemy enemy)
        {
            Enemy = enemy;
            GD.Print($"Initializing {this.Name}");

            foreach (Node child in GetChildren())
            {
                if (child is BTNode btChild)
                {
                    btChild.Initialize(enemy);
                }
            }
        }

        public abstract BTState Tick(double delta);
    }
}
