using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoteSpawner : MonoBehaviour
{
    public static MoteSpawner Instance;

    public GameObject motePrefab;

    //2D Sprites
    public Sprite circleSprite;
    public Sprite squareSprite;
    public Sprite triangleSprite;

    //3D Sprites
    public Sprite sphereSprite;
    public Sprite cubeSprite;
    public Sprite pyramidSprite;
    public Sprite cylinderSprite;
    public Sprite coneSprite;
    public Sprite prismSprite;

    private GameObject Canvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    public void SpawnMote2D(Vector3 position, Mote2DFormen.ShapeType moteShape)
    {
        GameObject mote = Instantiate(motePrefab, position, Quaternion.identity);
        Image moteImage = mote.GetComponent<Image>();
        
        switch (moteShape)
        {
            case Mote2DFormen.ShapeType.Circle:
                moteImage.sprite = circleSprite;
                break;
            case Mote2DFormen.ShapeType.Square:
                moteImage.sprite = squareSprite;
                break;
            case Mote2DFormen.ShapeType.Triangle:
                moteImage.sprite = triangleSprite;
                break;
            default:
                moteImage = null;
                Debug.LogError("Unknown shape type: " + moteShape);
                break;
        }
        mote.GetComponent<Mote>().currentShape2D = moteShape;

        mote.transform.SetParent(Canvas.transform, true);
    }

    public void SpawnMote3D(GameObject mote2D, Mote3DFormen.ShapeType moteShape)
    {
        GameObject mote = Instantiate(motePrefab, mote2D.transform.position, Quaternion.identity);
        Image moteImage = mote.GetComponent<Image>();

        switch (moteShape)
        {
            case Mote3DFormen.ShapeType.Sphere:
                moteImage.sprite = sphereSprite;
                break;
            case Mote3DFormen.ShapeType.Cube:
                moteImage.sprite = cubeSprite;
                break;
            case Mote3DFormen.ShapeType.Pyramid:
                moteImage.sprite = pyramidSprite;
                break;
            case Mote3DFormen.ShapeType.Cylinder:
                moteImage.sprite = cylinderSprite;
                break;
            case Mote3DFormen.ShapeType.Cone:
                moteImage.sprite = coneSprite;
                break;
            case Mote3DFormen.ShapeType.Prism:
                moteImage.sprite = prismSprite;
                break;
            default:
                moteImage = null;
                Debug.LogError("Unknown shape type: " + moteShape);
                break;
        }
        motePrefab.GetComponent<Mote>().currentShape3D = moteShape;

        mote.transform.SetParent(mote2D.transform.parent, true);
    }
}
