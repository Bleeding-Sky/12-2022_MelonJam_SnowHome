using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{

    public Image pipeCheckbox;
    public Image hatCheckbox;
    public Image scarfCheckbox;
    public Sprite checkedBox;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<ClothingHandler>().hasPipe)
        {
            pipeCheckbox.sprite = checkedBox;
        }

        if (player.GetComponent<ClothingHandler>().hasHat)
        {
            hatCheckbox.sprite = checkedBox;
        }

        if (player.GetComponent<ClothingHandler>().hasScarf)
        {
            scarfCheckbox.sprite = checkedBox;
        }

    }
}
