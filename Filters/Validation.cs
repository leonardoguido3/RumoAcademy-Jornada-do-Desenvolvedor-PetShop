using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Filters
{
    internal class Validation
    {
        public static string ConversaoData(string data)
        {
            int dataInt = 0;
            string dataStr = "";

            // se minha data contem /, (caso o cliente tenha escrevido faltando)
            if (data.Contains("/"))
            {
                // faço toda a remoção e gravo somente os valores em uma string
                var digitoData = string.Join("", data.ToCharArray().Where(Char.IsDigit));

                // converto para INT, e depois formato para o dd/MM/yyyy
                dataInt = Convert.ToInt32(digitoData);
                dataStr = dataInt.ToString(@"00\/00\/0000");

                return dataStr;
            }

            // caso não venha com /, ja é diretamente inserido no INT e formatado
            dataInt = Convert.ToInt32(data);
            dataStr = dataInt.ToString(@"00\/00\/0000");

            return dataStr;
        }
    }
}
