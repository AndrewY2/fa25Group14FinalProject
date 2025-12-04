using System;
using System.Collections.Generic;
using System.Linq;
using fa25Group14FinalProject.DAL;
using fa25Group14FinalProject.Models;

namespace fa25Group14FinalProject.Seeding
{
    public static class SeedOrders
    {
        public static void SeedAllOrders(AppDbContext db)
        {
            // =========================
            //  Seed Orders
            // =========================
            if (db.Orders.Any())
            {
                return; // already seeded
            }

            List<Order> orders = new List<Order>();

            // ----- Look up customers (names must match SeedPeople/SeedUsers) -----
            AppUser christopherBaker = db.Users.FirstOrDefault(u => u.FirstName == "Christopher" && u.LastName == "Baker");
            AppUser toddJacobs = db.Users.FirstOrDefault(u => u.FirstName == "Todd" && u.LastName == "Jacobs");
            AppUser charlesMiller = db.Users.FirstOrDefault(u => u.FirstName == "Charles" && u.LastName == "Miller");
            AppUser wendyChang = db.Users.FirstOrDefault(u => u.FirstName == "Wendy" && u.LastName == "Chang");
            AppUser limChou = db.Users.FirstOrDefault(u => u.FirstName == "Lim" && u.LastName == "Chou");
            AppUser jeffreyHampton = db.Users.FirstOrDefault(u => u.FirstName == "Jeffrey" && u.LastName == "Hampton"); // FIXED spelling
            AppUser ernestLowe = db.Users.FirstOrDefault(u => u.FirstName == "Ernest" && u.LastName == "Lowe");
            AppUser kellyNelson = db.Users.FirstOrDefault(u => u.FirstName == "Kelly" && u.LastName == "Nelson");
            AppUser chuckLuce = db.Users.FirstOrDefault(u => u.FirstName == "Chuck" && u.LastName == "Luce");
            AppUser erynRice = db.Users.FirstOrDefault(u => u.FirstName == "Eryn" && u.LastName == "Rice");

            // quick sanity check
            if (christopherBaker == null || toddJacobs == null || charlesMiller == null ||
                wendyChang == null || limChou == null || jeffreyHampton == null ||
                ernestLowe == null || kellyNelson == null || chuckLuce == null || erynRice == null)
            {
                throw new InvalidOperationException("SeedOrders: One or more customers could not be found. Check that SeedPeople/SeedUsers ran and the names match.");
            }

            // ----- Look up cards -----
            Card card4888 = db.Cards.FirstOrDefault(c => c.CardNumber == "4888561830797648");
            Card card5653 = db.Cards.FirstOrDefault(c => c.CardNumber == "5653264624505624");
            Card card7874 = db.Cards.FirstOrDefault(c => c.CardNumber == "7874839329412510");
            Card card8882 = db.Cards.FirstOrDefault(c => c.CardNumber == "8882933892564410");
            Card card9577 = db.Cards.FirstOrDefault(c => c.CardNumber == "9577230402048890");
            Card card3391 = db.Cards.FirstOrDefault(c => c.CardNumber == "3391194669212420");

            if (card4888 == null || card5653 == null || card7874 == null ||
                card8882 == null || card9577 == null || card3391 == null)
            {
                throw new InvalidOperationException("SeedOrders: One or more Cards could not be found. Check SeedCards and card numbers.");
            }

            // -------- Create order objects in memory --------

            // 10001 – Christopher Baker – In Cart
            Order o10001 = new Order
            {
                Customer = christopherBaker,
                OrderDate = new DateTime(2025, 11, 20),
                ShippingFee = 0.00m,
                OrderStatus = OrderStatus.InCart,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10001);

            // 10002 – Todd Jacobs – In Cart
            Order o10002 = new Order
            {
                Customer = toddJacobs,
                OrderDate = new DateTime(2025, 11, 20),
                ShippingFee = 0.00m,
                OrderStatus = OrderStatus.InCart,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10002);

            // 10003 – Charles Miller – In Cart
            Order o10003 = new Order
            {
                Customer = charlesMiller,
                OrderDate = new DateTime(2025, 11, 20),
                ShippingFee = 0.00m,
                OrderStatus = OrderStatus.InCart,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10003);

            // 10004 – Wendy Chang
            Order o10004 = new Order
            {
                Customer = wendyChang,
                Card = card4888,
                OrderDate = new DateTime(2025, 10, 31),
                ShippingFee = 3.50m,
                OrderStatus = OrderStatus.Ordered,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10004);

            // 10005 – Christopher Baker
            Order o10005 = new Order
            {
                Customer = christopherBaker,
                Card = card5653,
                OrderDate = new DateTime(2025, 10, 1),
                ShippingFee = 9.50m,
                OrderStatus = OrderStatus.Ordered,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10005);

            // 10006 – Lim Chou
            Order o10006 = new Order
            {
                Customer = limChou,
                Card = card7874,
                OrderDate = new DateTime(2025, 10, 5),
                ShippingFee = 107.00m,
                OrderStatus = OrderStatus.Ordered,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10006);

            // 10007 – Wendy Chang
            Order o10007 = new Order
            {
                Customer = wendyChang,
                Card = card4888,
                OrderDate = new DateTime(2025, 10, 30),
                ShippingFee = 3.50m,
                OrderStatus = OrderStatus.Ordered,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10007);

            // 10008 – Jeffrey Hampton
            Order o10008 = new Order
            {
                Customer = jeffreyHampton,
                Card = card8882,
                OrderDate = new DateTime(2025, 11, 1),
                ShippingFee = 5.00m,
                OrderStatus = OrderStatus.Ordered,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10008);

            // 10009 – Charles Miller
            Order o10009 = new Order
            {
                Customer = charlesMiller,
                Card = card9577,
                OrderDate = new DateTime(2025, 11, 3),
                ShippingFee = 3.50m,
                OrderStatus = OrderStatus.Ordered,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10009);

            // 10010 – Ernest Lowe
            Order o10010 = new Order
            {
                Customer = ernestLowe,
                Card = card3391,
                OrderDate = new DateTime(2025, 11, 2),
                ShippingFee = 6.50m,
                OrderStatus = OrderStatus.Ordered,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10010);

            // 10011 – Kelly Nelson – In Cart
            Order o10011 = new Order
            {
                Customer = kellyNelson,
                OrderDate = new DateTime(2025, 11, 20),
                ShippingFee = 0.00m,
                OrderStatus = OrderStatus.InCart,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10011);

            // 10012 – Chuck Luce – In Cart
            Order o10012 = new Order
            {
                Customer = chuckLuce,
                OrderDate = new DateTime(2025, 11, 20),
                ShippingFee = 0.00m,
                OrderStatus = OrderStatus.InCart,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10012);

            // 10013 – Eryn Rice – In Cart
            Order o10013 = new Order
            {
                Customer = erynRice,
                OrderDate = new DateTime(2025, 11, 20),
                ShippingFee = 0.00m,
                OrderStatus = OrderStatus.InCart,
                OrderDetails = new List<OrderDetail>()
            };
            orders.Add(o10013);

            // =========================
            //  Seed OrderDetails
            // =========================

            List<OrderDetail> orderDetails = new List<OrderDetail>();

            // Helper lookups for books
            Book racing = db.Books.FirstOrDefault(b => b.Title == "The Art Of Racing In The Rain");
            Book host = db.Books.FirstOrDefault(b => b.Title == "The Host");
            Book roses = db.Books.FirstOrDefault(b => b.Title == "Roses");
            Book altarOfEden = db.Books.FirstOrDefault(b => b.Title == "Altar Of Eden");      // FIXED spelling
            Book professional = db.Books.FirstOrDefault(b => b.Title == "The Professional");
            Book sayGoodbye2 = db.Books.FirstOrDefault(b => b.Title == "Say Goodbye");
            Book chasingDark2 = db.Books.FirstOrDefault(b => b.Title == "Chasing Darkness");
            Book otherQueen2 = db.Books.FirstOrDefault(b => b.Title == "The Other Queen");
            Book wrecked2 = db.Books.FirstOrDefault(b => b.Title == "Wrecked");
            Book reckless2 = db.Books.FirstOrDefault(b => b.Title == "Reckless");
            Book cast = db.Books.FirstOrDefault(b => b.Title == "The Castaways");      // FIXED to match SeedBooks
            Book brooklyn = db.Books.FirstOrDefault(b => b.Title == "Brooklyn");
            Book dexter = db.Books.FirstOrDefault(b => b.Title == "Dexter By Design");
            Book midnightHouse = db.Books.FirstOrDefault(b => b.Title == "The Midnight House");

            if (racing == null || host == null || roses == null || altarOfEden == null ||
                professional == null || sayGoodbye2 == null || chasingDark2 == null ||
                otherQueen2 == null || wrecked2 == null || reckless2 == null ||
                cast == null || brooklyn == null || dexter == null || midnightHouse == null)
            {
                throw new InvalidOperationException(
                    "SeedOrders: One or more Books could not be found. Check SeedBooks titles.");
            }


            // local helper to ALWAYS set ProductName
            void AddDetail(Order order, Book book, decimal price, decimal cost, int quantity)
            {
                orderDetails.Add(new OrderDetail
                {
                    Order = order,
                    Book = book,
                    ProductName = book.Title,   // <<< IMPORTANT: required field
                    Price = price,
                    Cost = cost,
                    Quantity = quantity
                });
            }

            // "10001" – Racing x3, Host x1
            AddDetail(o10001, racing, 23.95m, 10.30m, 3);
            AddDetail(o10001, host, 25.99m, 13.25m, 1);

            // "10002" – Roses x2
            AddDetail(o10002, roses, 24.99m, 20.99m, 2);

            // "10003" – Alter of Eden x2
            AddDetail(o10003, altarOfEden, 27.99m, 25.75m, 2);

            // "10004" – The Professional x1
            AddDetail(o10004, professional, 26.95m, 7.01m, 1);

            // "10005" – Say Goodbye x5, Chasing Darkness x1
            AddDetail(o10005, sayGoodbye2, 25.00m, 11.25m, 5);
            AddDetail(o10005, chasingDark2, 25.95m, 9.08m, 1);

            // "10006" – The Other Queen x70, Wrecked x10, Reckless x23
            AddDetail(o10006, otherQueen2, 25.95m, 23.61m, 70);
            AddDetail(o10006, wrecked2, 25.00m, 18.00m, 10);
            AddDetail(o10006, reckless2, 22.00m, 9.46m, 23);

            // "10007" – The Professional x1
            AddDetail(o10007, professional, 26.95m, 7.01m, 1);

            // "10008" – The Professional x2
            AddDetail(o10008, professional, 26.95m, 7.01m, 2);

            // "10009" – Say Goodbye x1
            AddDetail(o10009, sayGoodbye2, 25.00m, 11.25m, 1);

            // "10010" – Wrecked x3, Reckless x11
            AddDetail(o10010, wrecked2, 25.00m, 18.00m, 3);
            AddDetail(o10010, reckless2, 22.00m, 9.46m, 11);

            // "10011" – The Cast x1
            AddDetail(o10011, cast, 21.95m, 12.95m, 1);

            // "10012" – Brooklyn x4
            AddDetail(o10012, brooklyn, 18.95m, 3.60m, 4);

            // "10013" – Dexter By Design x1, The Midnight House x3
            AddDetail(o10013, dexter, 25.00m, 2.75m, 1);
            AddDetail(o10013, midnightHouse, 25.95m, 3.11m, 3);

            // ---- Add everything and save once ----
            db.Orders.AddRange(orders);
            db.OrderDetails.AddRange(orderDetails);
            db.SaveChanges();
        }
    }
}
