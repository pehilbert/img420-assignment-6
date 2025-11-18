using Godot;
using EnemyAI.BehaviorTree;

public partial class Enemy : CharacterBody2D
{
    [Export]
    public int MaxHealth { get; set; } = 100;

    public int CurrentHealth { get; private set; }

    [Export]
    public PackedScene AllyScene { get; set; }

    [Export]
    public NodePath BehaviorTreeRootPath { get; set; }

    private BTNode _behaviorTreeRoot;

    [Export]
    public Label StateLabel { get; set; }

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;

        if (BehaviorTreeRootPath != null)
        {
            _behaviorTreeRoot = GetNode<BTNode>(BehaviorTreeRootPath);
            if (_behaviorTreeRoot != null)
            {
                _behaviorTreeRoot.Enemy = this;
                _behaviorTreeRoot.Initialize();
            }
        }

        // TODO: Initialize navigation, detection, references to player, etc.
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_behaviorTreeRoot != null)
        {
            // TODO: Call Tick and update StateLabel text
            // var state = _behaviorTreeRoot.Tick(delta);
        }
    }

    public void TakeDamage(int amount)
    {
        // TODO: Reduce health, clamp, update UI, check death
        throw new System.NotImplementedException();
    }
}
