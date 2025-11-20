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
	public NodePath NavigationAgentPath { get; set; }

	[Export]
	public Label StateLabel { get; set; }

	[Export]
	public NodePath PlayerPath { get; set; }

	[Export]
	public NodePath PatrolPointsPath { get; set; }

	public int CurrentHealth { get; private set; }
	public bool CanAttack = true;
	public Player Player;
	public NavigationAgent2D NavigationAgent;
	public Node2D PatrolPoints;
	
	private BTNode _behaviorTreeRoot;
	private Timer _attackTimer;

	public override void _Ready()
	{
		CurrentHealth = MaxHealth;

		if (PatrolPointsPath != null)
		{
			PatrolPoints = GetNode<Node2D>(PatrolPointsPath);
		}

		if (BehaviorTreeRootPath != null)
		{
			_behaviorTreeRoot = GetNode<BTNode>(BehaviorTreeRootPath);
			if (_behaviorTreeRoot != null)
			{
				_behaviorTreeRoot.Initialize(this);
			}
		}
		
		if (PlayerPath != null)
		{
			Player = GetNode<Player>(PlayerPath);
		}

		if (NavigationAgentPath != null)
		{
			NavigationAgent = GetNode<NavigationAgent2D>(NavigationAgentPath);
		}

        _attackTimer = new Timer();
        _attackTimer.WaitTime = AttackCooldown;
        _attackTimer.Timeout += () => CanAttack = true;
		AddChild(_attackTimer);
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_behaviorTreeRoot != null)
		{
			_behaviorTreeRoot.Tick(delta);
		}
	}

	public void TakeDamage(int amount)
	{
        if (CurrentHealth < amount)
        {
            CurrentHealth = 0;
			QueueFree();
        }
        else
        {
            CurrentHealth -= amount;
        }
    }

	public void StartAttackCooldown()
	{
		CanAttack = false;
        _attackTimer.Start();
	}
}
