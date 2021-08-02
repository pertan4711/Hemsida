using Hemsida.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hemsida.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Pertans Pizza", Cuisine = Restaurant.CuisineType.Italian, Location = "Kungsholmen" },
                new Restaurant { Id = 2, Name = "Banglador", Cuisine = Restaurant.CuisineType.Indian, Location = "Upplandsgatan" },
                new Restaurant { Id = 3, Name = "Trattorian", Cuisine = Restaurant.CuisineType.None, Location = "Norr Mälarstrand" },
                new Restaurant { Id = 4, Name = "Prime Burger", Cuisine = Restaurant.CuisineType.American, Location = "Hantverkargatan" },
                new Restaurant { Id = 5, Name = "Uffe & Lottas", Cuisine = Restaurant.CuisineType.Swedish, Location = "Kungsholmsgatan" },
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
