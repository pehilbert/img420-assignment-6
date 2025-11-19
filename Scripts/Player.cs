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
		Vector2 direction = Vector2.Zero;

		if (Input.IsActionPressed("ui_up")) direction.Y -= 1;
		if (Input.IsActionPressed("ui_left")) direction.X -= 1;
		if (Input.IsActionPressed("ui_down")) direction.Y += 1;
		if (Input.IsActionPressed("ui_right")) direction.X += 1;

		Velocity = direction.Normalized() * MoveSpeed;
		MoveAndSlide();
	}

	public void TakeDamage(int amount)
	{
		// TODO: Apply damage, update health bar, handle death
		throw new System.NotImplementedException();
	}
}
