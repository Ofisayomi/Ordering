using System;
using System.Collections.Generic;
using System.Linq;
using Order_Manager.Models;
using Order_Manager.Models.Domain;

namespace Order_Manager.Services {
    public class OrderServices {
        OrderContext _cxt;
        public OrderServices (OrderContext cxt) {
            _cxt = cxt;
        }

        const double PIx = 3.141592653589793;
        const double RADIUS = 6371e3; //.16;

        public static double Radians (double x) {
            return x * PIx / 180;
        }
        public static double DistanceBetweenPlaces (
            double lon1,
            double lat1,
            double lon2,
            double lat2) {
            double dlon = Radians (lon2 - lon1);
            double dlat = Radians (lat2 - lat1);

            double a = (Math.Sin (dlat / 2) * Math.Sin (dlat / 2)) + Math.Cos (Radians (lat1)) * Math.Cos (Radians (lat2)) * (Math.Sin (dlon / 2) * Math.Sin (dlon / 2));
            double angle = 2 * Math.Atan2 (Math.Sqrt (a), Math.Sqrt (1 - a));
            return angle * RADIUS;
        }

        public List<Product> GetProducts(){
            List<Product> products = new List<Product>();
            bool prods = _cxt.Products.Any();
            if(prods){
                products = _cxt.Products.ToList();
            }
            else{
                bool create = new DataSeed(_cxt).CreateProducts();
                if(create)
                {
                    products = _cxt.Products.ToList();
                }
            }
            return products;
        }
        public Distances GetClosestOffice (double longitude, double latitude) {
            List<Distances> distances = new List<Distances> ();
            List<Office> offices = new List<Office> ();
            bool checky = _cxt.Offices.Any ();
            DataSeed seed = new DataSeed (_cxt);
            if (!checky) {
                if(seed.CreateOffices())
                {
                    offices = _cxt.Offices.ToList();
                }
            } else {
                offices = _cxt.Offices.ToList ();
            }

            foreach (Office office in offices) {
                double dist = DistanceBetweenPlaces (longitude, latitude, office.longitude, office.latitude);
                Distances distance = new Distances {
                    OfficeId = office.OfficeId,
                    distance = dist,
                    description = office.Description
                };
                distances.Add (distance);
            }

            List<Distances> distos = distances.OrderBy (disto => disto.distance).ToList ();
            return distos.First ();
        }

        public class Distances {
            public int OfficeId { get; set; }
            public double distance { get; set; }
            public string description { get; set; }
        }

    }
}