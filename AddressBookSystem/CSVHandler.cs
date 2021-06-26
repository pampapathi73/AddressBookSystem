using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class CSVHandler
    {
        string importFilePath = @"C:\Users\Pampapathi K\Desktop\Pampapathi\AddressBookSystem\AddressBookSystem\Addresses.csv";

        public void WriteToCsv(Dictionary<string, AddressBookBuider> addressbookDictionary)
        {
            using (StreamWriter writer = new StreamWriter(importFilePath))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    foreach (AddressBookBuider obj in addressbookDictionary.Values)
                    {
                        List<Contacts> contactRecord = obj.addressBook.Values.ToList();
                        csv.WriteRecords(contactRecord);
                    }
                    Console.WriteLine("\nSuccessfully added to CSV file.");
                    csv.Dispose();
                }
            }
        }
        public void ReadFromCSV()
        {
            using (StreamReader reader = new StreamReader(importFilePath))
            {
                using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    Console.WriteLine("Below are Contents of CSV File");
                    List<Contacts> contactRecord = csv.GetRecords<Contacts>().ToList();
                    foreach (Contacts contact in contactRecord)
                    {
                        Console.WriteLine(contact.ToString());
                    }
                }
            }
        }
    }
}
