using Godot;

public partial class Ally : CharacterBody2D
{
    [Export]
    public int MaxHealth { get; set; } = 50;

    public int CurrentHealth { get; private set; }

    [Export]
    public float MoveSpeed { get; set; } = 120f;

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
        // TODO: Setup basic follow/assist logic, animations
    }

    public override void _PhysicsProcess(double delta)
    {
        // TODO: Implement ally movement / behavior (chase player, assist enemy, etc.)
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        // TODO: Apply damage, update UI, handle death
        throw new System.NotImplementedException();
    }
}
