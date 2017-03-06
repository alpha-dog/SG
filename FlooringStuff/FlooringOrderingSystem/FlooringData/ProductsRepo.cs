using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringModels;
using System.IO;

namespace FlooringData
{
    public class ProductsRepo
    {
        List<Products> productsList = new List<Products>();
        string filePath = (@"C:\Users\Tom\Documents\SoftwareGuild\Repositories\david-evans-individual-work\FlooringStuff\Products.txt");

        public ProductsRepo()
        {
            if (File.Exists(filePath))
            {

                using (StreamReader sr = new StreamReader(filePath))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Products newProduct = new Products();

                        string[] columns = line.Split(',');

                        newProduct.ProductType = columns[0];
                        newProduct.CostPerSquareFoot = decimal.Parse(columns[1]);
                        newProduct.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                        productsList.Add(newProduct);
                    }





                }

            }
        }

        public Products GetProduct(string prodType)
        {
            Products orderProds = new Products();
            orderProds = productsList.SingleOrDefault(p => p.ProductType == prodType);

            return orderProds;
        }
    }
}
