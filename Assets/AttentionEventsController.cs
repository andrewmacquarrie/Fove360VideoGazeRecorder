using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AttentionEventsController : MonoBehaviour {

	public string PathToEventsFile;
	private List<AttentionEvent> events;
	int currentEventIndex;

	[System.Serializable]
	public enum EventType 
	{
		ARROW,
		CLEAR
	}

	[System.Serializable]
	public class AttentionEvent
	{
		public int startTime;
		public int xPos;
		public int yPos;
		public EventType type;
	}

	[System.Serializable]
	public class AllAttentionEventData
	{
		public List<AttentionEvent> events = new List<AttentionEvent>();
	}

	private List<AttentionEvent> LoadAttentionEvents(){
		if (File.Exists (PathToEventsFile)) {
			string dataAsJson = File.ReadAllText (PathToEventsFile);
			var allEventsContainer = JsonUtility.FromJson<AllAttentionEventData> (dataAsJson);
			return allEventsContainer.events;
		}
		Debug.Log ("Not able to load events - file path doesnt contain any events: " + PathToEventsFile);
		return new List<AttentionEvent> ();
	}

	// Use this for initialization
	void Start () {
		events = LoadAttentionEvents ();

		foreach (var e in events) {
			Debug.Log (e.startTime);
		}

		currentEventIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentEventIndex >= events.Count) {
			return;
		}

		var currentEvent = events [currentEventIndex];

		if (Time.time > currentEvent.startTime) {
			// do event thing
			Debug.Log("doing event" + currentEvent.type);

			currentEventIndex++;
		}
	}
}
