using System;
using UnityEngine;

public class Player : MonoBehaviour {

	private Input _input;
	private Piece _piece;
	private Camera _defaultCam;
	
	public bool canPlayerMove = true;
	
	private void Awake() {
		_input = new Input();
		_input.Mouse.RightClick.performed += _ => RightClick();
	}

	private void Start() {
		_input.Mouse.Enable();
		_piece = GetComponent<Piece>();
		_defaultCam = Camera.main;
	}

	private void RightClick() {
		if (!canPlayerMove) return;
		
		var diff = GetMouseDifference();
		if (Utility.IsVectorInRange(diff, 2)) {
			var move = Utility.CalcCell(_piece.cell, 
				Directions.GetVectorByDirection(Directions.GetDirectionByVector(diff)));
			_piece.Move(move);

			canPlayerMove = false;
		}
	}

	private float GetDistanceToMouse() {
		var mousePos = _input.Mouse.MousePos.ReadValue<Vector2>();
		var distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y + 0.5f), 
			_defaultCam.ScreenToWorldPoint(mousePos));
		return distance;
	}

	private Vector2 GetMouseDifference() {
		var mousePos = _input.Mouse.MousePos.ReadValue<Vector2>();
		var mouseWorldPos = _defaultCam.ScreenToWorldPoint(mousePos);
		var difference = new Vector2(
			-transform.position.x + mouseWorldPos.x,
			-transform.position.y - 0.5f + mouseWorldPos.y);
		return difference;
	}

}