using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class AreaTrigger : MonoBehaviour {

	public string CheckTag = "Player";
	public UnityEvent OnEnter;
	public UnityEvent OnExit;
	public UnityEvent OnStay;

	private void OnTriggerEnter2D( Collider2D collision ) {
		if (collision.gameObject.CompareTag(CheckTag)) {
			OnEnter.Invoke();
		}
	}

	private void OnTriggerExit2D( Collider2D collision ) {
		if (collision.gameObject.CompareTag(CheckTag)) {
			OnExit.Invoke();
		}
	}

	private void OnTriggerStay2D( Collider2D collision ) {
		if (collision.gameObject.CompareTag(CheckTag)) {
			OnStay.Invoke();
		}
	}
}
