﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour {

    private Queue<string> messages;
    private static MessageController _instance;
    private bool playingMessages = false;
    private Text text;
    private List<string> creepyWords;
    private bool interruptCurrentMessage = false;
    public GameObject messagePanel;

    void Awake()
    {
        _instance = this;
        messages = new Queue<string>(5);
        text = messagePanel.GetComponentInChildren<Text>();
        creepyWords = new List<string>
        {
            "c'thulu", "dark", "doom", "d'oom", "doom", "ne'thet", "hell", "xo#8", "will eat you", "f02 02b", " leavenow ", "monsters", "die", "---------", "what did you say to me you little", "", "Z", "X", "T", "DQ", "I*", "f'", "nff", "huz"
        };
    }

    private Transform lookTarget;
    public static void SetLookTarget(Transform target)
    {
        _instance.lookTarget = target;
    }

    public static void AddMessage(string message, bool interrupt = false, bool onlyLog = false)
    {
        MessageLogger.LogMessage(message);
        if (onlyLog) return;
        if (interrupt && _instance.playingMessages)
        {
            _instance.messages.Clear();
        }
        _instance.messages.Enqueue(message);
        if (!_instance.playingMessages)
        {
            _instance.StartCoroutine(_instance.PlayMessages());
        }
    }

    private IEnumerator PlayMessages()
    {
        Player.Instance.InputBlockers++;
        messagePanel.SetActive(true);
        playingMessages = true;
        while (playingMessages)
        {
            if (lookTarget != null) GameOrchestrator.Instance.FocusCamera(lookTarget);
            var currentMessage = messages.Dequeue();
            var currentString = string.Empty;
            foreach (char c in currentMessage)
            {
                if (interruptCurrentMessage || Input.GetKeyDown(KeyCode.Return))
                {
                    break;
                }
                currentString += c;
                text.text = Random.Range(0, 10) == -1 ? InjectCreep(currentString) : currentString;
                yield return null;
            }
            text.text = currentMessage;
            if (interruptCurrentMessage)
            {
                interruptCurrentMessage = false;
            } else
            {
                yield return new WaitForSeconds(2f);
            }
            if (messages.Count == 0)
            {
                playingMessages = false;
            }
        }
        text.text = string.Empty;
        messagePanel.SetActive(false);
        Player.Instance.InputBlockers--;
        GameOrchestrator.Instance.UnfocusCamera();
    }

    private string InjectCreep(string fitin)
    {
        if (fitin.Length < 4) return fitin;
        var availableWords = creepyWords.Where(cw => cw.Length < fitin.Length - 1).ToArray();
        var word = availableWords[Random.Range(0, availableWords.Length)];
        var diff = fitin.Length - word.Length;
        if (diff <= 1) return word;
        var builtString = (fitin.Substring(0, diff / 2) + word + fitin.Substring(Mathf.Max(0, diff / 2), Mathf.Max(0, fitin.Length - diff / 2 - 1)));
        return builtString.Substring(0, Mathf.Min(fitin.Length, builtString.Length));
    }
}
