using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject tunel;
    public GameObject room;
    public GameObject container;
    public GameObject romsholter;
    public int rooms;
    public int crownded;
    private Vector3 face = new Vector3 (-14,5,-1);
    void Start() {
        List<GameObject> nodes = new List<GameObject>() ;
            for (int i = 0 ; i < rooms; i++){
                for (int j = 0 ; j < rooms; j++){
                    Vector3 desface = new Vector3 ( 25 * i + (j*2), 0 , 25 * j + (i*-2) );
                    Vector3 posix = gameObject.transform.position + desface;
                    Quaternion rotate = room.transform.rotation;

                    GameObject next = Instantiate( room , posix , rotate );
                    next.transform.localScale = new Vector3 (0.7f,0.7f,0.7f);
                    next.gameObject.transform.parent = romsholter.transform;
                    rooter(next);
                    nodes.Add(next);
                }
            }
         CCleaner();

    }

    void Update(){
        
    }

    void rooter(GameObject root ){
        List<GameObject> nodes = new List<GameObject>() ;
            nodes.Add(root.transform.GetChild(2).gameObject);
            nodes.Add(root.transform.GetChild(1).gameObject);
            nodes.Add(root.transform.GetChild(4).gameObject);
            nodes.Add(root.transform.GetChild(3).gameObject);        

            for (int i = 0; i < nodes.Count; i++){
                nodes[i].gameObject.transform.parent = container.transform;
                if (Random.Range(0,100) < crownded ){
                    GameObject aux = Instantiate( tunel, nodes[i].transform.position  , nodes[i].transform.rotation );
                    aux.transform.Translate(face);
                    aux.gameObject.transform.parent = gameObject.transform;
                    Destroy(nodes[i].gameObject);
                }
            }

    }

    void CCleaner(){
        List<GameObject> childrens = new List<GameObject>();
        foreach (Transform child in gameObject.transform)
        {
            childrens.Add(child.gameObject);
        }
        
        for (int i = 0; i < childrens.Count; i++){
            for (int j = 0; j < childrens.Count; j++){
                if ( i != j ){
                    Vector3 dist = (childrens[i].transform.position - childrens[j].transform.position);
                    bool samerot = childrens[i].transform.rotation == childrens[j].transform.rotation;
                    if (dist.magnitude < 20 && samerot){
                        Destroy(childrens[i]);                        
                    }
                }
            }
        }


    }


}
