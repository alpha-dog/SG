using FlooringModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringData
{
    public class TaxesRepo
    {
        List<Taxes> taxList = new List<Taxes>();

        string filePath = (@"C:\Users\Tom\Documents\SoftwareGuild\Repositories\david-evans-individual-work\FlooringStuff\Taxes.txt");
        public TaxesRepo()
        {
            if (File.Exists(filePath))
            {

                using (StreamReader sr = new StreamReader(filePath))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Taxes newTaxInfo = new Taxes();

                        string[] columns = line.Split(',');

                        newTaxInfo.StateAbbreviation = columns[0];
                        newTaxInfo.State = columns[1];
                        newTaxInfo.TaxRate = decimal.Parse(columns[2]);

                        taxList.Add(newTaxInfo);
                    }
                    //response.TaxList = taxList;
                    //response.Success = true;
                    //response.Message = "taxes added from file";        
                }
            }
        }

        public Taxes GetStateTax(string stateabrv)
        {
            Taxes stateTax = new Taxes();
            stateTax = taxList.SingleOrDefault(t => t.StateAbbreviation == stateabrv);

            return stateTax;
        }
    }
}
