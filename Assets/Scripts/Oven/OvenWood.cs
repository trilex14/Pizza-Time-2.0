using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    public class OvenWood : MonoBehaviour
    {
        public float woodAddTemp;
        private OvenWood ovenWood;
        private ResourceLoader resourceLoader;

        void Start()
        {
            ovenWood = this;
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
        }

        //Adds Tempature to the Oven When Wood is added
        void OnCollisionEnter(Collision col)
        {
            GameObject oven = col.gameObject;
            if(oven.tag.Equals(resourceLoader.ovenObj.tag))
            {
                var ovenComp = oven.GetComponent<Oven>();
                ovenComp.newLogAdded = true;
                ovenComp.tempature += woodAddTemp;
                if (ovenComp.tempature >= ovenComp.maxTempature)
                {
                    ovenComp.tempature = ovenComp.maxTempature;
                }
                Destroy(this.gameObject);
            }
        }

    }
}

