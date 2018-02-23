using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    //	Private properties
    private int timesHits;
    private LevelManager levelManager;
    private bool isBreakable;

    public Sprite[] hitSprite;

    void Start()
    {
        //	We identify if the brick is breakable or not (using tags) and set the
        //	isBreakable flag accordingly
        isBreakable = (this.tag == "Breakable");

        //	We keep track of how many breakable bricks we haver created, increasing
        //	the static property breakableCount.
        if (isBreakable)
        {
            breakableCount++;
        }

        //	We set the number ot times the brick has been hit to 0
        timesHits = 0;

        //	We link the LevelManager object to this script
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("LLEGO A HANDLEHITS");
        //	We use the PlayClipAtPoint method on the AudioSource object to play the
        //	cracking sound, even if the brick is destroyed.
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);

        //	If the brick is a breakable one, we call the HandleHits() method
        if (isBreakable)
        {
            HandleHits();
        }
    }
    void HandleHits()
    {
        Debug.Log("LLEGO A HANDLEHITS");
        //	We increase the number of hits the brick has received.
        timesHits++;

        //	Using this new number of hits received, we display the next, and the number
        //	of sprites assigned to this particular type of brick, we compute the max
        //	number of hits the brick can take.
        int maxHits = hitSprites.Length + 1;

        //	If the times the brick has been hit is greater than or equals to the max
        //	number of hits it can take, we proceed to destroy it.  To do that,we need
        //	to decrease the number of breakable bricks in our scene, and call the
        //	BrickDestroyed() method within the level manager instance in our script.
        //	Then, we call the PuffSmoke() method to simulate the bricks destruction and
        //	then we call the Destroy() method for this game object.
        //	However, if the times the brick has been hit is less than the max number of
        //	hits it can take, then we call the LoadSprites() method.
        if (timesHits >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity);
        /*
		 * How would we do this in the newest version of Unity?
		smokePuff.GetComponent<ParticleSystem> ().main.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
		*/
    }
    void LoadSprites()
    {
        int spriteIndex = timesHits - 1;

        if (hitSprite[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        }
    }
}
