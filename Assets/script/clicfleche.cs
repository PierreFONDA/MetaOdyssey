using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class clicfleche : MonoBehaviour
{
    
    
    
    private GameObject camera;
    private Animator animator;
    

    //pour le changement de texture
    public GameObject sphere;
    public Texture[] textureArray;
    private Renderer sphereRender;
    // Start is called before the first frame update

    
    
    private GameObject ObjFleche1;
    private fleche _fleche1;
    private GameObject ObjFleche2;
    private fleche _fleche2;
    public GameObject[] TabDot;//tableau des points sur la map
    //ajouter les objets fleches dedans depuis unity
    public GameObject[] TabGameObjFleche ;//les objet de scene fleche
    private fleche[] TabDirection;//tableau contenat les objets de classe fleche
    


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        //animator.SetBool("clicfleche",false);
        //fleche=GameObject.Find("fleche");
        camera=GameObject.Find("Main Camera");
        
        sphereRender=sphere.GetComponent<Renderer>();


        //Declaration des fleches
        TabDirection=new fleche[2];
        
        //instance de la classe fleche origin 0 direction 1 identifiant 0
        ObjFleche1=TabGameObjFleche[0];
        _fleche1 =new fleche(0,1,0,ObjFleche1);
        TabDirection[0]=_fleche1;
        //fleche2
        ObjFleche1=TabGameObjFleche[1];
         _fleche2 =new fleche(1,0,1,ObjFleche2);
        TabDirection[1]=_fleche2;

        Debug.Log(TabDirection.Length);

    }


    public void activatefleche (fleche _fleche){
        
        //_fleche.ObjFleche.gameObject.GetComponent<Animator>().SetBool("clicfleche",true);//SceneManager.LoadScene("SceneTwo"); 
        int direction=_fleche.getdirection();
        int origin=_fleche.getorigin();
        if (Input.GetMouseButtonDown(0))//quand le clic est activer
        {
            print("changescene");
            sphereRender.material.mainTexture=textureArray[direction];
                    //disparaitre fleche scene depart
            for(int i =0;i<TabDirection.Length;i++)
            {

                if(TabDirection[i].getorigin()==origin)
                { 
                    TabGameObjFleche[i].SetActive(false);
                }
                if(TabDirection[i].getorigin()==direction)
                { 
                    TabGameObjFleche[i].SetActive(true);
                }
            }
            TabDot[direction].SetActive(true);
            TabDot[origin].SetActive(false);
        //apparaitre les flaches de la scene d'arrive
        } 


        
    }
    // Update is called once per frame
    void Update()
    {   
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
        RaycastHit hit; 
        //quand l'object fleche passe sous la souris 
        if (Physics.Raycast(ray, out hit)) {     
            if (hit.transform.name == "fleche1") {  
                
                activatefleche( _fleche1);
            }
            if (hit.transform.name == "fleche2") {  
                
                activatefleche( _fleche2);
            }
            
        }
        else//la souris n'est pas dessus on enleve la couleur
        {
            _fleche1.ObjFleche.gameObject.GetComponent<Animator>().SetBool("clicfleche",false);
        }     
        
    }
}
