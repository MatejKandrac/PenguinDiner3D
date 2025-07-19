using System;
using Objects.Foods;
using UnityEngine;
using Random = System.Random;

namespace Game
{
    public class Penguin : MonoBehaviour
    {
        public FoodType desiredFood;
        // private float _waitAssignSatisfaction = 0f;
        // private float _waitOrderSatisfaction = 0f;
        // private float _waitFoodSatisfaction = 0f;
        // private float _foodQualityModifier = 0f;
        // private float _restaurantEntertainmentModifier = 0f;

        private void Start()
        {
            var random = new Random();
            var foodOptions = Enum.GetValues(typeof(FoodType));
            var randomFood = random.Next(foodOptions.Length);
            desiredFood = (FoodType)foodOptions.GetValue(randomFood);
        }
    }
}