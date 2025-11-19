using Godot;
using EnemyAI.BehaviorTree;

public partial class Enemy : CharacterBody2D
{
    [Export]
    public int MaxHealth { get; set; } = 100;
    [Export]
    public float AttackCooldown = 1.0f;

    [Export]
    public PackedScene AllyScene { get; set; }

    [Export]
    public NodePath BehaviorTreeRootPath { get; set; }

    [Export]
    public Label StateLabel { get; set; }

    public int CurrentHealth { get; private set; }
    public bool CanAttack = true;
    
    private BTNode _behaviorTreeRoot;
    private Timer AttackTimer;

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
        AttackTimer = new Timer();
        AttackTimer.WaitTime = AttackCooldown;
        AttackTimer.Timeout += () => CanAttack = true;
        AddChild(AttackTimer);
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

    public void Attack()
    {
        CanAttack = false;
        AttackTimer.Start();
    }
}
