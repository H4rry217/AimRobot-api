using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.config {
    public interface IDataset<KType, VType> {

        public void Save();

        public void SetData(KType key, VType value);

        public void DelData(KType key);

        public VType GetData(KType key);

        public bool hasData(KType key);

        public int GetSize(KType key);

        public KType[] GetKeys();

    }
}
