using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour{

    public float force = 10f;
    public GameObject slicedFruit;
    
    private Text scoreText;
    private Rigidbody2D fruitRb;
    private LifeControl lifeControl;

    // Start is called before the first frame update
    void Start(){
        fruitRb = GetComponent<Rigidbody2D>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        lifeControl = GameObject.FindGameObjectWithTag("Life").GetComponent<LifeControl>();
        fruitRb.AddForce(transform.up*force, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag.Equals("Blade")){
            Vector2 direction = (collider.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject sliceFruit = Instantiate(slicedFruit, transform.position, rotation);
            scoreText.text = (int.Parse(scoreText.text) + 1).ToString();

            Destroy(sliceFruit, 3f);
            Destroy(gameObject);
        }

        else if(collider.tag.Equals("Bound")){
            LifeControl.lifeCountLost += 1;
            lifeControl.LifeLost();
        }
    }
    
}
