using FlooringModels;
using FlooringModels.Responses;
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

        string filePath = (@"C:\Users\Tom\Documents\SoftwareGuild\Repositories\david-evans-individual-work\FlooringStuff\Taxes.txt");
        //maybe set up a new display response with bad values here that can be changed further down

        TaxLoadResponse response = new TaxLoadResponse()
        {
            TaxList = null,
            Success = false,
            Message = "something is messed up in the TaxesRepo"
        };
        public List<Taxes> TaxLoader(string filePath)
        {
            if (File.Exists(filePath))
            {
                List<Taxes> taxList = new List<Taxes>();
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
                        newTaxInfo.taxRate = decimal.Parse(columns[2]);

                        taxList.Add(newTaxInfo);
                    }
                    response.TaxList = taxList;
                    response.Success = true;
                    response.Message = "taxes added from file";



                    
                }
            }
            else
            {
                response.Message = "something might be wrong with the file or the programmer messed up somewhere in TaxesRepo";
            }
            return response.TaxList;
            
        }
    }
}
//dictionaries where key is the state abbreviation and value is tax data object