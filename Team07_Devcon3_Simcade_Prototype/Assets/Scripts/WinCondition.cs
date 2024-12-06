using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject winText;
    public GameObject loseText;
    public int knockOutCount;
    public int strikeCount;
    // Start is called before the first frame update
    void Start()
    {
        knockOutCount = 0;
        strikeCount = 0;
        winText.SetActive(false);
        loseText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            if (this.gameObject.name == "Boarder")
            {
                knockOutCount++;
                if (knockOutCount == 3)
                {
                    winText.SetActive(true);
                }
            }
            else if (this.gameObject.name == "Missed Ball Collision")
            {
                strikeCount++;
                if (strikeCount == 3)
                {
                    loseText.SetActive(true);
                }
            }
        }
        
    }
}
