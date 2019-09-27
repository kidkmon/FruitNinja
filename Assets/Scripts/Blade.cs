using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour{

    [SerializeField] private bool isCutting = false;
    [SerializeField] private float minVelocityCut = 0.0f;
    
    private CircleCollider2D circleCollider;
    private Rigidbody2D rigidBody;
    private Vector2 lastPosition;

    private GameObject currentLine;

    // Start is called before the first frame update
    void Start(){
        circleCollider = GetComponent<CircleCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        
        if(Input.GetMouseButtonDown(0)){
            StartCutting();
        }
        else if(Input.GetMouseButtonUp(0)){
            StopCutting();
        }

        if(isCutting){
            UpdateCut();
        }
    }

    void UpdateCut(){
        Vector2 newPosition = (Vector2) Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        rigidBody.position = newPosition;
        
        float velocity = (newPosition-lastPosition).magnitude * Time.deltaTime;

        if(velocity > minVelocityCut){
            circleCollider.enabled = true;
        }
        else{
            circleCollider.enabled = false;
        }

        lastPosition = newPosition;
    }

    void StartCutting(){
        isCutting = true;
        circleCollider.enabled = true;
        lastPosition = (Vector2) Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }

    void StopCutting(){
        isCutting = false;
        circleCollider.enabled = false;
    }

}
