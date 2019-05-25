using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothing = 1f;

    private Transform cam;

    private Vector3 previousCamPos;
    // Start is called before the first frame update

    void Awake()
    {
        cam = Camera.main.transform;
    }
    void Start()
    {
        if (backgrounds == null || backgrounds.Length == 0)
        {
            backgrounds = new Transform[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                backgrounds[i] = transform.GetChild(i);
            }
        }
        previousCamPos = cam.position;
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var x = true;
        var y = false;
        
        for (int i = 0; i < backgrounds.Length; i++)
        {
            var parallax = (cam.position - previousCamPos) * parallaxScales[i];
            var backgroundTargetPos = backgrounds[i].position + new Vector3(x ? parallax.x : 0,y ? parallax.y : 0,0);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position,backgroundTargetPos, smoothing * Time.deltaTime);
        }
        previousCamPos = cam.position;
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ScrollLeft();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ScrollRight();
        }
        */
    }
    
    /*
    void ScrollLeft()
    {
        var b = backgrounds.Skip(backgrounds.Length - 1);
        b.First().transform.position += Vector3.left * Vector3.Distance(backgrounds.First().position, b.First().position);
        backgrounds = b.Concat(backgrounds.Take(backgrounds.Length - 1)).ToArray();
    }
    void ScrollRight()
    {
        var b = backgrounds.Take(1);
        backgrounds = backgrounds.Skip(1).Concat(b).ToArray();
    }
    */
}
