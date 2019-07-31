using System;
using System.Collections.Generic;
using Order_Manager.Models;
using Order_Manager.Models.Domain;

namespace Order_Manager.Services {
    public class DataSeed {
        OrderContext _cxt;
        public DataSeed (OrderContext cxt) {
            _cxt = cxt;
        }

        public bool CreateOffices () {
            try {
                List<Office> offices = new List<Office> {
                    new Office {
                    Description = "Maitama, Abuja",
                    longitude = 8.897767,
                    latitude = 9.007866
                    },
                    new Office {
                    Description = "Asokoro, Abuja",
                    longitude = 8.797767,
                    latitude = 9.107866
                    },
                    new Office {
                    Description = "Nyanya, Abuja",
                    longitude = 8.297767,
                    latitude = 9.407866
                    },
                    new Office {
                    Description = "Area 1, Abuja",
                    longitude = 8.837767,
                    latitude = 9.217866
                    },
                    new Office {
                    Description = "Zuba, Abuja",
                    longitude = 8.297767,
                    latitude = 9.907866
                    }
                };
                _cxt.Offices.AddRange (offices);
                _cxt.SaveChanges ();
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public bool CreateProducts () {
            try{
            List<Product> products = new List<Product> {
                new Product {
                Description = "Shirt",
                Price = 2000,
                ImagePath = "./pics/shirt.jpeg",
                },
                new Product {
                Description = "Shoe",
                Price = 2500,
                ImagePath = "./pics/shoe.jpeg",

                },
                new Product {
                Description = "Iron",
                Price = 3000,
                ImagePath = "./pics/iron.png",

                },
                new Product {
                Description = "Tie",
                Price = 1200,
                ImagePath = "./pics/tie.jpg",
                },
                new Product {
                Description = "Charger",
                Price = 1500,
                ImagePath = "./pics/charger.jpg",
                }
            };
            _cxt.Products.AddRange(products);
            _cxt.SaveChanges();
            return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}