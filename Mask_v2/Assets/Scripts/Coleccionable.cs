using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public bool tieneColeccionable = false;
    public bool mask1;
    public bool mask2;
    public bool mask3;
    public bool mask4;
    // Start is called before the first frame update
    void Start()
    {

        mask1 = false;
        mask2 = false;
        mask3 = false;
        mask4 = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "mask1")
        {
            Destroy(col.gameObject);
            mask1 = true;
            GameManager.Instance.mask1();
            GameManager.Instance.Img1();
            tieneColeccionable = true;
        }

        else if (col.gameObject.name == "mask2")
        {
            Destroy(col.gameObject);
            mask2 = true;
            GameManager.Instance.mask2();
            GameManager.Instance.Img2();
            tieneColeccionable = true;

        }

        else if (col.gameObject.name == "mask3")
        {
            Destroy(col.gameObject);
            mask3 = true;
            GameManager.Instance.mask3();
            GameManager.Instance.Img3();
            tieneColeccionable = true;
        }

        else if (col.gameObject.name == "mask4")
        {
            Destroy(col.gameObject);
            mask4 = true;
            GameManager.Instance.mask4();
            GameManager.Instance.Img4();
            tieneColeccionable = true;
        }

        if(mask1 == true && mask2 == true && mask3 == true && mask4 == true)
        {

        
        }

    }
}