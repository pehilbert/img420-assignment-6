using Godot;

public partial class HealthBar : Node
{
	[Export]
	public NodePath ProgressBarPath { get; set; }

	private Node2D _progressBar;
	private Node2D _entity;

	public override void _Ready()
	{
		base._Ready();

		if (ProgressBarPath != null)
		{
			_progressBar = GetNode<Node2D>(ProgressBarPath);
		}

		_entity = GetParent<Node2D>();
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);

		if (_progressBar != null)
		{
			_progressBar.Scale = new Vector2(getProgress(), 1.0f);
		}
	}

	private float getProgress()
	{
		if (_entity != null)
		{
			if (_entity is Player player)
			{
				return (float)player.CurrentHealth / (float)player.MaxHealth;
			}

			if (_entity is Enemy enemy)
			{
				return (float)enemy.CurrentHealth / (float)enemy.MaxHealth;
			}
		}

		return 1.0f;
	}
}
