using Godot;
using System.Collections.Generic;

namespace EnemyAI.BehaviorTree.Actions
{
	public partial class BTPatrol : BTNode
	{
		[Export]
		public float PatrolSpeed { get; set; } = 80f;

		[Export]
		public float WaypointTolerance { get; set; } = 8f;

		private List<Vector2> _patrolPoints = new List<Vector2>();
		private int _currentIndex = 0;

		public override void Initialize(Enemy enemy)
		{
			base.Initialize(enemy);

			if (enemy.PatrolPoints != null)
			{
				foreach (Node point in Enemy.PatrolPoints.GetChildren())
				{
					if (point is Node2D point2d)
					{
						_patrolPoints.Add(point2d.GlobalPosition);
					}
				}
			}
		}

		public override BTState Tick(double delta)
		{
			if (Enemy == null || Enemy.NavigationAgent == null)
				return BTState.Failure;

			if (_patrolPoints.Count == 0)
				return BTState.Failure;

			// Label
			if (Enemy.StateLabel != null)
				Enemy.StateLabel.Text = "Patrolling";

			// Current target waypoint
			Vector2 enemyPos = Enemy.GlobalPosition;
			Vector2 targetPos = _patrolPoints[_currentIndex];

			// NavigationAgent2D movement
			Enemy.NavigationAgent.TargetPosition = targetPos;

			if (!Enemy.NavigationAgent.IsNavigationFinished())
			{
				Vector2 nextPos = Enemy.NavigationAgent.GetNextPathPosition();
				Vector2 direction = (nextPos - Enemy.GlobalPosition).Normalized();

				Enemy.Velocity = direction * PatrolSpeed;
				Enemy.MoveAndSlide();
			}
			else
			{
				_currentIndex = (_currentIndex + 1) % _patrolPoints.Count;
			}	

			return BTState.Success;
		}
	}
}
