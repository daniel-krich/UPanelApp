using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPanel.Core
{
    public class ObjectMessanger
    {
        public delegate void MessangerHandler(object sender, object value);
        public static event MessangerHandler Messanger;

        public ObjectMessanger()
        {
            Messanger += RaisedHandler;
        }
        
        ~ObjectMessanger()
        {
            Messanger -= RaisedHandler;
        }

        public virtual void RaisedHandler(object sender, object value)
        {

        }

        public static void Raise(object sender, object value)
        {
            Messanger(sender, value);
        }
    }
}
