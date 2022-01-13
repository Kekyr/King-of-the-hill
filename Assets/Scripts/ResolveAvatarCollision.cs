using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResolveAvatarCollision : MonoBehaviour
{
    private float _gravity = -9.81f;
    private float _positionZLimit = 2.4f;
    private float _positionYLimit = 0.5f;
    
    private int _gravityModificator=2;
    
    
    private void Start()
    {
        Physics.gravity = Vector3.up* _gravity * _gravityModificator;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].point.z < _positionZLimit)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0f, _gravity * -1, 0f);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0f, _gravity * -0.95f, 0f);
        }

        if (collision.gameObject.GetComponent<GenerateRandomObstacles>() != null)
        {
            if (IsDiscAlsoThere(collision.transform) == false)
            {
                ScoreManager.ScoreModifier = 0;
                ScoreManager.Score++;
                ScoreManager.ScoreCounterPosition = collision.contacts[0].point;
                ScoreManager.ScoreCounterParent = collision.transform;
            }
        }
        else
        {
            Slot slot = collision.transform.parent.GetComponent<Slot>();
            ResolveCollision(slot, collision.gameObject);
        }
        
    }

    private void ResolveCollision(Slot slot, GameObject other)
    {
        if (slot == null)
            return;

        switch (slot.Obstacle)
        {
            case Obstacle.disc:
                ScoreManager.ScoreModifier++;
                ScoreManager.Score++;
                ScoreManager.ScoreCounterPosition = new Vector3(transform.position.x, transform.position.y - _positionYLimit, transform.position.z);
                ScoreManager.ScoreCounterParent = other.transform.parent.parent;
                break;
            
            case Obstacle.spike:
                SceneManager.LoadScene("StairsScene", LoadSceneMode.Single);
                break;
        }
    }
    

    private bool IsDiscAlsoThere(Transform stepTransform)
    {
        for (int i = 0; i < stepTransform.childCount; i++)
        {
            if (stepTransform.GetChild(i).childCount == 0)
            {
                continue;
            }

            if (stepTransform.GetChild(i).GetComponent<Slot>().Obstacle == Obstacle.disc)
            {
                Vector3 discPosition = stepTransform.GetChild(i).GetChild(0).position;
                float extents = stepTransform.GetChild(i).GetChild(0).GetComponent<BoxCollider>().bounds.extents.x;

                if (transform.position.x <= discPosition.x + extents && 
                    transform.position.x >= discPosition.x - extents)
                {
                    return true;
                }
            }
        }

        return false;

    }
    

   
}
