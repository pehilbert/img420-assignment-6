using Godot;

public partial class Player : CharacterBody2D
{
    [Export]
    public int MaxHealth { get; set; } = 100;

    public int CurrentHealth { get; private set; }

    [Export]
    public float MoveSpeed { get; set; } = 200f;

    [Export]
    public Node2D HealthBar { get; set; }

    [Export]
    public Area2D AttackArea { get; set; }

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
        // TODO: Init animations, attack area shape, etc.
    }

    public override void _PhysicsProcess(double delta)
    {
        // TODO: Handle movement & input (ui_left/right/up/down, attack)
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        // TODO: Apply damage, update health bar, handle death
        throw new System.NotImplementedException();
    }
}
