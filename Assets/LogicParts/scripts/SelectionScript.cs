using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionScript : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private string stickTag = "Stick";
    [SerializeField] private Material highlightMaterial;

    [Header("Highlighting")]
    public float raycastLength;
    public Text printText;

    private Material defaultMaterial;
    private Transform _selection;
    private PickableObject selectionInfo;
    private int parts = 0;
    public Text partsCounter;

    public EnemyAiTutorial enemyScript;

    public bool handingAnyThing = false;
    public GameObject flashlight;
    public GameObject lighting;
    public GameObject burnUpFireText;
    public GameObject campfire;

    public GameObject winMenu;

    [Header("Stick_1")]
    public GameObject stickInHands;
    public GameObject StickPlacePosition;
    public GameObject StickOnFire;
    public GameObject StickInForest;

    [Header("Stick_2")]
    public GameObject shortStickInHands;
    public GameObject shortStickPlacePosition;
    public GameObject shortStickOnFire;
    public GameObject shortStickInForest;

    [Header("Torso")]
    public GameObject torsoInHands;
    public GameObject torsoPlacePosition;
    public GameObject torsoOnFire;
    public GameObject torsoInForest;

    [Header("Skirt")]
    public GameObject skirtInHands;
    public GameObject skirtPlacePosition;
    public GameObject skirtOnFire;
    public GameObject skirtInForest;

    [Header("RightHand")]
    public GameObject rightHandInHands;
    public GameObject rightHandPlacePosition;
    public GameObject rightHandOnFire;
    public GameObject rightHandInForest;

    [Header("LeftHand")]
    public GameObject leftHandInHands;
    public GameObject leftHandPlacePosition;
    public GameObject leftHandOnFire;
    public GameObject leftHandInForest;

    [Header("Head")]
    public GameObject headInHands;
    public GameObject headPlacePosition;
    public GameObject headOnFire;
    public GameObject headInForest;

    public GameObject vendizel;
    public GameObject directLight;
    public GameObject chuceloInFire;


    private void Awake()
    {
        RenderSettings.fog = true;
        shortStickInForest.SetActive(false);
        torsoInForest.SetActive(false);
        skirtInForest.SetActive(false);
        rightHandInForest.SetActive(false);
        leftHandInForest.SetActive(false);
        headInForest.SetActive(false);
    }

    void Win()
    {
        directLight.GetComponent<Animator>().enabled = true;
        RenderSettings.fog = false;
        Invoke(nameof(InFire), 3);
    }

    void InFire()
    {
        chuceloInFire.SetActive(true);
        Invoke(nameof(showWinMenu), 4);
    }

    void showWinMenu()
    {
        winMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        partsCounter.text = parts + " / 7";

        if(parts >= 2)
        {
            enemyScript.sightRange = 999999;
        }

        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
            printText.text = "";
        }

        if(!handingAnyThing)
        {
            flashlight.SetActive(true);
        }
        else
        {
            flashlight.SetActive(false);
        }

        if(parts == 7)
        {
            //burnUpFireText.SetActive(true);
            //lighting.SetActive(true);
            campfire.SetActive(true);
            Destroy(vendizel);
            Invoke(nameof(Win), 1f);
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, raycastLength))
        {
            var selection = hit.transform;
            if(selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null)
                {
                    selectionInfo = selection.GetComponent<PickableObject>();
                    defaultMaterial = selectionRenderer.material;
                    selectionRenderer.material = highlightMaterial;
                    printText.text = selectionInfo.objectsName;

                    if(selectionInfo.objectsName == "Eat puncake (E)")
                    {
                        printText.text = "Eat puncake";
                        if (Input.GetMouseButtonDown(0))
                        {
                            Destroy(selection.gameObject);
                            printText.text = "";
                            GetComponent<PlayerStatistic>().Hunger += 40;
                        }
                    }
                    if(selectionInfo.objectsName == "Burn campfire on (Needed lighter)")
                    {
                        printText.text = "";
                    }
                    if (selectionInfo.objectsName == "Stick")
                    {
                        if(Input.GetMouseButtonDown(0) && !handingAnyThing)
                        {
                            Destroy(selection.gameObject);
                            handingAnyThing = true;
                            stickInHands.SetActive(true);
                            StickPlacePosition.SetActive(true);
                            printText.text = "";
                        }
                    }
                    if(selectionInfo.objectsName == "Drop stick")
                    {
                        if(Input.GetMouseButtonDown(0))
                        {
                            Destroy(selection.gameObject);
                            handingAnyThing = false;
                            Destroy(stickInHands.gameObject);
                            StickOnFire.SetActive(true);
                            shortStickInForest.SetActive(true);
                            printText.text = "";
                            parts++;
                        }
                    }
                    if(selectionInfo.objectsName == "Short stick")
                    {
                        if(Input.GetMouseButtonDown(0) && !handingAnyThing)
                        {
                            Destroy(selection.gameObject);
                            handingAnyThing = true;
                            shortStickInHands.SetActive(true);
                            shortStickPlacePosition.SetActive(true);
                            printText.text = "";
                        }
                    }
                    if(selectionInfo.objectsName == "Drop short stick")
                    {
                        if(Input.GetMouseButtonDown(0))
                        {
                            Destroy(selection.gameObject);
                            handingAnyThing = false;
                            Destroy(shortStickInHands.gameObject);
                            shortStickOnFire.SetActive(true);
                            printText.text = "";
                            torsoInForest.SetActive(true);
                            skirtInForest.SetActive(true);
                            rightHandInForest.SetActive(true);
                            leftHandInForest.SetActive(true);
                            headInForest.SetActive(true);
                            parts++;
                        }
                    }
                    if(selectionInfo.objectsName == "Torso")
                    {
                        if(Input.GetMouseButtonDown(0) && !handingAnyThing)
                        {
                            Destroy(torsoInForest);
                            handingAnyThing = true;
                            torsoInHands.SetActive(true);
                            torsoPlacePosition.SetActive(true);
                            printText.text = "";
                        }
                    }
                    if(selectionInfo.objectsName == "Drop torso")
                    {
                        if(Input.GetMouseButtonDown(0))
                        {
                            Destroy(torsoPlacePosition);
                            handingAnyThing = false;
                            Destroy(torsoInHands.gameObject);
                            torsoOnFire.SetActive(true);
                            printText.text = "";
                            parts++;
                        }
                    }
                    if(selectionInfo.objectsName == "Skirt")
                    {
                        if(Input.GetMouseButtonDown(0) && !handingAnyThing)
                        {
                            Destroy(selection.gameObject);
                            handingAnyThing = true;
                            skirtInHands.SetActive(true);
                            skirtPlacePosition.SetActive(true);
                            printText.text = "";
                        }
                    }
                    if(selectionInfo.objectsName == "Drop skirt")
                    {
                        if(Input.GetMouseButtonDown(0))
                        {
                            Destroy(selection.gameObject);
                            handingAnyThing = false;
                            Destroy(skirtInHands.gameObject);
                            skirtOnFire.SetActive(true);
                            printText.text = "";
                            parts++;
                        }
                    }
                    if(selectionInfo.objectsName == "Right hand")
                    {
                        if(Input.GetMouseButtonDown(0) && !handingAnyThing)
                        {
                            Destroy(selection.gameObject);
                            handingAnyThing = true;
                            rightHandInHands.SetActive(true);
                            rightHandPlacePosition.SetActive(true);
                            printText.text = "";
                        }
                    }
                    if(selectionInfo.objectsName == "Drop right hand")
                    {
                        if(Input.GetMouseButtonDown(0))
                        {
                            Destroy(selection.gameObject);
                            handingAnyThing = false;
                            Destroy(rightHandInHands.gameObject);
                            rightHandOnFire.SetActive(true);
                            printText.text = "";
                            parts++;
                        }
                    }
                    if(selectionInfo.objectsName == "Left hand")
                    {
                        if(Input.GetMouseButtonDown(0) && !handingAnyThing)
                        {
                            Destroy(selection.gameObject);
                            handingAnyThing = true;
                            leftHandInHands.SetActive(true);
                            leftHandPlacePosition.SetActive(true);
                            printText.text = "";
                        }
                    }
                    if(selectionInfo.objectsName == "Drop left hand")
                    {
                        if(Input.GetMouseButtonDown(0))
                        {
                            Destroy(selection.gameObject);
                            handingAnyThing = false;
                            Destroy(leftHandInHands.gameObject);
                            leftHandOnFire.SetActive(true);
                            printText.text = "";
                            parts++;
                        }
                    }
                    if(selectionInfo.objectsName == "Head")
                    {
                        if(Input.GetMouseButtonDown(0) && !handingAnyThing)
                        {
                            Destroy(headInForest);
                            handingAnyThing = true;
                            headInHands.SetActive(true);
                            headPlacePosition.SetActive(true);
                            printText.text = "";
                        }
                    }
                    if(selectionInfo.objectsName == "Drop head")
                    {
                        if(Input.GetMouseButtonDown(0))
                        {
                            Destroy(headPlacePosition);
                            handingAnyThing = false;
                            Destroy(headInHands.gameObject);
                            headOnFire.SetActive(true);
                            printText.text = "";
                            parts++;
                        }
                    }
                }

                _selection = selection;
            }
        }
    }
}