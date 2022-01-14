using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class FadeAnimation : MonoBehaviour
{
	[SerializeField] private float _duration;
	[SerializeField] private UnityEvent FadeInFinished;

	private Graphic _graphic;

	private void Awake() => _graphic = GetComponent<Graphic>();

	public void FadeIn() => Fade(1f, () => FadeInFinished.Invoke());
	public void FadeOut() => Fade(0f);

	private void Fade(float targetAlpha, TweenCallback callback = null)
	{
		if (_graphic == null)
			return;

		_graphic.DOFade(1 - targetAlpha, 0f);

		var sequence = DOTween.Sequence();

		sequence.Append(_graphic.DOFade(targetAlpha, _duration));
	
		if(callback != null)	
			sequence.AppendCallback(callback);

		sequence.Play();
	}
}