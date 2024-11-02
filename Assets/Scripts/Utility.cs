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