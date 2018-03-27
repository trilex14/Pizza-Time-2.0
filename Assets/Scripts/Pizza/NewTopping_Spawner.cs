using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PizzaTime
{
    public class NewTopping_Spawner : MonoBehaviour
    {
        // ------------------------- Class Variables -------------------------- \\
        public bool reset = false;
        public int maxSauceObjs;
        public int maxCheeseObjs;
        public int maxRoniObjs;
        public int maxBaconObjs;
        public int maxPepperObjs;
        public int maxMushroomObjs;
        private GameObject pizzaSpawnPosition;
        private GameObject sauceSpawnPosition;
        private GameObject cheeseSpawnPosition;
        private GameObject roniSpawnPosition;
        private GameObject baconSpawnPosition;
        private GameObject pepperSpawnPosition;
        private GameObject mushSpawnPosition;
        private GameObject pizzaObjForSpawner;
        private GameObject sauceObjForSpawner;
        private GameObject cheeseObjForSpawner;
        private GameObject roniObjForSpawner;
        private GameObject baconObjForSpawner;
        private GameObject pepperObjForSpawner;
        private GameObject mushObjForSpawner;
        private ResourceLoader resourceLoader;
        private GameObject[] sauceObjects;
        private GameObject[] cheeseObjects;
        private GameObject[] roniObjects;
        private GameObject[] baconObjects;
        private GameObject[] pepperObjects;
        private GameObject[] mushroomObjects;
        // -------------------------------------------------------------------- \\

        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();
            // ------------------- Topping Object Initalization ------------------------ \\
            pizzaObjForSpawner = resourceLoader.pizzaObj;
            sauceObjForSpawner = resourceLoader.sauceObj;
            cheeseObjForSpawner = resourceLoader.cheeseObj;
            roniObjForSpawner = resourceLoader.roniObj;
            baconObjForSpawner = resourceLoader.baconObj;
            pepperObjForSpawner = resourceLoader.pepperObj;
            mushObjForSpawner = resourceLoader.mushObj;
            // ------------------------------------------------------------------------- \\

            // ------------------- Topping Spawn Initalization ------------------------- \\
            pizzaSpawnPosition = GameObject.Find("Dough_Spawn");
            sauceSpawnPosition = GameObject.Find("Sauce_Spawn");
            cheeseSpawnPosition = GameObject.Find("Cheese_Spawn");
            roniSpawnPosition = GameObject.Find("Roni_Spawn");
            baconSpawnPosition = GameObject.Find("Bacon_Spawn");
            pepperSpawnPosition = GameObject.Find("Pepper_Spawn");
            mushSpawnPosition = GameObject.Find("Mushroom_Spawn");
            // ------------------------------------------------------------------------- \\
        }

        private void OnCollisionEnter(Collision col)
        {
            GameObject trigger = col.gameObject;
            if(trigger.tag.Equals(resourceLoader.pieSpawnTrigger.tag))
            {
                Instantiate(pizzaObjForSpawner, pizzaSpawnPosition.transform.position, pizzaSpawnPosition.transform.rotation);
            }
            else if(trigger.tag.Equals(resourceLoader.toppingSpawnTrigger.tag))
            {
                sauceObjects = GameObject.FindGameObjectsWithTag(resourceLoader.sauceObj.tag);
                cheeseObjects = GameObject.FindGameObjectsWithTag(resourceLoader.cheeseObj.tag);
                roniObjects = GameObject.FindGameObjectsWithTag(resourceLoader.roniObj.tag);
                baconObjects = GameObject.FindGameObjectsWithTag(resourceLoader.baconObj.tag);
                pepperObjects = GameObject.FindGameObjectsWithTag(resourceLoader.pepperObj.tag);
                mushroomObjects = GameObject.FindGameObjectsWithTag(resourceLoader.mushObj.tag);
                spawnTopping(sauceObjects, sauceObjForSpawner, sauceSpawnPosition, maxSauceObjs);
                spawnTopping(cheeseObjects, cheeseObjForSpawner, cheeseSpawnPosition, maxCheeseObjs);
                spawnTopping(roniObjects, roniObjForSpawner, roniSpawnPosition, maxRoniObjs);
                spawnTopping(baconObjects, baconObjForSpawner, baconSpawnPosition, maxBaconObjs);
                spawnTopping(pepperObjects, pepperObjForSpawner, pepperSpawnPosition, maxPepperObjs);
                spawnTopping(mushroomObjects, mushObjForSpawner, mushSpawnPosition, maxMushroomObjs);
            }
        }

        /// <summary>
        /// Spawns Toppings for the Specified max amount
        /// </summary>
        /// <param name="toppingArray">Topping Array</param>
        /// <param name="topping">Topping GameObject to Spawn</param>
        /// <param name="toppingSpawner">Topping Spawn Location</param>
        /// <param name="maxToppingAmount">Max Amount of Toppings to Spawn</param>
        private void spawnTopping(GameObject[] toppingArray, GameObject topping, GameObject toppingSpawner, int maxToppingAmount)
        {
            var length = toppingArray.Length;
            while(length != maxToppingAmount)
            {
                Instantiate(topping, toppingSpawner.transform.position, toppingSpawner.transform.rotation);
            }
        }
        
        
        //NOT SURE IF WILL BE NEEDED
        //    if (coll.tag == "button")
        //    {
        //        SceneManager.LoadScene("Level_GreyBox");
        //    }
        //    if (coll.tag == "reset")
        //    {
        //        dSceneManager.LoadScene("Level_GreyBox");
        //    }
        //}
    }
}
