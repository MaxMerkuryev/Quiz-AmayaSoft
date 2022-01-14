using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class BounceAnimation : MonoBehaviour
{
	[SerializeField] private float _duration;
	[SerializeField] private float[] _scaleIterations;
	[SerializeField] private UnityEvent BounceOutFinished;

	private void Bounce(float[] iterations, TweenCallback callback = null)
	{
		transform.DOScale(iterations[0], 0f);

		var sequence = DOTween.Sequence();

		for (int i = 0; i < iterations.Length; i++)
			sequence.Append(transform.DOScale(iterations[i], _duration));

		if(callback != null)
			sequence.AppendCallback(callback);

		sequence.Play();
	}

	public void BounceIn() => Bounce(_scaleIterations);
	public void BounceOut() => Bounce(_scaleIterations.Reverse().ToArray(), () => BounceOutFinished.Invoke());
}