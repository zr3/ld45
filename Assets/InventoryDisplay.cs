using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Text Text;

    void Start()
    {
        Text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        UpdateInventory();
    }

    void UpdateInventory()
    {
        var go = GameOrchestrator.Instance;
        var p = Player.Instance;
        Text.text =
            "Inventory:\n"
            + (go.HasBoat ? "Boat\n" : "")
            + (go.HasSail ? "Sail\n" : "")
            + (go.HasLoveLetter ? "Love Letter\n" : "")
            + (go.SavedSailor && !go.DeliveredSailor ? "Sailor\n" : "")
            + "\nSongs:\n"
            + (go.HasWindwards ? "Windwards\n" : "")
            + (go.HasHappyJig ? "Happy Jig\n" : "")
            + (go.HasSadShanty ? "Sad Shanty\n" : "")
            + (go.HasSlowJig ? "Slow Jig\n" : "")
            + (go.HasNorthEldritch ? "Mysterious Song from the North\n" : "")
            + (go.HasSouthEldritch ? "Mysterious Song from the South\n" : "")
            + (p.KnownSongs.Count > 0 ?
                "\nSelected Song:\n"
                + "\n<Q [space] E>\n"
                + Player.Instance.KnownSongs[Player.Instance.SelectedSong]
                : "")
        ;
    }
}
