using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CodeFlights
{
    public class GroupingDishes
    {
        private string[][] groupingDishes(string[][] dishes)
        {
            IDictionary<string, List<string>> hashMap = new Dictionary<string, List<string>>();

            for (int y = 0; y < dishes.Length; y++)
            {
                string dishName = dishes[y][0];

                for (int x = 1; x < dishes[y].Length; x++)
                {
                    string ingredientName = dishes[y][x];

                    if (!hashMap.ContainsKey(ingredientName))
                    {
                        hashMap[ingredientName] = new List<string>();
                    }

                    hashMap[ingredientName].Add(dishName);
                }
            }

            IOrderedEnumerable<string> orderedIngredients = hashMap.Where(x => x.Value.Count > 1).Select(x => x.Key).OrderBy(x => x);
            string[][] arr = new string[orderedIngredients.Count()][];

            for (int i = 0; i < orderedIngredients.Count(); i++)
            {
                List<string> returnValue = new List<string>();
                returnValue.Add(orderedIngredients.ElementAt(i));
                returnValue.AddRange(hashMap[orderedIngredients.ElementAt(i)].OrderBy(x => x));

                arr[i] = returnValue.ToArray();
            }

            return arr;
        }

        public void Run()
        {
            var returnValue = groupingDishes(new string[][] { new string[]{ "Salad", "Tomato", "Cucumber", "Salad", "Sauce" },
                                                     new string[]{ "Pizza", "Tomato", "Sausage", "Sauce", "Dough" },
                                                      new string[]{ "Quesadilla","Chicken","Cheese","Sauce" },
                                                       new string[]{ "Sandwich","Salad","Bread","Tomato","Cheese" },
                                                    });

        }
    }
}
