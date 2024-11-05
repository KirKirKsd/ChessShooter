using UnityEngine;

public class Piece : MonoBehaviour {

	public Cell cell;

	private PieceMove _pieceMove;
	
	private void Start() {
		_pieceMove = GetComponent<PieceMove>();
	}
	
	public void Move(Cell newCell) {
		cell = newCell;
		_pieceMove.enabled = true;
		_pieceMove.ToNewPoint(cell.GetTransform());
	}

	public void FastMove(Cell newCell) {
		cell = newCell;
		transform.position = cell.GetTransform();
	}
	
}