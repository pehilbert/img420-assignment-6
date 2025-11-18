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

        public virtual void Initialize()
        {
            // TODO: Optional initialization logic for node
        }

        public abstract BTState Tick(double delta);
    }
}
