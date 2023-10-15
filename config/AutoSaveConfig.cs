using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimRobot.Api.config {
    public abstract class AutoSaveConfig : IConfig, IDataset<string, string> {

        protected string name;

        public AutoSaveConfig(string name) {
            this.name = name;
        }

        public abstract void DelData(string key);

        public abstract string GetData(string key);

        public abstract FileInfo GetFile();

        public abstract int GetSize(string key);

        public abstract bool hasData(string key);

        public abstract void Save();

        public abstract void SetData(string key, string value);
    }
}
