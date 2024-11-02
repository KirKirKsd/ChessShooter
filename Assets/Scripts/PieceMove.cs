using System;
using UnityEngine;

public class PieceMove : MonoBehaviour {

	[SerializeField] private float delta;
	[SerializeField] private float speed;
	
	private Vector2 _target;

	private Piece _piece;
	private Animator _animator;
	private SpriteRenderer _renderer;
	
	public void ToNewPoint(Vector2 pos) {
		_animator.SetBool(Animator.StringToHash("IsMoving"), true);
		_renderer.sortingOrder = 10;
		_target = pos;
	}

	private void Start() {
		_piece = GetComponent<Piece>();
		_animator = GetComponent<Animator>();
		_renderer = GetComponentInChildren<SpriteRenderer>();
	}

	private void Update() {
		if (Vector2.Distance(transform.position, _target) < delta) {
			transform.position = _target;
			_animator.SetBool(Animator.StringToHash("IsMoving"), false);
			_renderer.sortingOrder = 8 - _piece.cell.y;

			this.enabled = false;
		}
		else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("UpPos")) {
			transform.position = Vector3.Lerp(transform.position, _target, Time.deltaTime * speed);
		}
	}
}