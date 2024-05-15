using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed =0.2f;
    public Game game;

    int clickCount = 0;
    string tag = "";
    private void OnMouseEnter()
    {
        jump();
    }
    public void jump()
    {
        transform.Translate(Vector3.right * moveSpeed );
        transform.Translate(Vector3.up * moveSpeed );
        if (clickCount > 5)
        {
            clickCount = 0;
        }

        game.ColorBoxShifter(clickCount);

        clickCount++;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null)
        {
            tag = other.GetComponent<Renderer>().material.color.ToHexString() ;
        }
        else
        {
            tag = "";
        }
    }

    public string GetTag()
    {
        return tag;
    }
}
