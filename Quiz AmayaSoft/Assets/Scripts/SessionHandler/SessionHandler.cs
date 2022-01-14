using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(SessionDataGenerator))]
public class SessionHandler : MonoBehaviour
{
	[SerializeField] private UnityEvent SessionFinishedEvent;
	[SerializeField] private UnityEvent<UnityAction<CardView>, LevelData, bool> SpawnEvent;
	[SerializeField] private GameEvent NextLevelTriggerEvent;

	private LevelData[] _sessionData;
	private LevelData _currentLevel;

	private SessionDataGenerator _sessionDataGenerator;

	private void Awake() => _sessionDataGenerator = GetComponent<SessionDataGenerator>();

	private void OnEnable() => NextLevelTriggerEvent.AddListener(NextLevel);
	private void OnDisable() => NextLevelTriggerEvent.RemoveListener(NextLevel);

	private void Start()
	{
		Invoke(nameof(CreateSession), 1f);
	}
		
	private void CreateSession()
	{
		_sessionData = _sessionDataGenerator.GenerateSessionData();
		_currentLevel = _sessionData[0];
		SpawnEvent.Invoke(CheckTap, _currentLevel, true);
	}

	private void CheckTap(CardView cardView)
	{
		if (cardView.Identifier == _currentLevel.TargetCard.Identifier)
			cardView.RightAnswer();
		else
			cardView.WrongAnswer();
	}

	public void NextLevel()
	{
		int nextLevelIndex = Array.IndexOf(_sessionData, _currentLevel) + 1;

		if (nextLevelIndex < _sessionData.Length)
		{
			_currentLevel = _sessionData[nextLevelIndex];
			SpawnEvent.Invoke(CheckTap, _currentLevel, false);
			return;
		}

		SessionFinishedEvent.Invoke();
	}
}

