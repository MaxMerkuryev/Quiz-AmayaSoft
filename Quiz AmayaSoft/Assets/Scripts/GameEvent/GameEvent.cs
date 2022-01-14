using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="New GameEvent", menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
	private UnityEvent _event;

	public void AddListener(UnityAction listener) => _event.AddListener(listener);
	public void RemoveListener(UnityAction listener) => _event.RemoveListener(listener);

	public void Invoke() => _event.Invoke();
}
