using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMeshSpawner : MonoBehaviour
{
    Vector3[] meshVerticies;
    private Mesh mesh;
    private GameObject meshPosition;
    private GameObject parent;
    private MeshCollider meshCollider;
    private TurretConeController turretConeController;
    [SerializeField]private bool turretIsSet = false;
    [SerializeField] private Material meshMaterial;
    private bool trigger = true;

    // Start is called before the first frame update

    void Awake()
    {
        InstantiateMesh();
        
    }

    private void  InstantiateMesh()
    {
        //Note : Instatiate a new Parent gameobject to handle the Mesh and the Turret together
        // So if the parent get destroyed the mesh and the turret get destroyed
        parent = new GameObject("ParentOf" + "///" + this.gameObject.name);
        transform.parent = parent.GetComponent<Transform>();

        //Note: Uses the getVerteciesPosition to get the points where the 
        // direction Gameobjects looking at
        //Maybe It will Later get extendet so we can make complex Meshes
        meshVerticies = new Vector3[]{
            getVerticiesPosition(transform.GetChild(0).GetChild(0)),
            getVerticiesPosition(transform.GetChild(0).GetChild(1)),
            getVerticiesPosition(transform.GetChild(0).GetChild(2))
        };
        //Instatiating the Mesh
        mesh = new Mesh();
        meshPosition = new GameObject("MeshPosition" + "///" + this.gameObject.name);
        meshPosition.transform.position = meshVerticies[0];
        meshPosition.transform.parent = parent.GetComponent<Transform>();
        meshPosition.AddComponent<MeshFilter>();
        meshPosition.AddComponent<MeshRenderer>();
        meshPosition.GetComponent<MeshRenderer>().material = meshMaterial;
        meshPosition.GetComponent<MeshFilter>().mesh = mesh;
        meshPosition.AddComponent<TurretConeController>();
        turretConeController = meshPosition.GetComponent<TurretConeController>();
        turretConeController.setRefferentTurret(this.gameObject);
    }

    void Start(){
        mesh.vertices = meshVerticies;
        mesh.triangles = new int[]{
            2,0,1
        };

    }

    // Update is called once per frame
    void Update()
    {
        if(!turretIsSet){
        // Add stuff after Placing the Turret
        RefreshVertecies();
        }
        if(turretIsSet && trigger){
            AddMeshCollider();
            trigger = false;
        }
    }

    private Vector3 getVerticiesPosition(Transform direction){
        //Note: We use a Ray to get the point where they are looking at
        // To make a triangle for the Mesh
        Ray directionRaycast = new Ray(direction.transform.position,direction.forward);
        RaycastHit hit;
        if (Physics.Raycast(directionRaycast,out hit,Mathf.Infinity))
        {
            return(hit.point);
        }
        else{
            return Vector3.zero;
        }
    }

    public TurretConeController getTurretConeController(){
        return turretConeController;
    }

    public void RefreshVertecies(){

        meshVerticies = new Vector3[]{
            getVerticiesPosition(transform.GetChild(0).GetChild(0)),
            getVerticiesPosition(transform.GetChild(0).GetChild(1)),
            getVerticiesPosition(transform.GetChild(0).GetChild(2))
        };

        mesh.vertices = meshVerticies;
        meshPosition.transform.position = meshVerticies[0];
    }

    public void AddMeshCollider(){
        meshCollider =meshPosition.AddComponent<MeshCollider>();
        meshCollider.convex = true;
        meshCollider.isTrigger= true;
        meshCollider.cookingOptions = MeshColliderCookingOptions.EnableMeshCleaning;
        Destroy(meshPosition.GetComponent<MeshRenderer>());
    }

    public void setTurretIsSet(bool turretIsSet){
        this.turretIsSet = turretIsSet;
    }
}
