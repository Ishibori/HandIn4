using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HistoricModelHandler
    {
        public void Save(string JsonToSave)
        {
            var historicModel = new HistoricModel();
            var DataContext = new EntityContext();
            historicModel.TimeStamp = DateTime.Now;
            historicModel.BinaryData = Encoding.ASCII.GetBytes(JsonToSave);
            DataContext.HistoricModels.Add(historicModel);
            DataContext.SaveChanges();
        }
    }
}
