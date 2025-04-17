using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Modul8_103022300160
{
    internal class BankTransferConfig
    {
        class Transfer
        {
            public int treshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }
        class Confirmation
        {
            public int en { get; set; }
            public int id { get; set; }
        }
        class Config
        {
            public string lang { get; set; }
            public Transfer transfer { get; set; }
            public string[] methods { get; set; }
            public Confirmation confirmation { get; set; }

            public Config(){}
            public void ReadConfigFile()
            {
                string configJsonData = File.ReadAllText(filePath);
                Config config = JsonSerializer.Deserialize<Config>(configJsonData);

                lang = config.lang; 
                transfer = config.transfer;
                methods = config.methods;
                confirmation = config.confirmation;
                
            }

        }

            public const String filePath = "D:\\Modul8_103022300160\\bank_transfer_config.json";
            public config_bank()
            {
                try
                {
                    ReadConfigFile();
                }
                catch (Exception)
                {
                    setDefault();
                    WriteNewConfigFile();
                }
            }
            

            public void setDefault()
            {
                ReadConfigFile();
            }
            public void WriteNewConfigFile()
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };
                String jsonString = JsonSerializer.Serialize(bankTransferConfig, options);
                File.WriteAllText(filePath, jsonString);
            }
        

        public void ubahBahasa(string lang, BankTransferConfig data)
        {
            lang = (lang == null) ? "en" : "id";
            ReadConfigFile();
        }
    }
}

