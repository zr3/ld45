﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOrchestrator : MonoBehaviour
{
    [Header("State")]
    public int Time = 12;
    private int bananas = 0;
    public int Bananas
    {
        get => bananas;
        set {
            bananas = value;
            Player.Instance.UpdateInventoryFX();
        }
    }
    private bool hasBoat;
    public bool HasBoat
    {
        get => hasBoat;
        set {
            hasBoat = value;
            Player.Instance.UpdateInventoryFX();
            Player.Instance.GetComponentInChildren<Animator>().SetBool("InWater", !hasBoat);
        }
    }
    private bool hasSail;
    public bool HasSail
    {
        get => hasSail;
        set
        {
            hasSail = value;
            Player.Instance.UpdateInventoryFX();
        }
    }
    private bool hasSlowJig;
    public bool HasSlowJig {
        get => hasSlowJig;
        set
        {
            if (!hasSlowJig)
            {
                Player.Instance.KnownSongs.Add(Player.Song.SlowJig);
                SaveGame();
            }
            hasSlowJig = value;
        }
    }
    public int SharksKilled = 0;
    public bool savedSailor;
    public bool SavedSailor
    {
        get => savedSailor;
        set
        {
            savedSailor = value;
            Player.Instance.UpdateInventoryFX();
        }
    }
    public bool deliveredSailor;
    public bool DeliveredSailor
    {
        get => deliveredSailor;
        set
        {
            deliveredSailor = value;
            Player.Instance.UpdateInventoryFX();
        }
    }
    private bool hasSadShanty;
    public bool HasSadShanty
    {
        get => hasSadShanty;
        set
        {
            if (!hasSadShanty)
            {
                Player.Instance.KnownSongs.Add(Player.Song.SadShanty);
                SaveGame();
            }
            hasSadShanty = value;
        }
    }
    public bool SadGuyHealed;
    public bool BoredGuyHealed;
    private bool hasNorthEldritch;
    public bool HasNorthEldritch
    {
        get => hasNorthEldritch;
        set
        {
            if (!hasNorthEldritch)
            {
                Player.Instance.KnownSongs.Add(Player.Song.NorthEldritch);
                SaveGame();
            }
            hasNorthEldritch = value;
        }
    }
    private bool hasSouthEldritch;
    public bool HasSouthEldritch
    {
        get => hasSouthEldritch;
        set
        {
            if (!hasSouthEldritch)
            {
                Player.Instance.KnownSongs.Add(Player.Song.SouthEldritch);
                SaveGame();
            }
            hasSouthEldritch = value;
        }
    }
    public bool hasLoveLetter;
    public bool HasLoveLetter
    {
        get => hasLoveLetter;
        set
        {
            hasLoveLetter = value;
            Player.Instance.UpdateInventoryFX();
        }
    }
    public bool deliveredLoveLetter;
    public bool DeliveredLoveLetter
    {
        get => deliveredLoveLetter;
        set
        {
            deliveredLoveLetter = value;
            Player.Instance.UpdateInventoryFX();
        }
    }
    private bool hasHappyJig;
    public bool HasHappyJig
    {
        get => hasHappyJig;
        set
        {
            if (!hasHappyJig)
            {
                Player.Instance.KnownSongs.Add(Player.Song.HappyJig);
                SaveGame();
            }
            hasHappyJig = value;
        }
    }
    private bool hasWindwards;
    public bool HasWindwards
    {
        get => hasWindwards;
        set
        {
            if (!hasWindwards)
            {
                Player.Instance.KnownSongs.Add(Player.Song.Windwards);
                SaveGame();
            }
            hasWindwards = value;
        }
    }
    private bool hasToThePast;
    public bool HasToThePast
    {
        get => hasToThePast;
        set
        {
            if (!hasToThePast)
            {
                Player.Instance.KnownSongs.Add(Player.Song.ToThePast);
                SaveGame();
            }
            hasToThePast = value;
        }
    }

    public bool FestivalActive;

    [Header("Configuration")]
    public float HourTime = 10;
    public bool CheatsActive = true;
    public GameObject[] FestivalActivations;
    public Transform FestivalTeleport;
    public CharacterCamera characterCamera;

    private Coroutine dayRoutine;

    public static GameOrchestrator Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        characterCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CharacterCamera>();
        dayRoutine = StartCoroutine(DailyClock());
        LoadGame();
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
        if (Input.GetKey(KeyCode.F12))
        {
            SceneManager.LoadScene("World");
        }
        // reset game
        if (Input.GetKey(KeyCode.F11))
        {
            ResetGame();
            SceneManager.LoadScene("World");
        }
        // warp to festival
        if (Input.GetKey(KeyCode.F10))
        {
            Time = 22;
        }
    }

    IEnumerator DailyClock()
    {
        yield return new WaitForSeconds(1);
        ScreenFader.FadeIn();
        NotifyTime();
        yield return new WaitForSeconds(HourTime);
        while (Time < 22)
        {
            Time++;
            NotifyTime();
            yield return new WaitForSeconds(HourTime);
        }
        Player.Instance.InputBlockers++;
        ScreenFader.FadeOut();
        yield return new WaitForSeconds(1);
        MessageController.AddMessage("The festival has started.");
        FestivalActive = true;
        yield return new WaitForSeconds(2.5f);
        foreach (var gob in FestivalActivations)
        {
            gob.SetActive(true);
        }
        Player.Instance.transform.position = FestivalTeleport.position;
        Player.Instance.transform.rotation = FestivalTeleport.rotation;
        ScreenFader.FadeIn();
        yield return new WaitForSeconds(1);
        Player.Instance.InputBlockers--;
        MessageController.AddMessage("welp....");
        MessageController.AddMessage("you've run out of time....");
        MessageController.AddMessage("more importantly at the moment....");
        MessageController.AddMessage("I've run out of time....");
        MessageController.AddMessage("(there was going to be a festival here, and a horror that could be summoned by song)");
        MessageController.AddMessage("(unfortunately, that was a bit ambitious for 48 hours...)");
        MessageController.AddMessage("(so the world will just end! you will be warped back to the beginning, with nothing but your memories of songs)");
        ScreenFader.FadeOutThen(() => SceneManager.LoadScene("World"));
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

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }

    public void LoadGame()
    {
        var p = Player.Instance;
        foreach (var s in PlayerPrefs.GetString("songs", "").Split('|'))
        {
            switch (s)
            {
                case "HappyJig":
                    p.KnownSongs.Add(Player.Song.HappyJig);
                    hasHappyJig = true;
                    break;
                case "NorthEldritch":
                    p.KnownSongs.Add(Player.Song.NorthEldritch);
                    hasNorthEldritch = true;
                    break;
                case "SadShanty":
                    p.KnownSongs.Add(Player.Song.SadShanty);
                    hasSadShanty = true;
                    break;
                case "SlowJig":
                    p.KnownSongs.Add(Player.Song.SlowJig);
                    hasSlowJig = true;
                    break;
                case "SouthEldritch":
                    p.KnownSongs.Add(Player.Song.SouthEldritch);
                    hasSouthEldritch = true;
                    break;
                case "ToThePast":
                    p.KnownSongs.Add(Player.Song.ToThePast);
                    hasToThePast = true;
                    break;
                case "Windwards":
                    p.KnownSongs.Add(Player.Song.Windwards);
                    hasWindwards = true;
                    break;
            }
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetString("songs", String.Join("|", Player.Instance.KnownSongs.Select(s => s.ToString())));
        PlayerPrefs.Save();
    }

    public void FocusCamera(Transform target)
    {
        characterCamera.LookTarget = target;
        characterCamera.LookSharpness = 1;
    }

    public void UnfocusCamera()
    {
        if (Player.Instance)
        {
            characterCamera.LookTarget = Player.Instance.transform;
            StartCoroutine(ResetCameraTightness());
        }
    }

    IEnumerator ResetCameraTightness()
    {
        while (characterCamera.LookSharpness < 1000)
        {
            characterCamera.LookSharpness += 5;
            yield return null;
        }
        characterCamera.LookSharpness = 1000;
    }
}
