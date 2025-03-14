using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class Game_Manager : MonoBehaviour
{
    PrimitiveType primitiveToPlace;

    Vector3 nextShapePreviewPos = new Vector3(-7, 1, 1);
    GameObject previewObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        GenerateNextShape();
    }

    // Update is called once per frame
    void GenerateNextShape()
    {
        string objectTag = null;


        switch (Random.Range(0, 4)) //Da 0 a 3 (4 e' escluso)
        {
            case 0: primitiveToPlace = PrimitiveType.Cube; objectTag = "Block1"; break;
            case 1: primitiveToPlace = PrimitiveType.Sphere; objectTag = "Block2"; break;
            case 2: primitiveToPlace = PrimitiveType.Capsule; objectTag = "Block3"; break;
            case 3: primitiveToPlace = PrimitiveType.Cylinder; objectTag = "Block4"; break;
            default: primitiveToPlace = PrimitiveType.Cube; objectTag = "Block1"; break;
        }

        if (previewObject) Destroy(previewObject);

        previewObject = GameObject.CreatePrimitive(primitiveToPlace);
        previewObject.name = "Preview shape";
        previewObject.tag = objectTag;
        previewObject.transform.position = nextShapePreviewPos;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //right mouse button 
        {
            if(Time.time > 15)
            {
                enabled = false;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject go = GameObject.CreatePrimitive(primitiveToPlace);

                go.tag = previewObject.tag;
                go.transform.localScale = Vector3.one * 0.3f;
                go.transform.position = hit.point + new Vector3(0, 1f, 0);
                go.transform.rotation = Random.rotation;
                Block block = go.AddComponent<Block>();

                switch (primitiveToPlace)
                {
                    case PrimitiveType.Cube: block.Points = 5; break;
                    case PrimitiveType.Sphere: block.Points = 10; break;
                    case PrimitiveType.Capsule: block.Points = 15; break;
                    case PrimitiveType.Cylinder: block.Points = 25; break;
                }

                go.AddComponent<Rigidbody>();

                // Control color randomness
                Color randomColor = Random.ColorHSV();

                float H, S, V;
                Color.RGBToHSV(randomColor, out H, out S, out V);

                S = 0.8f;
                V = 0.8f;

                randomColor = Color.HSVToRGB(H, S, V);

                go.GetComponent<MeshRenderer>().material.color = randomColor;

                //MUST BE INSIDE ASSETS/RESOURCES
                Texture texture = Resources.Load<Texture>("Wood_Texture");

                Debug.Log(texture);

                //go.GetComponent<MeshRenderer>().material.SetTexture("_BaseMap", texture);
                go.GetComponent<MeshRenderer>().material.mainTexture = texture;

                go.AddComponent<DestroyOnFall>();

                go.AddComponent<DragWithMouse>();

                GenerateNextShape();

            }
        }
    }
}
