using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Obstacle
{
    empty, spike,disc
}

public class Slot : MonoBehaviour
{
    [SerializeField] private GameObject _spikePrefab;
    [SerializeField] private GameObject _discPrefab;

    private int _spikeLocalScaleModificator = 40;
    private int _discLocalScaleModificator = 50;
    
    private Obstacle _obstacle;

    public Obstacle Obstacle
    {
        get
        {
            return _obstacle;
        }
        set
        {
            if (transform.childCount > 0)
            {
                Destroy(transform.GetChild(0).gameObject);
            }

            _obstacle=value;

            if (value == Obstacle.empty)
            {
                return;
            }

            switch (value)
            {
                case Obstacle.spike:
                    GameObject spikeChild = Instantiate(_spikePrefab);
                    spikeChild.transform.SetParent(transform,false);
                    spikeChild.transform.localPosition = Vector3.zero;
                    spikeChild.transform.localScale = Vector3.one * _spikeLocalScaleModificator;
                    break;
                case Obstacle.disc:
                    GameObject discChild = Instantiate(_discPrefab);
                    discChild.transform.SetParent(transform,false);
                    discChild.transform.localPosition = new Vector3 (0f, -0.4999f, 0f);
                    discChild.transform.localScale = Vector3.one * _discLocalScaleModificator;
                    break;
            }
            
            
            
        }
    }
}
