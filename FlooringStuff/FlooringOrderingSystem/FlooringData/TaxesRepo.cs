﻿using FlooringModels;
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
        public List<Taxes> TaxLoader() 
        {
            List<Taxes> taxList = new List<Taxes>();

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
                        newTaxInfo.taxRate = decimal.Parse(columns[2]);

                        taxList.Add(newTaxInfo);
                    }
                    //response.TaxList = taxList;
                    //response.Success = true;
                    //response.Message = "taxes added from file";



                    
                }
                
            }
            return taxList;

            

        }
    }
}
//dictionaries where key is the state abbreviation and value is tax data object