using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TargetCardTextView : MonoBehaviour
{
	[SerializeField] private UnityEvent AppearEvent;
	
	private Text _view;

	private void Awake() => _view = GetComponent<Text>();

	public void UpdateView(string newText, bool appear)
	{
		_view.text = $"Find {newText}";

		if (appear)
			AppearEvent.Invoke();
	}
}