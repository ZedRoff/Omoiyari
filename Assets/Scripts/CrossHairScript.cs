
using System.Collections.Generic;
using System.Linq;
using DoorScript;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CrossHairScript : MonoBehaviour
{
   
    private float rayDistance = 5.0f;
    public Camera camView;
    public Sprite EKeyImage;
    public Sprite RKeyImage;
    public Sprite defaultImage;
    public Image crossHair;
    public InventoryScript inventoryScript;
    public ItemsList itemsList;
    private float defaultSize = 3.0f;
    private float scaledSize = 12.0f;
    public Image holdPoint;
    public GameScript gameScript;
    public ActionsScript actionsScript;

    public List<string> contenus = new List<string>();
    public Material bonneCouleur;
    public Material mauvaiseCouleur;
    public Material pasAssezCouleur;
    public Material videCouleur;
    public GameObject becher;
    public GameObject status;
    public TextMeshPro statusText;
    public List<string> ingredients;

    public GameObject colorsMenu;

    public Material yellowMaterial;
    public Material greenMaterial;
    public Material redMaterial;
    public Material blueMaterial;
    public Material violetMaterial;



    private Dictionary<string, Material> requiredMaterials = new Dictionary<string, Material>();
    private List<GameObject> coloredObjects = new List<GameObject>();
    public bool testBool;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        inventoryScript = GameObject.Find("Inventory Manager").GetComponent<InventoryScript>();
        itemsList = GameObject.Find("Items Manager").GetComponent<ItemsList>();
        gameScript = GameObject.Find("Game Manager").GetComponent<GameScript>();
         actionsScript = GameObject.Find("Actions Manager").GetComponent<ActionsScript>();
        statusText = status.GetComponent<TextMeshPro>();
        statusText.text = $"Ajouter le mélange";
        colorsMenu.SetActive(false);

        ingredients.Add(itemsList.items["aOHN"].itemName);
        ingredients.Add(itemsList.items["Cu504"].itemName);
        ingredients.Add(itemsList.items["NAH5O3"].itemName);
        ingredients.Add(itemsList.items["NAHGO3"].itemName);
        ingredients.Add(itemsList.items["Cu2O"].itemName);

        requiredMaterials.Add("BigTriangleLeft (1)", blueMaterial);
        requiredMaterials.Add("Square (1)", violetMaterial);
        requiredMaterials.Add("SmallTriangle2 (1)", blueMaterial);
        requiredMaterials.Add("Parallelogram (1)", yellowMaterial);
        requiredMaterials.Add("MediumTriangle (1)", redMaterial);
        requiredMaterials.Add("SmallTriangle1 (1)", greenMaterial);
        requiredMaterials.Add("BigTriangle1 (1)", violetMaterial);


    }

    public bool AreAllColorsSet()
    {
        foreach (var item in requiredMaterials)
        {
            GameObject obj = GameObject.Find(item.Key);

            if (obj != null)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null && renderer.material != item.Value)
                {
                    return false;
                }
            }
            else
            {
                Debug.LogError($"Object {item.Key} not found!");
                return false;
            }
        }
        return true;
    }

    public void VerserDansBecher(string itemName)
    {
            contenus.Add(itemName);
    }
    IEnumerator CheckSolution()
    {
        statusText.text = "En attente...";
        yield return new WaitForSeconds(2.0f);
        Renderer rend = becher.GetComponent<Renderer>();
        statusText.text = "Notez votre résultat au tableau";
        if (contenus.Count != 5)
        {
            rend.material = pasAssezCouleur;
        }
        else
        {
            if (CheckMix())
            {
                rend.material = bonneCouleur;
            }
            else
            {
                rend.material = mauvaiseCouleur;
            }
        }
        gameScript.isAllowedToAnswerChemistry = true;
    }

    void ResetMelange()
    {
        gameScript.isAllowedToAnswerChemistry = false;
        statusText.text = "Ajouter le mélange";
        Renderer rend = becher.GetComponent<Renderer>(); 
        rend.material = videCouleur;
        contenus.Clear();
    }
    // Update is called once per frame
    void Update()
    {


        if (AreAllColorsSet() || testBool)
        {
            gameScript.hasFinishedPlayground = true;
            gameScript.filter.DeActivateDaltonism();
            gameScript.playgroundCollider.GetComponent<BoxCollider>().isTrigger = true;
        }



        Ray ray = new Ray(camView.transform.position, camView.transform.forward);
        RaycastHit hit;
         Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Collectible") && (gameScript.player.inventory.HasItem("Bag") || hit.collider.gameObject.name == "Bag"))
            {
                if(Input.GetKeyUp(KeyCode.E)) {
                    string itemName = hit.collider.gameObject.name;

            if(itemsList.items.ContainsKey(itemName)) {


                Item item = itemsList.items[itemName];
                inventoryScript.player.inventory.AddItem(item);
                        if(item.usable)
                        {
                            gameScript.ChangeCurrentItem(item);
                        }
               
                Debug.Log("Picked up: " + item.itemName);
                        if(item.itemName == "Clé")
                        {
                            actionsScript.FinishTask("Trouvez la clé");
                        }

                        if (hit.collider.gameObject.TryGetComponent<TangramPiece>(out var myComponent))
                        {
                            hit.collider.GetComponent<TangramPiece>().Collect();
                        }



                        hit.collider.gameObject.SetActive(false);
            }
                }
                crossHair.sprite = EKeyImage;
                crossHair.rectTransform.localScale = new Vector3(scaledSize, scaledSize, scaledSize);
              
               
            } else if(hit.collider.CompareTag("Interactable")) {


                if(Input.GetKeyUp(KeyCode.R) && hit.collider.name.Contains("(1)"))
                {
                    string itName = gameScript.player.currentItem.itemName;
                    string hitColName = hit.collider.gameObject.name;
                    Renderer renderer = hit.collider.GetComponent<Renderer>();
                   if (itName == "BlueBigTriangle")
                    {
                        if (hitColName == "BigTriangleLeft (1)")
                        {
                            renderer.material = blueMaterial;
                        }
                    } else if(itName == "PurpleSquare")
                    {
                        if (hitColName == "Square (1)")
                        {
                            renderer.material = violetMaterial;
                        }
                    }
                    else if (itName == "BlueSmallTriangle")
                    {
                        if (hitColName == "SmallTriangle2 (1)")
                        {
                            renderer.material = blueMaterial;
                        }
                    }
                    else if (itName == "YellowPara")
                    {
                        if(hitColName == "Parallelogram (1)")
                        {
                            renderer.material = yellowMaterial;
                        }
                    }
                    else if (itName == "RedMediumTriangle")
                    {
                        if(hitColName == "MediumTriangle (1)")
                        {
                            renderer.material = redMaterial;
                        }
                    }
                    else if (itName == "GreenSmallTriangle")
                    {
                        if (hitColName == "SmallTriangle1 (1)")
                        {
                            renderer.material = greenMaterial;
                        }
                    }
                    else if (itName == "VioletBigTriangle")
                    {
                        if (hitColName == "BigTriangle1 (1)")
                        {
                            renderer.material = violetMaterial;
                        }
                    }
                }


                if(Input.GetKeyUp(KeyCode.R) && hit.collider.name == "ResultColor" && !gameScript.isAllowedToAnswerChemistry)
                {
                    gameScript.stateScript.state = State.NotAllowedToAnswer;
                    return;
                }
                if(hit.collider.name == "ResultColor" && gameScript.isAllowedToAnswerChemistry)
                {
                    if (Input.GetKeyUp(KeyCode.R))
                    {
                        colorsMenu.SetActive(true);
                        gameScript.stateScript.state = State.ColorMenu;
                        Cursor.lockState = CursorLockMode.None;
                    }
                }

                if(hit.collider.name == "Becher" && gameScript.isAllowedToAnswerChemistry && Input.GetKeyUp(KeyCode.R))
                {
                    gameScript.stateScript.state = State.StartBecherAlreadyDialog;
                    return;
                }

                if (hit.collider.name == "Becher")
                {
                    if (Input.GetKeyUp(KeyCode.C))
                    {
                        StartCoroutine(CheckSolution());
                    }
                    if (Input.GetKeyUp(KeyCode.V))
                    {
                        ResetMelange();
                    }
                }

                if (Input.GetKeyUp(KeyCode.R)) {
                     if(hit.collider.name == "Becher")
                    {
                        string playerCurrentItemName = gameScript.player.currentItem.itemName;
                        if (!ingredients.Contains(playerCurrentItemName)) return;
                        VerserDansBecher(playerCurrentItemName);
                        var groupedContents = contenus
     .GroupBy(item => item)
     .Select(group => $"{group.Count()}{group.Key}");

                        statusText.text = string.Join(" + ", groupedContents);
                    }
                    if(hit.collider.name == "Door") {
                        if(gameScript.player.currentItem.itemName == "Clé") {
                            hit.collider.gameObject.GetComponent<Door>().OpenDoor();
                            gameScript.player.inventory.RemoveItem(gameScript.player.currentItem);
                            actionsScript.FinishTask("Ouvrir la porte");
                        }
                    }

}
  crossHair.sprite = RKeyImage;
                crossHair.rectTransform.localScale = new Vector3(scaledSize, scaledSize, scaledSize);
              
            }
            else
            {  
              crossHair.sprite = defaultImage;
              crossHair.rectTransform.localScale = new Vector3(defaultSize, defaultSize, defaultSize);
               
            }
        }
        else
        {
             crossHair.sprite = defaultImage;
             crossHair.rectTransform.sizeDelta = new Vector3(defaultSize, defaultSize, defaultSize);
        }
    }

    public bool CheckMix()
    {
        int aOHNCount = 0;
        int Cu504Count = 0;

        foreach (string itemName in contenus)
        {
            if (Cu504Count < 2 && itemName == "Cu504" && aOHNCount == 0)
            {
                Cu504Count++;
            }
            else if (Cu504Count == 2 && aOHNCount < 3 && itemName == "aOHN")
            {
                aOHNCount++;
            }
            else
            {
                return false;
            }
        }

        return Cu504Count == 2 && aOHNCount == 3;
    }
}
