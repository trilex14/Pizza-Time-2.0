using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaTime
{
    /// <summary>
    /// Used for Loading Game Objects and/or Materials
    /// </summary>
    public class ResourceLoader : MonoBehaviour
    {
        // -------------- GameObject Variables ------------------------------------------------------------------------------------------ \\
        public GameObject pizzaObj;
        public GameObject sauceObj;
        public GameObject cheeseObj;
        public GameObject roniObj;
        public GameObject baconObj;
        public GameObject pepperObj;
        public GameObject mushObj;
        public GameObject ovenObj;
        public GameObject pieSpawnTrigger;
        public GameObject toppingSpawnTrigger;
        // ------------------------------------------------------------------------------------------------------------------------------ \\

        // -------------- Base Material Variables --------------------------------------------------------------------------------------- \\
        public Material pizzaDoughMaterial;
        public Material sauceMaterial;
        public Material cheeseMaterial;
        public Material roniMaterial;
        public Material baconMaterial;
        public Material peppersMaterial;
        public Material mushMaterial;
        // ------------------------------------------------------------------------------------------------------------------------------ \\

        // -------------- Two-Topping Material Variables -------------------------------------------------------------------------------- \\
        public Material roniAndBaconMaterial;
        public Material roniAndPeppersMaterial;
        public Material roniAndMushMaterial;
        public Material peppersAndMushMaterial;
        public Material peppersAndBaconMaterial;
        public Material baconAndMushMaterial;
        // ------------------------------------------------------------------------------------------------------------------------------ \\

        // -------------- Three-Topping Material Variables ------------------------------------------------------------------------------ \\
        public Material roniAndBaconAndPeppersMaterial;
        public Material roniAndBaconAndMushMaterial;
        public Material roniAndPeppersAndMushMaterial;
        public Material mushAndBaconAndPeppers;
        // ------------------------------------------------------------------------------------------------------------------------------ \\

        // -------------- Specialty Material Variables ---------------------------------------------------------------------------------- \\
        public Material theWorksMaterial;
        // ------------------------------------------------------------------------------------------------------------------------------ \\

        // --------------- Cooked Single Topping Material Variables --------------------------------------------------------------------- \\
        public Material cookedDoughMaterial;
        public Material cookedSauceMaterial;
        public Material cookedCheeseMaterial;
        public Material cookedRoniMaterial;
        public Material cookedBaconMaterial;
        public Material cookedPeppersMaterial;
        public Material cookedMushMaterial;
        public Material cookedBurnt;
        // ------------------------------------------------------------------------------------------------------------------------------ \\

        // --------------- Cooked Two-Topping Material Variables ------------------------------------------------------------------------ \\
        public Material cookedRoniAndBaconMaterial;
        public Material cookedRoniAndPeppersMaterial;
        public Material cookedRoniAndMushMaterial;
        public Material cookedPeppersAndMushMaterial;
        public Material cookedPeppersAndBaconMaterial;
        public Material cookedBaconAndMushMaterial;
        // ------------------------------------------------------------------------------------------------------------------------------ \\

        // --------------- Cooked Three-Topping Material Variables ---------------------------------------------------------------------- \\
        public Material cookedRoniAndBaconAndPeppersMaterial;
        public Material cookedRoniAndBaconAndMushMaterial;
        public Material cookedRoniAndPeppersAndMushMaterial;
        public Material cookedMushAndBaconAndPeppersMaterial;
        // ------------------------------------------------------------------------------------------------------------------------------ \\

        // -------------- Cooked Specialty Material Variables --------------------------------------------------------------------------- \\
        public Material cookedTheWorksMaterial;
        // ------------------------------------------------------------------------------------------------------------------------------ \\

        // Loads Game Objects / Materials
        void Start()
        {
            LoadResources();
        }

        private void LoadResources()
        {
            // -------------- Load GameObject Into Variables ---------------------------------------------------------------------------- \\
            pizzaObj = Resources.Load("ToppingPrefabs/Pie2.0") as GameObject;
            sauceObj = Resources.Load("ToppingPrefabs/Sauce2.0") as GameObject;
            cheeseObj = Resources.Load("ToppingPrefabs/Cheese2.0") as GameObject;
            roniObj = Resources.Load("ToppingPrefabs/Pepperoni2.0") as GameObject;
            baconObj = Resources.Load("ToppingPrefabs/Bacon2.0") as GameObject;
            pepperObj = Resources.Load("ToppingPrefabs/Pepper2.0") as GameObject;
            mushObj = Resources.Load("ToppingPrefabs/Mushroom2.0") as GameObject;
            ovenObj = Resources.Load("GamePrefabs/Oven") as GameObject;
            pieSpawnTrigger = Resources.Load("GamePrefabs/PieSpawnTrigger") as GameObject;
            toppingSpawnTrigger = Resources.Load("GamePrefabs/ToppingSpawnTrigger") as GameObject;
            // -------------------------------------------------------------------------------------------------------------------------- \\

            // -------------- Load Base Materials Into Variables ------------------------------------------------------------------------ \\
            pizzaDoughMaterial = Resources.Load("ToppingMaterial/Uncooked/Materials/Pizza_Dough") as Material;
            sauceMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Sauce") as Material;
            cheeseMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Cheese") as Material;
            roniMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Roni") as Material;
            baconMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Bacon") as Material;
            peppersMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Pepper") as Material;
            mushMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Mush") as Material;
            // -------------------------------------------------------------------------------------------------------------------------- \\

            // -------------- Load Two-Topping Materials Into Variables ----------------------------------------------------------------- \\
            roniAndBaconMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Roni_Bacon") as Material;
            roniAndPeppersMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Roni_Peppers") as Material;
            roniAndMushMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Roni_Mush") as Material;
            peppersAndMushMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Peppers_Mush") as Material;
            peppersAndBaconMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Peppers_Bacon") as Material;
            baconAndMushMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Bacon_Mush") as Material;
            // -------------------------------------------------------------------------------------------------------------------------- \\

            // -------------- Load Three-Topping Materials Into Variables --------------------------------------------------------------- \\
            roniAndBaconAndPeppersMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Roni_Bacon_Peppers") as Material;
            roniAndBaconAndMushMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Roni_Bacon_Mush") as Material;
            roniAndPeppersAndMushMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_Roni_Peppers_Mush") as Material;
            mushAndBaconAndPeppers = Resources.Load("ToppingMaterial/Uncooked/Pizza_Bacon_Peppers_Mush") as Material;
            // -------------------------------------------------------------------------------------------------------------------------- \\

            // -------------- Load Specialty Material Variables ------------------------------------------------------------------------- \\
            theWorksMaterial = Resources.Load("ToppingMaterial/Uncooked/Pizza_The_Works") as Material;
            // -------------------------------------------------------------------------------------------------------------------------- \\

            // --------------- Load Cooked Single Topping Material Into Variables ------------------------------------------------------- \\
            cookedDoughMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Dough") as Material;
            cookedSauceMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Sauce") as Material;
            cookedCheeseMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Cheese") as Material;
            cookedRoniMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Roni") as Material;
            cookedBaconMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Bacon") as Material;
            cookedPeppersMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Peppers") as Material;
            cookedMushMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Mush") as Material;
            cookedBurnt = Resources.Load("ToppingMaterial/Cooked/Burnt") as Material;
            // -------------------------------------------------------------------------------------------------------------------------- \\

            // --------------- Load Cooked Two-Topping Material Into Variables ---------------------------------------------------------- \\
            cookedRoniAndBaconMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Roni_Bacon") as Material;
            cookedRoniAndPeppersMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Roni_Peppers") as Material;
            cookedRoniAndMushMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Roni_Mush") as Material;
            cookedPeppersAndMushMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Peppers_Mush") as Material;
            cookedPeppersAndBaconMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Peppers_Bacon") as Material;
            cookedBaconAndMushMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Bacon_Mush") as Material;
            // -------------------------------------------------------------------------------------------------------------------------- \\

            // --------------- Load Cooked Three-Topping Material Into Variables -------------------------------------------------------- \\
            cookedRoniAndBaconAndPeppersMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Roni_Bacon_Peppers") as Material;
            cookedRoniAndBaconAndMushMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Roni_Bacon_Mush") as Material;
            cookedRoniAndPeppersAndMushMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Roni_Peppers_Mush") as Material;
            cookedMushAndBaconAndPeppersMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Mush_Bacon_Peppers") as Material;
            // -------------------------------------------------------------------------------------------------------------------------- \\

            // -------------- Load Specialty Material Variables ------------------------------------------------------------------------- \\
            cookedTheWorksMaterial = Resources.Load("ToppingMaterial/Cooked/Cooked_Works") as Material;
            // -------------------------------------------------------------------------------------------------------------------------- \\
        }
    }
}
