﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
namespace PizzaTime
{
    public enum PIZZA
    {
        Dough,
        Sauce,
        Cheese,
        Roni,
        Bacon,
        Peppers,
        Mushrooms,
        RoniBacon,
        RoniPepper,
        RoniMush,
        PeppersBacon,
        PeppersMush,
        BaconMush,
        RoniPeppersBacon,
        PeppersBaconMush,
        RoniBaconMush,
        RoniPeppersMush
    };
    
    // TODO: Refactor in a way that it could be expaneded laters
    public class Pizza_Controller : MonoBehaviour
    {
        // ----------------- Class Variables ---------------- \\
        public float cookTime = 0;
        public float doneTime = 10;
        public float burntTime = 20;
        public bool isCooked = false;
        public bool isBurned = false;
        public GameObject pizza;
        public Pizza_Controller pizzaController;
        public Material activePizzaTexture;
        private Material currentPizzaTexture;
        private PIZZA pizzaCase;
        private PIZZA toppingCase;
        private ResourceLoader resourceLoader;
        // -------------------------------------------------- \\
        void Start()
        {
            resourceLoader = GameObject.FindObjectOfType<ResourceLoader>();

            pizzaController = this;
            activePizzaTexture = resourceLoader.pizzaDoughMaterial;
        }
        public void Update()
        {
            pizza.GetComponent<Renderer>().material = activePizzaTexture;
        }

        private void OnCollisionEnter(Collision col)
        {
            GameObject topping = col.gameObject;
            currentPizzaTexture = pizza.GetComponent<Renderer>().sharedMaterial;

            //Looks at the current pizza texture and then sets pizzaCase to the correct value
            if (currentPizzaTexture.Equals(resourceLoader.pizzaDoughMaterial))
            {
                pizzaCase = PIZZA.Dough;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.sauceMaterial))
            {
                pizzaCase = PIZZA.Sauce;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.cheeseMaterial))
            {
                pizzaCase = PIZZA.Cheese;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.roniMaterial))
            {
                pizzaCase = PIZZA.Roni;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.baconMaterial))
            {
                pizzaCase = PIZZA.Bacon;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.peppersMaterial))
            {
                pizzaCase = PIZZA.Peppers;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.mushMaterial))
            {
                pizzaCase = PIZZA.Mushrooms;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.roniAndBaconMaterial))
            {
                pizzaCase = PIZZA.RoniBacon;
            }
            else if (currentPizzaTexture.Equals(resourceLoader.roniAndPeppersMaterial))
            {
                pizzaCase = PIZZA.RoniPepper;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.roniAndMushMaterial))
            {
                pizzaCase = PIZZA.RoniMush;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.peppersAndBaconMaterial))
            {
                pizzaCase = PIZZA.PeppersBacon;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.peppersAndMushMaterial))
            {
                pizzaCase = PIZZA.PeppersMush;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.baconAndMushMaterial))
            {
                pizzaCase = PIZZA.BaconMush;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.roniAndBaconAndPeppersMaterial))
            {
                pizzaCase = PIZZA.RoniPeppersBacon;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.mushAndBaconAndPeppers))
            {
                pizzaCase = PIZZA.PeppersBaconMush;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.roniAndBaconAndMushMaterial))
            {
                pizzaCase = PIZZA.RoniBaconMush;
            }
            else if(currentPizzaTexture.Equals(resourceLoader.roniAndPeppersAndMushMaterial))
            {
                pizzaCase = PIZZA.RoniPeppersMush;
            }

            switch(pizzaCase)
            {
                case PIZZA.Dough:
                    pizzaAddSauceTopping(topping);
                    break;
                case PIZZA.Sauce:
                    pizzaAddCheeseTopping(topping);
                    break;
                default:
                    ToppingSelector(topping);
                    break;
            }

        }


        void OnTriggerStay(Collider col)
        {
            GameObject oven = col.gameObject;
            if (oven.tag.Equals(resourceLoader.ovenObj.tag))
            {
                Cook();
            }
        }

        /// <summary>
        /// Selects the Topping Case to enable putting a topping onto a pizza
        /// </summary>
        /// <param name="topping"></param>
        private void ToppingSelector(GameObject topping)
        {
            if (topping.tag.Equals(resourceLoader.roniObj.tag))
            {
                toppingCase = PIZZA.Roni;
            }
            else if (topping.tag.Equals(resourceLoader.baconObj.tag))
            {
                toppingCase = PIZZA.Bacon;
            }
            else if (topping.tag.Equals(resourceLoader.pepperObj.tag))
            {
                toppingCase = PIZZA.Peppers;
            }
            else if (topping.tag.Equals(resourceLoader.mushObj.tag))
            {
                toppingCase = PIZZA.Mushrooms;
            }

            switch (toppingCase)
            {
                case PIZZA.Roni:
                    pizzaAddRoniTopping(topping);
                    break;
                case PIZZA.Bacon:
                    pizzaAddBaconTopping(topping);
                    break;
                case PIZZA.Peppers:
                    pizzaAddPeppersTopping(topping);
                    break;
                case PIZZA.Mushrooms:
                    pizzaAddMushroomsTopping(topping);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// If-Else Statment for Beginning the Pizza with Sauce
        /// </summary>
        /// <param name="topping"></param>
        private void pizzaAddSauceTopping(GameObject topping)
        {
            if (topping.tag.Equals(resourceLoader.sauceObj.tag))
            {
                activePizzaTexture = resourceLoader.sauceMaterial;
                Destroy(topping);
            }
        }

        /// <summary>
        /// If-Else Statement for Adding Cheese Before Able to Add Other Toppings
        /// </summary>
        /// <param name="topping"></param>
        private void pizzaAddCheeseTopping(GameObject topping)
        {
            if (topping.tag.Equals(resourceLoader.cheeseObj.tag))
            {
                activePizzaTexture = resourceLoader.cheeseMaterial;
                Destroy(topping);
            }
        }

        /// <summary>
        /// Adds Roni To the Current Pizza
        /// </summary>
        /// <param name="topping"></param>
        private void pizzaAddRoniTopping(GameObject topping)
        {
            switch(pizzaCase)
            {
                case PIZZA.Cheese:
                    activePizzaTexture = resourceLoader.roniMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Bacon:
                    activePizzaTexture = resourceLoader.roniAndBaconMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Peppers:
                    activePizzaTexture = resourceLoader.roniAndPeppersMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Mushrooms:
                    activePizzaTexture = resourceLoader.roniAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersBacon:
                    activePizzaTexture = resourceLoader.roniAndBaconAndPeppersMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersMush:
                    activePizzaTexture = resourceLoader.roniAndPeppersAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.BaconMush:
                    activePizzaTexture = resourceLoader.roniAndBaconAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersBaconMush:
                    activePizzaTexture = resourceLoader.theWorksMaterial;
                    Destroy(topping);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Adds Bacon to the Crrent Pizza
        /// </summary>
        /// <param name="topping"></param>
        private void pizzaAddBaconTopping(GameObject topping)
        {
            switch(pizzaCase)
            {
                case PIZZA.Cheese:
                    activePizzaTexture = resourceLoader.baconMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Roni:
                    activePizzaTexture = resourceLoader.roniAndBaconMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Peppers:
                    activePizzaTexture = resourceLoader.peppersAndBaconMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Mushrooms:
                    activePizzaTexture = resourceLoader.baconAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.RoniMush:
                    activePizzaTexture = resourceLoader.roniAndBaconAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.RoniPepper: 
                    activePizzaTexture = resourceLoader.roniAndBaconAndPeppersMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersMush:
                    activePizzaTexture = resourceLoader.mushAndBaconAndPeppers;
                    Destroy(topping);
                    break;
                case PIZZA.RoniPeppersMush:
                    activePizzaTexture = resourceLoader.theWorksMaterial;
                    Destroy(topping);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Adds Peppers to the Current Pizza
        /// </summary>
        /// <param name="topping"></param>
        private void pizzaAddPeppersTopping(GameObject topping)
        {
            switch(pizzaCase)
            {
                case PIZZA.Cheese:
                    activePizzaTexture = resourceLoader.peppersMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Roni:
                    activePizzaTexture = resourceLoader.roniAndPeppersMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Bacon:
                    activePizzaTexture = resourceLoader.peppersAndBaconMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Mushrooms:
                    activePizzaTexture = resourceLoader.peppersAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.RoniBacon:
                    activePizzaTexture = resourceLoader.roniAndBaconAndPeppersMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.RoniMush:
                    activePizzaTexture = resourceLoader.roniAndPeppersAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.BaconMush:
                    activePizzaTexture = resourceLoader.mushAndBaconAndPeppers;
                    Destroy(topping);
                    break;
                case PIZZA.RoniBaconMush:
                    activePizzaTexture = resourceLoader.theWorksMaterial;
                    Destroy(topping);
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Adds Mushrooms to the Current Pizza
        /// </summary>
        /// <param name="topping"></param>
        private void pizzaAddMushroomsTopping(GameObject topping)
        {
            switch(pizzaCase)
            {
                case PIZZA.Cheese:
                    activePizzaTexture = resourceLoader.mushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Roni:
                    activePizzaTexture = resourceLoader.roniAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Bacon:
                    activePizzaTexture = resourceLoader.baconAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.Peppers:
                    activePizzaTexture = resourceLoader.peppersAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.RoniBacon:
                    activePizzaTexture = resourceLoader.roniAndBaconAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.RoniPepper:
                    activePizzaTexture = resourceLoader.roniAndPeppersAndMushMaterial;
                    Destroy(topping);
                    break;
                case PIZZA.PeppersBacon:
                    activePizzaTexture = resourceLoader.mushAndBaconAndPeppers;
                    Destroy(topping);
                    break;
                case PIZZA.RoniPeppersBacon:
                    activePizzaTexture = resourceLoader.theWorksMaterial;
                    Destroy(topping);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Changes pizza to cooked material when cooked
        /// </summary>
        /// <param name="cooked"></param>
        private void CookedPizzas(bool cooked)
        {
            if(cooked)
            {
                switch (pizzaCase)
                {
                    case PIZZA.Cheese:
                        activePizzaTexture = resourceLoader.cookedCheeseMaterial;
                        break;
                    case PIZZA.Roni:
                        activePizzaTexture = resourceLoader.cookedRoniMaterial;
                        break;
                    case PIZZA.Bacon:
                        activePizzaTexture = resourceLoader.cookedBaconMaterial;
                        break;
                    case PIZZA.Peppers:
                        activePizzaTexture = resourceLoader.cookedPeppersMaterial;
                        break;
                    case PIZZA.Mushrooms:
                        activePizzaTexture = resourceLoader.cookedMushMaterial;
                        break;
                    case PIZZA.RoniPepper:
                        activePizzaTexture = resourceLoader.cookedRoniAndPeppersMaterial;
                        break;
                    case PIZZA.RoniBacon:
                        activePizzaTexture = resourceLoader.cookedRoniAndBaconMaterial;
                        break;
                    case PIZZA.RoniMush:
                        activePizzaTexture = resourceLoader.cookedRoniAndMushMaterial;
                        break;
                    case PIZZA.PeppersBacon:
                        activePizzaTexture = resourceLoader.cookedPeppersAndBaconMaterial;
                        break;
                    case PIZZA.PeppersMush:
                        activePizzaTexture = resourceLoader.cookedPeppersAndMushMaterial;
                        break;
                    case PIZZA.BaconMush:
                        activePizzaTexture = resourceLoader.cookedBaconAndMushMaterial;
                        break;
                    case PIZZA.RoniPeppersBacon:
                        activePizzaTexture = resourceLoader.cookedRoniAndBaconAndPeppersMaterial;
                        break;
                    case PIZZA.PeppersBaconMush:
                        activePizzaTexture = resourceLoader.cookedMushAndBaconAndPeppersMaterial;
                        break;
                    case PIZZA.RoniBaconMush:
                        activePizzaTexture = resourceLoader.cookedRoniAndBaconAndMushMaterial;
                        break;
                    case PIZZA.RoniPeppersMush:
                        activePizzaTexture = resourceLoader.cookedRoniAndPeppersAndMushMaterial;
                        break;
                    default:
                        activePizzaTexture = resourceLoader.cookedTheWorksMaterial;
                        break;
                }
            }
        }

        /// <summary>
        /// Timer for Determining whether the pizza is cooked/burned
        /// </summary>
        private void Cook()
        {
            cookTime += Time.deltaTime;
            if (cookTime >= doneTime && cookTime <= burntTime)
            {
                isCooked = true;
                CookedPizzas(isCooked);
            }   
            else if (cookTime >= burntTime)
            {
                isBurned = true;
                activePizzaTexture = resourceLoader.cookedBurnt;
            }
                
        }
    }
}