using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    public MoteCombiner moteCombiner;

    public void AddMote(GameObject mote)
    {
        inventory.Add(mote);
        if (inventory.Count == 2)
        {
            CombineMotes();
        }
    }

    public void RemoveMote(GameObject mote)
    {
        inventory.Remove(mote);
    }

    private void CombineMotes()
    {
        if (inventory.Count >= 2)
        {
            GameObject mote1 = inventory[0];
            GameObject mote2 = inventory[1];

            moteCombiner.CombineMotes(mote1, mote2);

            inventory.Clear();
        }
    }
}
