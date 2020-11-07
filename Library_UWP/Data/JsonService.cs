using Library_UWP.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_UWP
{
    

    public static class JsonService
    {
        public static void WriteToFile(string filename, OrderProduct orderProduct)
        {
            var json = JsonConvert.SerializeObject(orderProduct);

            using StreamWriter writer = new StreamWriter(filename);
            writer.Write(json);
        }
    }
}
