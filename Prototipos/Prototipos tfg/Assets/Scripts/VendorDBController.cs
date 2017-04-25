using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class VendorDBController : MonoBehaviour {

    public VendorDB db;

	// Use this for initialization
	void Start () {
		string datos = File.ReadAllText(Application.dataPath + "/Resources/vendors.json"); //establezco la ruta donde se encuentra el fichero json
        db = JsonUtility.FromJson<VendorDB>(datos);   
    }


    public Vendor getVendor(int id)
    {
        return db.vendors.Find(x => x.id == id);
    }


}
