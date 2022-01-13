using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomObstacles : MonoBehaviour
{
    public void Generate()
    {
        ResetSlots();

        int numberOfSpikes = Random.Range(0, transform.childCount-1);

        while (numberOfSpikes!=0)
        {
            int randomIndex = Random.Range(0, transform.childCount-1);
            
            if (transform.GetChild(randomIndex).GetComponent<Slot>().Obstacle != Obstacle.spike)
            {
                transform.GetChild(randomIndex).GetComponent<Slot>().Obstacle=Obstacle.spike;
                numberOfSpikes--;
            }
        }
        
        int numberOfDiscs = 1;

        while (numberOfDiscs!=0)
        {
            int randomIndex = Random.Range(0, transform.childCount-1);
            
            if (transform.GetChild(randomIndex).GetComponent<Slot>().Obstacle == Obstacle.empty)
            {
                transform.GetChild(randomIndex).GetComponent<Slot>().Obstacle=Obstacle.disc;
                numberOfDiscs--;
            }
        }
    }

    private void ResetSlots()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Slot slot = transform.GetChild(i).GetComponent<Slot>();
            if (slot != null)
            {
                slot.Obstacle = Obstacle.empty;
            }
        }
    }
}
