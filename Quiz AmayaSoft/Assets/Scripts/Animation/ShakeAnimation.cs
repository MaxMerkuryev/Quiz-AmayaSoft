using UnityEngine;
using DG.Tweening;

public class ShakeAnimation : MonoBehaviour
{
	[SerializeField] private float _duration;
	[SerializeField] private float _strength;

	public void Shake()
	{
		transform.DOComplete();
		transform.DOShakePosition(_duration, _strength);
	}
}