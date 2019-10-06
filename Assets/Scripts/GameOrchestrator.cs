using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOrchestrator : MonoBehaviour
{
    [Header("State")]
    public int Time = 12;
    public int Bananas = 0;
    public bool HasBoat;
    public bool HasSail;
    public bool HasSlowJig;
    public int SharksKilled = 0;
    public bool SavedSailor;
    public bool DeliveredSailor;
    public bool HasSadShanty;
    public bool SadGuyHealed;
    public bool BoredGuyHealed;
    public bool HasNorthEldritch;
    public bool HasSouthEldritch;
    public bool HasLoveLetter;
    public bool DeliveredLoveLetter;
    public bool HasHappyJig;

    [Header("Configuration")]
    public float HourTime = 10;
    public bool CheatsActive = true;

    private Coroutine dayRoutine;

    public static GameOrchestrator Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        dayRoutine = StartCoroutine(DailyClock());
    }

    void Update()
    {
        if (CheatsActive)
        {
            CheckCheats();
        }
    }

    void CheckCheats()
    {
        // restart day
        if (Input.GetKey(KeyCode.Tilde))
        {
            StopCoroutine(dayRoutine);
            dayRoutine = StartCoroutine(DailyClock());
        }
    }

    IEnumerator DailyClock()
    {
        NotifyTime();
        yield return new WaitForSeconds(HourTime);
        while (Time < 24)
        {
            Time++;
            NotifyTime();
            yield return new WaitForSeconds(HourTime);
        }
        MessageController.AddMessage("The festival has started.");
        yield return new WaitForSeconds(HourTime);
        MessageController.AddMessage("The world has ended.");
    }

    void NotifyTime()
    {
        MessageController.AddMessage($"It is {(Time % 12 == 0 ? 12 : Time % 12)} o'clock.", onlyLog: true);
    }

    private List<Action<Player.Song>> songActions = new List<Action<Player.Song>>();

    public void RegisterForSongs(Action<Player.Song> action)
    {
        songActions.Add(action);
    }

    public void PlaySong(Player.Song song)
    {
        MessageController.AddMessage($"Played the {song} song!");
        foreach(var action in songActions)
        {
            action.Invoke(song);
        }
    }
}
