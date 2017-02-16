using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            Exercise31();
            

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> pList = DataLoader.LoadProducts();
            var outOfStock = from someVar in pList
                             where someVar.UnitsInStock == 0
                             select someVar;
            PrintProductInformation(outOfStock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            //List<Product> pList = DataLoader.LoadProducts();
            //var inAnd3 = from prod in pList
            //             where prod.UnitsInStock > 0 && prod.UnitPrice > 3
            //             select prod;
            //PrintProductInformation(inAnd3);

            List<Product> methList = DataLoader.LoadProducts();
            var inAnd3 = methList.Where(prod => prod.UnitsInStock > 0 && prod.UnitPrice > 3);
            PrintProductInformation(inAnd3);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            //var thoseGuys = DataLoader.LoadCustomers();

            //var regionAndOrder = from cstmr in thoseGuys
            //                     where cstmr.Region == "WA"
            //                     select cstmr;
            //PrintCustomerInformation(regionAndOrder); 

            var thoseGuys = DataLoader.LoadCustomers();

            var regionAndOrder = thoseGuys.Where(cstmr => cstmr.Region == "WA");
            PrintCustomerInformation(regionAndOrder);

        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            //var prods = DataLoader.LoadProducts();
            //var pn = from name in prods
            //         select new
            //         {
            //             pName = name.ProductName
            //         };
            //foreach (var p in pn)
            //{
            //    Console.WriteLine(p);

            //}
            var prods = DataLoader.LoadProducts();

            var pn = prods.Select(p => new { p.ProductName });
            foreach (var p in pn)
            {
                Console.WriteLine(p);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {

            var prods = DataLoader.LoadProducts();

            var marco = from pStuff in prods
                        select new
                        {
                            pStuff.ProductName,
                            newPrice = pStuff.UnitPrice * 1.25M,
                            pStuff.UnitsInStock,
                            pStuff.ProductID,
                            pStuff.Category
                        };
            foreach (var blahblah in marco)
            {
                Console.WriteLine(blahblah);
            }

            //var pn = prods.Select(p => new
            //{
            //    p.ProductName, p.ProductID, p.UnitsInStock, newPrice = p.UnitPrice * 1.25M, p.Category //only the one we modify needs a name
            //});

            //foreach (var p in pn)
            //{
            //    Console.WriteLine(p);
            //}
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var products = DataLoader.LoadProducts();

            //var PRODUCTS = products.Select(allCaps => new
            //{
            //    bigName = allCaps.ProductName.ToUpper(),      //lambda or method syntax
            //    bigCat = allCaps.Category.ToUpper()
            //});

            var PRODUCTS = from allCap in products
                           select new
                           {
                               bigName = allCap.ProductName.ToUpper(),  //querry syntax
                               bigCat = allCap.Category.ToUpper()
                           };                     

            foreach (var dsntMattr in PRODUCTS)
            {
                Console.WriteLine(dsntMattr);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// 
        /// </summary>
        /// 
        // if input is > than 0, classify is positive, otherwise its negative  
        //classify = (input > 0) ? "positive" : "negative";
        static void Exercise7()
        {
            var productz = DataLoader.LoadProducts();

            //var threeInStock = productz.Select(three => new                       lambda or method syntax
            //{
            //    three.ProductName,
            //    three.UnitPrice,
            //    three.UnitsInStock,
            //    ReOrder = (three.UnitsInStock < 3 ? true : false)
            //});

            var threeInStock = from frankIsDumb in productz
                               select new
                               {
                                   ReOrder = (frankIsDumb.UnitsInStock < 3 ? true : false),
                                   frankIsDumb.UnitsInStock,
                                   frankIsDumb.ProductName,                                 //querry syntax
                                   frankIsDumb.ProductID,
                                   frankIsDumb.Category,
                                   frankIsDumb.UnitPrice
                               };

            foreach (var aligator in threeInStock)
            {
                Console.WriteLine(aligator);
            }
           

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var productz = DataLoader.LoadProducts();

            var withStocks = productz.Select(p => new
            {
                p.Category,
                p.ProductID,
                p.ProductName,
                p.UnitPrice,
                p.UnitsInStock,
                StockValue = p.UnitPrice*p.UnitsInStock
            });

            foreach (var stokz in withStocks)
            {
                Console.WriteLine(stokz);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var onlyEvens = DataLoader.NumbersA.Where(n => n % 2 == 0);
            foreach (var n in onlyEvens)
            {
                Console.WriteLine(n);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        

        static void Exercise10() //use 'any' I think i overheard
        {
            var customerInfo = DataLoader.LoadCustomers();

            var under500 = customerInfo.Where(c => c.Orders.Any(o => o.Total < 500));
            foreach (var whatever in under500)
            PrintCustomerInformation(under500);
                          
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var nums = DataLoader.NumbersC.Where(n => n % 2 == 1).Take(3);
            foreach (var dog in nums)
            {
                Console.WriteLine(dog);
            } 
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var nums = DataLoader.NumbersB.Skip(3);
            foreach (var cat in nums)
            {
                Console.WriteLine(cat);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var orderInfo = DataLoader.LoadCustomers();
            var recentWAorders = from p in orderInfo
                                 where p.Region == "WA"
                                 select new
                                 {
                                     name = p.CompanyName,
                                     newOrder = p.Orders.OrderByDescending(oD => oD.OrderDate).First()
                                 };
            foreach (var whatever  in recentWAorders)
            {
                Console.WriteLine(whatever.name +", "+ whatever.newOrder.OrderDate);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var until6 = DataLoader.NumbersC.TakeWhile(n => n <= 6);
            foreach (var blah in until6)
            {
                Console.WriteLine(blah);
            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var divis3 = DataLoader.NumbersC.SkipWhile(d=> d % 3 != 0).Skip(1);
            foreach (var whatevs in divis3)
            {
                Console.WriteLine(whatevs);
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var productz = DataLoader.LoadProducts();
            var alfabet = productz.OrderBy(a => a.ProductName);
            foreach (var alf in alfabet)
                Console.WriteLine(alf.ProductName);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var productz = DataLoader.LoadProducts();
            var bakwerds = productz.OrderByDescending(b => b.UnitsInStock);
            foreach (var bName in bakwerds)
            {
                Console.WriteLine(bName.ProductName + bName.UnitsInStock);
            } 
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var productz = DataLoader.LoadProducts();
            var byCat = productz.OrderBy(cat => cat.Category).ThenByDescending(p => p.UnitPrice);
            //var kat = productz.OrderByDescending(p => p.UnitPrice).OrderBy(cat => cat.Category);
            //var byPrice = productz.OrderByDescending(p => p.UnitPrice);

            PrintProductInformation(byCat);
            
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void  Exercise19()
        {
            var reverso = DataLoader.NumbersB.Reverse();
            foreach (var r in reverso)
            {
                Console.WriteLine(r);
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        /// 
static void Exercise20()
        {
            var prods = DataLoader.LoadProducts();

            var result = from p in prods
                         //orderby p.Category, p.ProductName
                         group p by p.Category;

            foreach (var g in result)
            {
                Console.WriteLine(g.Key);
                foreach (var p in g)
                {
                    Console.WriteLine ($"\t{p.ProductName}");
                }
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        ///     
        /// David indicated we'd be doing a groupBy on an anonymous type made up of more than one property (e.g. day,month,year)
        /// </summary>
        static void Exercise21()
        {
            var cstmr = DataLoader.LoadCustomers();
            var custOrderDate = from c in cstmr
                                select new
                                {
                                    c.CompanyName,
                                    orderTotals = c.Orders.GroupBy(o => new
                                    {
                                        year = o.OrderDate.Year,
                                        month = o.OrderDate.Month
                                    })
                                    .Select(g => new
                                    {
                                        year = g.Key.year,
                                        month = g.Key.month,
                                        orderTotal = g.Sum(o => o.Total)
                                    })
                                    
                                };
            foreach (var whatever in custOrderDate)
            {
                Console.WriteLine(whatever.CompanyName);

                foreach (var orderData in whatever.orderTotals)
                {
                    Console.WriteLine(orderData);
                }
            }
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var prods = DataLoader.LoadProducts();
            var unique = prods.Select(p => p.Category).Distinct();
           
            foreach (var p in unique)
            {
                Console.WriteLine(p);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            var prods = DataLoader.LoadProducts();
            var prod789 = prods.FirstOrDefault(p => p.ProductID == 789); //switch Where to FirstorDefault
            Console.WriteLine($"products with that ID: {prod789}");
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            var prods = DataLoader.LoadProducts();
            var catOutofStock = (from p in prods
                                 where p.UnitsInStock == 0  //u => {return UnitsInStock > 0;}
                                 select new
                                 {
                                     category = p.Category,
                                    
                                 }).Distinct();

            foreach (var p in catOutofStock)


            {
                Console.WriteLine(p.category);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25() //google: "linq all" and go to msdn
        {
            var prods = DataLoader.LoadProducts();
            var AllStock = from p in prods
                           group p by p.Category into pGroup
                           where pGroup.All(p => p.UnitsInStock > 0)
                           select

                               pGroup.Key;
                           

            foreach (var p in AllStock)
            {
                Console.WriteLine(p);
            }
            /*var*/
            AllStock = prods.GroupBy(p => p.Category)
                                .Where(g => g.All(p => p.UnitsInStock > 0))
                                .Select(g => g.Key);

            foreach (var p in AllStock)
            {
                Console.WriteLine(p);           
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            int occCount = DataLoader.NumbersA.Count(a => a % 2 == 1);
            Console.WriteLine(occCount);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var customers = DataLoader.LoadCustomers();
            var orderAndID = customers.Select(c => new
            {
                Company = c.CompanyName,
                ID = c.CustomerID,
                orders = c.Orders.Count()
            });
            foreach (var c in orderAndID)
            {
                Console.WriteLine(c);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            var prods = DataLoader.LoadProducts();
            var catProds = prods.GroupBy(p => p.Category)
                                .Select(g => new
                                {
                                    g.Key,
                                    productsCount = g.Count()
                                });

            foreach (var c in catProds)
            {
                Console.WriteLine(c);
            }


        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            var prods = DataLoader.LoadProducts();
            var catProds = prods.GroupBy(p => p.Category)
                                .Select(g => new
                                {
                                    g.Key,
                                    productsSum = g.Sum(p => p.UnitsInStock)
                                });

            foreach (var c in catProds)
            {
                Console.WriteLine(c);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            var prods = DataLoader.LoadProducts();

            var catAndLowPrice = prods.GroupBy(p => p.Category)
                                      .Select(g => new
                                      {
                                          g.Key,
                                          lowPrice = g.Min(p => p.UnitPrice)
                                      });
            foreach (var g in catAndLowPrice)
            {
                Console.WriteLine(g);
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var prods = DataLoader.LoadProducts();

            var topAv3 = prods.GroupBy(p => p.Category)
                              .Select(g => new
                              {
                                  g.Key,
                                  AvPrice = g.Average(p => p.UnitPrice)
                              })
                              .OrderByDescending(g => g.AvPrice).Take(3);

            foreach (var expnsv in topAv3)
            {
                Console.WriteLine(expnsv);
            }
        }
    }
}
