using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    abstract class Component
    {
        GameObject gameObject;


        public GameObject GameObject
        {
            get { return gameObject; }
        }

        public Component()
        {

        }
        public Component(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
}
