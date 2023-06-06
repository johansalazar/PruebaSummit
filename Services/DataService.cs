using Prueba_tecnica_Summit_Systems.BussinesLayer;

namespace Prueba_tecnica_Summit_Systems.Services
{
    public class DataService
    {
        public DataDict StartService(DataDict dataDict)
        {
            DataDict dataDictResponse = new DataDict();
            string val = dataDict.Text;
            if (val != null)
            {
                if (val == string.Empty)
                {
                    dataDictResponse.MessageError = "No hay texto";
                    dataDictResponse.Text = ServiceState.Rejected.ToString();
                }
                else
                {
                    int valorEntero = 0;
                    bool result = int.TryParse(val, out valorEntero);

                    if (result)
                    {
                        NumericServices numericServices = new NumericServices();
                        dataDictResponse = numericServices.Process(valorEntero);
                    }
                    else
                    {
                        AlphaNumericService alphaNumericServices = new AlphaNumericService();
                        dataDictResponse = alphaNumericServices.Process(val);
                    }
                }
            }
            else
            {
                dataDictResponse.MessageError = "No hay datos";
                dataDictResponse.Text = ServiceState.Aborted.ToString();
            }
            return dataDictResponse;
        }
    }
}