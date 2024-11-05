using UnityEngine;

public class Cell {

	public int x;
	public int y;

	public Cell(int x, int y) {
		this.x = x;
		this.y = y;
	}

	public Vector2 GetTransform() {
		var position = new Vector2((x - 4) * 1.5f - 0.75f, (y - 5) * 1.5f + 0.25f);
		return position;
	}

}

public enum Direction {
	TopLeft, Top, TopRight,
	Left, Center, Right,
	BottomLeft, Bottom, BottomRight
}

public static class Directions {

	public static Direction DirectionSum(Direction dy, Direction dx) {
		if (dy == Direction.Top) {
			if (dx == Direction.Left) return Direction.TopLeft;
			if (dx == Direction.Right) return Direction.TopRight;
		}
		else if (dy == Direction.Bottom) {
			if (dx == Direction.Left) return Direction.BottomLeft;
			if (dx == Direction.Right) return Direction.BottomRight;
		}
		return Direction.Center;
	}
	
	public static Direction GetDirectionByVector(Vector2 vector) {
		var dy = vector.y switch {
			> 0.77f => Direction.Top,
			< -0.77f => Direction.Bottom,
			_ => Direction.Center
		};

		var dx = vector.x switch {
			< -0.77f => Direction.Left,
			> 0.77f => Direction.Right,
			_ => Direction.Center
		};

		if (dx == dy) return Direction.Center;
		if (dy == Direction.Center) return dx;
		if (dx == Direction.Center) return dy;
		
		return DirectionSum(dy, dx);
	}

	public static Vector2 GetVectorByDirection(Direction d) {
		switch (d) {
			case Direction.TopLeft: return new Vector2(-1, 1);
			case Direction.Top: return Vector2.up;
			case Direction.TopRight: return new Vector2(1, 1);
			case Direction.Left: return Vector2.left;
			case Direction.Center: return Vector2.zero;
			case Direction.Right: return Vector2.right;
			case Direction.BottomLeft: return new Vector2(-1, -1);
			case Direction.Bottom: return Vector2.down;
			case Direction.BottomRight: return new Vector2(1, -1);
		}
		return Vector2.zero;
	}
}

public class Utility {
	public static bool IsVectorInRange(Vector2 vec, float range) {
		var ans = Mathf.Abs(vec.x) < range && Mathf.Abs(vec.y) < range;
		return ans;
	}

	public static Cell CalcCell(Cell cell, Vector2 move) {
		var newCell = new Cell(cell.x + (int)move.x, cell.y + (int)move.y);
		return newCell;
	}
}