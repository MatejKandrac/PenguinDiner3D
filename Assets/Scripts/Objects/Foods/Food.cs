using UnityEngine;

namespace Objects.Foods
{
    [CreateAssetMenu(fileName = "Food", menuName = "Scriptable Objects/Food")]
    public class Food : ScriptableObject
    {
        public FoodType foodType;
    }

    public enum FoodType
    {
        FishRagu, Stew
    }
}
