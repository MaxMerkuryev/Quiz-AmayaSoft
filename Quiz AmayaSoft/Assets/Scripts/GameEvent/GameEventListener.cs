using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
	[SerializeField] private GameEvent _event;
	[SerializeField] private UnityEvent EventInvoked;

	private void OnEnable() => _event.AddListener(InvokeAction);
	private void OnDisable() => _event.RemoveListener(InvokeAction);

	private void InvokeAction() => EventInvoked.Invoke();
}