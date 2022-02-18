using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleche : MonoBehaviour
{
    
    public GameObject ObjFleche;
    public int origin;//index of the origin sphere in textureArray
    public int direction;//the direction were that bring you,also index
    public int id;//identifiant

    public fleche (int Origin,int Direction,int identifiant,GameObject Fleche){
        ObjFleche=Fleche;
        origin=Origin;
        direction=Direction;
        id=identifiant;
    }
    public int getdirection(){
        return direction;
    }
    public int getorigin(){
        return origin;
    }
}
